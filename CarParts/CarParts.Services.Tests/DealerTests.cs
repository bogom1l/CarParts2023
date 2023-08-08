namespace CarParts.Services.Tests
{
    using CarParts.Data;
    using Microsoft.EntityFrameworkCore;

    public class DealerTests
    {
        private DbContextOptions<ApplicationDbContext> _dbOptions;
        private ApplicationDbContext _dbContext;

        public DealerTests(ApplicationDbContext dbContext)
        {
            
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this._dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("CarPartsInMemory" + Guid.NewGuid().ToString())
                .Options;

            this._dbContext = new ApplicationDbContext(_dbOptions);
        }


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}