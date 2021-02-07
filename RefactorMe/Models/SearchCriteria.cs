using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Models
{
    public class SearchCriteria
    {
        public ProductType? productType { get; set; }
        public string name { get; set; }
    }
}
