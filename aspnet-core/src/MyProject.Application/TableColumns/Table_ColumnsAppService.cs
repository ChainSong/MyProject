
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
	/// <see cref="Table_Columns" />
    ///</summary>

    [AbpAuthorize]
    public class Table_ColumnsAppService : MyProjectAppServiceBase, ITable_ColumnsAppService
    {

        private readonly IRepository<Table_Columns, long>
          _table_ColumnsRepository;

        private readonly IRepository<Table_ColumnsDetail, long> _table_ColumnsDetailRepository;

        //private readonly ITable_ColumnsListExcelExporter _table_ColumnsListExcelExporter;
        private readonly ICacheManager _cacheManage;

        private readonly ITable_ColumnsManager _table_ColumnsManager;
        /// <summary>
        /// 构造函数
        /// </summary>
        public Table_ColumnsAppService(
               IRepository<Table_Columns, long> table_ColumnsRepository,
               ITable_ColumnsManager table_ColumnsManager,
               ICacheManager cacheManage,
               IRepository<Table_ColumnsDetail, long> table_ColumnsDetailRepository
            )
        {
            _table_ColumnsRepository = table_ColumnsRepository;
            _table_ColumnsManager = table_ColumnsManager;
            _cacheManage = cacheManage;
            _table_ColumnsDetailRepository = table_ColumnsDetailRepository;

            //_table_ColumnsListExcelExporter = table_ColumnsListExcelExporter;

        }


        /// <summary>
        /// 获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        //[AbpAuthorize(Table_ColumnsPermissions.Table_Columns_Query)]
        public async Task<PagedResultDto<Table_ColumnsListDto>> GetPaged(GetTable_ColumnssInput input)
        {
            try
            {

                var query = _table_ColumnsRepository.GetAll()
                .WhereIf(!input.RoleName.IsNullOrWhiteSpace(), a =>
                              //模糊搜索RoleName
                              a.RoleName.Contains(input.RoleName))
                .WhereIf(!input.TableName.IsNullOrWhiteSpace(), a =>

                              //模糊搜索TableName
                              a.TableName.Contains(input.TableName))
                .WhereIf(input.TenantId != 0, a =>
                                //模糊搜索TenantId
                                a.TenantId == (input.TenantId))
                 .WhereIf(input.CustomerId != 0, a =>
                                //模糊搜索CustomerId
                                a.CustomerId == (input.CustomerId))
                .WhereIf(!input.RoleName.IsNullOrWhiteSpace(), a =>
                              //模糊搜索RoleName
                              a.RoleName.Contains(input.RoleName)
                ).Select(a => new Table_Columns { CustomerId = a.CustomerId, RoleName = a.RoleName, TableName = a.TableName, TableNameCH = a.TableNameCH }).Distinct();
                // TODO:根据传入的参数添加过滤条件

                var count = query.Count();

                var table_ColumnsList = await query
                //.OrderBy(input.Sorting).AsNoTracking()
                   .OrderByDescending(t => t.TableName).AsNoTracking()
                .PageBy(input)
                .ToListAsync();


                var table_ColumnsListDtos = ObjectMapper.Map<List<Table_ColumnsListDto>>(table_ColumnsList);

                return new PagedResultDto<Table_ColumnsListDto>(count, table_ColumnsListDtos);

            }
            catch (Exception ex)
            {

            }
            return new PagedResultDto<Table_ColumnsListDto>();
        }

        /// <summary>
        /// 获取的不分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        //[AbpAuthorize(Table_ColumnsPermissions.Table_Columns_Query)]
        public async Task<PagedResultDto<Table_ColumnsListDto>> GetAll(GetTable_ColumnssInput input)
        {
            try
            {

                var query = _table_ColumnsRepository.GetAll()
                .WhereIf(!input.RoleName.IsNullOrWhiteSpace(), a =>
                              //模糊搜索RoleName
                              a.RoleName.Contains(input.RoleName))
                .WhereIf(!input.TableName.IsNullOrWhiteSpace(), a =>

                              //模糊搜索TableName
                              a.TableName.Contains(input.TableName))
                .WhereIf(input.TenantId != 0, a =>
                                //模糊搜索TenantId
                                a.TenantId == (input.TenantId))
                 .WhereIf(input.CustomerId != 0, a =>
                                //模糊搜索CustomerId
                                a.CustomerId == (input.CustomerId))
                .WhereIf(!input.RoleName.IsNullOrWhiteSpace(), a =>
                              //模糊搜索RoleName
                              a.RoleName.Contains(input.RoleName)
                );
                // TODO:根据传入的参数添加过滤条件

                var count = await query.CountAsync();

                var table_ColumnsList = await query
                .OrderByDescending(t => t.Id).AsNoTracking()
                .OrderBy(a => a.Order).AsNoTracking()
                //.PageBy(input)
                .ToListAsync();

                var table_ColumnsListDtos = ObjectMapper.Map<List<Table_ColumnsListDto>>(table_ColumnsList);

                return new PagedResultDto<Table_ColumnsListDto>(count, table_ColumnsListDtos);

            }
            catch (Exception ex)
            {

            }
            return new PagedResultDto<Table_ColumnsListDto>();
        }


        /// <summary>
        /// 通过指定id获取Table_ColumnsListDto信息
        /// </summary>
        [AbpAuthorize(Table_ColumnsPermissions.Table_Columns_Query)]
        public async Task<Table_ColumnsListDto> GetById(EntityDto<long> input)
        {
            var entity = await _table_ColumnsRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<Table_ColumnsListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(Table_ColumnsPermissions.Table_Columns_Create, Table_ColumnsPermissions.Table_Columns_Edit)]
        public async Task<GetTable_ColumnsForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetTable_ColumnsForEditOutput();
            Table_ColumnsEditDto editDto;

            if (input.Id.HasValue)
            {


                var entity = await _table_ColumnsRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<Table_ColumnsEditDto>(entity);
            }
            else
            {
                editDto = new Table_ColumnsEditDto();
            }



            output.Table_Columns = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(Table_ColumnsPermissions.Table_Columns_Create, Table_ColumnsPermissions.Table_Columns_Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateTable_ColumnsInput input)
        {

            if (input.Table_Columns.Id.HasValue)
            {
                await Update(input.Table_Columns);
            }
            else
            {
                await Create(input.Table_Columns);
            }
            await GetTables(new GetTable_ColumnssInput { TableName = input.Table_Columns.TableName });
        }


        /// <summary>
        /// 新增
        /// </summary>
        [AbpAuthorize(Table_ColumnsPermissions.Table_Columns_Create)]
        protected virtual async Task<Table_ColumnsEditDto> Create(Table_ColumnsEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<Table_Columns>(input);
            //调用领域服务
            entity = await _table_ColumnsManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<Table_ColumnsEditDto>(entity);
            return dto;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        [AbpAuthorize(Table_ColumnsPermissions.Table_Columns_Edit)]
        protected virtual async Task Update(Table_ColumnsEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _table_ColumnsRepository.GetAsync(input.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _table_ColumnsManager.UpdateAsync(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary> 
        //[AbpAuthorize(Table_ColumnsPermissions.Table_Columns_Edit)]
        [HttpPost]
        public async Task BatchUpdate(GetTable_ColumnsForEditOutput table_Columns)
        {
            //try
            //{


            //List<Table_Columns> Table_Columns = new List<Table_Columns>();
            foreach (var item in table_Columns.Table_Columnss)
            {
                //TODO:更新前的逻辑判断，是否允许更新
                var entity = await _table_ColumnsRepository.GetAsync(item.Id.Value);
                entity.Table_ColumnsDetails = new List<Table_ColumnsDetail>();
                //item.tal = new List<Table_ColumnsDetail>();
                //item.MapTo(entity);
                //将input属性的值赋值到entity中
                ObjectMapper.Map(item, entity);
                //Mapper(ObjectMapper);
                await _table_ColumnsManager.UpdateAsync(entity);
                await GetTables(new GetTable_ColumnssInput { TableName = table_Columns.Table_Columnss.FirstOrDefault().TableName });

            }
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}

        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(Table_ColumnsPermissions.Table_Columns_Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _table_ColumnsManager.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除Table_Columns的方法
        /// </summary>
        [AbpAuthorize(Table_ColumnsPermissions.Table_Columns_BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _table_ColumnsManager.BatchDelete(input);
        }




        //// custom codes







        /// <summary>
        /// 通过指定表名获取Table_ColumnsListDto信息
        /// </summary>
        [HttpPost]
        public async Task<PagedResultDto<Table_ColumnsListDto>> GetByTableNameList(GetTable_ColumnssInput input)
        {
            //try
            //{

            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            int count = 0;
            input.Sorting = "Order";
            input.TenantId = AbpSession.TenantId ?? 0;
            //var table_ColumnsList = _cacheManage.GetCache("TableColumn").Get("TableColumn_" + input.TableName + "_" + AbpSession.RoleName + "", (val) =>
            //  {
            //      return val;
            //  }) as List<Table_Columns>;

            var table_ColumnsList = _cacheManage.GetCache("TableColumn").Get("TableColumn_" + input.TableName + "_" + input.TenantId + "", (val) =>
           {
               return val;
           }) as List<Table_Columns>;

            if (table_ColumnsList != null && table_ColumnsList.Count() > 0)
            {
                //count = table_ColumnsList.Count();
            }
            else
            {
                table_ColumnsList = GetTables(input).Result;

            }
            count = table_ColumnsList.Count();
            //Table_ColumnsRowListDto table_Rows = new Table_ColumnsRowListDto() { Table_Columns = new List<Table_Columns>() };
            //if (input.TableFormat == "line")
            //{
            //    for (int i = 0; i < Math.Ceiling(table_ColumnsList.Count / 4.0); i++)
            //    {
            //        var Table_ColumnsRowListDto = table_ColumnsList.Skip(i * 4).Take(4);
            //        table_Rows.Table_Columns.AddRange(Table_ColumnsRowListDto.ToList());
            //    }
            //}
            //else
            //{
            //    table_Rows.Table_Columns = table_ColumnsList;
            //}
            //var table_ColumnsListDtos = ObjectMapper.Map<List<Table_ColumnsRowListDto>>(table_ColumnsList);
            //return table_Rows;

            var customerInfoListDtos = ObjectMapper.Map<List<Table_ColumnsListDto>>(table_ColumnsList);
            //var aaaa = new PagedResultDto<Table_ColumnsListDto>(count, customerInfoListDtos);
            return new PagedResultDto<Table_ColumnsListDto>(count, customerInfoListDtos);

        }

        private async Task<List<Table_Columns>> GetTables(GetTable_ColumnssInput input)
        {
            //try
            //{

            int count = 0;
            input.Sorting = "Order";
            //input.TenantId = AbpSession.TenantId.Value;

            var query = _table_ColumnsRepository.GetAll().AsNoTracking()
            //模糊搜索TableName
            .WhereIf(!input.TableName.IsNullOrWhiteSpace(), a => a.TableName == input.TableName)
            .WhereIf(!input.RoleName.IsNullOrWhiteSpace(), a => a.RoleName == input.RoleName)
            .WhereIf(1 == 1, a => a.TenantId == input.TenantId)
            .Select(a => new Table_Columns
            {
                Id = a.Id
              //,TenantId = a.TenantId
              ,
                ProjectId = a.ProjectId
              ,
                RoleName = a.RoleName
              ,
                CustomerId = a.CustomerId
              ,
                TableName = a.TableName
              ,
                TableNameCH = a.TableNameCH
              ,
                DisplayName = a.DisplayName
              ,
                    //由于框架约定大于配置， 数据库的字段首字母小写
                DbColumnName = a.DbColumnName.Substring(0, 1).ToLower() + a.DbColumnName.Substring(1)
              ,
                IsKey = a.IsKey
              ,
                IsSearchCondition = a.IsSearchCondition
              ,
                IsHide = a.IsHide
              ,
                IsReadOnly = a.IsReadOnly
              ,
                IsShowInList = a.IsShowInList
              ,
                IsImportColumn = a.IsImportColumn
              ,
                IsDropDownList = a.IsDropDownList
              ,
                Associated = a.Associated
              ,
                Table_ColumnsDetails = _table_ColumnsDetailRepository.GetAll().Where(b => b.Associated == a.Associated)
              .Select(b =>
                new Table_ColumnsDetail
                {
                    Id = b.Id,
                    CodeInt = b.CodeInt,
                    CodeStr = b.CodeStr,
                    Name = b.Name,
                    Type = b.Type,
                    Associated = b.Associated,
                    Status = b.Status,
                    Creator = b.Creator,
                    CreationTime = b.CreationTime
                }
              ).ToList()
              ,
                IsCreate = a.IsCreate
              ,
                IsUpdate = a.IsUpdate
              ,
                SearchConditionOrder = a.SearchConditionOrder
              ,
                Validation = a.Validation
              ,
                Group = a.Group
              ,
                Type = a.Type
              ,
                Order = a.Order
              ,
                ForView = a.ForView
            })
            ;
            // var query = _table_ColumnsDetailRepository.GetAll().AsNoTracking()
            ////模糊搜索TableName
            //.WhereIf(!input.TableName.IsNullOrWhiteSpace(), a => a.TableName == input.TableName)
            //.WhereIf(!input.RoleName.IsNullOrWhiteSpace(), a => a.RoleName == input.RoleName)
            //.Include(a => a.IsDropDownList)
            //;
            count = await query.CountAsync();
            var table_ColumnsList = await query
             .OrderBy(input.Sorting).AsNoTracking()
             //.PageBy(input)
             .ToListAsync();
            _cacheManage.GetCache("TableColumn").Set("TableColumn_" + input.TableName + "_" + input.TenantId, table_ColumnsList);
            return table_ColumnsList;
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}

        }


        /// <summary>
        /// 删除自定义表缓存的方法
        /// </summary>

        public void CleanTableColumnsCache(GetTable_ColumnssInput input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            _cacheManage.GetCache("TableColumn").Set("TableColumn_" + input.TableName + "_" + input.TenantId, null);
        }

        //// custom codes end

    }
}


