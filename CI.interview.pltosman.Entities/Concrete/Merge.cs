using System;
using System.ComponentModel.DataAnnotations.Schema;
using CI.interview.pltosman.Core.Entities;

namespace CI.interview.pltosman.Entities.Concrete
{
    public class Merge:IEntity
    {
        //TODO
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Base { get; set; }

        public string Country { get; set; }

        [NotMapped]
        public decimal amount_eur {

            get
            {
                //TODO:
                return Amount / Amount;
            }
        }

        public string Currency { get; set; }

        public decimal Amount { get; set; }


    }
}
