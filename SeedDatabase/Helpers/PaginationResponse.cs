using System.Collections.Generic;
using System.Linq;

namespace SeedDatabase.Helpers
{
    public class PaginationResponse<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
        public PaginationResponse(IEnumerable<T> data, int index, int length)
        {
            Data = data.Skip((index - 1) * length).Take(length).ToList();
            Total = data.Count();
        }
    }
}