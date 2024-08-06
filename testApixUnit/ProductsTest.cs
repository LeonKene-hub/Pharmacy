using Moq;
using PharmacyTest.Domains;
using PharmacyTest.Interfaces;
using PharmacyTest.Repositories;

namespace testApixUnit
{
    public class ProductsTest
    {
        //indica que o metodo e de teste de unidade

        //GetAll
        [Fact]
        public void GetAll()
        {
            //Arrange : Cenario

            //Lista de produtos
            var products = new List<Products>
            {
                new Products {IdProduct = Guid.NewGuid(), Name="Produto 1", Price=10},
                new Products {IdProduct = Guid.NewGuid(), Name="Produto 2", Price=20},
                new Products {IdProduct = Guid.NewGuid(), Name="Produto 3", Price=30},
            };

            //Cria um boj de simulacao do tipo IProductsRepository
            var mockRepository = new Mock<IProductsRepository>();

            //Configura o metodo GetAll para retornar a lista de produtos "mock"
            mockRepository.Setup(x => x.GetAll()).Returns(products);

            //Act : Agir

            //Chama o metodo GetAll() e armazena o resultado em result
            var result = mockRepository.Object.GetAll();

            //Assert : Provar

            //Prova se o resultado esperado e igual ao resultado obtido atraves da busca
            Assert.Equal(3, result.Count);
        }

        //GetById
        //Post
        [Fact]
        public void GetById()
        {
            //Arrange : Cenario

            //Lista de produtos
            var products = new List<Products>
            {
                new Products {IdProduct = Guid.NewGuid(), Name="Produto 1", Price=10},
                new Products {IdProduct = Guid.NewGuid(), Name="Produto 2", Price=20},
                new Products {IdProduct = Guid.NewGuid(), Name="Produto 3", Price=30},
            };

            //Cria um boj de simulacao do tipo IProductsRepository
            var mockRepository = new Mock<IProductsRepository>();

            //Configura o metodo GetById para retornar o produto "mock"
            mockRepository.Setup(x => x.GetById(products[0].IdProduct)).Returns(products[0]);

            //Act : Agir

            //Chama o metodo GetById() e armazena o resultado em result
            var result = mockRepository.Object.GetById(products[0].IdProduct);

            //Assert : Provar

            //Prova se o resultado esperado e igual ao resultado obtido atraves da busca
            Assert.Equal(products[0], result);
        }

        //Delete
        [Fact]
        public void Delete()
        {
            //Arrange : Cenario

            //Lista de produtos
            var products = new List<Products>
            {
                new Products {IdProduct = Guid.NewGuid(), Name="Produto 1", Price=10},
                new Products {IdProduct = Guid.NewGuid(), Name="Produto 2", Price=20},
                new Products {IdProduct = Guid.NewGuid(), Name="Produto 3", Price=30},
            };

            //Cria um boj de simulacao do tipo IProductsRepository
            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.GetAll()).Returns(products);

            //Act : Agir
            mockRepository.Object.Delete(products[2].IdProduct);
            products.RemoveAt(2);

            mockRepository.Setup(x => x.GetAll()).Returns(products);


            //Chama o metodo GetAll() e armazena o resultado em result
            var result = mockRepository.Object.GetAll();

            //Assert : Provar

            //Prova se o resultado esperado e igual ao resultado obtido atraves da busca
            Assert.Equal(2, result.Count);
        }

        //Post
        [Fact]
        public void Post()
        {
            Products product = new Products { IdProduct = Guid.NewGuid(), Price = 10, Name = "Kiwi" };
            var productList = new List<Products>();

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.Post(product)).Callback<Products>(x => productList.Add(product));

            mockRepository.Object.Post(product);

            Assert.Contains(product, productList);

            //Desafio : Update
        }
    }
}