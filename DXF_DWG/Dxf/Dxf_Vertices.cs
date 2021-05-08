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
    class Dxf_Vertices
    {
        List<List<Vector3>> colVertices = new List<List<Vector3>>();
        List<Tuple<Vector3, Vector3>> wallVertices = new List<Tuple<Vector3, Vector3>>();
        List<List<Vector3>> floorVertices = new List<List<Vector3>>();

        private List<Tuple<List<HatchBoundaryPath>, Layer>> boundaryPaths = new List<Tuple<List<HatchBoundaryPath>, Layer>>();
        private List<Tuple<List<HatchBoundaryPath.Edge>, Layer>> edges = new List<Tuple<List<HatchBoundaryPath.Edge>, Layer>>();
        private List<Tuple<List<Vector3>, Layer>> points = new List<Tuple<List<Vector3>, Layer>>();


        public Dxf_Vertices(DxfDocument document,string column_layer, string wall_layer,string floor_layer)
        {
            if (document != null)
            {
                // Get the boundary of Floors
                var Floor_polyline = document.LwPolylines.Where(p => p.Layer.ToString() == floor_layer).ToList();
                
                var Column_polylines = document.LwPolylines.Where(p => p.Layer.ToString() == column_layer).ToList();

                var Wall_lines = document.Lines.Where(l => l.Layer.ToString() == wall_layer).ToList();

                Wall_lines.ForEach(l => 
                {
                    wallVertices.Add(Tuple.Create(l.StartPoint, l.EndPoint));
                });

                Floor_polyline.ForEach(p =>
                {
                    // list of vector 3 of 1 floor vertices
                    List<Vector3> lv = new List<Vector3>();

                    // list of one column vertices
                    var vs = p.Vertexes.ToList();

                    vs.ForEach(v =>
                    {

                        lv.Add(new Vector3(v.Position.X, v.Position.Y, 0));

                    });


                    floorVertices.Add(lv);

                });

                Column_polylines.ForEach(p =>
                {
                    // list of vector 3 of 1 column vertices
                    List<Vector3> lv = new List<Vector3>();

                    // list of one column vertices
                    var vs = p.Vertexes.ToList();

                    vs.ForEach(v =>
                    {

                        lv.Add(new Vector3(v.Position.X, v.Position.Y, 0));

                    });


                    colVertices.Add(lv);

                });

            }
        }




        public List<List<Vector3>> ColVertices { get => colVertices; }
        public List<List<Vector3>> FloorVertices { get => floorVertices; }
        public List<Tuple<Vector3, Vector3>> WallVertices { get => wallVertices; set => wallVertices = value; }
    }
}
