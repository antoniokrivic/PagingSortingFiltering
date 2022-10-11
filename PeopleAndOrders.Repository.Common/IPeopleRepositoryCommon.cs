using PeopleAndOrders.Common;
using PeopleAndOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Repository.Common
{
    public interface IPeopleRepositoryCommon
    {
        Task<List<People>> GetAllPeople(PeopleParameters peopleParameters);
        Task<People> GetPeopleById(int id);
        Task<People> PostPeople(People people);
        Task<People> PutPeople(int id, People people);
        Task DeletePeople(People people, int id);
    }
}
