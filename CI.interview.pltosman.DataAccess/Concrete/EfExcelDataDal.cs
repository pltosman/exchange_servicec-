using System;
using CI.interview.pltosman.Core.DataAccesss.EntityFramework;
using CI.interview.pltosman.DataAccess.Abstract;
using CI.interview.pltosman.DataAccess.Concrete.EntityFramework.Contexts;
using CI.interview.pltosman.Entities.Concrete;

namespace CI.interview.pltosman.DataAccess.Concrete
{
    public class EfExcelDataDal : EfEntityRepositoryBase<ExcelData, InterviewContext>, IExcelDataDal
    {
       
    }
}
