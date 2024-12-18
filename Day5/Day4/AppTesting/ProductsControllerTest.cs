using day4.Contracts;
using day4.Controllers;
using day4.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AppTesting;

public class ProductsControllerTest
{
    private Mock<IProductsRepository> productsRepositoryMock;
    private List<Product> products;
    private ProductsController _controller;

    [SetUp]
    public void Setup()
    {
        productsRepositoryMock = new Mock<IProductsRepository>();
        _controller = new ProductsController(productsRepositoryMock.Object, null);
        products = new List<Product>();
        products.Add(new Product { Id = 1, Name = "Bread", Price = 30, Description = "1" });
        products.Add(new Product { Id = 2, Name = "Milk", Price = 10, Description = "2" });
        products.Add(new Product { Id = 3, Name = "Cream", Price = 20, Description = "3" });
        products.Add(new Product { Id = 4, Name = "Tomato", Price = 40, Description = "4" });
    }


    [Test]
    public async Task TestGetAll()
    {
        productsRepositoryMock.Setup(a => a.GetAllProducts()).ReturnsAsync(products);

        // Act
        var result = await _controller.Get();

        // Assert
        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult.Value, Is.EqualTo(products));
    }

    [Test]
    public async Task GetItemAsync_ReturnsOk_WhenItemExists()
    {
        int itemId = 1;
        productsRepositoryMock.Setup(a => a.GetById(itemId)).ReturnsAsync(products.FirstOrDefault(p=>p.Id == itemId));

        // Act
        var result = await _controller.Get(itemId);

        // Assert
        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(((Product)okResult.Value).Id, Is.EqualTo(itemId));
    }

    [Test]
    public async Task GetItemAsync_ReturnsNotFound_WhenItemDoesNotExist()
    {
        int itemId = 1;
        productsRepositoryMock.Setup(service => service.GetById(itemId))
                    .ReturnsAsync((Product)null);

        // Act
        var result = await _controller.Get(itemId);

        // Assert
        Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public async Task DeleteItemAsync_ReturnsOk_WhenItemExists()
    {
        int itemId = 1;
        productsRepositoryMock.Setup(a => a.Delete(itemId)).ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(itemId);

        // Assert
        Assert.That(result, Is.TypeOf<OkResult>());
        
    }

    [Test]
    public async Task DeleteItemAsync_ReturnsNotFound_WhenItemDoesNotExist()
    {
        int itemId = 1;
        productsRepositoryMock.Setup(service => service.Delete(itemId))
                    .ReturnsAsync(false);

        // Act
        var result = await _controller.Delete(itemId);

        // Assert
        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }
}
