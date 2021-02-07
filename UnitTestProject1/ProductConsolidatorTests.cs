using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe.Models;
using System;
using System.Linq;

namespace RefactorMe.Tests
{
    [TestClass]
    public class ProductConsolidatorTests
    {
        [TestMethod]
        [DataRow(Currency.Dollars)]
        [DataRow(Currency.Euros)]
        [DataRow(null)]
        public void GetAllProducts(Currency? currency)
        {
            string expected1 = ProductType.Lawnmover.ToString();
            string expected2 = ProductType.PhoneCase.ToString();
            string expected3 = ProductType.TShirt.ToString();

            var productConsolidator = new ProductDataConsolidator();
            var result = productConsolidator.GetAll(currency);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Where(x => x.Type.Equals(expected1)).Select(x => x.Type).FirstOrDefault());
            Assert.IsNotNull(result.Where(x => x.Type.Equals(expected2)).Select(x => x.Type).FirstOrDefault());
            Assert.IsNotNull(result.Where(x => x.Type.Equals(expected3)).Select(x => x.Type).FirstOrDefault());
        }

        [TestMethod]
        public void GetProducts_Search_null()
        {
            SearchCriteria searchCriteria = null;
           
            var productConsolidator = new ProductDataConsolidator();            
            Assert.ThrowsException<ArgumentNullException>(() => productConsolidator.Get(searchCriteria));
        }

        [TestMethod]
        public void GetProducts_Search_LawnMower_and_name()
        {
            SearchCriteria searchCriteria = new SearchCriteria { 
             productType = ProductType.Lawnmover,
             name = "Fisher"
            };

            var productConsolidator = new ProductDataConsolidator();
            var result = productConsolidator.Get(searchCriteria);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetProducts_Search_name_and_producttype_null()
        {
            SearchCriteria searchCriteria = new SearchCriteria
            {
                productType = null,
                name = "Fisher"
            };

            var productConsolidator = new ProductDataConsolidator();
            var result = productConsolidator.Get(searchCriteria);
            Assert.IsNotNull(result);
        }
    }
}
