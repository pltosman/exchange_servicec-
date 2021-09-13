using System;
using Newtonsoft.Json;

namespace CI.interview.pltosman.Entities.Dtos
{
    public class FixerRequestDto
    {
        [JsonRequired]
        public string SDate { get; set; }

        [JsonRequired]
        public string EDate { get; set; }

        public string RateTypes { get; set; }
    }
}
