using System;
using System.Collections.Generic;

namespace CI.interview.pltosman.Core.Entities.Concrete
{
    public class FixerDetailResponse
    {
       public bool Success { get; set; }
       public string Timestamp { get; set; }
       public string Base { get; set; }
       public string Date { get; set; }
       public Dictionary<string, decimal> Rates { get; set; }


        public FixerDetailResponse()
        {

        }

        public FixerDetailResponse(bool success, string Timestamp, string _base, string date, Dictionary<string, decimal> rates)
        {
            this.Success = success;
            this.Timestamp = Timestamp;
            this.Base = _base;
            this.Date = date;
            this.Rates = rates;
        }
    }
}
