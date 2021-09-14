using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CI.interview.pltosman.Core.Entities.Concrete;
using CI.interview.pltosman.Core.Utilities.Results;
using CI.interview.pltosman.Entities.Concrete;
using CI.interview.pltosman.Entities.ResponseModel;

namespace CI.interview.pltosman.Business.Abstract
{
    public interface IFixerDetailService
    {
        Task<IDataResult<List<Rate>>> GetFixerDetail(string sdate, string edate, string currency);
    }
}
