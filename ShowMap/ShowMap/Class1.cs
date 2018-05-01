//using System;
//using System.Windows;
//using System.Windows.Media.Media3D;

//namespace PointCloud
//{
//    public partial class Window1 : Window
//    {
//        public Window1()
//        {
//            InitializeComponent();
//        }

//        private void Window_Loaded(object sender, RoutedEventArgs e)
//        {
//            Point3DCollection points = ReadData();
//            CreatePointCloud(points);
//        }

//        private void CreatePointCloud(Point3DCollection points)
//        {
//            for (int i = 0; i < points.Count; i++)
//            {
//                AddCubeToMesh(pointCloudMesh, points[i], 0.005);
//            }

//            pointCloudMesh.Freeze();
//        }

//        private Point3DCollection ReadData()
//        {
//            // read 3d points from a file or create at runtime
//            return CreateSphere(70, 70);
//        }

//        private Point3DCollection CreateSphere(int hDiv, int vDiv)
//        {
//            double maxTheta = Math.PI * 2;
//            double minY = -1.0;
//            double maxY = 1.0;

//            double dt = maxTheta / hDiv;
//            double dy = (maxY - minY) / vDiv;

//            MeshGeometry3D mesh = new MeshGeometry3D();
//            Point3DCollection points = new Point3DCollection();

//            for (int yi = 0; yi <= vDiv; yi++)
//            {
//                double y = minY + yi * dy;

//                for (int ti = 0; ti <= hDiv; ti++)
//                {
//                    double t = ti * dt;
//                    double r = Math.Sqrt(1 - y * y);
//                    double x = r * Math.Cos(t);
//                    double z = r * Math.Sin(t);
//                    points.Add(new Point3D(x, y, z));
//                }
//            }

//            return points;
//        }

//        private void AddCubeToMesh(MeshGeometry3D mesh, Point3D center, double size)
//        {
//            if (mesh != null)
//            {
//                int offset = mesh.Positions.Count;

//                mesh.Positions.Add(new Point3D(center.X - size, center.Y + size, center.Z - size));
//                mesh.Positions.Add(new Point3D(center.X + size, center.Y + size, center.Z - size));
//                mesh.Positions.Add(new Point3D(center.X + size, center.Y + size, center.Z + size));
//                mesh.Positions.Add(new Point3D(center.X - size, center.Y + size, center.Z + size));
//                mesh.Positions.Add(new Point3D(center.X - size, center.Y - size, center.Z - size));
//                mesh.Positions.Add(new Point3D(center.X + size, center.Y - size, center.Z - size));
//                mesh.Positions.Add(new Point3D(center.X + size, center.Y - size, center.Z + size));
//                mesh.Positions.Add(new Point3D(center.X - size, center.Y - size, center.Z + size));

//                mesh.TriangleIndices.Add(offset + 3);
//                mesh.TriangleIndices.Add(offset + 2);
//                mesh.TriangleIndices.Add(offset + 6);

//                mesh.TriangleIndices.Add(offset + 3);
//                mesh.TriangleIndices.Add(offset + 6);
//                mesh.TriangleIndices.Add(offset + 7);

//                mesh.TriangleIndices.Add(offset + 2);
//                mesh.TriangleIndices.Add(offset + 1);
//                mesh.TriangleIndices.Add(offset + 5);

//                mesh.TriangleIndices.Add(offset + 2);
//                mesh.TriangleIndices.Add(offset + 5);
//                mesh.TriangleIndices.Add(offset + 6);

//                mesh.TriangleIndices.Add(offset + 1);
//                mesh.TriangleIndices.Add(offset + 0);
//                mesh.TriangleIndices.Add(offset + 4);

//                mesh.TriangleIndices.Add(offset + 1);
//                mesh.TriangleIndices.Add(offset + 4);
//                mesh.TriangleIndices.Add(offset + 5);

//                mesh.TriangleIndices.Add(offset + 0);
//                mesh.TriangleIndices.Add(offset + 3);
//                mesh.TriangleIndices.Add(offset + 7);

//                mesh.TriangleIndices.Add(offset + 0);
//                mesh.TriangleIndices.Add(offset + 7);
//                mesh.TriangleIndices.Add(offset + 4);

//                mesh.TriangleIndices.Add(offset + 7);
//                mesh.TriangleIndices.Add(offset + 6);
//                mesh.TriangleIndices.Add(offset + 5);

//                mesh.TriangleIndices.Add(offset + 7);
//                mesh.TriangleIndices.Add(offset + 5);
//                mesh.TriangleIndices.Add(offset + 4);

//                mesh.TriangleIndices.Add(offset + 2);
//                mesh.TriangleIndices.Add(offset + 3);
//                mesh.TriangleIndices.Add(offset + 0);

//                mesh.TriangleIndices.Add(offset + 2);
//                mesh.TriangleIndices.Add(offset + 0);
//                mesh.TriangleIndices.Add(offset + 1);
//            }
//        }
//    }
//}