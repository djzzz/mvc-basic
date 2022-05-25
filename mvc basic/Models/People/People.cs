﻿using mvc_basic.Models.Cities;
using mvc_basic.Models.Languages;
using mvc_basic.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models
{
    public class People
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeopleId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public ICollection<LanguagePeople> LanguagePeople { get; set; }
    }
}
