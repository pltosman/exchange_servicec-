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
            if (!context.Rates.Any())
            {

                var rate = new Rate
                {
                    Timestamp = "1631021583",
                    Base = "EUR",
                    Date = new DateTime(2021, 09, 07).ToString("yyyy-MM-dd"),
                    Symbol = "AED",
                    Value = 4.353199M,
                };

                /*
                var rates = new List<Rate>
                {
                    new Rate
                    {
                       Timestamp = "1631021583",
                       Base = "EUR",
                       Date = new DateTime(2021,09,07).ToString("yyyy-MM-dd"),
                       Symbol = "AED",
                       Value= 4.353199M,
                    },
                     new Rate
                    {
                       Timestamp = "1631021583",
                       Base = "EUR",
                       Date = new DateTime(2021,09,07).ToString("yyyy-MM-dd"),
                       Symbol = "AFN",
                       Value= 102.970791M,
                    }
                };
                */

                await context.Rates.AddAsync(rate);

                await context.SaveChangesAsync();
            }
        }
    }
}