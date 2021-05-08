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
    class Dxf_Floor
    {
        List<List< Tuple<Vector3, Vector3>>> floor_boundary = new List<List<Tuple<Vector3, Vector3>>>();


        public Dxf_Floor(Dxf_Vertices _Vertices)
        {

            var vertices = _Vertices.FloorVertices;
            vertices.ForEach(vl =>
            {
                List<Tuple<Vector3, Vector3>> li = new List<Tuple<Vector3, Vector3>>();

                for (int i = 0; i < vl.Count() - 1; i++)
                {
                    li.Add(Tuple.Create(vl[i], vl[i + 1]));
                }

                floor_boundary.Add(li);
            });
            

        }

        public List<List<Tuple<Vector3, Vector3>>> Floor_boundary { get => floor_boundary; set => floor_boundary = value; }
    }
}
