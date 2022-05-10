using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_basic.Models
{
    public class FeverModel
    {
        public bool CheckFever(int temp)
        {
            if(temp >= 38)
            {
                return true;
            }
            return false;
        }
        public bool CheckHypofermia(int temp)
        {
            if (temp <= 35)
            {
                return true;
            }
            return false;
        }
    }
}
