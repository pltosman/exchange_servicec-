using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CI.interview.pltosman.Entities.Dtos;

namespace CI.interview.pltosman.Business.Abstract
{
    public interface IExcelService
    {
        Task<List<DataExcelModelDto>> GetData();
        List<string> ReadInCSV();
        List<DataExcelModelDto> GetCSVExcelData();
    }
}
