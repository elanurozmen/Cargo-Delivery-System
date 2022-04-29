using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kargoTakip
{
    public partial class User : Form
    {
       Dictionary<string, Customer> cargoList = new();
        public List<GMarkerGoogle> markerList = new();
        public Courier loggedInfo;
        int selectedRow = 0;
        public GMarkerGoogle marker;
        public static User instance;
        public TextBox txtlatitude;
        public TextBox txtlongitude;
        public DataGridView dt;
        private readonly Operations operations = new();
        static double totaldist = double.MaxValue;
        static int[] enkisayol;
        static double[,] um;
        public User()
        {
            InitializeComponent();
            instance = this;
            txtlatitude= txtLat;
            txtlongitude = txtLng;
            dt = Table;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customer customerInfo = new()
            {
                customerName = txtName.Text,
                customerLocation = new Location()
                {
                    latitude = Convert.ToDouble(txtLat.Text),
                    longitude = Convert.ToDouble(txtLng.Text)
                },
                situation = "false"
            };
            bool res = operations.AddCargo(customerInfo);
            if (res)
            {
                Table.Rows.Add(txtName.Text, txtLat.Text, txtLng.Text);
                marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(txtLat.Text), Convert.ToDouble(txtLng.Text)), GMarkerGoogleType.green);
                Map.instance.markerOverlay.Markers.Add(marker);
                markerList.Add(marker);
                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTipText = string.Format("KONUM \n Enlem: {0} \n Boylam: {1}", Convert.ToDouble(txtLat.Text), Convert.ToDouble(txtLng.Text));
                Map.instance.mapControl.Position = marker.Position;
                MessageBox.Show("Teslimat adresi başarıyla kaydedildi!");
            }
            else
            {
                MessageBox.Show("Teslimat adresi kaydedilemedi...");
            }
         }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach(var marker in markerList)
            {
                if(marker.Position.Lat== Convert.ToDouble(Table.Rows[selectedRow].Cells[1].Value) && marker.Position.Lng == Convert.ToDouble(Table.Rows[selectedRow].Cells[2].Value))
                {
                    Map.instance.markerOverlay.Markers.Remove(marker);
                    markerList.Remove(marker);
                    break;
                }
            }
            var res = operations.client.Delete("Customers/" + txtName.Text);
            Table.Rows.RemoveAt(selectedRow);

        }

        private void User_Load(object sender, EventArgs e)
        {
            GetCargosToTable(); 
        }
        public void GetCargosToTable()
        {
            cargoList = operations.GetCargos();
            Table.Rows.Clear();
            Table.Columns.Clear();
            DataGridViewTextBoxColumn Name = new();
            Name.HeaderText = "İSİM";
            Name.ReadOnly = true;
            Table.Columns.Add(Name);

            DataGridViewTextBoxColumn Latitude = new();
            Latitude.HeaderText = "ENLEM";
            Latitude.ReadOnly = true;
            Table.Columns.Add(Latitude);

            DataGridViewTextBoxColumn Longitude = new();
            Longitude.HeaderText = "BOYLAM";
            Longitude.ReadOnly = true;
            Table.Columns.Add(Longitude);

            DataGridViewCheckBoxColumn Situation = new();
            Situation.HeaderText = "Durum";
            Table.Columns.Add(Situation);
            if (cargoList != null)
            {
                foreach (var cargo in cargoList)
                {
                    Table.Rows.Add(cargo.Value.customerName, cargo.Value.customerLocation.latitude, cargo.Value.customerLocation.longitude,cargo.Value.situation);
                    marker = new GMarkerGoogle(new PointLatLng(cargo.Value.customerLocation.latitude, cargo.Value.customerLocation.longitude), GMarkerGoogleType.green);
                    Map.instance.markerOverlay.Markers.Add(marker);
                   Map.instance.mapControl.Position = marker.Position;
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    marker.ToolTipText = string.Format("KONUM \n Enlem: {0} \n Boylam: {1}", cargo.Value.customerLocation.latitude, cargo.Value.customerLocation.longitude);
                    markerList.Add(marker);
                    Map.instance.stationList.Add(marker.Position);
                }
                
            }
            if (cargoList == null)
            {
                cargoList = new Dictionary<string, Customer>();
            }
            if (!(cargoList.Any(x => x.Value.customerName== "Kurye")))
            {
                cargoList.Add("Kurye", new Customer
                {
                    customerName = "Kurye",
                    customerLocation=new Location(){ 
                    latitude = Convert.ToDouble(loggedInfo.loc.latitude),
                    longitude = Convert.ToDouble(loggedInfo.loc.longitude)},
                    situation = "Kurye"
                });
            }
        }

        private void Select(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedRow = e.RowIndex;
            txtName.Text = Table.Rows[selectedRow].Cells[0].Value.ToString();
            txtLat.Text = Table.Rows[selectedRow].Cells[1].Value.ToString();
            txtLng.Text = Table.Rows[selectedRow].Cells[2].Value.ToString();
            marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(txtLat.Text), Convert.ToDouble(txtLng.Text)), GMarkerGoogleType.green);
            Map.instance.mapControl.Position = marker.Position;

        }
        public void ShortestPath()
        {
            int[,] array = new int[markerList.Count,markerList.Count];
            int[] a = new int[markerList.Count];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i;
            }
            int n = a.Length;
            um = new double[a.Max() + 1, a.Max() + 1];
            foreach (int i in a)
            {
                foreach (int j in a)
                {
                    um[i, j] = 0;
                    if (i != j)
                    {
                    var r = GoogleMapProvider.Instance.GetRoute(Map.instance.stationList[i], Map.instance.stationList[j], true, true, 14);
                    um[i, j] = r.Distance; 
                    }

                }
            }
            enkisayol = new int[n];
            permute(a, 0, n - 1);

            List<PointLatLng> localList= new();
            for (int i = 1; i < enkisayol.Length-1; i++)
            {
                localList.Add(Map.instance.stationList[enkisayol[i]]);
            }
            GDirections direction;
            var route = GMapProviders.GoogleMap.GetDirections(out direction, Map.instance.stationList[0],localList ,Map.instance.stationList[enkisayol.Length-1], true, false, true, false, false);
            var routes = new GMapRoute(direction.Route, "rota");
            var myroutes = new GMapOverlay("Rota");
            myroutes.Routes.Add(routes);
          
            Map.instance.mapControl.Overlays.Add(myroutes);
            Console.Write("\n");
        }
       
        private static void permute(int[] str, int l, int r)
        {
            if (l == r)
            {
                double dist = 0;
                for (int i = 0; i < str.Length - 1; i++)
                {
                    dist += um[i,i+1];
                }
                Console.Write("path: ");
                foreach (int x in str)
                {
                    Console.Write(x);
                }
                Console.Write("\n");
                Console.Write("cost: " + dist);
                Console.Write("\n");
                if (dist < totaldist)
                {
                    totaldist = dist;
                    Console.Write("Yeni kısa yol: ");
                    for (int i = 0; i < str.Length; i++)
                    {
                        enkisayol[i] = str[i];
                        Console.Write(enkisayol[i]);
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    swap(str, l, i);
                    permute(str, l + 1, r);
                    swap(str, l, i);
                }
            }
        }
        public static void swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        private void btnRota_Click(object sender, EventArgs e)
        {
            List<PointLatLng> Places = new List<PointLatLng>();
            double lat, lng;
            for (int rows = 0; rows < User.instance.dt.Rows.Count; rows++)
            {
                lat = Convert.ToDouble(dt.Rows[rows].Cells[1].Value);
                lng = Convert.ToDouble(dt.Rows[rows].Cells[2].Value);
                Places.Add(new PointLatLng(lat, lng));
            }
            GMapRoute routePlaces = new GMapRoute(Places, "Kargo");
            Map.instance.markerOverlay.Routes.Add(routePlaces);
            Map.instance.mapControl.Overlays.Add(Map.instance.markerOverlay);
            Map.instance.mapControl.Zoom = Map.instance.mapControl.Zoom + 1;
            Map.instance.mapControl.Zoom = Map.instance.mapControl.Zoom - 1;
        }

        private void btnYol_Click(object sender, EventArgs e)
        {
            //User.instance.ShortestPath();
            Map.instance.routes.Clear();
            Map.instance.CreateWay();
        }
    }
}
