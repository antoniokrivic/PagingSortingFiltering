using AutoMapper;
using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using PeopleAndOrders.Service;
using PeopleAndOrders.Service.Common;
using System.CodeDom;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace PeopleAndOrders.WebAPI.Controllers
{
    public class OrdersController : ApiController
    {
        public OrdersController(){}
        private IOrdersServiceCommon service { get; set; }
        private IMapper Mapper { get; set; }
        
        public OrdersController(IOrdersServiceCommon service, IMapper mapper)
        {
            this.service = service;
            this.Mapper = mapper;
        }
      
        [HttpGet]
        public async Task<HttpResponseMessage> GetOrder(PeopleParameters ordersParameters)
        {
            List<Orders> order = await service.GetAllOrders(ordersParameters);
            List<OrdersRest> ordersRest = MapToRest(order);

            if (order == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.OK, ordersRest);
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetOrderById(int id)
        {
            Orders order = await service.GetOrderById(id);
            OrdersRest orders = Mapper.Map<OrdersRest>(order);

            if (orders == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, orders);
        }
        [HttpPut]
        public async Task<HttpResponseMessage> PutOrder(int id, Orders order)
        {
            if (order == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            service.PutOrder(id, order);
            OrdersRest _ordersRest = Mapper.Map<OrdersRest>(order);
            return Request.CreateResponse(HttpStatusCode.OK, _ordersRest);
        }
        [HttpPost]
        public async Task<HttpResponseMessage> PostOrder(OrdersRest ordersRest)
        {
            if (ordersRest == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            service.PostOrder(ordersRest);
            Orders orders = Mapper.Map<Orders>(ordersRest);
            return Request.CreateResponse(HttpStatusCode.OK, orders);
        }
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteOrder(Orders order)
        {
            if (order == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            service.DeleteOrder(order);
            OrdersRest _ordersRest = Mapper.Map<OrdersRest>(order);
            return Request.CreateResponse(HttpStatusCode.OK, _ordersRest);
        }
        public List<OrdersRest> MapToRest(List<Orders> orders)
        {
            List<OrdersRest> ordersRest = new List<OrdersRest>();

            if (orders == null)
            {
                return null;
            }
            foreach (Orders order in orders)
            {
                OrdersRest _ordersRest = Mapper.Map<OrdersRest>(order);
                ordersRest.Add(_ordersRest);
            }
            return ordersRest;
        }

    }
}
