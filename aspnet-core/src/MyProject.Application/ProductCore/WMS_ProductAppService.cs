
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Linq.Extensions;

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Dtos;
using MyProject.ProductCore;
using MyProject.ProductCore.Dtos;
using MyProject.ProductCore.DomainService;

using MyProject.Authorization;
using MyProject.CommonCore;
using MyProject.CustomerCore.DomainService;
using Abp.Extensions;

namespace MyProject.ProductCore
{
    /// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
    [ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
    public class WMS_ProductAppService : MyProjectAppServiceBase, IWMS_ProductAppService
    {
        /// <summary>
        ///【WMS_Product】仓储层
        /// </summary>
        private readonly IRepository<WMS_Product, long> _wms_productRepository;

        /// <summary>
        ///【CustomerUserMapping】领域服务
        /// </summary>
        private readonly ICustomerUserMappingManager _customerusermappingManager;

        /// <summary>
        ///【WMS_Product】领域服务
        /// </summary>
        private readonly IWMS_ProductManager _wms_productManager;

        public WMS_ProductAppService(
            IRepository<WMS_Product, long> wms_productRepository,
            IWMS_ProductManager wms_productManager,
            ICustomerUserMappingManager customerusermappingManager
        )
        {
            _wms_productRepository = wms_productRepository;
            _wms_productManager = wms_productManager;
            _customerusermappingManager = customerusermappingManager;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        ///【WMS_Product】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ProductPermissions.Node)]
        [HttpPost]
        public async Task<PagedResultDto<WMS_ProductListDto>> GetPaged(GetWMS_ProductsInput input)
        {

            var query = _wms_productRepository.GetAll()
                          //模糊搜索 字段CustomerName
                          .WhereIf(input.CustomerId > 0, a => a.CustomerId == input.CustomerId)
                          .WhereIf(!input.CustomerName.IsNullOrWhiteSpace(), a => a.CustomerName.Contains(input.CustomerName))
                          //模糊搜索 字段SKU
                          .WhereIf(!input.SKU.IsNullOrWhiteSpace(), a => a.SKU.Contains(input.SKU))
                          //模糊搜索 字段GoodsName
                          .WhereIf(!input.GoodsName.IsNullOrWhiteSpace(), a => a.GoodsName.Contains(input.GoodsName))
                          //模糊搜索 ProductStatus
                          .WhereIf(input.ProductStatus != 0, a => a.ProductStatus == (input.ProductStatus))
                          //模糊搜索 字段GoodsType
                          .WhereIf(!input.GoodsType.IsNullOrWhiteSpace(), a => a.GoodsType == (input.GoodsType))
                          //模糊搜索 字段SKUClassification
                          .WhereIf(!input.SKUClassification.IsNullOrWhiteSpace(), a => a.SKUClassification == (input.SKUClassification))
                          //模糊搜索 字段SKULevel
                          .WhereIf(!input.SKULevel.IsNullOrWhiteSpace(), a => a.SKULevel == (input.SKULevel))
                          //模糊搜索 字段SKUGroup
                          .WhereIf(!input.SKUGroup.IsNullOrWhiteSpace(), a => a.SKUGroup == (input.SKUGroup))
                          //模糊搜索 字段ManufacturerSKU
                          .WhereIf(!input.ManufacturerSKU.IsNullOrWhiteSpace(), a => a.ManufacturerSKU == (input.ManufacturerSKU))
                          //模糊搜索 字段RetailSKU
                          .WhereIf(!input.RetailSKU.IsNullOrWhiteSpace(), a => a.RetailSKU == (input.RetailSKU))
                          //模糊搜索 字段ReplaceSKU
                          .WhereIf(!input.ReplaceSKU.IsNullOrWhiteSpace(), a => a.ReplaceSKU == (input.ReplaceSKU))
                          //模糊搜索 字段BoxGroup
                          .WhereIf(!input.BoxGroup.IsNullOrWhiteSpace(), a => a.BoxGroup == (input.BoxGroup))
                          //模糊搜索 字段Country
                          .WhereIf(!input.Country.IsNullOrWhiteSpace(), a => a.Country.Contains(input.Country))
                          //模糊搜索 字段Manufacturer
                          .WhereIf(!input.Manufacturer.IsNullOrWhiteSpace(), a => a.Manufacturer.Contains(input.Manufacturer))
                          //模糊搜索 字段DangerCode
                          .WhereIf(!input.DangerCode.IsNullOrWhiteSpace(), a => a.DangerCode == (input.DangerCode))
                          //模糊搜索 字段Color
                          .WhereIf(!input.Color.IsNullOrWhiteSpace(), a => a.Color == (input.Color))
                          //模糊搜索 字段Remark
                          .WhereIf(!input.Remark.IsNullOrWhiteSpace(), a => a.Remark.Contains(input.Remark))
                          //模糊搜索 字段Creator
                          .WhereIf(!input.Creator.IsNullOrWhiteSpace(), a => a.Creator.Contains(input.Creator))

                          .WhereIf(input.CreationTime != null && input.CreationTime.Length > 0, a => a.CreationTime >= (input.CreationTime[0]))

                          .WhereIf(input.CreationTime != null && input.CreationTime.Length > 1, a => a.CreationTime <= (input.CreationTime[1]))
                        //模糊搜索 字段Str1
                        //.WhereIf(!input.Str1.IsNullOrWhiteSpace(), a => a.Str1 == (input.Str1))
                        ////模糊搜索 字段Str2										 
                        //.WhereIf(!input.Str2.IsNullOrWhiteSpace(), a => a.Str2 == (input.Str2))
                        ////模糊搜索 字段Str3										 
                        //.WhereIf(!input.Str3.IsNullOrWhiteSpace(), a => a.Str3 == (input.Str3))
                        ////模糊搜索 字段Str4										 
                        //.WhereIf(!input.Str4.IsNullOrWhiteSpace(), a => a.Str4 == (input.Str4))
                        ////模糊搜索 字段Str5									 
                        //.WhereIf(!input.Str5.IsNullOrWhiteSpace(), a => a.Str5 == (input.Str5))
                        ////模糊搜索 字段Str6									 
                        //.WhereIf(!input.Str6.IsNullOrWhiteSpace(), a => a.Str6 == (input.Str6))
                        ////模糊搜索 字段Str7									 
                        //.WhereIf(!input.Str7.IsNullOrWhiteSpace(), a => a.Str7 == (input.Str7))
                        ////模糊搜索 字段Str8									 
                        //.WhereIf(!input.Str8.IsNullOrWhiteSpace(), a => a.Str8 == (input.Str8))
                        ////模糊搜索 字段Str9										 
                        //.WhereIf(!input.Str9.IsNullOrWhiteSpace(), a => a.Str9 == (input.Str9))
                        ////模糊搜索 字段Str10
                        //.WhereIf(!input.Str10.IsNullOrWhiteSpace(), a => a.Str10 == (input.Str10))
                        ////模糊搜索 字段Str11
                        //.WhereIf(!input.Str11.IsNullOrWhiteSpace(), a => a.Str11 == (input.Str11))
                        ////模糊搜索 字段Str12
                        //.WhereIf(!input.Str12.IsNullOrWhiteSpace(), a => a.Str12 == (input.Str12))
                        ////模糊搜索 字段Str13
                        //.WhereIf(!input.Str13.IsNullOrWhiteSpace(), a => a.Str13 == (input.Str13))
                        ////模糊搜索 字段Str14										 
                        //.WhereIf(!input.Str14.IsNullOrWhiteSpace(), a => a.Str14 == (input.Str14))
                        ////模糊搜索 字段Str15										 
                        //.WhereIf(!input.Str15.IsNullOrWhiteSpace(), a => a.Str15 == (input.Str15))
                        ////模糊搜索 字段Str16										 
                        //.WhereIf(!input.Str16.IsNullOrWhiteSpace(), a => a.Str16 == (input.Str16))
                        ////模糊搜索 字段Str17										 
                        //.WhereIf(!input.Str17.IsNullOrWhiteSpace(), a => a.Str17 == (input.Str17))
                        ////模糊搜索 字段Str18										 
                        //.WhereIf(!input.Str18.IsNullOrWhiteSpace(), a => a.Str18 == (input.Str18))
                        ////模糊搜索 字段Str19										 
                        //.WhereIf(!input.Str19.IsNullOrWhiteSpace(), a => a.Str19 == (input.Str19))
                        ////模糊搜索 字段Str20										 
                        //.WhereIf(!input.Str20.IsNullOrWhiteSpace(), a => a.Str20 == (input.Str20))
                        ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderByDescending(a => a.Id).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            var entityListDtos = ObjectMapper.Map<List<WMS_ProductListDto>>(entityList);

            return new PagedResultDto<WMS_ProductListDto>(count, entityListDtos);

        }

        /// <summary>
        ///【WMS_Product】通过指定id获取MemberListDto信息
        /// </summary>
        //[AbpAuthorize(WMS_ProductPermissions.Node)]
        [HttpGet]
        public async Task<WMS_ProductListDto> GetById(EntityDto<long> input)
        {
            var entity = await _wms_productRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<WMS_ProductListDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_Product】 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ProductPermissions.Node)]
        [HttpGet]
        public async Task<GetWMS_ProductForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_ProductForEditOutput();
            WMS_ProductEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _wms_productRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<WMS_ProductEditDto>(entity);
            }
            else
            {
                editDto = new WMS_ProductEditDto();
            }
            output.WMS_Product = editDto;
            return output;
        }
        /// <summary>
        ///【WMS_Product】 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ProductPermissions.Node)]
        [HttpPost]
        public async Task CreateOrUpdate(CreateOrUpdateWMS_ProductInput input)
        {

            if (input.WMS_Product.Id.HasValue)
            {
                await Update(input.WMS_Product);
            }
            else
            {
                await Create(input.WMS_Product);
            }
        }
        /// <summary>
        ///【WMS_Product】新增
        /// </summary>
        //[AbpAuthorize(WMS_ProductPermissions.Node)]
        protected virtual async Task<WMS_ProductEditDto> Create(WMS_ProductEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_Product>(input);
            //调用领域服务
            entity = await _wms_productManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WMS_ProductEditDto>(entity);
            return dto;


        }

        /// <summary>
        ///【WMS_Product】编辑
        /// </summary>
        //[AbpAuthorize(WMS_ProductPermissions.Node)]
        protected virtual async Task Update(WMS_ProductEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var key = input.Id.Value;
            var entity = await _wms_productRepository.GetAsync(key);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_productManager.UpdateAsync(entity);
        }

        /// <summary>
        ///【WMS_Product】删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ProductPermissions.Node)]
        [HttpGet]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_productManager.DeleteAsync(input.Id);
        }

        /// <summary>
        ///【WMS_Product】 批量删除Member的方法
        /// </summary>
        //[AbpAuthorize(WMS_ProductPermissions.Node)]
        [HttpPost]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_productManager.BatchDelete(input);
        }

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展应用服务实现*/

        /// <summary>
        /// 客户下拉列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<List<SelectListItem>> GetProductSelect(SelectListItemInput input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            try
            {

                var query = _wms_productRepository.GetAll()
                                //添加查询限制（默认必有的查询条件）
                              .Where(a => _customerusermappingManager.Query().Where(b => b.UserId == AbpSession.UserId).Select(c => c.CustomerId).Contains(a.CustomerId))
                              //模糊搜索 字段CustomerName
                              .WhereIf(input.CustomerId > 0, a => a.CustomerId == input.CustomerId)
                              .WhereIf(!input.Input.IsNullOrEmpty(), a => a.SKU.Contains(input.Input))
                              .Take(5)
                ;
                // TODO:根据传入的参数添加过滤条件

                //var count = await query.CountAsync();

                var entityList = await query
                        .OrderBy(a => a.Id).AsNoTracking()
                        .Select(a => new SelectListItem { Label = a.SKU, Value = a.GoodsName.ToString() })
                        .ToListAsync();

                //var entityListDtos = ObjectMapper.Map<List<WMS_WarehouseListDto>>(entityList);
                return entityList;

            }
            catch (Exception sas)
            {

                throw;
            }
        }
        #endregion
    }
}


