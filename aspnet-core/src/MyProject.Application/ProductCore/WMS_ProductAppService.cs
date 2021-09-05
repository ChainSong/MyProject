
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
using MyProject.ProductCore;
using MyProject.ProductCore.Dtos;
//using MyProject.ProductCore.Exporting;
using MyProject.ProductCore.DomainService;
using MyProject.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.ProductCore
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>
    [AbpAuthorize]
    public class WMS_ProductAppService : MyProjectAppServiceBase, IWMS_ProductAppService
    {
        private readonly IRepository<WMS_Product, long>
            _wMS_ProductRepository;



        private readonly IWMS_ProductManager _wMS_ProductManager;
        /// <summary>
        /// 构造函数
        ///</summary>
        public WMS_ProductAppService(
        IRepository<WMS_Product, long> wMS_ProductRepository
            , IWMS_ProductManager wMS_ProductManager

            )
        {
            _wMS_ProductRepository = wMS_ProductRepository;
            _wMS_ProductManager = wMS_ProductManager;


        }


        /// <summary>
        /// 获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [AbpAuthorize(WMS_ProductPermissions.WMS_Product_Query)]
        public async Task<PagedResultDto<WMS_ProductListDto>> GetPaged(GetWMS_ProductsInput input)
        {

            var query = _wMS_ProductRepository.GetAll()
            .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a =>


                          //模糊搜索CustomerName
                          a.CustomerName.Contains(input.FilterText) &




                          //模糊搜索WarehouseName
                          a.WarehouseName.Contains(input.FilterText) &




                          //模糊搜索SKU
                          a.SKU.Contains(input.FilterText) &




                          //模糊搜索GoodsName
                          a.GoodsName.Contains(input.FilterText) &




                          //模糊搜索GoodsType
                          a.GoodsType.Contains(input.FilterText) &




                          //模糊搜索SKUClassification
                          a.SKUClassification.Contains(input.FilterText) &




                          //模糊搜索SKUGroup
                          a.SKUGroup.Contains(input.FilterText) &




                          //模糊搜索ManufacturerSKU
                          a.ManufacturerSKU.Contains(input.FilterText) &




                          //模糊搜索RetailSKU
                          a.RetailSKU.Contains(input.FilterText) &




                          //模糊搜索ReplaceSKU
                          a.ReplaceSKU.Contains(input.FilterText) &




                          //模糊搜索BoxGroup
                          a.BoxGroup.Contains(input.FilterText) &




                          //模糊搜索Packing
                          a.Packing.Contains(input.FilterText) &




                          //模糊搜索Grade
                          a.Grade.Contains(input.FilterText) &




                          //模糊搜索Country
                          a.Country.Contains(input.FilterText) &




                          //模糊搜索Manufacturer
                          a.Manufacturer.Contains(input.FilterText) &




                          //模糊搜索DangerCode
                          a.DangerCode.Contains(input.FilterText) &




                          //模糊搜索Vvolume
                          a.Vvolume.Contains(input.FilterText) &




                          //模糊搜索StandardVolume
                          a.StandardVolume.Contains(input.FilterText) &




                          //模糊搜索Weight
                          a.Weight.Contains(input.FilterText) &




                          //模糊搜索StandardWeight
                          a.StandardWeight.Contains(input.FilterText) &




                          //模糊搜索NetWeight
                          a.NetWeight.Contains(input.FilterText) &




                          //模糊搜索StandardNetWeight
                          a.StandardNetWeight.Contains(input.FilterText) &




                          //模糊搜索Price
                          a.Price.Contains(input.FilterText) &




                          //模糊搜索Cost
                          a.Cost.Contains(input.FilterText) &




                          //模糊搜索ActualCost
                          a.ActualCost.Contains(input.FilterText) &




                          //模糊搜索StandardOrderingCost
                          a.StandardOrderingCost.Contains(input.FilterText) &




                          //模糊搜索ShipmentCost
                          a.ShipmentCost.Contains(input.FilterText) &




                          //模糊搜索QcInSpectionLoc
                          a.QcInSpectionLoc.Contains(input.FilterText) &




                          //模糊搜索QcPercentage
                          a.QcPercentage.Contains(input.FilterText) &




                          //模糊搜索ReceiptQcUom
                          a.ReceiptQcUom.Contains(input.FilterText) &




                          //模糊搜索QcEligible
                          a.QcEligible.Contains(input.FilterText) &




                          //模糊搜索PutArea
                          a.PutArea.Contains(input.FilterText) &




                          //模糊搜索PutCode
                          a.PutCode.Contains(input.FilterText) &




                          //模糊搜索PutRule
                          a.PutRule.Contains(input.FilterText) &




                          //模糊搜索PutStrategy
                          a.PutStrategy.Contains(input.FilterText) &




                          //模糊搜索AllocateRule
                          a.AllocateRule.Contains(input.FilterText) &




                          //模糊搜索PickedCode
                          a.PickedCode.Contains(input.FilterText) &




                          //模糊搜索SKUType
                          a.SKUType.Contains(input.FilterText) &




                          //模糊搜索Color
                          a.Color.Contains(input.FilterText) &




                          //模糊搜索Size_L
                          a.Size_L.Contains(input.FilterText) &




                          //模糊搜索Size_W
                          a.Size_W.Contains(input.FilterText) &




                          //模糊搜索Size_H
                          a.Size_H.Contains(input.FilterText) &




                          //模糊搜索Remark
                          a.Remark.Contains(input.FilterText) &




                          //模糊搜索Creator
                          a.Creator.Contains(input.FilterText) &




                          //模糊搜索Str1
                          a.Str1.Contains(input.FilterText) &




                          //模糊搜索Str2
                          a.Str2.Contains(input.FilterText) &




                          //模糊搜索Str3
                          a.Str3.Contains(input.FilterText) &




                          //模糊搜索Str4
                          a.Str4.Contains(input.FilterText) &




                          //模糊搜索Str5
                          a.Str5.Contains(input.FilterText) &




                          //模糊搜索Str6
                          a.Str6.Contains(input.FilterText) &




                          //模糊搜索Str7
                          a.Str7.Contains(input.FilterText) &




                          //模糊搜索Str8
                          a.Str8.Contains(input.FilterText) &




                          //模糊搜索Str9
                          a.Str9.Contains(input.FilterText) &




                          //模糊搜索Str10
                          a.Str10.Contains(input.FilterText) &




                          //模糊搜索Str11
                          a.Str11.Contains(input.FilterText) &




                          //模糊搜索Str12
                          a.Str12.Contains(input.FilterText) &




                          //模糊搜索Str13
                          a.Str13.Contains(input.FilterText) &




                          //模糊搜索Str14
                          a.Str14.Contains(input.FilterText) &




                          //模糊搜索Str15
                          a.Str15.Contains(input.FilterText) &




                          //模糊搜索Str16
                          a.Str16.Contains(input.FilterText) &




                          //模糊搜索Str17
                          a.Str17.Contains(input.FilterText) &




                          //模糊搜索Str18
                          a.Str18.Contains(input.FilterText) &




                          //模糊搜索Str19
                          a.Str19.Contains(input.FilterText) &




                          //模糊搜索Str20
                          a.Str20.Contains(input.FilterText)




            );
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var wMS_ProductList = await query
            .OrderBy(input.Sorting).AsNoTracking()
            .PageBy(input)
            .ToListAsync();

            var wMS_ProductListDtos = ObjectMapper.Map<List<WMS_ProductListDto>>(wMS_ProductList);

            return new PagedResultDto<WMS_ProductListDto>(count, wMS_ProductListDtos);
        }


        /// <summary>
        /// 通过指定id获取WMS_ProductListDto信息
        /// </summary>
        [AbpAuthorize(WMS_ProductPermissions.WMS_Product_Query)]
        public async Task<WMS_ProductListDto> GetById(EntityDto<long> input)
        {
            var entity = await _wMS_ProductRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<WMS_ProductListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ProductPermissions.WMS_Product_Create, WMS_ProductPermissions.WMS_Product_Edit)]
        public async Task<GetWMS_ProductForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_ProductForEditOutput();
            WMS_ProductEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _wMS_ProductRepository.GetAsync(input.Id.Value);
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
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ProductPermissions.WMS_Product_Create, WMS_ProductPermissions.WMS_Product_Edit)]
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
        /// 新增
        /// </summary>
        [AbpAuthorize(WMS_ProductPermissions.WMS_Product_Create)]
        protected virtual async Task<WMS_ProductEditDto> Create(WMS_ProductEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_Product>(input);
            //调用领域服务
            entity = await _wMS_ProductManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WMS_ProductEditDto>(entity);
            return dto;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        [AbpAuthorize(WMS_ProductPermissions.WMS_Product_Edit)]
        protected virtual async Task Update(WMS_ProductEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _wMS_ProductRepository.GetAsync(input.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wMS_ProductManager.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ProductPermissions.WMS_Product_Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ProductManager.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除WMS_Product的方法
        /// </summary>
        [AbpAuthorize(WMS_ProductPermissions.WMS_Product_BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wMS_ProductManager.BatchDelete(input);
        }




        //// custom codes



        //// custom codes end

    }
}


