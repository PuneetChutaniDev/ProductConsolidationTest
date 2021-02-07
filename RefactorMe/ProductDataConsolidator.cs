using RefactorMe.Data.Implementation;
using RefactorMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorMe
{
    public class ProductDataConsolidator
    {
        private LawnmowerRepository _lawnmowerRepository;
        private PhoneCaseRepository _phoneCaseRepository;
        private TShirtRepository _tShirtRepository;
        private List<Product> ps;
        public ProductDataConsolidator()
        {
            _lawnmowerRepository = new LawnmowerRepository();
            _phoneCaseRepository = new PhoneCaseRepository();
            _tShirtRepository = new TShirtRepository();
        }

        /// <summary>
        /// This will consolidate the products in a single list for 
        /// lawnmover, phonecase and tshirt
        /// </summary>
        /// <param name="Currency"></param>
        /// <returns></returns>
        public List<Product> GetAll(Currency? Currency)
        {
            double newChangePrice = 1;
            ps = new List<Product>();
            if (Currency.HasValue)
            {
                switch (Currency.Value)
                {
                    case Models.Currency.Dollars:
                        newChangePrice = 0.76;
                        break;
                    case Models.Currency.Euros:
                        newChangePrice = 0.67;
                        break;
                    default:
                        break;

                }
            }
            GetProducts(_lawnmowerRepository.GetAll(), ProductType.Lawnmover, newChangePrice);
            GetProducts(_phoneCaseRepository.GetAll(), ProductType.PhoneCase, newChangePrice);
            GetProducts(_tShirtRepository.GetAll(), ProductType.TShirt, newChangePrice);

            // Default sorting by  name 
            return ps.OrderBy(x => x.Type).ToList();
        }

        /// <summary>
        /// Eg. This function will get the product value based on the product type category 
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        public List<Product> Get(SearchCriteria searchCriteria)
        {
            ps = new List<Product>();
            if (searchCriteria == null)
            {
                throw new ArgumentNullException(nameof(searchCriteria), "Null exception");
            }

            if (searchCriteria.productType.HasValue)
            {
                var productType = searchCriteria.productType.Value;
                switch (productType)
                {
                    case ProductType.Lawnmover:
                        GetProducts(_lawnmowerRepository.Get(x => x.Name.Contains(searchCriteria.name)), ProductType.Lawnmover);
                        break;
                    case ProductType.PhoneCase:
                        GetProducts(_phoneCaseRepository.Get(x => x.Name.Contains(searchCriteria.name)), ProductType.PhoneCase);
                        break;
                    case ProductType.TShirt:
                        GetProducts(_tShirtRepository.Get(x => x.Name.Contains(searchCriteria.name)), ProductType.TShirt);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                GetProducts(_lawnmowerRepository.Get(x => x.Name.Contains(searchCriteria.name)), ProductType.Lawnmover);

                GetProducts(_phoneCaseRepository.Get(x => x.Name.Contains(searchCriteria.name)), ProductType.PhoneCase);
                
                GetProducts(_tShirtRepository.Get(x => x.Name.Contains(searchCriteria.name)), ProductType.TShirt);
            }

            // Default sorting by  name 
            return ps.OrderBy(x => x.Name).ToList();
        }

        private List<Product> GetProducts<T>(IQueryable<T> productList, ProductType productType, double changePrice = 1.0) where T : Product
        {
            foreach (var i in productList)
            {
                ps.Add(new Product()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price * changePrice,
                    Type = productType.ToString()
                });
            }
            return ps;
        }

    }
}
