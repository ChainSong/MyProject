
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.Domain.Repositories;
//using L._52ABP.Application.Dtos;
//using L._52ABP.Common.Extensions.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using MyProject.TableColumns;
using MyProject.TableColumns.Dtos;
using MyProject.TableColumns.Exporting;
using MyProject.TableColumns.DomainService;
using MyProject.Authorization;
using Abp.Runtime.Caching;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.TableColumns
{
    /// <summary>
    /// 应用层服务的接口实现方法
	/// <see cref="Table_ColumnsDetail" />
    ///</summary>

    [AbpAuthorize]
    public class Table_ColumnsDetailAppService : MyProjectAppServiceBase, ITable_ColumnsDetailAppService
    {


        //private readonly IRepository<Table_Columns, long> _table_ColumnsRepository;

        private readonly IRepository<Table_ColumnsDetail, long> _table_ColumnsDetailRepository;

        //private readonly ITable_ColumnsListExcelExporter _table_ColumnsListExcelExporter;
        private readonly ICacheManager _cacheManage;

        //private readonly ITable_ColumnsManager _table_ColumnsManager;
        private readonly ITable_ColumnsDetailManager _table_ColumnsDetailManager;
        /// <summary>
        /// 构造函数
        /// </summary>
        public Table_ColumnsDetailAppService(
               //IRepository<Table_Columns, long> table_ColumnsRepository,
               ITable_ColumnsDetailManager table_ColumnsDetailManager,
               ICacheManager cacheManage,
               IRepository<Table_ColumnsDetail, long> table_ColumnsDetailRepository
            )
        {
            //_table_ColumnsRepository = table_ColumnsRepository;
            _table_ColumnsDetailManager = table_ColumnsDetailManager;
            _cacheManage = cacheManage;
            _table_ColumnsDetailRepository = table_ColumnsDetailRepository;

            //_table_ColumnsListExcelExporter = table_ColumnsListExcelExporter;

        }

        //private readonly ITable_ColumnsDetailManager _table_ColumnsDetailManager;


        ///// <summary>
        ///// 构造函数
        /////</summary>

        //public Table_ColumnsDetailAppService(ITable_ColumnsDetailManager table_ColumnsDetailManager

        //    )
        //{
        //    _table_ColumnsDetailManager = table_ColumnsDetailManager;


        //}


        /// <summary>
        /// 获取的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<PagedResultDto<Table_ColumnsDetailListDto>> GetPaged(GetTable_ColumnsDetailsInput input)
        {

            var query = _table_ColumnsDetailRepository.GetAll().WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Code
                          a.CodeStr.Contains(input.FilterText)

            );
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var table_ColumnsDetailList = await query
            .OrderBy(input.Sorting).AsNoTracking()
            .PageBy(input)
            .ToListAsync();

            var table_ColumnsDetailListDtos = ObjectMapper.Map<List<Table_ColumnsDetailListDto>>(table_ColumnsDetailList);

            return new PagedResultDto<Table_ColumnsDetailListDto>(count, table_ColumnsDetailListDtos);
        }


        /// <summary>
        /// 获取的不分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        //[AbpAuthorize(Table_ColumnsPermissions.Table_Columns_Query)]
        public async Task<PagedResultDto<Table_ColumnsDetailListDto>> GetAll(GetTable_ColumnsDetailsInput input)
        {
            try
            {

                var query = _table_ColumnsDetailRepository.GetAll()
                .WhereIf(!input.Associated.IsNullOrWhiteSpace(), a =>
                              //模糊搜索RoleName
                              a.Associated == (input.Associated)
                );
                // TODO:根据传入的参数添加过滤条件
                var count = await query.CountAsync();
                var table_ColumnsDetailList = await query
                //.OrderByDescending(t => t.Id).AsNoTracking()
                .ToListAsync();
                var table_ColumnsDetailListDtos = ObjectMapper.Map<List<Table_ColumnsDetailListDto>>(table_ColumnsDetailList);
                return new PagedResultDto<Table_ColumnsDetailListDto>(count, table_ColumnsDetailListDtos);
            }
            catch (Exception ed)
            {
                throw;
            }
        }


        /// <summary>
        /// 通过指定id获取Table_ColumnsDetailListDto信息
        /// </summary>

        public async Task<Table_ColumnsDetailListDto> GetById(EntityDto<long> input)
        {
            var entity = await _table_ColumnsDetailRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<Table_ColumnsDetailListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<GetTable_ColumnsDetailForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetTable_ColumnsDetailForEditOutput();
            Table_ColumnsDetailEditDto editDto;

            if (input.Id.HasValue)
            {


                var entity = await _table_ColumnsDetailRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<Table_ColumnsDetailEditDto>(entity);
            }
            else
            {
                editDto = new Table_ColumnsDetailEditDto();
            }



            output.Table_ColumnsDetail = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task CreateOrUpdate(CreateOrUpdateTable_ColumnsDetailInput input)
        {

            if (input.Table_ColumnsDetail.Id.HasValue)
            {
                await Update(input.Table_ColumnsDetail);
            }
            else
            {
                await Create(input.Table_ColumnsDetail);
            }
        }


        /// <summary>
        /// 新增
        /// </summary>

        protected virtual async Task<Table_ColumnsDetailEditDto> Create(Table_ColumnsDetailEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<Table_ColumnsDetail>(input);
            //调用领域服务
            entity = await _table_ColumnsDetailManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<Table_ColumnsDetailEditDto>(entity);
            return dto;
        }

        /// <summary>
        /// 编辑
        /// </summary>

        protected virtual async Task Update(Table_ColumnsDetailEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _table_ColumnsDetailRepository.GetAsync(input.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _table_ColumnsDetailManager.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _table_ColumnsDetailManager.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除Table_ColumnsDetail的方法
        /// </summary>

        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _table_ColumnsDetailManager.BatchDelete(input);
        }




        //// custom codes



        //// custom codes end

    }
}






