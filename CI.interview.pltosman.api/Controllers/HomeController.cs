using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CI.interview.pltosman.Business.Abstract;
using CI.interview.pltosman.Core.Entities.Concrete;
using CI.interview.pltosman.Core.Extentions;
using CI.interview.pltosman.Core.Utilities.Messages;
using CI.interview.pltosman.Core.Utilities.Results;
using CI.interview.pltosman.Entities.Dtos;
using CI.interview.pltosman.Entities.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CI.interview.pltosman.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IFixerDetailService _fixerDetailService;
        private readonly IFixerRateService _fixerRateService;
        private readonly IExcelService _excelService;
        private readonly ILogger<HomeController> _logger;
        private readonly IExcelDataService _excelDataService;

        private readonly IMapper _mapper;

        public HomeController(IFixerDetailService fixerDetailService, ILogger<HomeController> logger, IFixerRateService fixerRateService, IExcelService excelService, IExcelDataService excelDataService, IMapper mapper)
        {
            _fixerDetailService = fixerDetailService;
            _fixerRateService = fixerRateService;
            _excelService = excelService;
            _logger = logger;
            _excelDataService = excelDataService;
            _mapper = mapper;
        }


        [HttpPost()]
        [Produces("application/json")]
        [ProducesResponseType(typeof(FixerDetailResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetRateByDates([FromBody] FixerRequestDto request)
        {

            _logger.LogInformation("Fixer Service controller's method called");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage().ToString());
            }

            var result = await _fixerDetailService.GetFixerDetail(request.SDate, request.EDate,request.Currency);

            if (result.Success)
            {
             //   _fixerRateService.SaveFixerResult(result.Data);
                return Ok(result.Data);
            }

            if (result.Message.Contains("NotFound"))
            {
                return NotFound(new Result(false, AspectMessages.NotFoundResult));
            }

            return BadRequest(new Result(false, AspectMessages.InvalidRequest));
        }


        [HttpPost("readExcelData")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IDataResult<List<DataExcelModelDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public IActionResult ReadExcelData()
        {
            List<DataExcelModelDto> data = _excelService.GetCSVExcelData();

            if (data != null && data.Count > 0)
            {
                _excelDataService.SaveExcelData(data);

            }

          var response=  _excelDataService.GetByDate(new DateTime(2019, 10, 1)).Result;


          var rDto=   _mapper.Map<List<DataExcelModelDto>>(response);

            return Ok(new DataResult<List<DataExcelModelDto>>(rDto,true));
           // return NotFound(new Result(false, AspectMessages.NotFoundResult));

        }


    }
}
