using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Service.Common
{
    public interface IPeopleServiceCommon
    {
        Task<List<People>> GetAllPeople(PeopleParameters peopleParameters);
        Task<People> GetPeopleById(int id);
        Task PostPeople(People people);
        Task PutPeople(int id, People people);
        Task DeletePeople(People people, int id);
    }
}
