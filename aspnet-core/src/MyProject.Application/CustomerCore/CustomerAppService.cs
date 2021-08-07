
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
using MyProject.CustomerCore;
using MyProject.CustomerCore.Dtos;
//using MyProject.CustomerCore.Exporting;
using MyProject.CustomerCore.DomainService;
using MyProject.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.CustomerCore
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>
    [AbpAuthorize]
    public class CustomerAppService : MyProjectAppServiceBase, ICustomerAppService
    {
        private readonly IRepository<Customer, long>
                 _customerRepository;

        //private readonly ICustomerDetailManager _customerDetailManager;
        private readonly IRepository<CustomerDetail, long>
         _customerDetailRepository;

        private readonly ICustomerManager _customerManager;
        /// <summary>
        /// 构造函数
        ///  </summary>
        public CustomerAppService(
        IRepository<Customer, long> customerRepository
            , ICustomerManager customerManager
             //, ICustomerDetailManager customerDetailManager
             , IRepository<CustomerDetail, long> customerDetailRepository
            )
        {
            _customerRepository = customerRepository;
            _customerManager = customerManager;
            //_customerDetailManager = customerDetailManager;
            _customerDetailRepository = customerDetailRepository;


        }


        /// <summary>
        /// 获取的分页列表信息
        ///  </summary>
        /// <param name="input"></param>
        /// <returns></returns> 
        [HttpPost]
        public async Task<PagedResultDto<CustomerListDto>> GetPaged(GetCustomersInput input)
        {

            var query = _customerRepository.GetAll()
            .WhereIf(!input.CustomerCode.IsNullOrWhiteSpace(), a =>
                          //模糊搜索CustomerCode
                          a.CustomerCode == (input.CustomerCode))
             .WhereIf(!input.CustomerName.IsNullOrWhiteSpace(), a =>
                          //模糊搜索CustomerName
                          a.CustomerName == (input.CustomerName))
             .WhereIf(!input.Description.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Description
                          a.Description == (input.Description))
             .WhereIf(!input.CustomerType.IsNullOrWhiteSpace(), a =>
                          //模糊搜索CustomerType
                          a.CustomerType == (input.CustomerType))
              .WhereIf(input.CustomerStatus != 0, a =>
                            //模糊搜索CustomerStatus
                            a.CustomerStatus == (input.CustomerStatus))
             .WhereIf(!input.CreditLine.IsNullOrWhiteSpace(), a =>
                          //模糊搜索CreditLine
                          a.CreditLine == (input.CreditLine))
             .WhereIf(!input.Province.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Province
                          a.Province == (input.Province))
             .WhereIf(!input.City.IsNullOrWhiteSpace(), a =>
                          //模糊搜索City
                          a.City == (input.City))
             .WhereIf(!input.Address.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Address
                          a.Address == (input.Address))
             .WhereIf(!input.Remark.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Remark
                          a.Remark == (input.Remark))
             .WhereIf(!input.Email.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Email
                          a.Email == (input.Email))
             .WhereIf(!input.Phone.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Phone
                          a.Phone == (input.Phone))
             .WhereIf(!input.LawPerson.IsNullOrWhiteSpace(), a =>
                          //模糊搜索LawPerson
                          a.LawPerson == (input.LawPerson))
             .WhereIf(!input.PostCode.IsNullOrWhiteSpace(), a =>
                          //模糊搜索PostCode
                          a.PostCode == (input.PostCode))
             .WhereIf(!input.Bank.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Bank
                          a.Bank == (input.Bank))
             .WhereIf(!input.Account.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Account
                          a.Account == (input.Account))
             .WhereIf(!input.TaxId.IsNullOrWhiteSpace(), a =>
                          //模糊搜索TaxId
                          a.TaxId == (input.TaxId))
             .WhereIf(!input.InvoiceTitle.IsNullOrWhiteSpace(), a =>
                          //模糊搜索InvoiceTitle
                          a.InvoiceTitle == (input.InvoiceTitle))
             .WhereIf(!input.Fax.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Fax
                          a.Fax == (input.Fax))
             .WhereIf(!input.WebSite.IsNullOrWhiteSpace(), a =>
                          //模糊搜索WebSite
                          a.WebSite == (input.WebSite))
             .WhereIf(!input.Creator.IsNullOrWhiteSpace(), a =>
                          //模糊搜索Creator
                          a.Creator == (input.Creator))
           .WhereIf(input.CreateTime != null, a =>
                              //模糊搜索CreateTime
                              a.CreateTime >= (input.CreateTime[0]) &&
                              a.CreateTime <= (input.CreateTime[1])

            );
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var customerList = await query
            //.OrderBy(input.Sorting).AsNoTracking()
            .OrderByDescending(t => t.Id).AsNoTracking()
            .PageBy(input)
            .ToListAsync();

            var customerListDtos = ObjectMapper.Map<List<CustomerListDto>>(customerList);

            return new PagedResultDto<CustomerListDto>(count, customerListDtos);
        }


        /// <summary>
        /// 通过指定id获取CustomerListDto信息
        /// </summary>
        [HttpGet]
        public async Task<CustomerListDto> GetById(EntityDto<long> input)
        {
            try
            {
                var entity = await _customerRepository.GetAsync(input.Id);
                entity.CustomerDetails = _customerDetailRepository.GetAll().Where(a => a.CustomerId == input.Id).ToList();

                var dto = ObjectMapper.Map<CustomerListDto>(entity);
                return dto;
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        /// <summary>
        /// 获取编辑 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

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
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task CreateOrUpdate(CreateOrUpdateCustomerInput input)
        {

            if (input.Customer.Id.HasValue)
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

        protected virtual async Task<CustomerEditDto> Create(CreateOrUpdateCustomerInput input)
        {
            try
            {
                //TODO:新增前的逻辑判断，是否允许新增

                var customerEntity = ObjectMapper.Map<Customer>(input.Customer);
                var customerDetailEntitys = ObjectMapper.Map<List<CustomerDetail>>(input.CustomerDetails);

                customerDetailEntitys.ForEach(a =>
                {
                    //a.CustomerId = customerEntity.Id;
                    a.CustomerName = customerEntity.CustomerName;
                    a.CustomerCode = customerEntity.CustomerCode;
                    a.Creator = AbpSession.UserName;
                });
                customerEntity.Creator = AbpSession.UserName;
                customerEntity.CustomerDetails = customerDetailEntitys;
                //调用领域服务
                customerEntity = await _customerManager.CreateAsync(customerEntity);
                //customerInfoEntity = await _customerDetailInfoManager.CreateAsync(customerDetailInfoEntitys);
                var dto = ObjectMapper.Map<CustomerEditDto>(customerEntity);
                return dto;
            }
            catch (Exception ex)
            {


            }
            return new CustomerEditDto();
        }

        /// <summary>
        /// 编辑
        /// </summary>

        protected virtual async Task Update(CreateOrUpdateCustomerInput input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            //var entity = await _customerRepository.GetAsync(input.Customer.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            try
            {
                var entity = await _customerRepository.GetAsync(input.Customer.Id.Value);
                entity.CustomerDetails = _customerDetailRepository.GetAll().Where(a => a.CustomerId == input.Customer.Id.Value).ToList();
                input.Customer.CustomerDetails = input.CustomerDetails;
                ObjectMapper.Map(input.Customer, entity);
                await _customerManager.UpdateAsync(entity);
            }
            catch (Exception ex)
            {

            }

        }



        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task Delete(EntityDto<long> input)
        {
            try
            {
                //TODO:删除前的逻辑判断，是否允许删除
                //await _customerManager.DeleteAsync(input.Id);

                var entity = await _customerRepository.GetAsync(input.Id);
                entity.CustomerStatus = -1;
                entity.Updator = AbpSession.UserName;
                entity.UpdateTime = DateTime.Now;
                //entity.CustomerDetails = _customerDetailRepository.GetAll().Where(a => a.CustomerId == input.Customer.Id.Value).ToList();
                //input.Customer.CustomerDetails = input.CustomerDetails;
                //ObjectMapper.Map(input.Customer, entity);
                await _customerManager.UpdateAsync(entity);
            }
            catch (Exception ex)
            {

            }
        }



        /// <summary>
        /// 批量删除Customer的方法
        /// </summary>

        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _customerManager.BatchDelete(input);
        }




        //// custom codes



        //// custom codes end

    }
}


