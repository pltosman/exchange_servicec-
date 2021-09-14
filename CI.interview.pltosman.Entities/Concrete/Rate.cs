using System;
using System.Collections.Generic;
using CI.interview.pltosman.Core.Entities;
using CI.interview.pltosman.Core.Entities.Concrete;

namespace CI.interview.pltosman.Entities.Concrete
{
    public class Rate:IEntity
    { 
       // public Guid Id { get; set; }

        public string Symbol { get; set; }

        public decimal Value { get; set; }

        public string  Base { get; set; } //EUR

        public string Date { get; set; }

        public string Timestamp { get; set; }


        public Rate()
        {

        }


        public Rate(string symbol, decimal value, string _base,string date, string timestamp )
        {
            this.Symbol = symbol;
            this.Value = value;
            this.Base = _base;
            this.Date = date;
            this.Timestamp = timestamp;
         
        }

        public static List<Rate> FillList(FixerDetailResponse fixerDetail)
        {
            var VMs = new List<Rate>();
            foreach (var rateItem in fixerDetail.Rates)
            {
                VMs.Add(new Rate(rateItem.Key,rateItem.Value,fixerDetail.Base,fixerDetail.Date,fixerDetail.Timestamp));
            }
            return VMs;
        }
    }
}
