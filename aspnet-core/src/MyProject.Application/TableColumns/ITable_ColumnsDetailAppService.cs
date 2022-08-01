
using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
//using L._52ABP.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.TableColumns.Dtos;
using MyProject.TableColumns;



namespace MyProject.TableColumns
{
    /// <summary>
    /// 应用层服务的接口方法
    ///</summary>
    public interface ITable_ColumnsDetailAppService : IApplicationService
    {
        /// <summary>
		/// 获取的分页列表集合
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<Table_ColumnsDetailListDto>> GetPaged(GetTable_ColumnsDetailsInput input);


		/// <summary>
		/// 通过指定id获取ListDto信息
		/// </summary>
		Task<Table_ColumnsDetailListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetTable_ColumnsDetailForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateTable_ColumnsDetailInput input);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);

		
        /// <summary>
        /// 批量删除
        /// </summary>
        Task BatchDelete(List<long> input);


		
							//// custom codes
									
							

							//// custom codes end
    }
}
