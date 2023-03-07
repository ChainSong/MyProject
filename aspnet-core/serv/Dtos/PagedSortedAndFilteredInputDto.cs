
using MyProject;

namespace serv.Dtos
{
    public class PagedSortedAndFilteredInputDto : PagedAndSortedInputDto
    {
        public string FilterText { get; set; }
    }
}