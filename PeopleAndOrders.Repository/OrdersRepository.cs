using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleAndOrders.Model;
using PeopleAndOrders.Repository.Common;
using PeopleAndOrders.Common;

/*TODO LIST
-Exceptions
-REST Model dovršiti
*/


namespace PeopleAndOrders.Repository
{
    
    public class OrdersRepository : IOrdersRepositoryCommon
    {
        string connString = @"Server=ST-02\SQLEXPRESS;Initial Catalog=master;Trusted_connection=true;";

        public OrdersRepository()
        {

        }
        public async Task<List<Orders>> GetAllOrders(PeopleParameters ordersParameters)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Orders", con))
                {
                    List<Orders> order = new List<Orders>();
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            order.Add(new Orders
                            {
                                Id_Order = Convert.ToInt32(sdr["id_order"]),
                                Id_User = Convert.ToInt32(sdr["id_user"]),
                                Product = sdr["product"].ToString(),
                                Total_Price = Convert.ToInt32(sdr["total_price"]),                               
                            });
                        }
                    }
                    con.Close();
                    return order
                        .OrderBy(c=>c.Product)
                        .Skip((ordersParameters.PageNumber - 1) * ordersParameters.PageSize)
                        .Take(ordersParameters.PageSize)
                        .ToList();
                }
            }
        }
        public async Task<Orders> GetOrderById(int id)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Orders WHERE Id_Order=@id_order", con))
                {
                    Orders order = new Orders();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_order", id);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            order = new Orders
                            {
                                Id_Order = Convert.ToInt32(sdr["id_order"]),
                                Id_User = Convert.ToInt32(sdr["id_user"]),
                                Product = sdr["product"].ToString(),
                                Total_Price = Convert.ToInt32(sdr["total_price"]),
                            };
                        }
                    }
                    con.Close();
                    return order;
                }
            }          
        }
        public async Task<Orders> PostOrder(OrdersRest orderRest)
        {
            Orders order = new Orders(orderRest.Id_Order, orderRest.Id_User, orderRest.Product, orderRest.Total_Price);
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Orders VALUES (@id_order,@product,@total_price)", con))
                {
                    cmd.Parameters.AddWithValue("@id_order", $"{order.Id_Order}"); 
                    cmd.Parameters.AddWithValue("@product", $"{order.Product}");
                    cmd.Parameters.AddWithValue("@total_price", $"{order.Total_Price}");
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return order;
                }
            }
        }
        public async Task<Orders> PutOrder(int id, Orders orders)
        {
            id = orders.Id_Order;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Orders SET id_order=@id_order,id_user=@id_user,product=@product,total_price=@total_priceWHERE id_order=@id_order", con))
                {
                    cmd.Parameters.AddWithValue("@id_user", $"{orders.Id_User}");
                    cmd.Parameters.AddWithValue("@id_order", $"{id}");
                    cmd.Parameters.AddWithValue("@product", $"{orders.Product}");
                    cmd.Parameters.AddWithValue("@total_price", $"{orders.Total_Price}");             
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return orders;
                }
            }
        }
        public async Task DeleteOrder(Orders orders)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Orders WHERE id_order=@id_order", con))
                {
                    cmd.Parameters.AddWithValue("@id", $"{orders.Id_Order}");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
