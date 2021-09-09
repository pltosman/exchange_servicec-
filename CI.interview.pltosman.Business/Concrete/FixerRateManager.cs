using System;
using AutoMapper;
using CI.interview.pltosman.Business.Abstract;
using CI.interview.pltosman.Core.Entities.Concrete;
using CI.interview.pltosman.Core.Utilities.Results;
using CI.interview.pltosman.DataAccess.Abstract;
using CI.interview.pltosman.Entities.Concrete;
using Microsoft.Extensions.Logging;

namespace CI.interview.pltosman.Business.Concrete
{
    public class FixerRateManager : IFixerRateService
    {

        private readonly ILogger<FixerRateManager> _logger;
        private readonly IFixerRateDal _fixerRateDal;
        private readonly IMapper _mapper;

        public FixerRateManager(IFixerRateDal fixerRateDal, ILogger<FixerRateManager> logger, IMapper mapper)
        {
            _logger = logger;
            _fixerRateDal = fixerRateDal;
            _mapper = mapper;
        }


        public void SaveFixerResult(FixerDetailResponse data)
        {
            try
            {
                var model = _mapper.Map<FixerRate>(data);
                _fixerRateDal.Add(model);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
