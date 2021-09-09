using System;
using CI.interview.pltosman.Core.Entities.Concrete;
using CI.interview.pltosman.Core.Utilities.Results;

namespace CI.interview.pltosman.Business.Abstract
{
    public interface IFixerRateService
    {
        void SaveFixerResult(FixerDetailResponse data);

    }
}
