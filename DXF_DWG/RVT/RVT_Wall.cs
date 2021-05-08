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
    class RVT_Wall
    {
        const double _feet_to_mm = 304.8;
        const double _mm_to_feet = 0.00328084;


        List<Curve> center_lines = new List<Curve>();

        public RVT_Wall(List<Tuple<Vector3, Vector3>> walls_center)
        {
            walls_center.ForEach(w => 
            {
                double x1 = UnitUtils.ConvertToInternalUnits(w.Item1.X, DisplayUnitType.DUT_METERS);
                double y1 = UnitUtils.ConvertToInternalUnits(w.Item1.Y, DisplayUnitType.DUT_METERS);
                double x2 = UnitUtils.ConvertToInternalUnits(w.Item2.X, DisplayUnitType.DUT_METERS);
                double y2 = UnitUtils.ConvertToInternalUnits(w.Item2.Y, DisplayUnitType.DUT_METERS);


                center_lines.Add(Autodesk.Revit.DB.Line
                            .CreateBound(new XYZ(x1, y1, 0), new XYZ(x2, y2, 0)));


            });
        }


        public List<Curve> Center_lines { get => center_lines; }


        public void CreateWalls(Document document,WallType wallType,Level base_level, Level level2)
        {
            Center_lines.ForEach(l => 
            {

                Wall w = Wall.Create(document, l, wallType.Id, base_level.Id, 3200 * _mm_to_feet, 0, false, false);

                w.LookupParameter("Top Constraint").Set(level2.Id);
            });
        }
    }
}
