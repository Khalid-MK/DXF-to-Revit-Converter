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
    class RVT_Floor
    {
        List<List<Curve>> boundary = new List<List<Curve>>();


        public RVT_Floor(List<List<Tuple<Vector3, Vector3>>> dxf_floors )
        {
            dxf_floors.ForEach(dxf_floor => 
            {
                List<Curve> li = new List<Curve>();

                dxf_floor.ForEach(l =>
                {
                    double x1 = UnitUtils.ConvertToInternalUnits(l.Item1.X, DisplayUnitType.DUT_METERS);
                    double y1 = UnitUtils.ConvertToInternalUnits(l.Item1.Y, DisplayUnitType.DUT_METERS);
                    double x2 = UnitUtils.ConvertToInternalUnits(l.Item2.X, DisplayUnitType.DUT_METERS);
                    double y2 = UnitUtils.ConvertToInternalUnits(l.Item2.Y, DisplayUnitType.DUT_METERS);

                    li.Add(Autodesk.Revit.DB.Line
                                .CreateBound(new XYZ(x1, y1, 0), new XYZ(x2, y2, 0)));
                });

                boundary.Add(li);
            });
            
        }

        public List<List<Curve>> Boundary { get => boundary; set => boundary = value; }

        public void CreateFloor(Document document, Level level2)
        {
            boundary.ForEach(bo => 
            {

                CurveArray floor = new CurveArray();

                foreach (Curve c in bo)
                {
                    floor.Append(c);
                }

                Floor f = document.Create.NewFloor(floor, false);
                f.LookupParameter("Level").Set(level2.Id);   

            });
        }

    }
}
