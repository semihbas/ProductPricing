using Moq;
using NUnit.Framework;
using ProductPricing.Core.Data;
using ProductPricing.Core.Data.Repositories;
using ProductPricing.Core.Entities;
using ProductPricing.Core.Services;
using ProductPricing.Data;
using ProductPricing.Services.Services;
using System;

namespace ProductPricing.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private Mock<IProductRepository> productRepository;
        private IProductService productService;

        private Product expectedProduct;

        [SetUp]
        public void Initialization()
        {
            //Arrange
            productRepository = new Mock<IProductRepository>();

            var mockContext = new Mock<ProductPricingDbContext>();
            var unitOfWork = new UnitOfWork(mockContext.Object);

            productService = new ProductService(productRepository.Object, unitOfWork);

            expectedProduct = new Product
            {
                Id = 1,
                Name = "Small wongle",
                Price = 5
            };

            productRepository.Setup(s => s.GetByIdAsync(It.IsAny<long>())).ReturnsAsync(expectedProduct);
        }

        [Test]
        [TestCase(TestName = "WillCallSaveChanges")]
        public void SaveChanges()
        {
            var mockContext = new Mock<ProductPricingDbContext>();
            var unitOfWork = new UnitOfWork(mockContext.Object);

            unitOfWork.Commit();

            mockContext.Verify(x => x.SaveChanges());
        }

        [Test]
        [TestCase("2", TestName = "ExistentUserShouldReturnValidProductById")]
        public async void GetByIdAsync(long expectedId)
        {
            //Act
            Product product = await productService.GetByIdAsync(expectedId);
            //Assert
            Assert.AreEqual(product.Id, expectedId);
        }

        [Test]
        [TestCase(TestName = "DeleteShouldRemoveValidProductById")]
        public void Delete()
        {
            productRepository.Setup(r => r.Delete(It.IsAny<Product>()));
            productService.Delete(expectedProduct);
            productRepository.Verify(r => r.Delete(It.IsAny<Product>()), Times.AtLeastOnce());
        }

        [Test]
        [TestCase(TestName = "GetAllShouldReturnAllProducts")]
        public void GetAll()
        {
            productRepository.Setup(r => r.GetAllAsync());
            productService.GetAllAsync();
            productRepository.Verify(r => r.GetAllAsync(), Times.AtLeastOnce());
        }

        [Test]
        [TestCase(TestName = "UpdateShouldUpdateProductData")]
        public void Update()
        {
            var product = new Product();
            productRepository.Setup(r => r.Update(It.IsAny<Product>()));
            productService.Update(product);
            productRepository.Verify(r => r.Update(It.IsAny<Product>()), Times.AtLeastOnce());
        }
    }
}