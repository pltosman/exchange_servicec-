using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CI.interview.pltosman.DataAccess.Concrete.EntityFramework.Contexts;
using CI.interview.pltosman.Entities.Concrete;

namespace CI.interview.pltosman.DataAccess.Concrete.EntityFramework
{
    public class Seed
    {
        public static async Task SeedData(InterviewContext context)
        {
            if (!context.FixerRates.Any())
            {
                var rates = new List<Rate>
                {
                    new Rate
                    {
                       Symbol = "AED",
                       Value= 4.353199M,
                    },
                     new Rate
                    {
                       Symbol = "AFN",
                       Value= 102.970791M,
                    }
                };

                var fixerRate = new FixerRate
                {
                    Success = true,
                    Timestamp = "1631021583",
                    Base = "EUR",
                    Date = new DateTime(2021,09,07),
                    Rates = rates
                };

                await context.FixerRates.AddAsync(fixerRate);
                await context.SaveChangesAsync();
            }
        }
    }
}