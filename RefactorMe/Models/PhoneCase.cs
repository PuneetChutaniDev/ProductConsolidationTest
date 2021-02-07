using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Models
{
    public class PhoneCase : Product
    {
        public string Colour { get; set; }

        public string TargetPhone { get; set; }

        public string Material { get; set; }
    }
}
