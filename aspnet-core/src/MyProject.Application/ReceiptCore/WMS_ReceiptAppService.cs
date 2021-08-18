
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
using MyProject.ReceiptCore.DomainService;
using MyProject.Authorization;

namespace MyProject.ReceiptCore
{
    /// <summary>
    /// 应用层服务的接口实现方法
	/// <see cref="WMS_Receipt" />
    ///</summary>

    [AbpAuthorize]
    public class WMS_ReceiptAppService : MyProjectAppServiceBase, IWMS_ReceiptAppService
    {

        private readonly IRepository<WMS_Receipt, long> _wMS_ReceiptRepository;


        private readonly IWMS_ReceiptManager _wMS_ReceiptManager;


        /// <summary>
        /// 构造函数
        ///</summary>

        public WMS_ReceiptAppService(IWMS_ReceiptManager wMS_ReceiptManager
                    ,IRepository<WMS_Receipt, long> wMS_ReceiptRepository
            )
        {
            _wMS_ReceiptManager = wMS_ReceiptManager;
            _wMS_ReceiptRepository = wMS_ReceiptRepository;


        }


        /// <summary>
        /// 获取的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ReceiptPermissions.WMS_Receipt_Query)]
        public async Task<PagedResultDto<WMS_ReceiptListDto>> GetPaged(GetWMS_ReceiptsInput input)
        {

            var query = _wMS_ReceiptRepository.GetAll()
                   
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
                .WhereIf(!input.ReceiptType.IsNullOrWhiteSpace(), a => 
                          //模糊搜索ReceiptType
                          a.ReceiptType.Contains(input.ReceiptType) )
                .WhereIf(!input.PO.IsNullOrWhiteSpace(), a => 
                          //模糊搜索PO
                          a.PO.Contains(input.PO))
                .WhereIf(!input.Contact.IsNullOrWhiteSpace(), a => 
                          //模糊搜索Contact
                          a.Contact.Contains(input.Contact))
                .WhereIf(!input.ContactInfo.IsNullOrWhiteSpace(), a => 
                          //模糊搜索ContactInfo
                          a.ContactInfo.Contains(input.ContactInfo))
                .WhereIf(input.CompleteDate!=null && input.CompleteDate.Length>0, a =>
                          //模糊搜索CompleteDate
                          a.CompleteDate>(input.CompleteDate[0]))
                  .WhereIf(input.CompleteDate != null && input.CompleteDate.Length > 1, a =>
                              //模糊搜索CompleteDate
                              a.CompleteDate > (input.CompleteDate[1]))
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
                .WhereIf(!input.ASNNumber.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str11
                          a.Str11.Contains(input.Str11))
                .WhereIf(!input.ASNNumber.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str12
                          a.Str12.Contains(input.Str12))
                .WhereIf(!input.ASNNumber.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str13
                          a.Str13.Contains(input.Str13))
                .WhereIf(!input.ASNNumber.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str14
                          a.Str14.Contains(input.Str14))
                .WhereIf(!input.ASNNumber.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Str15
                          a.Str15.Contains(input.Str15))
                .WhereIf(!input.ASNNumber.IsNullOrWhiteSpace(), a =>
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

            var wMS_ReceiptList = await query
            .OrderBy(input.Sorting).AsNoTracking()
            .PageBy(input)
            .ToListAsync();

            var wMS_ReceiptListDtos = ObjectMapper.Map<List<WMS_ReceiptListDto>>(wMS_ReceiptList);

            return new PagedResultDto<WMS_ReceiptListDto>(count, wMS_ReceiptListDtos);
        }


        /// <summary>
        /// 通过指定id获取WMS_ReceiptListDto信息
        /// </summary>
        [AbpAuthorize(WMS_ReceiptPermissions.WMS_Receipt_Query)]
        public async Task<WMS_ReceiptListDto> GetById(EntityDto<long> input)
        {
            var entity = await _wMS_ReceiptRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<WMS_ReceiptListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ReceiptPermissions.WMS_Receipt_Create, WMS_ReceiptPermissions.WMS_Receipt_Edit)]
        public async Task<GetWMS_ReceiptForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_ReceiptForEditOutput();
            WMS_ReceiptEditDto editDto;

            if (input.Id.HasValue)
            {


                var entity = await _wMS_ReceiptRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<WMS_ReceiptEditDto>(entity);
            }
            else
            {
                editDto = new WMS_ReceiptEditDto();
            }



            output.WMS_Receipt = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ReceiptPermissions.WMS_Receipt_Create, WMS_ReceiptPermissions.WMS_Receipt_Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateWMS_ReceiptInput input)
        {

            if (input.WMS_Receipt.Id.HasValue)
            {
                await Update(input.WMS_Receipt);
            }
            else
            {
                await Create(input.WMS_Receipt);
            }
        }


        /// <summary>
        /// 新增
        /// </summary>
        [AbpAuthorize(WMS_ReceiptPermissions.WMS_Receipt_Create)]
        protected virtual async Task<WMS_ReceiptEditDto> Create(WMS_ReceiptEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_Receipt>(input);
            //调用领域服务
            entity = await _wMS_ReceiptManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WMS_ReceiptEditDto>(entity);
            return dto;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        [AbpAuthorize(WMS_ReceiptPermissions.WMS_Receipt_Edit)]
        protected virtual async Task Update(WMS_ReceiptEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _wMS_ReceiptRepository.GetAsync(input.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wMS_ReceiptManager.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(WMS_ReceiptPermissions.WMS_Receipt_Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ReceiptManager.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除WMS_Receipt的方法
        /// </summary>
        [AbpAuthorize(WMS_ReceiptPermissions.WMS_Receipt_BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wMS_ReceiptManager.BatchDelete(input);
        }




        //// custom codes



        //// custom codes end

    }
}


