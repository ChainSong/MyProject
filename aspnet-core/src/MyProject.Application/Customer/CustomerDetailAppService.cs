
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
using MyProject.Customers;
using MyProject.Customers.Dtos;
//using MyProject.Customers.Exporting;
using MyProject.Customers.DomainService;
using MyProject.Authorization;

namespace MyProject.Customers
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>
    [AbpAuthorize]
    public class CustomerDetailAppService : MyProjectAppServiceBase, ICustomerDetailAppService
    {
        private readonly IRepository<CustomerDetail, long>
            _customerDetailRepository;



        private readonly ICustomerDetailManager _customerDetailManager;
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomerDetailAppService(
        IRepository<CustomerDetail, long> customerDetailRepository
            , ICustomerDetailManager customerDetailManager

            )
        {
            _customerDetailRepository = customerDetailRepository;
            _customerDetailManager = customerDetailManager;


        }


        /// <summary>
        /// 获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<PagedResultDto<CustomerDetailListDto>> GetPaged(GetCustomerDetailsInput input)
        {

            var query = _customerDetailRepository.GetAll()
                        .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a =>


                                      //模糊搜索CustomerCode
                                      a.CustomerCode.Contains(input.FilterText) &




                                      //模糊搜索CustomerName
                                      a.CustomerName.Contains(input.FilterText) &




                                      //模糊搜索Contact
                                      a.Contact.Contains(input.FilterText) &




                                      //模糊搜索TEL
                                      a.TEL.Contains(input.FilterText) &




                                      //模糊搜索Creator
                                      a.Creator.Contains(input.FilterText)




            );
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var customerDetailList = await query
            .OrderBy(input.Sorting).AsNoTracking()
            .PageBy(input)
            .ToListAsync();

            var customerDetailListDtos = ObjectMapper.Map<List<CustomerDetailListDto>>(customerDetailList);

            return new PagedResultDto<CustomerDetailListDto>(count, customerDetailListDtos);
        }


        /// <summary>
        /// 通过指定id获取CustomerDetailListDto信息
        /// </summary>

        public async Task<CustomerDetailListDto> GetById(EntityDto<long> input)
        {
            var entity = await _customerDetailRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<CustomerDetailListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<GetCustomerDetailForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetCustomerDetailForEditOutput();
            CustomerDetailEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _customerDetailRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<CustomerDetailEditDto>(entity);
            }
            else
            {
                editDto = new CustomerDetailEditDto();
            }



            output.CustomerDetail = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task CreateOrUpdate(CreateOrUpdateCustomerDetailInput input)
        {

            if (input.CustomerDetail.Id!=0)
            {
                await Update(input.CustomerDetail);
            }
            else
            {
                await Create(input.CustomerDetail);
            }
        }


        /// <summary>
        /// 新增
        /// </summary>

        protected virtual async Task<CustomerDetailEditDto> Create(CustomerDetailEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<CustomerDetail>(input);
            //调用领域服务
            entity = await _customerDetailManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<CustomerDetailEditDto>(entity);
            return dto;
        }

        /// <summary>
        /// 编辑
        /// </summary>

        protected virtual async Task Update(CustomerDetailEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _customerDetailRepository.GetAsync(input.Id);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _customerDetailManager.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customerDetailManager.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除CustomerDetail的方法
        /// </summary>

        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _customerDetailManager.BatchDelete(input);
        }




        //// custom codes



        //// custom codes end

    }
}


