using System;
using System.Collections.Generic;
using CI.interview.pltosman.Entities.Concrete;

namespace CI.interview.pltosman.Entities.ResponseModel
{
    public class FixerServiceResponse
    {
        public bool Success { get; set; }
        public string Timestamp { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
        public List<RateResponse> Rates { get; set; }

        public FixerServiceResponse()
        {
            Rates = new List<RateResponse>();
        }

        public FixerServiceResponse(bool success, string Timestamp, string _base, string date,List<Rate> rates)
        {
            this.Success = success;
            this.Timestamp = Timestamp;
            this.Base = _base;
            this.Date = date;
            this.Rates = RateResponse.FillList(rates);
        }
    }
}
