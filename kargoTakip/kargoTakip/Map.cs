using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;
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
    public partial class Map : Form
    {
        public GMarkerGoogle marker;
        public GMapOverlay markerOverlay;
        public GMapControl mapControl;
        public GMapOverlay routes = new GMapOverlay("Yol");
        public Courier loggedInfo;
        private readonly Operations operations = new();
        public static Map instance;
        bool way = false;
        public List<PointLatLng> stationList = new();
       public PointLatLng start;
        public Map()
        {
            InitializeComponent();
            instance = this;
            mapControl = MyMap;
        }

        private void Map_Load_1(object sender, EventArgs e)
        {
            GMapProviders.GoogleMap.ApiKey = @"enter your API key";
            MyMap.DragButton = MouseButtons.Left;
            MyMap.CanDragMap = true;
            MyMap.MapProvider = GMapProviders.GoogleMap;
            MyMap.Position = new PointLatLng(loggedInfo.loc.latitude,loggedInfo.loc.longitude);
            MyMap.MinZoom = 0;
            MyMap.MaxZoom = 24;
            MyMap.Zoom = 9;
            MyMap.AutoScroll = true;
           markerOverlay = new GMapOverlay("Konum");
            marker = new GMarkerGoogle(new PointLatLng(loggedInfo.loc.latitude, loggedInfo.loc.longitude), GMarkerGoogleType.green);
            markerOverlay.Markers.Add(marker);
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("KURYE KONUM \n Enlem: {0} \n Boylam: {1}", loggedInfo.loc.latitude, loggedInfo.loc.longitude);
            MyMap.Overlays.Add(markerOverlay);
        }

        private void MyMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double lat = MyMap.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = MyMap.FromLocalToLatLng(e.X, e.Y).Lng;
            User.instance.txtlatitude.Text = lat.ToString();
            User.instance.txtlongitude.Text = lng.ToString();
            marker.Position = new PointLatLng(lat, lng);
            marker.ToolTipText = string.Format("KONUM \n Enlem: {0} \n Boylam: {1}", lat, lng);
        }
        public void CreateWay()
        {           
                        start = new PointLatLng(loggedInfo.loc.latitude,loggedInfo.loc.longitude);
                        GDirections direction;
                    var routeDirection = GMapProviders.GoogleMap.GetDirections(out direction, start, stationList, markerOverlay.Markers[markerOverlay.Markers.Count-1].Position, false, false, true, false, false);
                    GMapRoute lastRoute = new GMapRoute(direction.Route, "İZLENECEK ROTA");
                    routes.Routes.Add(lastRoute);
                    MyMap.Overlays.Add(routes);
                        MyMap.Zoom = MyMap.Zoom + 1;
                        MyMap.Zoom = MyMap.Zoom - 1;
        }
    }
}
