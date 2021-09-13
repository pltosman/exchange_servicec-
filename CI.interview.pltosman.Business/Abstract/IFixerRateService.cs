using System;
using System.Collections.Generic;
using CI.interview.pltosman.Core.Entities.Concrete;
using CI.interview.pltosman.Core.Utilities.Results;
using CI.interview.pltosman.Entities.Concrete;

namespace CI.interview.pltosman.Business.Abstract
{
    public interface IFixerRateService
    {
        void SaveFixerResult(FixerDetailResponse data);
        List<FixerRate> GetList();
    }
}
