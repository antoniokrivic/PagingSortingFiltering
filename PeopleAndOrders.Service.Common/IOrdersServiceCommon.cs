using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Service.Common
{
    public interface IOrdersServiceCommon
    {
        Task<List<Orders>> GetAllOrders(PeopleParameters ordersParameters);
        Task<Orders> GetOrderById(int id);
        Task PostOrder(OrdersRest ordersRest);
        Task PutOrder(int id, Orders model);
        Task DeleteOrder(Orders model);
    }
}
