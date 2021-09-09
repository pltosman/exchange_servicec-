using System;
using CI.interview.pltosman.Core.Entities;

namespace CI.interview.pltosman.Entities.Concrete
{
    public class Rate:IEntity
    { 
        public Guid Id { get; set; }

        public string Symbol { get; set; }

        public decimal Value { get; set; }

        public FixerRate FixerRate { get; set; }

        public Guid FixerRateId { get; set; }
    }
}
