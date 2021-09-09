using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CI.interview.pltosman.Entities.Concrete;
using CI.interview.pltosman.Entities.Dtos;

namespace CI.interview.pltosman.Business.Abstract
{
    public interface IExcelDataService
    {
        void SaveExcelData(List<DataExcelModelDto> data);
        Task<List<ExcelData>> GetByDate(DateTime date);
    }
}
