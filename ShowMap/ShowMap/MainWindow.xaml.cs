using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShowMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int mapSize = 400;
        public MainWindow(){
            InitializeComponent();
        }

        private void ScrollBarVertical_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e){
            angleContent_x.Content = "x-Axis: " + Math.Floor(vScroll.Value).ToString() + "*";
            Cube.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), vScroll.Value));
        }

        private void ScrollBarHorizontal_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e){
            angleContent_x.Content = "y-Axis: " + Math.Floor(hScroll.Value).ToString() + "*";
            Cube.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), hScroll.Value));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e){

            Point3DCollection points = ReadData();

            MultipleTransformationsExample1(points);

        }

        public void MultipleTransformationsExample(){
            // Declare scene objects.
            Viewport3D myViewport3D = new Viewport3D();
            Model3DGroup myModel3DGroup = new Model3DGroup();
            GeometryModel3D myGeometryModel = new GeometryModel3D();
            ModelVisual3D myModelVisual3D = new ModelVisual3D();

            MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();

            // Apply the mesh to the geometry model.
            myGeometryModel.Geometry = myMeshGeometry3D;

            myModel3DGroup.Children.Add(myGeometryModel);

            // Add the group of models to the ModelVisual3d.
            myModelVisual3D.Content = myModel3DGroup;

            myViewport3D.Children.Add(myModelVisual3D);

            // Apply the viewport to the page so it will be rendered.
            this.Content = myViewport3D;
        }

        public void MultipleTransformationsExample1(Point3DCollection points){

            MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();
            myMeshGeometry3D.Positions.Clear();
            myMeshGeometry3D.TriangleIndices.Clear();
            for (int i = 0; i < points.Count; i++)
            {
                AddCubeToMesh(myMeshGeometry3D, points[i], 2);
            }
            
            myMeshGeometry3D.Freeze();
            Cube.Geometry = myMeshGeometry3D;
        }

        private Point3DCollection ReadData()
        {
            // read 3d points from a file or create at runtime
            return CreatePoint();
        }
        private Point3DCollection CreatePoint()
        {
            string[] lines = System.IO.File.ReadAllLines(@"../../../../WriteText.txt");
            Point3DCollection points = new Point3DCollection();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] coor = lines[i].Split(' ');
                double x = Convert.ToDouble(coor[0]);
                double y = Convert.ToDouble(coor[1]);
                double z = Convert.ToDouble(coor[coor.Length - 1]);
                points.Add(new Point3D(x, z * 100, y));
            }

            return points;
        }
        private void AddCubeToMesh(MeshGeometry3D mesh, Point3D centerOld, double size)
        {
            Point3D center = new Point3D(centerOld.X-200, centerOld.Y, centerOld.Z-200);
            if (mesh != null)
            {
                int offset = mesh.Positions.Count;

                mesh.Positions.Add(new Point3D(center.X - size, center.Y + size, center.Z - size));
                mesh.Positions.Add(new Point3D(center.X + size, center.Y + size, center.Z - size));
                mesh.Positions.Add(new Point3D(center.X + size, center.Y + size, center.Z + size));
                mesh.Positions.Add(new Point3D(center.X - size, center.Y + size, center.Z + size));
                mesh.Positions.Add(new Point3D(center.X - size, center.Y - size, center.Z - size));
                mesh.Positions.Add(new Point3D(center.X + size, center.Y - size, center.Z - size));
                mesh.Positions.Add(new Point3D(center.X + size, center.Y - size, center.Z + size));
                mesh.Positions.Add(new Point3D(center.X - size, center.Y - size, center.Z + size));

                mesh.TriangleIndices.Add(offset + 3);
                mesh.TriangleIndices.Add(offset + 2);
                mesh.TriangleIndices.Add(offset + 6);

                mesh.TriangleIndices.Add(offset + 3);
                mesh.TriangleIndices.Add(offset + 6);
                mesh.TriangleIndices.Add(offset + 7);

                mesh.TriangleIndices.Add(offset + 2);
                mesh.TriangleIndices.Add(offset + 1);
                mesh.TriangleIndices.Add(offset + 5);

                mesh.TriangleIndices.Add(offset + 2);
                mesh.TriangleIndices.Add(offset + 5);
                mesh.TriangleIndices.Add(offset + 6);

                mesh.TriangleIndices.Add(offset + 1);
                mesh.TriangleIndices.Add(offset + 0);
                mesh.TriangleIndices.Add(offset + 4);

                mesh.TriangleIndices.Add(offset + 1);
                mesh.TriangleIndices.Add(offset + 4);
                mesh.TriangleIndices.Add(offset + 5);

                mesh.TriangleIndices.Add(offset + 0);
                mesh.TriangleIndices.Add(offset + 3);
                mesh.TriangleIndices.Add(offset + 7);

                mesh.TriangleIndices.Add(offset + 0);
                mesh.TriangleIndices.Add(offset + 7);
                mesh.TriangleIndices.Add(offset + 4);

                mesh.TriangleIndices.Add(offset + 7);
                mesh.TriangleIndices.Add(offset + 6);
                mesh.TriangleIndices.Add(offset + 5);

                mesh.TriangleIndices.Add(offset + 7);
                mesh.TriangleIndices.Add(offset + 5);
                mesh.TriangleIndices.Add(offset + 4);

                mesh.TriangleIndices.Add(offset + 2);
                mesh.TriangleIndices.Add(offset + 3);
                mesh.TriangleIndices.Add(offset + 0);

                mesh.TriangleIndices.Add(offset + 2);
                mesh.TriangleIndices.Add(offset + 0);
                mesh.TriangleIndices.Add(offset + 1);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Point3DCollection points = ReadData();

            MultipleTransformationsExample1(points);
        }
    }
}