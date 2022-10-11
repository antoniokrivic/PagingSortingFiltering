using PeopleAndOrders.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PeopleAndOrders.Model
{
    public class Orders : IOrdersModelCommon
    {
        private object priv;
        public Orders(int id_Order, int id_User, string product, int total_Price)
        {
            Id_Order = id_Order;
            Id_User = id_User;
            Product = product;
            Total_Price = total_Price;
            
        }

        public Orders()
        {
            Id_Order = 0;
            Id_User = 0;
            Product = "";
            Total_Price = 0;

        }


        public int Id_Order { get; set; } 
        public int Id_User { get; set; }
        public string Product { get; set; }
        public int Total_Price { get; set; }
    }
}
