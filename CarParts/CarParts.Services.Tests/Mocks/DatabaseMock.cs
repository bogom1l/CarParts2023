namespace CarParts.Services.Tests.Mocks
{
    using CarParts.Data;
    using Microsoft.EntityFrameworkCore;

    public static class DatabaseMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("CarPartsInMemory" + Guid.NewGuid())
                    .Options;

                return new ApplicationDbContext(dbOptions, false);
            }
        }
    }
}