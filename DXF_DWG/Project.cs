using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf;
using netDxf.Header;
using netDxf.Entities;
using netDxf.Tables;
using netDxf.Blocks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace DXF_DWG
{
    [TransactionAttribute(TransactionMode.Manual)]

    public class Project: IExternalCommand
    {
        const double _feet_to_mm = 304.8;
        const double _mm_to_feet = 0.00328084;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Path of file
            string filePath = null;

            // Using Windows form to get file path
            using (Data form = new Data())
            {
                OpenFileDialog browserDialog = new OpenFileDialog();
                browserDialog.ShowDialog();
                if (browserDialog.FileName != null)
                {

                    filePath = browserDialog.FileName;

                }
                else
                {
                    return Result.Cancelled;
                }
            }


            // Get Dxf document
            DxfDocument document = DxfDocument.Load(filePath);

            // Get Revit UI document
            UIDocument uIDocument = commandData.Application.ActiveUIDocument;

            // Get Revit document
            Document rvtDocument = uIDocument.Document;

            //Get Level of revit file
            List<Level> levels = new FilteredElementCollector(rvtDocument)
                                    .OfCategory(BuiltInCategory.OST_Levels)
                                    .WhereElementIsNotElementType().Cast<Level>().ToList();

            // Get Wall Type
            var wallType = new FilteredElementCollector(rvtDocument)
                          .OfCategory(BuiltInCategory.OST_Walls)
                          .WhereElementIsElementType()
                          .Cast<WallType>()
                          .FirstOrDefault();


            // Get Layers of dxf file
            List<Layer> layers = document.Layers.ToList();

            // Declear variables 
            string base_level_name = null;

            string top_level_name = null;

            string column_layer = null;

            string wall_layer = null;

            string floor_layer = null;

            // Get Data from user by form
            using (Data form = new Data())
            {
                // Set dxf layers to comboBoxs
                form.ComboBox_wall_layer.Items.AddRange(layers.Select(layer => (object)layer).ToArray());

                form.ComboBox_col_layer.Items.AddRange(layers.Select(layer => (object)layer).ToArray());

                form.ComboBox_floor_layer.Items.AddRange(layers.Select(layer => (object)layer).ToArray());

                // Set levels to ComboBoxs  
                form.ComboBox_base_level.Items.AddRange(levels.Select(l => (object)l.Name).ToArray());

                form.ComboBox_top_level.Items.AddRange(levels.Select(l => (object)l.Name).ToArray());

                form.ShowDialog();

                
                if (form.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                {

                    return Result.Cancelled;
                    
                }
                else if (form.Button_ok.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    //Get Data from ComboBoxs

                    base_level_name = form.ComboBox_base_level.SelectedItem.ToString();

                    top_level_name = form.ComboBox_top_level.SelectedItem.ToString();

                    wall_layer = form.ComboBox_wall_layer.SelectedItem.ToString();

                    column_layer = form.ComboBox_col_layer.SelectedItem.ToString();

                    floor_layer = form.ComboBox_floor_layer.SelectedItem.ToString();

                }
            }

            // Get Data of vertix and its layer by sending document and layers 
            Dxf_Vertices vertices = new Dxf_Vertices(document, column_layer, wall_layer, floor_layer);

            // Get Column Vertix
            Dxf_Column columns = new Dxf_Column(vertices);

            // Get Walls Vertix
            Dxf_Wall walls = new Dxf_Wall(vertices);

            // Get Floor Vertix
            Dxf_Floor floor = new Dxf_Floor(vertices);



            RVT_Col rVT_Col = new RVT_Col(columns.Points);

            RVT_Wall rVT_Wall = new RVT_Wall(walls.Walls_center);

            RVT_Floor rVT_Floor = new RVT_Floor(floor.Floor_boundary);



            Level base_level = GetLEVEL(rvtDocument, base_level_name);

            Level top_level = GetLEVEL(rvtDocument, top_level_name);

            FamilySymbol symbol;

            using (Transaction t = new Transaction(rvtDocument,"Load"))
            {
                t.Start();

                bool ff = rvtDocument.LoadFamily($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Concrete-Rectangular-Column.rfa");

                symbol = new FilteredElementCollector(rvtDocument).OfClass(typeof(FamilySymbol))
                                  .WhereElementIsElementType()
                                  .Cast<FamilySymbol>()
                                  .First(x => x.Name == "12 x 18");

                symbol.Activate();

                t.Commit();
            }


            using (Transaction t = new Transaction(rvtDocument, "Create "))
            {
                t.Start();


                WallType newWallType = CreateWallType(rvtDocument, wallType, 300);

                rVT_Col.CreateColumns(rvtDocument, symbol, base_level , top_level) ;

                rVT_Wall.CreateWalls(rvtDocument, newWallType, base_level , top_level);

                rVT_Floor.CreateFloor(rvtDocument,top_level);

                t.Commit();
            }

            return Result.Succeeded;
        }

        // Get Level 
        public static Level GetLEVEL(Document document, string level)
        {
            // Get Level By Linq 
            return new FilteredElementCollector(document)
                          .OfCategory(BuiltInCategory.OST_Levels)
                          .WhereElementIsNotElementType()
                          .Cast<Level>()
                          .First(x => x.Name == level);
        }


        public WallType CreateWallType(Document document, WallType _wallType, double wallTypeThickness)
        {
            WallType wallType = null;

            try
            {
                wallType = _wallType.Duplicate($"Wall {Convert.ToInt32((wallTypeThickness )).ToString() }mm") as WallType;

                CompoundStructure compoundStructure = wallType.GetCompoundStructure();

                int layerIndex = compoundStructure.GetFirstCoreLayerIndex();

                
                IList<CompoundStructureLayer> clayers = compoundStructure.GetLayers();

                foreach (CompoundStructureLayer csl in clayers)
                {
                    if (csl.Function.ToString() == "Structure")
                    {
                        compoundStructure.SetLayerWidth(layerIndex, wallTypeThickness * _mm_to_feet);
                    }

                    layerIndex++;
                }

                wallType.SetCompoundStructure(compoundStructure);
            }
            catch { }


            return wallType;
        }
    }
}
