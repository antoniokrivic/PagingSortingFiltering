using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Repository.Common
{
    public interface IOrdersRepositoryCommon
    {
        Task<List<Orders>> GetAllOrders(PeopleParameters ordersParameters);
        Task<Orders> GetOrderById(int id);
        Task<Orders> PostOrder(OrdersRest orderRest);
        Task<Orders> PutOrder(int id, Orders orders);
        Task DeleteOrder(Orders orders);
    }
}
