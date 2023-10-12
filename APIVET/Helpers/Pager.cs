using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIVET.Helpers
{
    public class Pager<T> where T : class
    {
        public string Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling(Total/(double)PageSize);}
            set { this.TotalPages = value;}
        }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 1);}
            set { this.HasPreviousPage = value;}
        }

        public bool HasNexPage
        {
            get { return (PageIndex < TotalPages);}
            set { this.HasNexPage = value;}
        }

        public Pager()
        {
        }
        
        public List<T> Registros { get; private set; }

        public Pager(List<T> registros, int total, int pageIndex, int pageSize, string search)
        {
            Registros = registros;
            Total = total;
            PageIndex = pageIndex;
            PageSize = pageSize;
            Search = search;
        }

        

    }
}