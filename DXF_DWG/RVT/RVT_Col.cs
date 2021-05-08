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

namespace DXF_DWG
{
    class RVT_Col
    {
        List<XYZ> col_position = new List<XYZ>();

        public RVT_Col(List<Vector3> dxf_Column)
        {
            dxf_Column.ForEach(c => 
            {
                double x = UnitUtils.ConvertToInternalUnits(c.X, DisplayUnitType.DUT_METERS);
                double y = UnitUtils.ConvertToInternalUnits(c.Y, DisplayUnitType.DUT_METERS);
                double z = UnitUtils.ConvertToInternalUnits(c.Z, DisplayUnitType.DUT_METERS);

                col_position.Add(new XYZ(x, y, z));
            });
        }


        public List<XYZ> Col_position { get => col_position;}


        public void CreateColumns(Document document , FamilySymbol familySymbol,Level level ,Level level2)
        {
            col_position.ForEach(c => 
            {
                FamilyInstance column = document.Create.NewFamilyInstance(c, familySymbol, level, Autodesk.Revit.DB.Structure.StructuralType.Column);
                column.LookupParameter("Top Level").Set(level2.Id);
            });
        }
    }
}
