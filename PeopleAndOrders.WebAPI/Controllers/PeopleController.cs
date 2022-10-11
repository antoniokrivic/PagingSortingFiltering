using AutoMapper;
using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using PeopleAndOrders.Service;
using PeopleAndOrders.Service.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PeopleAndOrders.WebAPI.Controllers
{
public class PeopleController : ApiController
{
    public PeopleController(){}
    public IMapper Mapper { get; set; }
    private IPeopleServiceCommon service { get; set; }
    public PeopleController(IPeopleServiceCommon service)
    {
        this.service = service;        
    }

    
    public async Task<HttpResponseMessage> GetPeople(PeopleParameters peopleParameters)
    {
        List<People> people = await service.GetAllPeople(peopleParameters);
        
        if (people == null)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);                
        }
        return Request.CreateResponse(HttpStatusCode.OK, people);
    }
    
    public async Task<HttpResponseMessage> GetPeopleById(int id)
    {
        People people = await service.GetPeopleById(id);
        if (people == null)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        return Request.CreateResponse(HttpStatusCode.OK, people);
    }
    [HttpDelete]
    public async Task<HttpResponseMessage> DeletePeople(People people, int id)
    {
        if (people == null)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        service.DeletePeople(people, id);
        return Request.CreateResponse(HttpStatusCode.OK, people);
    }
    [HttpPut]
    public async Task<HttpResponseMessage> PutPeople(int id, People people)
    {
        if (people == null)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        service.PutPeople(id, people);
        return Request.CreateResponse(HttpStatusCode.OK, people);
    }
    [HttpPost]
    public async Task<HttpResponseMessage> PostPeople(People people)
    {
        if (people == null)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        service.PostPeople(people);
        return Request.CreateResponse(HttpStatusCode.OK, people);
    }

}
}
