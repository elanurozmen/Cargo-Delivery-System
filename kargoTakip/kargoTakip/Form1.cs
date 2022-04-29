using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;

namespace kargoTakip
{
    public partial class Form1 : Form
    {
        private GeoCoordinateWatcher watcher = new();
        public double courierLatitude;
        public double courierLongitude;
        private readonly Operations operations = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if(e.Status== GeoPositionStatus.Ready)
            {
                if (watcher.Position.Location.IsUnknown)
                {
                    courierLongitude = 0;
                    courierLatitude = 0;
                }
                else
                {
                    courierLongitude = watcher.Position.Location.Longitude;
                    courierLatitude = watcher.Position.Location.Latitude;
                }
            }
            else
            {
                courierLongitude = 0;
                courierLatitude = 0;
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            var res = operations.Login(txtusername.Text, txtpassword.Text);
            if (res!=null)
            {   Map map = new();
                map.loggedInfo = res;
                map.Show();
               User user = new();
                user.loggedInfo = res;
                user.Show();
                this.Hide();
            }
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            Courier courierInfo = new() 
            {
                courierName = txtusername.Text,
                password = txtpassword.Text,
                loc = new Location()
                {
                    longitude=courierLongitude,
                    latitude=courierLatitude
                }
            };
            var res = operations.Register(courierInfo);
            if (res)
            {
                MessageBox.Show("Kullanıcı başarıyla kaydedildi!");
            }
            else
            {
                MessageBox.Show("Kullanıcı kaydedilemedi...");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            watcher = new GeoCoordinateWatcher();
            watcher.StatusChanged += Watcher_StatusChanged;
            watcher.Start();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            Courier courierInfo = new()
            {
                courierName = txtusername.Text,
                password = txtNewPass.Text,
                loc = new Location()
                {
                    longitude = courierLongitude,
                    latitude = courierLatitude
                }
            };
            var setter = operations.client.Update("Couriers/"+txtusername.Text,courierInfo);
            MessageBox.Show("Şifre başarıyla değiştirildi!");
        }
    }
}
