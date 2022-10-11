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
    public class PeopleService : IPeopleServiceCommon
    {
        public PeopleService(IPeopleRepositoryCommon repository)
        {
            this.repository = repository;
        }
        private IPeopleRepositoryCommon repository { get; set; }

        public async Task<List<People>> GetAllPeople(PeopleParameters peopleParameters) { 
            List<People> people = await repository.GetAllPeople(peopleParameters);
            return people;
        }

        public async Task<People> GetPeopleById(int id)
        {
            People people = await repository.GetPeopleById(id);
            return people;
        }

        public async Task PostPeople(People people)
        {
            repository.PostPeople(people);
        }

        public async Task PutPeople(int id, People people)
        {
            repository.PutPeople(id, people);
        }

        public async Task DeletePeople(People people, int id)
        {
            repository.DeletePeople(people, id);
        }
    }
}
