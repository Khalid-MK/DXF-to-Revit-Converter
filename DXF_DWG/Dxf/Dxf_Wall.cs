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

namespace DXF_DWG
{
    class Dxf_Wall
    {
        List<Tuple< Vector3, Vector3>> walls_center = new List<Tuple<Vector3, Vector3>>();
        double thickness;


        public Dxf_Wall(Dxf_Vertices _Vertices)
        {
            walls_center = _Vertices.WallVertices;

            //walls_center = GetColumnCenterLine(vertices);
        }



        public List<Tuple<Vector3, Vector3>> Walls_center { get => walls_center; }
        public double Thickness { get => thickness; }



        //private List<Tuple<Vector3, Vector3>> GetColumnCenterLine(List<List<Vector3>> vertices)
        //{
        //    List<Tuple<Vector3, Vector3>> mid_lines = new List<Tuple<Vector3, Vector3>>();

        //    vertices.ForEach(vertex =>
        //    {
        //        Vector3 pll = vertex.First();
        //        Vector3 plr = new Vector3();
        //        Vector3 pur = new Vector3();
        //        Vector3 pul = new Vector3();

        //        vertex.ForEach(v =>
        //        {
        //            if (v.X != pll.X && v.Y == pll.Y)
        //            {
        //                plr = v;
        //            }
        //            else if (v.X != pll.X && v.Y != pll.Y)
        //            {
        //                pur = v;
        //            }
        //            else if (v.X == pll.X && v.Y != pll.Y)
        //            {
        //                pul = v;
        //            }
        //        });

        //        Vector3 h1 = new Vector3((pul.X + pll.X) / 2, (pul.Y + pll.Y) / 2, 0);
        //        Vector3 h2 = new Vector3((plr.X + pur.X) / 2, (plr.Y + pur.Y) / 2, 0);

        //        double hz = Math.Sqrt(Math.Pow(h1.X - h2.X, 2) + Math.Pow(h1.Y - h2.Y, 2));

        //        Vector3 v1 = new Vector3((pll.X + plr.X) / 2, (pll.Y + plr.Y) / 2, 0);
        //        Vector3 v2 = new Vector3((pul.X + pur.X) / 2, (pul.Y + pur.Y) / 2, 0);

        //        double vl = Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));

        //        if ( vl > hz)
        //        {
        //            mid_lines.Add(Tuple.Create(v1, v2));
        //            thickness = hz;
        //        }
        //        else
        //        {
        //            mid_lines.Add(Tuple.Create(h1, h2));
        //            thickness = vl;
        //        }

        //    });

        //    return mid_lines;
        //}


    }
}
