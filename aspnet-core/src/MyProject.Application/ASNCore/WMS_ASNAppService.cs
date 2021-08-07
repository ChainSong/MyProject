
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
using MyProject.ASNCore;
using MyProject.ASNCore.Dtos;
//using MyProject.ASNCore.Exporting;
using MyProject.ASNCore.DomainService;
using MyProject.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.WarehouseCore;
using MyProject.CustomerCore;

namespace MyProject.ASNCore
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>
    [AbpAuthorize]
    public class WMS_ASNAppService : MyProjectAppServiceBase, IWMS_ASNAppService
    {
        private readonly IRepository<WMS_ASN, long> _wMS_ASNRepository;
        private readonly IRepository<WarehouseUserMapping, long> _warehouseUserMappingRepository;
        private readonly IRepository<CustomerUserMapping, long> _customerUserMappingRepository;


        private readonly IWMS_ASNManager _wMS_ASNManager;
        /// <summary>
        /// 构造函数
        ///  </summary>
        public WMS_ASNAppService(
        IRepository<WMS_ASN, long> wMS_ASNRepository,
        IRepository<WarehouseUserMapping, long> warehouseUserMappingRepository,
        IRepository<CustomerUserMapping, long> customerUserMappingRepository
            , IWMS_ASNManager wMS_ASNManager

            )
        {
            _wMS_ASNRepository = wMS_ASNRepository;
            _warehouseUserMappingRepository = warehouseUserMappingRepository;
            _customerUserMappingRepository = customerUserMappingRepository;
            _wMS_ASNManager = wMS_ASNManager;
        }


        /// <summary>
        /// 获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PagedResultDto<WMS_ASNListDto>> GetPaged(GetWMS_ASNsInput input)
        {
            try
            {
                var customer = _customerUserMappingRepository.GetAll()
                    .Where(a => a.Status == 1 & a.UserId == AbpSession.UserId)
                    .Select(a => a.CustomerId);
                var query = _wMS_ASNRepository.GetAll()
                .WhereIf(!input.ASNNumber.IsNullOrWhiteSpace(), a =>
                              //模糊搜索ASNNumber
                              a.ASNNumber.Contains(input.ASNNumber))
                .WhereIf(!input.ExternReceiptNumber.IsNullOrWhiteSpace(), a =>
                              //模糊搜索ExternReceiptNumber
                              a.ExternReceiptNumber.Contains(input.ExternReceiptNumber))
                .WhereIf(input.CustomerID != 0, a =>
                                //模糊搜索CustomerID
                                a.CustomerID == (input.CustomerID))
                .WhereIf(!input.CustomerName.IsNullOrWhiteSpace(), a =>
                              //模糊搜索CustomerName
                              a.CustomerName.Contains(input.CustomerName))
                 .WhereIf(input.WarehouseID != 0, a =>
                                //模糊搜索WarehouseID
                                a.WarehouseID == (input.WarehouseID))
                .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a =>
                              //模糊搜索WarehouseName
                              a.WarehouseName.Contains(input.WarehouseName))
                .WhereIf(!input.ASNType.IsNullOrWhiteSpace(), a =>
                              //模糊搜索ASNType
                              a.ASNType.Contains(input.ASNType))
                .WhereIf(!input.PO.IsNullOrWhiteSpace(), a =>
                              //模糊搜索PO
                              a.PO.Contains(input.PO))
                .WhereIf(!input.Contact.IsNullOrWhiteSpace(), a =>
                              //模糊搜索Contact
                              a.Contact.Contains(input.Contact))
                .WhereIf(!input.ContactInfo.IsNullOrWhiteSpace(), a =>
                              //模糊搜索ContactInfo
                              a.ContactInfo.Contains(input.ContactInfo))
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
                              a.Str20.Contains(input.Str20))
                .Where(a => customer.Contains(a.CustomerID))
                ;
                // TODO:根据传入的参数添加过滤条件

                var count = await query.CountAsync();

                var wMS_ASNList = await query
                //.OrderBy(input.Sorting).AsNoTracking()
                    .OrderByDescending(t => t.ASNId).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

                var wMS_ASNListDtos = ObjectMapper.Map<List<WMS_ASNListDto>>(wMS_ASNList);

                return new PagedResultDto<WMS_ASNListDto>(count, wMS_ASNListDtos);
            }
            catch (Exception e)
            {

            }
            return new PagedResultDto<WMS_ASNListDto>();
        }


        /// <summary>
        /// 通过指定id获取WMS_ASNListDto信息
        /// </summary>

        public async Task<WMS_ASNListDto> GetById(EntityDto<long> input)
        {
            var entity = await _wMS_ASNRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<WMS_ASNListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<GetWMS_ASNForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_ASNForEditOutput();
            WMS_ASNEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _wMS_ASNRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<WMS_ASNEditDto>(entity);
            }
            else
            {
                editDto = new WMS_ASNEditDto();
            }



            output.WMS_ASN = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task CreateOrUpdate(CreateOrUpdateWMS_ASNInput input)
        {

            if (input.WMS_ASN.Id.HasValue)
            {
                await Update(input);
            }
            else
            {
                await Create(input);
            }
        }


        /// <summary>
        /// 新增
        /// </summary>

        protected virtual async Task<WMS_ASNEditDto> Create(CreateOrUpdateWMS_ASNInput input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<WMS_ASN>(input.WMS_ASN);
            var detailEntitys = ObjectMapper.Map<List<WMS_ASNDetail>>(input.WMS_ASNDetails);

            detailEntitys.ForEach(a =>
            {
                //a.CustomerId = customerEntity.Id;
                //a.CustomerName = entity.CustomerName;
                //a.CustomerCode = entity.CustomerCode;
                //a.Creator = AbpSession.UserName;
            });
            entity.Creator = AbpSession.UserName;
            entity.WMS_ASNDetails = detailEntitys;
            //调用领域服务
            entity = await _wMS_ASNManager.CreateAsync(entity);
            //customerInfoEntity = await _customerDetailInfoManager.CreateAsync(customerDetailInfoEntitys);
            var dto = ObjectMapper.Map<WMS_ASNEditDto>(entity);
            return dto;

            //var entity = ObjectMapper.Map<WMS_ASN>(input);
            ////调用领域服务
            //entity = await _wMS_ASNManager.CreateAsync(entity);

            //var dto = ObjectMapper.Map<WMS_ASNEditDto>(entity);
            //return dto;
        }

        /// <summary>
        /// 编辑
        /// </summary>

        protected virtual async Task Update(CreateOrUpdateWMS_ASNInput input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _wMS_ASNRepository.GetAsync(input.WMS_ASN.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wMS_ASNManager.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wMS_ASNManager.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除WMS_ASN的方法
        /// </summary>

        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wMS_ASNManager.BatchDelete(input);
        }




        //// custom codes



        //// custom codes end

    }
}


