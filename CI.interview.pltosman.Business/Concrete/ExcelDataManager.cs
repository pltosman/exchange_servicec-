using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CI.interview.pltosman.Business.Abstract;
using CI.interview.pltosman.DataAccess.Abstract;
using CI.interview.pltosman.Entities.Concrete;
using CI.interview.pltosman.Entities.Dtos;
using Microsoft.Extensions.Logging;

namespace CI.interview.pltosman.Business.Concrete
{
    public class ExcelDataManager : IExcelDataService
    {
        private readonly ILogger<ExcelDataManager> _logger;
        private readonly IExcelDataDal _excelData;
        private readonly IMapper _mapper;

        public ExcelDataManager(IExcelDataDal exceldata, ILogger<ExcelDataManager> logger, IMapper mapper)
        {
            _logger = logger;
            _excelData = exceldata;
            _mapper = mapper;
        }

        public void SaveExcelData(List<DataExcelModelDto> data)
        {

            _logger.LogInformation("Excel data service called.");

            try
            {
                var model = _mapper.Map<List<ExcelData>>(data);

                _excelData.SaveAllAsync(model);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex,"Excel data didn't write to database");
            }
        }


        public async Task<List<ExcelData>> GetByDate(DateTime date)
        {
            return ((List<ExcelData>)await _excelData.GetAllAsync(x => x.Date.Equals(date)));
        }

        public List<ExcelData> GetList()
        {
           return _excelData.GetList().ToList();
        }
    }
}
