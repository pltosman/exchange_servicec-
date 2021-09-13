using System;
using System.Collections.Generic;
using CI.interview.pltosman.Entities.Concrete;

namespace CI.interview.pltosman.Business.Abstract
{
    public interface IMergeService
    {
        void Merge(List<ExcelData> data, List<FixerRate> rates);
    }
}
