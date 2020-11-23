using NUnit.Framework;

namespace MedicineTest
{
    public class Tests
    {
        List<MedicineListModel> item = new List<MedicineListModel>();
        IQueryable<BillServices> itemdata;
        Mock<DbSet<BillServices>> mockSet;
        Mock<BillDbContext> itemcontextmock;
        [SetUp]
        public void Setup()
        {
            item = new List<BillServices>()
           {
                new BillServices{BillNo = 1230, CustomerName="Manisha",BillAmt=126},
           };
            itemdata = item.AsQueryable();
            mockSet = new Mock<DbSet<BillServices>>();
            mockSet.As<IQueryable<BillServices>>().Setup(m => m.Provider).Returns(itemdata.Provider);
            mockSet.As<IQueryable<BillServices>>().Setup(m => m.Expression).Returns(itemdata.Expression);
            mockSet.As<IQueryable<BillServices>>().Setup(m => m.ElementType).Returns(itemdata.ElementType);
            mockSet.As<IQueryable<BillServices>>().Setup(m => m.GetEnumerator()).Returns(itemdata.GetEnumerator());
            var p = new DbContextOptions<BillDbContext>();
            itemcontextmock = new Mock<BillDbContext>(p);
            itemcontextmock.Setup(x => x.Bill).Returns(mockSet.Object);



        }


        [Test]
        public void GetAll()
        {
            var itemrepo = new BillRepository(itemcontextmock.Object);
            var itemlist = itemrepo.Getbill(1230);
            Assert.NotNull(itemlist);
        }
    }
}