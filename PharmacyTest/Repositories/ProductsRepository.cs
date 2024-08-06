using PharmacyTest.Contexts;
using PharmacyTest.Domains;
using PharmacyTest.Interfaces;

namespace PharmacyTest.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly PharmacyContext _pharmacyContext;

        public ProductsRepository()
        {
            _pharmacyContext = new PharmacyContext();
        }
        public void Delete(Guid id)
        {
            Products finded = _pharmacyContext.Products.Find(id)!;
            _pharmacyContext.Remove(finded);
            _pharmacyContext.SaveChanges();
        }

        public List<Products> GetAll()
        {
            return _pharmacyContext.Products.ToList();
        }

        public Products GetById(Guid id)
        {
            try
            {
                Products finded = _pharmacyContext.Products.FirstOrDefault(p => p.IdProduct == id);

                if (finded != null)
                {
                    return finded;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Post(Products product)
        {
            _pharmacyContext.Products.Add(product);
            _pharmacyContext.SaveChanges();
        }

        public void Put(Guid id, Products product)
        {
            Products finded = _pharmacyContext.Products.Find(id)!;

            if (finded != null)
            {
                finded.Name = product.Name;
                finded.Price = product.Price;
            }

            _pharmacyContext.Update(finded);
            _pharmacyContext.SaveChanges();
        }
    }
}
