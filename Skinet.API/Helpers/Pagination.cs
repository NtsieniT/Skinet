using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.API.Helpers
{
    // Used for any classes to pass pagination information 
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            this.pageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }

        public int pageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; } // count items after filters have been applied
        public IReadOnlyList<T> Data { get; set; }


    }
}
