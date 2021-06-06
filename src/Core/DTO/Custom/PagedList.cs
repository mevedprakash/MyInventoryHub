
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DTO.CustomModel
{



    public class PagedList<T>
    {

        public List<T> Data { get; set; }
        public int TotalData { get; set; }
        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage => Page > 1;
        public bool HasNextPage => Page < TotalPages;

        public PagedList<T> Populate(IQueryable<T> source, int pageIndex, int pageSize)
        {

            TotalData = source.Count();
            PageSize = pageSize;
            Page = pageIndex;
            if (PageSize == 0)
            {
                PageSize = int.MaxValue;
            }
            TotalPages = TotalData / PageSize;        
            if (TotalData % PageSize > 0)
                TotalPages++;
            
            this.Data = source.Skip((Page - 1) * PageSize).Take(PageSize).ToList();
            return this;
        }

        public async Task<PagedList<T>> PopulateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            TotalData = source.Count();
            PageSize = pageSize;
            Page = pageIndex;
            if (PageSize == 0)
            {
                PageSize = int.MaxValue;
            }
            TotalPages = TotalData / PageSize;
            TotalPages++;          
            this.Data =source.Skip((Page - 1) * PageSize).Take(PageSize).ToList();
            return this;
        }
        public async Task<PagedList<T>> PopulateAsync(IQueryable<T> source)
        {
            TotalData = source.Count();
            PageSize = TotalData;           
            Page = 1;
            if (PageSize == 0)
            {
                PageSize = int.MaxValue;
            }
            TotalPages = TotalData / PageSize;
            TotalPages++;          
            this.Data = source.Skip((Page - 1) * PageSize).Take(PageSize).ToList();
            return this;
        }


        public PagedList<T> Populate(IList<T> source, int pageIndex, int pageSize)
        {
            TotalData = source.Count;
            PageSize = pageSize;
            Page = pageIndex;
            if (PageSize == 0)
            {
                PageSize = int.MaxValue;
            }
            TotalPages = TotalData / PageSize;
            if (TotalData % PageSize > 0)
                TotalPages++;
            Data = source.Skip((pageIndex-1) * pageSize).Take(pageSize).ToList();
            return this;
        }

       
        public PagedList<T> Populate(List<T> data)
        {
            
            TotalData = data.Count;
            TotalPages = 1;
            PageSize = TotalData;
            Page = 1;
            this.Data = data;
            return this;
        }


    }

}
