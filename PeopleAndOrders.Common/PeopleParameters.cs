using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Common
{
    public class PeopleParameters
    {
        public int PageNumber { get; set; } = 1;
        const int maxPageSize = 4;
        private int _pageSize = 3;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
