
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.Extensions;
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
using MyProject.ASNCore;
using MyProject.ASNCore.Dtos;
using MyProject.ASNCore.DomainService;

using MyProject.Authorization;

namespace MyProject.ASNCore
{
    /// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
    [ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
    public class WMS_ASNAppService : MyProjectAppServiceBase, IWMS_ASNAppService
    {
        /// <summary>
        ///【WMS_ASN】仓储层
        /// </summary>
        private readonly IRepository<WMS_ASN, long> _wms_asnRepository;

        /// <summary>
        ///【WMS_ASN】领域服务
        /// </summary>
        private readonly IWMS_ASNManager _wms_asnManager;

        public WMS_ASNAppService(
            IRepository<WMS_ASN, long> wms_asnRepository,
            IWMS_ASNManager wms_asnManager
        )
        {
            _wms_asnRepository = wms_asnRepository;
            _wms_asnManager = wms_asnManager;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        ///【WMS_ASN】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        //[AbpAuthorize(WMS_ASNPermissions.Node)]
        public async Task<PagedResultDto<WMS_ASNListDto>> GetPaged(GetWMS_ASNsInput input)
        {
            var query = _wms_asnRepository.GetAll()
                          //模糊搜索 字段ASNNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ASNNumber.Contains(input.FilterText))
                          //模糊搜索 字段ExternReceiptNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ExternReceiptNumber.Contains(input.FilterText))
                          //模糊搜索 字段CustomerName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CustomerName.Contains(input.FilterText))
                          //模糊搜索 字段WarehouseName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.WarehouseName.Contains(input.FilterText))
                          //模糊搜索 字段ReceiptType
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ReceiptType.Contains(input.FilterText))
                          //模糊搜索 字段Contact
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Contact.Contains(input.FilterText))
                          //模糊搜索 字段ContactInfo
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ContactInfo.Contains(input.FilterText))
                          //模糊搜索 字段Remark
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Remark.Contains(input.FilterText))
                          //模糊搜索 字段Creator
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Creator.Contains(input.FilterText))
                          //模糊搜索 字段Updator
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Updator.Contains(input.FilterText))
                          //模糊搜索 字段Str1
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str1.Contains(input.FilterText))
                          //模糊搜索 字段Str2
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str2.Contains(input.FilterText))
                          //模糊搜索 字段Str3
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str3.Contains(input.FilterText))
                          //模糊搜索 字段Str4
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str4.Contains(input.FilterText))
                          //模糊搜索 字段Str5
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str5.Contains(input.FilterText))
                          //模糊搜索 字段Str6
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str6.Contains(input.FilterText))
                          //模糊搜索 字段Str7
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str7.Contains(input.FilterText))
                          //模糊搜索 字段Str8
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str8.Contains(input.FilterText))
                          //模糊搜索 字段Str9
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str9.Contains(input.FilterText))
                          //模糊搜索 字段Str10
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str10.Contains(input.FilterText))
                          //模糊搜索 字段Str11
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str11.Contains(input.FilterText))
                          //模糊搜索 字段Str12
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str12.Contains(input.FilterText))
                          //模糊搜索 字段Str13
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str13.Contains(input.FilterText))
                          //模糊搜索 字段Str14
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str14.Contains(input.FilterText))
                          //模糊搜索 字段Str15
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str15.Contains(input.FilterText))
                          //模糊搜索 字段Str16
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str16.Contains(input.FilterText))
                          //模糊搜索 字段Str17
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str17.Contains(input.FilterText))
                          //模糊搜索 字段Str18
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str18.Contains(input.FilterText))
                          //模糊搜索 字段Str19
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str19.Contains(input.FilterText))
                          //模糊搜索 字段Str20
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Str20.Contains(input.FilterText))
            ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            var entityListDtos = ObjectMapper.Map<List<WMS_ASNListDto>>(entityList);

            return new PagedResultDto<WMS_ASNListDto>(count, entityListDtos);
        }

        /// <summary>
        ///【WMS_ASN】通过指定id获取MemberListDto信息
        /// </summary>
        /// 
        [HttpGet]
        //[AbpAuthorize(WMS_ASNPermissions.Node)]
        public async Task<WMS_ASNListDto> GetById(EntityDto<long> input)
        {
            var entity = await _wms_asnRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<WMS_ASNListDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_ASN】 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ASNPermissions.Node)]
        [HttpPost]
        public async Task<GetWMS_ASNForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_ASNForEditOutput();
            WMS_ASNEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _wms_asnRepository.GetAsync(input.Id.Value);
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
        ///【WMS_ASN】 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ASNPermissions.Node)]
        [HttpPost]
        public async Task CreateOrUpdate(CreateOrUpdateWMS_ASNInput input)
        {

            if (input.WMS_ASN.Id.HasValue)
            {
                await Update(input.WMS_ASN);
            }
            else
            {
                await Create(input.WMS_ASN);
            }
        }
        /// <summary>
        ///【WMS_ASN】新增
        /// </summary>
        //[AbpAuthorize(WMS_ASNPermissions.Node)]
        protected virtual async Task<WMS_ASNEditDto> Create(WMS_ASNEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_ASN>(input);
            //调用领域服务
            entity = await _wms_asnManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WMS_ASNEditDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_ASN】编辑
        /// </summary>
        //[AbpAuthorize(WMS_ASNPermissions.Node)]
        protected virtual async Task Update(WMS_ASNEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var key = input.Id.Value;
            var entity = await _wms_asnRepository.GetAsync(key);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_asnManager.UpdateAsync(entity);
        }

        /// <summary>
        ///【WMS_ASN】删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ASNPermissions.Node)]
        [HttpPost]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_asnManager.DeleteAsync(input.Id);
        }

        /// <summary>
        ///【WMS_ASN】 批量删除Member的方法
        /// </summary>
        //[AbpAuthorize(WMS_ASNPermissions.Node)]
        [HttpPost]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_asnManager.BatchDelete(input);
        }

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展应用服务实现*/
        #endregion
    }
}
