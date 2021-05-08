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
    class Dxf_Column
    {
        List<Vector3> columns_center = new List<Vector3>();

        // Width is in x dir 
        // Height is in y dir
        List<Tuple<int, int>> width_height = new List<Tuple<int, int>>();

        public Dxf_Column(Dxf_Vertices _Vertices)
        {
            var vertices = _Vertices.ColVertices;

            vertices.ForEach(vertex =>
            {
                Vector3 p1 = vertex.First();

                Vector3 p2 = new Vector3();

                vertex.ForEach(v =>
                {
                    if (v.X != p1.X && v.Y != p1.Y)
                    {
                        p2 = v;
                    }
                });

                Vector3 mid_point = new Vector3((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2, 0);

                width_height.Add(Tuple.Create((int)Math.Abs(p1.X - p2.X), (int)Math.Abs(p1.Y - p2.Y)));

                columns_center.Add(mid_point);
            });
        }
        
        public List<Vector3> Points { get => columns_center; }

        public List<Tuple<int, int>> Width_height { get => width_height; set => width_height = value; }

    }
}
