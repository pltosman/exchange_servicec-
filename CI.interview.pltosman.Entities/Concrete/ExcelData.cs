using System;
using CI.interview.pltosman.Core.Entities;

namespace CI.interview.pltosman.Entities.Concrete
{
    public class ExcelData:IEntity
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Country { get; set; }
     
        public string Currency { get; set; }
      
        public int Amount { get; set; }
    }
}
