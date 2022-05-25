using mvc_basic.Models.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models.ManyToMany
{
    public class LanguagePeople
    {
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
    }
}
