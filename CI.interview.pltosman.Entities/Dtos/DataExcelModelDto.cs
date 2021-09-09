using System;
using Ganss.Excel;

namespace CI.interview.pltosman.Entities.Dtos
{
    public class DataExcelModelDto
    {
        [Column(11)]
        public string SheetName { get; set; }

        [Column(1)]
        public DateTime Date { get; set; }

        [Column(2)]
        public string Country { get; set; }

        [Column(3)]
        public string Currency { get; set; }

        [Column(4)]
        public int Amount { get; set; }
    }
}
