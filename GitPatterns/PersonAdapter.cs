using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPatterns
{

    class PersonAdapter
    {
        private List<BusinessPerson> _PeopleRepo;

        public PersonAdapter()
        {
            _PeopleRepo = new List<BusinessPerson>();
        }

        public void addPerson(DTOPerson DTOPerson)
        {
            _PeopleRepo.Add(new BusinessPerson
            {
                firstName = DTOPerson.fName,
                lastName = DTOPerson.lName,
                position = DTOPerson.job
            });
        }

        public List<BusinessPerson> getPeople()
        {
            return _PeopleRepo;
        }

    }

    class DTOPerson
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string job { get; set; }
    }

    class BusinessPerson
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string position { get; set; }
    }

}
