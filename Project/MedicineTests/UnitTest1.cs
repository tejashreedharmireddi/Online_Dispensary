using Medicine.Model;
using Medicine.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MedicineTests
{
    public class Tests
    {
        List<MedicineListModel> item = new List<MedicineListModel>();
        IQueryable<MedicineListModel> itemdata;
        Mock<DbSet<MedicineListModel>> mockSet;
        Mock<MedicineDbContext> itemcontextmock;
        [SetUp]
        public void Setup()
        {
            item = new List<MedicineListModel>()
           {
                new MedicineListModel{Id = 2, Name="Keto",Cost=200},
           };
            itemdata = item.AsQueryable();
            mockSet = new Mock<DbSet<MedicineListModel>>();
            mockSet.As<IQueryable<MedicineListModel>>().Setup(m => m.Provider).Returns(itemdata.Provider);
            mockSet.As<IQueryable<MedicineListModel>>().Setup(m => m.Expression).Returns(itemdata.Expression);
            mockSet.As<IQueryable<MedicineListModel>>().Setup(m => m.ElementType).Returns(itemdata.ElementType);
            mockSet.As<IQueryable<MedicineListModel>>().Setup(m => m.GetEnumerator()).Returns(itemdata.GetEnumerator());
            var p = new DbContextOptions<MedicineDbContext>();
            itemcontextmock = new Mock<MedicineDbContext>(p);
            itemcontextmock.Setup(x => x.MedicineList).Returns(mockSet.Object);



        }


        [Test]
        public void GetAll()
        {
            var itemrepo = new MedicineRepository(itemcontextmock.Object);
            var itemlist = itemrepo.GetName("Keto");
            Assert.NotNull(itemlist);
        }
    }
}