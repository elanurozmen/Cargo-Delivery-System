using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;

namespace kargoTakip
{
    class Operations
    {
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "",
            BasePath = "enter your base path"
        };
        public GMarkerGoogle marker;
        public GMapOverlay markerOverlay;
        public IFirebaseClient client;
        public Operations()
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                Console.Write("Bağlantı başarılı!");
            }
            catch (Exception)
            {
                Console.Write("Bağlantı kurulamadı...");
                throw;
            }
        }

        public bool Register(Courier userInfo)
        {
            try
            {
                SetResponse set = client.Set(@"Couriers/" + userInfo.courierName, userInfo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Courier Login(string Name, string pass)
        {
            FirebaseResponse res = client.Get(@"Couriers/" + Name);
            Courier DbCourier = res.ResultAs<Courier>();
            Courier LoginCourier = new Courier()
            {
                courierName = Name,
                password = pass
            };
            if(DbCourier!=null && LoginCourier!=null)
            {
                if(DbCourier.courierName!= LoginCourier.courierName)
                {
                    return null;
                }
                else if (DbCourier.password != LoginCourier.password)
                {
                    return null;
                }
                return DbCourier;
            }
            else
            {
                return null;
            }
        }

        public bool AddCargo(Customer customerInfo)
        {
            try
            {
                SetResponse set = client.Set(@"Customers/" + customerInfo.customerName, customerInfo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Dictionary<string, Customer> GetCargos()
        {
            try
            {
                int i = 0;
                FirebaseResponse res = client.Get(@"Customers");
                Dictionary<string, Customer> cargos= JsonConvert.DeserializeObject<Dictionary<string, Customer>>(res.Body.ToString());
                return cargos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
