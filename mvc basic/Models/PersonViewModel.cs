using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models
{
    public class PersonViewModel
    {
        public PeopleModel peopleModel = new PeopleModel();
        public List<CreatePersonViewModel> List = PeopleModel.people;
        public CreatePersonViewModel createPersonView = new CreatePersonViewModel();
        public void Add(CreatePersonViewModel createPersonViewModel)
        {
            PeopleModel.people.Add(createPersonViewModel);
        }
    }
}
