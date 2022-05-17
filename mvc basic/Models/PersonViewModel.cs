﻿using System;
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
        public CreatePersonViewModel createPersonView { get; set; }
        public void Add(CreatePersonViewModel createPersonViewModel)
        {
            createPersonViewModel.index = PeopleModel.lastIndex;
            PeopleModel.people.Add(createPersonViewModel);
            PeopleModel.lastIndex++;
            
        }
        public void Remove(int id)
        {
            PeopleModel.people.Remove(PeopleModel.people.Find(o => o.index == id));
        }
    }
}
