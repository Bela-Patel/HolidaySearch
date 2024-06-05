using HolidaySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Services
{
    public interface ISearchService
    {
        public Result Search(SearchVM search);
    }
}
