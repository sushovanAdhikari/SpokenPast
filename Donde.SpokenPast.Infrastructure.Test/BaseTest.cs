using System;
using Donde.SpokenPast.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Donde.SpokenPast.Infrastructure.Test
{
    public class BaseTest
    {
        public DondeContext GetDondeContext()
        {
            var options = new DbContextOptionsBuilder<DondeContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DondeContext(options);

            return context;
        }
    }
}
