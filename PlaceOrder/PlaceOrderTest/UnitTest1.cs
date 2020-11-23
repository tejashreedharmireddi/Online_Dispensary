using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PlaceOrder.Models;
using PlaceOrder.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PlaceOrderTest
{
    public class Tests
    {
        List<OrderDetails> item = new List<OrderDetails>();
        IQueryable<OrderDetails> itemdata;
        Mock<DbSet<OrderDetails>> mockSet;
        Mock<OrderDbContext> itemcontextmock;
        [SetUp]
        public void Setup()
        {
            item = new List<OrderDetails>()
           {
                new OrderDetails{OrderId = 1, MedId=2,MedName="Keto",Amount=200,Address="Vizag"},
           };
            itemdata = item.AsQueryable();
            mockSet = new Mock<DbSet<OrderDetails>>();
            mockSet.As<IQueryable<OrderDetails>>().Setup(m => m.Provider).Returns(itemdata.Provider);
            mockSet.As<IQueryable<OrderDetails>>().Setup(m => m.Expression).Returns(itemdata.Expression);
            mockSet.As<IQueryable<OrderDetails>>().Setup(m => m.ElementType).Returns(itemdata.ElementType);
            mockSet.As<IQueryable<OrderDetails>>().Setup(m => m.GetEnumerator()).Returns(itemdata.GetEnumerator());
            var p = new DbContextOptions<OrderDbContext>();
            itemcontextmock = new Mock<OrderDbContext>(p);
            itemcontextmock.Setup(x => x.OrderList).Returns(mockSet.Object);



        }


        [Test]
        public void GetAll()
        {
            var obj = new MedicineViewModel() { Id = 1, Name = "Keto", Cost= 200 };
            var itemrepo = new PlaceOrderRepository(itemcontextmock.Object);
            var itemlist = itemrepo.PlaceOrder(obj);
            Assert.NotNull(itemlist);
        }
    }
}