
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
using MyProject.ReceiptCore;
using MyProject.ReceiptCore.Dtos;
//using MyProject.ReceiptCore.Exporting;
using MyProject.ReceiptCore.DomainService;
using MyProject.Authorization;

namespace MyProject.ReceiptCore
{
    /// <summary>
    /// 应用层服务的接口实现方法
	/// <see cref="WMS_ReceiptDetail" />
    ///</summary>

    [AbpAuthorize]
    public class WMS_ReceiptDetailAppService : MyProjectAppServiceBase, IWMS_ReceiptDetailAppService
    {


        private readonly IRepository<WMS_ReceiptDetail, long> _wMS_ReceiptDetailRepository;

        private readonly IWMS_ReceiptDetailManager _wMS_ReceiptDetailManager;


        /// <summary>
        /// 构造函数
        ///</summary>

        public WMS_ReceiptDetailAppService(IWMS_ReceiptDetailManager wMS_ReceiptDetailManager
            , IRepository<WMS_ReceiptDetail, long> wMS_ReceiptDetailRepository
            )
        {
            _wMS_ReceiptDetailManager = wMS_ReceiptDetailManager;
            _wMS_ReceiptDetailRepository = wMS_ReceiptDetailRepository;

        }


        /// <summary>
        /// 获取的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Query)]
        public async Task<PagedResultDto<WMS_ReceiptDetailListDto>> GetPaged(GetWMS_ReceiptDetailsInput input)
        {

            var query = _wMS_ReceiptDetailRepository.GetAll().WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a =>

                          //模糊搜索ReceiptNumber
                          a.ReceiptNumber.Contains(input.FilterText) ||


                          //模糊搜索ExternReceiptNumber
                          a.ExternReceiptNumber.Contains(input.FilterText) ||




                          //模糊搜索ASNNumber
                          a.ASNNumber.Contains(input.FilterText) ||




                          //模糊搜索CustomerName
                          a.CustomerName.Contains(input.FilterText) ||




                          //模糊搜索WarehouseName
                          a.WarehouseName.Contains(input.FilterText) ||




                          //模糊搜索LineNumber
                          a.LineNumber.Contains(input.FilterText) ||




                          //模糊搜索SKU
                          a.SKU.Contains(input.FilterText) ||




                          //模糊搜索UPC
                          a.UPC.Contains(input.FilterText) ||




                          //模糊搜索GoodsType
                          a.GoodsType.Contains(input.FilterText) ||




                          //模糊搜索GoodsName
                          a.GoodsName.Contains(input.FilterText) ||




                          //模糊搜索BoxNumber
                          a.BoxNumber.Contains(input.FilterText) ||




                          //模糊搜索BatchNumber
                          a.BatchNumber.Contains(input.FilterText) ||




                          //模糊搜索Unit
                          a.Unit.Contains(input.FilterText) ||




                          //模糊搜索Specifications
                          a.Specifications.Contains(input.FilterText) ||




                          //模糊搜索ProductionDate
                          a.ProductionDate.Contains(input.FilterText) ||




                          //模糊搜索ExpirationDate
                          a.ExpirationDate.Contains(input.FilterText) ||




                          //模糊搜索Creator
                          a.Creator.Contains(input.FilterText) ||




                          //模糊搜索Updator
                          a.Updator.Contains(input.FilterText) ||




                          //模糊搜索Str1
                          a.Str1.Contains(input.FilterText) ||




                          //模糊搜索Str2
                          a.Str2.Contains(input.FilterText) ||




                          //模糊搜索Str3
                          a.Str3.Contains(input.FilterText) ||




                          //模糊搜索Str4
                          a.Str4.Contains(input.FilterText) ||




                          //模糊搜索Str5
                          a.Str5.Contains(input.FilterText) ||




                          //模糊搜索Str6
                          a.Str6.Contains(input.FilterText) ||




                          //模糊搜索Str7
                          a.Str7.Contains(input.FilterText) ||




                          //模糊搜索Str8
                          a.Str8.Contains(input.FilterText) ||




                          //模糊搜索Str9
                          a.Str9.Contains(input.FilterText) ||




                          //模糊搜索Str10
                          a.Str10.Contains(input.FilterText) ||




                          //模糊搜索Str11
                          a.Str11.Contains(input.FilterText) ||




                          //模糊搜索Str12
                          a.Str12.Contains(input.FilterText) ||




                          //模糊搜索Str13
                          a.Str13.Contains(input.FilterText) ||




                          //模糊搜索Str14
                          a.Str14.Contains(input.FilterText) ||




                          //模糊搜索Str15
                          a.Str15.Contains(input.FilterText) ||




                          //模糊搜索Str16
                          a.Str16.Contains(input.FilterText) ||




                          //模糊搜索Str17
                          a.Str17.Contains(input.FilterText) ||




                          //模糊搜索Str18
                          a.Str18.Contains(input.FilterText) ||




                          //模糊搜索Str19
                          a.Str19.Contains(input.FilterText) ||




                          //模糊搜索Str20
                          a.Str20.Contains(input.FilterText) ||




                          //模糊搜索Int1
                          a.Int1.Contains(input.FilterText) ||




                          //模糊搜索Int2
                          a.Int2.Contains(input.FilterText) ||




                          //模糊搜索Int3
                          a.Int3.Contains(input.FilterText) ||




                          //模糊搜索Int4
                          a.Int4.Contains(input.FilterText) ||




                          //模糊搜索Int5
                          a.Int5.Contains(input.FilterText)




            );
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var wMS_ReceiptDetailList = await query
            .OrderBy(input.Sorting).AsNoTracking()
            .PageBy(input)
            .ToListAsync();

            var wMS_ReceiptDetailListDtos = ObjectMapper.Map<List<WMS_ReceiptDetailListDto>>(wMS_ReceiptDetailList);

            return new PagedResultDto<WMS_ReceiptDetailListDto>(count, wMS_ReceiptDetailListDtos);
        }


        /// <summary>
        /// 通过指定id获取WMS_ReceiptDetailListDto信息
        /// </summary>
        [AbpAuthorize(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Query)]
        public async Task<WMS_ReceiptDetailListDto> GetById(EntityDto<long> input)
        {
            var entity = await _wMS_ReceiptDetailRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<WMS_ReceiptDetailListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Create, WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Edit)]
        public async Task<GetWMS_ReceiptDetailForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_ReceiptDetailForEditOutput();
            WMS_ReceiptDetailEditDto editDto;

            if (input.Id.HasValue)
            {


                var entity = await _wMS_ReceiptDetailRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<WMS_ReceiptDetailEditDto>(entity);
            }
            else
            {
                editDto = new WMS_ReceiptDetailEditDto();
            }



            output.WMS_ReceiptDetail = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Create, WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateWMS_ReceiptDetailInput input)
        {

            if (input.WMS_ReceiptDetail.Id.HasValue)
            {
                await Update(input.WMS_ReceiptDetail);
            }
            else
            {
                await Create(input.WMS_ReceiptDetail);
            }
        }


        /// <summary>
        /// 新增
        /// </summary>
        [AbpAuthorize(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Create)]
        protected virtual async Task<WMS_ReceiptDetailEditDto> Create(WMS_ReceiptDetailEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_ReceiptDetail>(input);
            //调用领域服务
            entity = await _wMS_ReceiptDetailManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WMS_ReceiptDetailEditDto>(entity);
            return dto;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        [AbpAuthorize(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Edit)]
        protected virtual async Task Update(WMS_ReceiptDetailEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _wMS_ReceiptDetailRepository.GetAsync(input.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wMS_ReceiptDetailManager.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ReceiptDetailManager.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除WMS_ReceiptDetail的方法
        /// </summary>
        [AbpAuthorize(WMS_ReceiptDetailPermissions.WMS_ReceiptDetail_BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wMS_ReceiptDetailManager.BatchDelete(input);
        }




        //// custom codes



        //// custom codes end

    }
}


