using System;
using System.Collections.Generic;
using CI.interview.pltosman.Entities.Concrete;

namespace CI.interview.pltosman.Entities.ResponseModel
{
    public class RateResponse
    {
        public string Symbol { get; set; }

        public decimal Value { get; set; }


        public RateResponse()
        {

        }

        public RateResponse(string symbol, decimal value)
        {
            this.Symbol = symbol;
            this.Value = value;
        }

        public static List<RateResponse> FillList(List<Rate> rates)
        {
            var VMs = new List<RateResponse>();
            foreach (Rate rateItem in rates)
            {
                VMs.Add(new RateResponse(rateItem.Symbol, rateItem.Value));
            }
            return VMs;
        }
    }
}
