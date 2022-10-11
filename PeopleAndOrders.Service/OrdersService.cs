using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using PeopleAndOrders.Repository;
using PeopleAndOrders.Repository.Common;
using PeopleAndOrders.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Service
{
    public class OrdersService : IOrdersServiceCommon
    {
        public OrdersService(IOrdersRepositoryCommon repository)
        {
            this.repository = repository;
        }

        public OrdersService()
        {
        }

        private IOrdersRepositoryCommon repository { get; set; }
        
        public async Task<List<Orders>> GetAllOrders(PeopleParameters peopleParameters)
        {
            List<Orders> order = await repository.GetAllOrders(peopleParameters);
            return order;
        }

        public async Task<Orders> GetOrderById(int id)
        {
            Orders order = await repository.GetOrderById(id);
            return order;
        }
        public async Task PostOrder(OrdersRest order)
        {
            repository.PostOrder(order);
        }
        public async Task PutOrder(int id, Orders order)
        {
            repository.PutOrder(id, order);
        }
        public async Task DeleteOrder(Orders order)
        {
            repository.DeleteOrder(order);
        }
    }
}
