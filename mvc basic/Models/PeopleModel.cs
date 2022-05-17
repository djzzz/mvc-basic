using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models
{
    public class PeopleModel
    {
        static public List<CreatePersonViewModel> people = new List<CreatePersonViewModel> { };
    }
}
