
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
using MyProject.ReceiptReceivingCore;
using MyProject.ReceiptReceivingCore.Dtos;
//using MyProject.ReceiptReceivingCore.Exporting;
using MyProject.ReceiptReceivingCore.DomainService;
using MyProject.Authorization;

namespace MyProject.ReceiptReceivingCore
{
    /// <summary>
    /// 应用层服务的接口实现方法
	/// <see cref="WMS_ReceiptReceiving" />
    ///</summary>

    [AbpAuthorize]
    public class WMS_ReceiptReceivingAppService : MyProjectAppServiceBase, IWMS_ReceiptReceivingAppService
    {

        private readonly IRepository<WMS_ReceiptReceiving, long> _wMS_ReceiptReceivingRepository;


        private readonly IWMS_ReceiptReceivingManager _wMS_ReceiptReceivingManager;


        /// <summary>
        /// 构造函数
        ///</summary>

        public WMS_ReceiptReceivingAppService(IWMS_ReceiptReceivingManager wMS_ReceiptReceivingManager
              , IRepository<WMS_ReceiptReceiving, long> wMS_ReceiptReceivingRepository
            )
        {
            _wMS_ReceiptReceivingManager = wMS_ReceiptReceivingManager;
            _wMS_ReceiptReceivingRepository = wMS_ReceiptReceivingRepository;


        }


        /// <summary>
        /// 获取的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Query)]
        public async Task<PagedResultDto<WMS_ReceiptReceivingListDto>> GetPaged(GetWMS_ReceiptReceivingsInput input)
        {

            var query = _wMS_ReceiptReceivingRepository.GetAll()
                     .WhereIf(!input.ReceiptNumber.IsNullOrWhiteSpace(), a =>
                          //模糊搜索ReceiptNumber
                          a.ReceiptNumber.Contains(input.ReceiptNumber))
                     .WhereIf(!input.ExternReceiptNumber.IsNullOrWhiteSpace(), a =>
                          //模糊搜索ExternReceiptNumber
                          a.ExternReceiptNumber.Contains(input.ExternReceiptNumber))
                     .WhereIf(!input.ASNNumber.IsNullOrWhiteSpace(), a =>
                          //模糊搜索ASNNumber
                          a.ASNNumber.Contains(input.ASNNumber))
                     .WhereIf(!input.CustomerName.IsNullOrWhiteSpace(), a =>
                          //模糊搜索CustomerName
                          a.CustomerName.Contains(input.CustomerName))
                     .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a =>
                          //模糊搜索WarehouseName
                          a.WarehouseName.Contains(input.WarehouseName))
                     .WhereIf(!input.LineNumber.IsNullOrWhiteSpace(), a =>
                          //模糊搜索LineNumber
                          a.LineNumber.Contains(input.LineNumber))
                     .WhereIf(!input.SKU.IsNullOrWhiteSpace(), a =>
                          //模糊搜索SKU
                          a.SKU.Contains(input.SKU))
                     .WhereIf(!input.UPC.IsNullOrWhiteSpace(), a =>
                          //模糊搜索UPC
                          a.UPC.Contains(input.UPC))
                     .WhereIf(!input.GoodsType.IsNullOrWhiteSpace(), a =>
                          //模糊搜索GoodsType
                          a.GoodsType.Contains(input.GoodsType))
                     .WhereIf(!input.GoodsName.IsNullOrWhiteSpace(), a =>
                          //模糊搜索GoodsName
                          a.GoodsName.Contains(input.GoodsName))
                     .WhereIf(!input.BoxNumber.IsNullOrWhiteSpace(), a =>
                          //模糊搜索BoxNumber
                          a.BoxNumber.Contains(input.BoxNumber))
                     .WhereIf(!input.BatchNumber.IsNullOrWhiteSpace(), a =>
                          //模糊搜索BatchNumber
                          a.BatchNumber.Contains(input.BatchNumber))
                     .WhereIf(!input.Unit.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Unit
                          a.Unit.Contains(input.Unit))
                     .WhereIf(!input.Specifications.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Specifications
                          a.Specifications.Contains(input.Specifications))
                     .WhereIf(!input.Area.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Area
                          a.Area.Contains(input.Area))
                     .WhereIf(!input.Location.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Location
                          a.Location.Contains(input.Location))
                     .WhereIf(!input.Remark.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Remark
                          a.Remark.Contains(input.Remark))
                     .WhereIf(!input.Creator.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Creator
                          a.Creator.Contains(input.Creator))
                     .WhereIf(!input.Updator.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Updator
                          a.Updator.Contains(input.Updator))
                     .WhereIf(!input.Str1.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str1
                          a.Str1.Contains(input.Str1))
                     .WhereIf(!input.Str2.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str2
                          a.Str2.Contains(input.Str2))
                     .WhereIf(!input.Str3.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str3
                          a.Str3.Contains(input.Str3))
                     .WhereIf(!input.Str4.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str4
                          a.Str4.Contains(input.Str4))
                     .WhereIf(!input.Str5.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str5
                          a.Str5.Contains(input.Str5))
                     .WhereIf(!input.Str6.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str6
                          a.Str6.Contains(input.Str6))
                     .WhereIf(!input.Str7.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str7
                          a.Str7.Contains(input.Str7))
                     .WhereIf(!input.Str8.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str8
                          a.Str8.Contains(input.Str8))
                     .WhereIf(!input.Str9.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str9
                          a.Str9.Contains(input.Str9))
                     .WhereIf(!input.Str10.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str10
                          a.Str10.Contains(input.Str10))
                     .WhereIf(!input.Str11.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str11
                          a.Str11.Contains(input.Str11))
                     .WhereIf(!input.Str12.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str12
                          a.Str12.Contains(input.Str12))
                     .WhereIf(!input.Str13.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str13
                          a.Str13.Contains(input.Str13))
                     .WhereIf(!input.Str14.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str14
                          a.Str14.Contains(input.Str14))
                     .WhereIf(!input.Str15.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str15
                          a.Str15.Contains(input.Str15))
                     .WhereIf(!input.Str16.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str16
                          a.Str16.Contains(input.Str16))
                     .WhereIf(!input.Str17.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str17
                          a.Str17.Contains(input.Str17))
                     .WhereIf(!input.Str18.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str18
                          a.Str18.Contains(input.Str18))
                     .WhereIf(!input.Str19.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str19
                          a.Str19.Contains(input.Str19))
                     .WhereIf(!input.Str20.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str20
                          a.Str20.Contains(input.Str20)
               );
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var wMS_ReceiptReceivingList = await query
            .OrderBy(input.Sorting).AsNoTracking()
            .PageBy(input)
            .ToListAsync();

            var wMS_ReceiptReceivingListDtos = ObjectMapper.Map<List<WMS_ReceiptReceivingListDto>>(wMS_ReceiptReceivingList);

            return new PagedResultDto<WMS_ReceiptReceivingListDto>(count, wMS_ReceiptReceivingListDtos);
        }


        /// <summary>
        /// 通过指定id获取WMS_ReceiptReceivingListDto信息
        /// </summary>
        [AbpAuthorize(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Query)]
        public async Task<WMS_ReceiptReceivingListDto> GetById(EntityDto<long> input)
        {
            var entity = await _wMS_ReceiptReceivingRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<WMS_ReceiptReceivingListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Create, WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Edit)]
        public async Task<GetWMS_ReceiptReceivingForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_ReceiptReceivingForEditOutput();
            WMS_ReceiptReceivingEditDto editDto;

            if (input.Id.HasValue)
            {


                var entity = await _wMS_ReceiptReceivingRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<WMS_ReceiptReceivingEditDto>(entity);
            }
            else
            {
                editDto = new WMS_ReceiptReceivingEditDto();
            }



            output.WMS_ReceiptReceiving = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Create, WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateWMS_ReceiptReceivingInput input)
        {

            if (input.WMS_ReceiptReceiving.Id.HasValue)
            {
                await Update(input.WMS_ReceiptReceiving);
            }
            else
            {
                await Create(input.WMS_ReceiptReceiving);
            }
        }


        /// <summary>
        /// 新增
        /// </summary>
        [AbpAuthorize(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Create)]
        protected virtual async Task<WMS_ReceiptReceivingEditDto> Create(WMS_ReceiptReceivingEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_ReceiptReceiving>(input);
            //调用领域服务
            entity = await _wMS_ReceiptReceivingManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WMS_ReceiptReceivingEditDto>(entity);
            return dto;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        [AbpAuthorize(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Edit)]
        protected virtual async Task Update(WMS_ReceiptReceivingEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _wMS_ReceiptReceivingRepository.GetAsync(input.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wMS_ReceiptReceivingManager.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ReceiptReceivingManager.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除WMS_ReceiptReceiving的方法
        /// </summary>
        [AbpAuthorize(WMS_ReceiptReceivingPermissions.WMS_ReceiptReceiving_BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wMS_ReceiptReceivingManager.BatchDelete(input);
        }




        //// custom codes



        //// custom codes end

    }
}


