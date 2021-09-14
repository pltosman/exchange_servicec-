using System;
using System.Collections.Generic;
using AutoMapper;
using CI.interview.pltosman.Business.Abstract;
using CI.interview.pltosman.DataAccess.Abstract;
using CI.interview.pltosman.Entities.Concrete;
using Microsoft.Extensions.Logging;

namespace CI.interview.pltosman.Business.Concrete
{
    public class MergeManager : IMergeService
    {
        private readonly IMergeDal _mergeDal;

        private readonly ILogger<MergeManager> _logger;

        private readonly IMapper _mapper; 


        public MergeManager(IMergeDal mergeDal, ILogger<MergeManager> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _mergeDal = mergeDal;
        }


        public void Merge(List<ExcelData> data, List<Rate> rates)
        {


            //TODO:




        }
    }
}
