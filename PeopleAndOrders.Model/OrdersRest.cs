using PeopleAndOrders.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Model
{
    public class OrdersRest : IOrdersRestCommon
    {
        public int Id_Order { get; set; }       
        public string Product { get; set; }
        public int Total_Price { get; set; }
        public int Id_User { get; set; }
        private int NumberOfOrders { get; set; }

        public OrdersRest(int id_Order, string product, int total_Price)
        {
            Id_Order = id_Order;
            Product = product;
            Total_Price = total_Price;
        }
    }
}
