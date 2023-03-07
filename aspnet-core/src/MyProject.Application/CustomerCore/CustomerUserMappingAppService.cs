
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
using MyProject.CustomerCore;
using MyProject.CustomerCore.Dtos;
using MyProject.CustomerCore.DomainService;

using MyProject.Authorization;

namespace MyProject.CustomerCore
{
    /// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
    [ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
    public class CustomerUserMappingAppService : MyProjectAppServiceBase, ICustomerUserMappingAppService
    {
        /// <summary>
        ///【CustomerUserMapping】仓储层
        /// </summary>
        private readonly IRepository<CustomerUserMapping, long> _customerusermappingRepository;

        /// <summary>
        ///【CustomerUserMapping】领域服务
        /// </summary>
        private readonly ICustomerUserMappingManager _customerusermappingManager;


        /// <summary>
        ///【Customer】仓储层
        /// </summary>
        private readonly IRepository<Customer, long> _customerRepository;
        /// <summary>
        ///【Customer】领域服务
        /// </summary>
        //private readonly ICustomerManager _customerManager;


        /// <summary>
        ///【Customer】仓储层
        /// </summary>
        //private readonly IRepository<Customer, long> _customerRepository;
        //private readonly IRepository<CustomerDetail, long> _customerDetailRepository;

        ///// <summary>
        /////【Customer】领域服务
        ///// </summary>
        //private readonly ICustomerManager _customerManager;



        public CustomerUserMappingAppService(
            IRepository<CustomerUserMapping, long> customerusermappingRepository,
            ICustomerUserMappingManager customerusermappingManager,
            IRepository<Customer, long> customerRepository

        )
        {

            _customerusermappingRepository = customerusermappingRepository;
            _customerusermappingManager = customerusermappingManager;
            _customerRepository = customerRepository;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        ///【CustomerUserMapping】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(CustomerUserMappingPermissions.Node)]
        [HttpPost]
        public async Task<PagedResultDto<CustomerUserMappingListDto>> GetPaged(GetCustomerUserMappingsInput input)
        {
            var query = _customerusermappingRepository.GetAll()
                          //模糊搜索 字段UserName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.UserName.Contains(input.FilterText))
                          //模糊搜索 字段CustomerName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CustomerName.Contains(input.FilterText))
                          //模糊搜索 字段Creator
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Creator.Contains(input.FilterText))
                          //模糊搜索 字段Updator
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Updator.Contains(input.FilterText))
            ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            var entityListDtos = ObjectMapper.Map<List<CustomerUserMappingListDto>>(entityList);

            return new PagedResultDto<CustomerUserMappingListDto>(count, entityListDtos);
        }

        /// <summary>
        ///【CustomerUserMapping】通过指定id获取MemberListDto信息
        /// </summary>
        //[AbpAuthorize(CustomerUserMappingPermissions.Node)]
        [HttpPost]
        public async Task<CustomerUserMappingListDto> GetById(EntityDto<long> input)
        {
            var entity = await _customerusermappingRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<CustomerUserMappingListDto>(entity);
            return dto;
        }

        /// <summary>
        ///【CustomerUserMapping】 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(CustomerUserMappingPermissions.Node)]
        [HttpPost]
        public async Task<GetCustomerUserMappingForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetCustomerUserMappingForEditOutput();
            CustomerUserMappingEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _customerusermappingRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<CustomerUserMappingEditDto>(entity);
            }
            else
            {
                editDto = new CustomerUserMappingEditDto();
            }
            output.CustomerUserMapping = editDto;
            return output;
        }
        /// <summary>
        ///【CustomerUserMapping】 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(CustomerUserMappingPermissions.Node)]
        [HttpPost]
        public async Task CreateOrUpdate(CreateOrUpdateCustomerUserMappingInput input)
        {
            var entity = ObjectMapper.Map<List<CustomerUserMapping>>(input.CustomerUserMappings);
            //调用领域服务
            //先删除mapping关系

            await _customerusermappingManager.UserIdDelete(entity.First().UserId);
            //然后创建mapping关系
            foreach (var item in entity)
            {
                if (item.Status > 0)
                {
                    item.Creator = AbpSession.UserName;
                    await _customerusermappingManager.CreateAsync(item);
                }
            }
            //if (input.CustomerUserMapping.Id.HasValue)
            //{
            //	await Update(input.CustomerUserMapping);
            //}
            //else
            //{
            //	await Create(input.CustomerUserMapping);
            //}
        }
        /// <summary>
        ///【CustomerUserMapping】新增
        /// </summary>
        //[AbpAuthorize(CustomerUserMappingPermissions.Node)]
        protected virtual async Task<CustomerUserMappingEditDto> Create(CustomerUserMappingEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<CustomerUserMapping>(input);
            //调用领域服务
            entity = await _customerusermappingManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<CustomerUserMappingEditDto>(entity);
            return dto;
        }

        /// <summary>
        ///【CustomerUserMapping】编辑
        /// </summary>
        //[AbpAuthorize(CustomerUserMappingPermissions.Node)]
        protected virtual async Task Update(CustomerUserMappingEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var key = input.Id.Value;
            var entity = await _customerusermappingRepository.GetAsync(key);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _customerusermappingManager.UpdateAsync(entity);
        }

        /// <summary>
        ///【CustomerUserMapping】删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(CustomerUserMappingPermissions.Node)]
        [HttpGet]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customerusermappingManager.DeleteAsync(input.Id);
        }

        /// <summary>
        ///【CustomerUserMapping】 批量删除Member的方法
        /// </summary>
        //[AbpAuthorize(CustomerUserMappingPermissions.Node)]
        [HttpPost]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _customerusermappingManager.BatchDelete(input);
        }

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展应用服务实现*/

        [HttpPost]
        public async Task<PagedResultDto<CustomerUserMappingListDto>> GetMapping(CustomerUserMappingEditDto input)
        {


            var query = _customerusermappingRepository.GetAll()
                      //模糊搜索 字段UserName
                      .WhereIf(!input.UserName.IsNullOrWhiteSpace(), a => a.UserName.Contains(input.UserName))
                      .WhereIf(input.UserId != 0, a => a.UserName == (input.UserName))
                      //模糊搜索 字段WarehouseName
                      .WhereIf(input.CustomerId != 0, a => a.CustomerId == (input.CustomerId))
                      .WhereIf(!input.CustomerName.IsNullOrWhiteSpace(), a => a.CustomerName == (input.CustomerName))
        //模糊搜索 字段Creator

        ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderByDescending(a => a.Id).AsNoTracking()
                    .ToListAsync();

            var entityListDtos = ObjectMapper.Map<List<CustomerUserMappingListDto>>(entityList);

            return new PagedResultDto<CustomerUserMappingListDto>(count, entityListDtos);


        }
        #endregion
    }
}
