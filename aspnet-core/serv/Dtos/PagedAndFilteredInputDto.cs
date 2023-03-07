
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using MyProject;
namespace  serv.Dtos
{
    public class PagedAndFilteredInputDto : IPagedResultRequest
    {
        /// <summary>
        /// 最大记录数默认为 1000
        /// </summary>
        [Range(1, AppLtmConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }
        /// <summary>
        /// 要筛选的文本
        /// </summary>
        public string FilterText { get; set; }

        public PagedAndFilteredInputDto()
        {
            MaxResultCount = AppLtmConsts.DefaultPageSize;
        }
    }
}