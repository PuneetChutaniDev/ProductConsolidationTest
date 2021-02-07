using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Models
{
    public enum ProductType
    {
        Lawnmover,
        PhoneCase,
        TShirt
    }

    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }
    }
}
