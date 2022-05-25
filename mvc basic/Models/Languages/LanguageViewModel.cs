using mvc_basic.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models.Languages
{
    public class LanguageViewModel
    {
        public List<Language> List { get; set; }
        public List<People> Peoples { get; set; }
        public List<LanguagePeople> LanguagePeoples { get; set; }
        public CreateLanguageViewModel CreateLanguageViewModel { get; set; }
        public CreateLanguagePeopleViewModel CreateLanguagePeopleViewModel { get; set; }
    }
}
