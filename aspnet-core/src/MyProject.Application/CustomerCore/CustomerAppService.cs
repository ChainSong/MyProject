
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
    public class CustomerAppService : MyProjectAppServiceBase, ICustomerAppService
    {
        /// <summary>
        ///【Customer】仓储层
        /// </summary>
        private readonly IRepository<Customer, long> _customerRepository;

        /// <summary>
        ///【Customer】领域服务
        /// </summary>
        private readonly ICustomerManager _customerManager;

        public CustomerAppService(
            IRepository<Customer, long> customerRepository,
            ICustomerManager customerManager
        )
        {
            _customerRepository = customerRepository;
            _customerManager = customerManager;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        ///【Customer】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(CustomerPermissions.Node)]
        [HttpPost]
        public async Task<PagedResultDto<CustomerListDto>> GetPaged(GetCustomersInput input)
        {
            var query = _customerRepository.GetAll()
                          //模糊搜索 字段CustomerCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CustomerCode.Contains(input.FilterText))
                          //模糊搜索 字段CustomerName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CustomerName.Contains(input.FilterText))
                          //模糊搜索 字段Description
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Description.Contains(input.FilterText))
                          //模糊搜索 字段CustomerType
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CustomerType.Contains(input.FilterText))
                          //模糊搜索 字段CreditLine
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CreditLine.Contains(input.FilterText))
                          //模糊搜索 字段Province
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Province.Contains(input.FilterText))
                          //模糊搜索 字段City
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.City.Contains(input.FilterText))
                          //模糊搜索 字段Address
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Address.Contains(input.FilterText))
                          //模糊搜索 字段Remark
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Remark.Contains(input.FilterText))
                          //模糊搜索 字段Email
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Email.Contains(input.FilterText))
                          //模糊搜索 字段Phone
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Phone.Contains(input.FilterText))
                          //模糊搜索 字段LawPerson
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.LawPerson.Contains(input.FilterText))
                          //模糊搜索 字段PostCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.PostCode.Contains(input.FilterText))
                          //模糊搜索 字段Bank
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Bank.Contains(input.FilterText))
                          //模糊搜索 字段Account
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Account.Contains(input.FilterText))
                          //模糊搜索 字段TaxId
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.TaxId.Contains(input.FilterText))
                          //模糊搜索 字段InvoiceTitle
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.InvoiceTitle.Contains(input.FilterText))
                          //模糊搜索 字段Fax
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Fax.Contains(input.FilterText))
                          //模糊搜索 字段WebSite
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.WebSite.Contains(input.FilterText))
                          //模糊搜索 字段Creator
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Creator.Contains(input.FilterText))
                          //模糊搜索 字段Updator
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Updator.Contains(input.FilterText))
            ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderByDescending(a => a.Id).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            var entityListDtos = ObjectMapper.Map<List<CustomerListDto>>(entityList);

            return new PagedResultDto<CustomerListDto>(count, entityListDtos);
        }

        /// <summary>
        ///【Customer】通过指定id获取MemberListDto信息
        /// </summary>
        //[AbpAuthorize(CustomerPermissions.Node)]
        [HttpGet]
        public async Task<CustomerListDto> GetById(EntityDto<long> input)
        {
            //var entity = await _customerRepository.GetAsync(input.Id);
            var entity = await _customerRepository.GetAllIncluding(a => a.CustomerDetails).Where(a => a.Id == input.Id).FirstAsync();

            var dto = ObjectMapper.Map<CustomerListDto>(entity);
            return dto;
        }

        /// <summary>
        ///【Customer】 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(CustomerPermissions.Node)]
        [HttpPost]
        public async Task<GetCustomerForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetCustomerForEditOutput();
            CustomerEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _customerRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<CustomerEditDto>(entity);
            }
            else
            {
                editDto = new CustomerEditDto();
            }
            output.Customer = editDto;
            return output;
        }
        /// <summary>
        ///【Customer】 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(CustomerPermissions.Node)]
        [HttpPost]
        public async Task CreateOrUpdate(CreateOrUpdateCustomerInput input)
        {


            if (input.Customer.Id.HasValue)
            {
                await Update(input.Customer);
            }
            else
            {
                await Create(input.Customer);
            }
        }
        /// <summary>
        ///【Customer】新增
        /// </summary>
        //[AbpAuthorize(CustomerPermissions.Node)]
        protected virtual async Task<CustomerEditDto> Create(CustomerEditDto input)
        {
            input.Updator = AbpSession.UserName;
            input.UpdateTime= DateTime.Now;
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<Customer>(input);
            //调用领域服务
            entity = await _customerManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<CustomerEditDto>(entity);
            return dto;
        }

        /// <summary>
        ///【Customer】编辑
        /// </summary>
        //[AbpAuthorize(CustomerPermissions.Node)]
        protected virtual async Task Update(CustomerEditDto input)
        {
            foreach (var item in input.CustomerDetails)
            {
                item.CustomerName = input.CustomerName;
                item.CustomerCode = input.CustomerCode;
                item.Creator = AbpSession.UserName;
            }
            //TODO:更新前的逻辑判断，是否允许更新
            var key = input.Id.Value;
            var entity = await _customerRepository.GetAsync(key);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _customerManager.UpdateAsync(entity);
        }

        /// <summary>
        ///【Customer】删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(CustomerPermissions.Node)]
        [HttpGet]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customerManager.DeleteAsync(input.Id);
        }

        /// <summary>
        ///【Customer】 批量删除Member的方法
        /// </summary>
        //[AbpAuthorize(CustomerPermissions.Node)]
        [HttpPost]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _customerManager.BatchDelete(input);
        }

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展应用服务实现*/
        #endregion
    }
}
