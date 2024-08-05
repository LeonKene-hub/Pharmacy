using PharmacyTest.Domains;

namespace PharmacyTest.Interfaces
{
    public interface IProductsRepository
    {
        List<Products> GetAll();
        Products GetById(Guid id);
        void Post(Products product);
        void Put(Guid id, Products product);
        void Delete(Guid id);
    }
}
