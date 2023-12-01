using System.Collections;

namespace SacraLingua.Vocalbulary.Domain.Entities
{
    public class PagedResult<T> : IEnumerable<T>, IEnumerable
    {
        public IReadOnlyList<T> Items { get; }
        public int TotalItems { get; }
        public int PageSize { get; }
        public int Page { get; }
        public int NumberOfPages => GetNumberOfPages();
        public int Count => Items.Count;
        public T this[int index] => Items[index];

        public PagedResult(IReadOnlyList<T> items, int totalItems, int pageSize, int page)
        {
            Items = items;
            TotalItems = totalItems;
            PageSize = pageSize;
            Page = page;
        }

        private int GetNumberOfPages()
        {
            int number = TotalItems / PageSize;
            if(number * PageSize >= TotalItems)
            {
                return number;
            }

            return number + 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
