
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
using Abp.Json;

namespace MyProject.CustomerCore
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>

    [AbpAuthorize]
    public class CustomerUserMappingAppService : MyProjectAppServiceBase, ICustomerUserMappingAppService
    {



        private readonly IRepository<CustomerUserMapping, long> _customerUserMappingRepository;

        private readonly ICustomerUserMappingManager _customerUserMappingManager;


        /// <summary>
        /// 构造函数
        ///</summary>

        public CustomerUserMappingAppService(IRepository<CustomerUserMapping, long> customerUserMappingRepository
            , ICustomerUserMappingManager customerUserMappingManager
            )
        {
            _customerUserMappingRepository = customerUserMappingRepository;
            _customerUserMappingManager = customerUserMappingManager;

        }


        /// <summary>
        /// 获取的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<PagedResultDto<CustomerUserMappingListDto>> GetPaged(GetCustomerUserMappingsInput input)
        {
            input.UserId= AbpSession.UserId.Value;
            var query = _customerUserMappingRepository.GetAll()//.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a =>
                          .WhereIf(!input.UserName.IsNullOrWhiteSpace(), a =>
                          //模糊搜索UserName
                          a.UserName == (input.UserName))
                          .WhereIf(!input.CustomerName.IsNullOrWhiteSpace(), a =>
                          //模糊搜索CustomerName
                          a.CustomerName == (input.CustomerName))
                          .WhereIf(input.UserId != 0, a =>
                            //模糊搜索UserId
                            a.UserId == (input.UserId))
                          .WhereIf(input.CustomerId != 0, a =>
                            //模糊搜索CustomerId
                            a.CustomerId == (input.CustomerId))
                           .WhereIf(input.Status != 0, a =>
                            //模糊搜索Status
                            a.Status == (input.Status))
                          ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var customerUserMappingList = await query
            .OrderBy(input.Sorting).AsNoTracking()
            .PageBy(input)
            .ToListAsync();

            var customerUserMappingListDtos = ObjectMapper.Map<List<CustomerUserMappingListDto>>(customerUserMappingList);

            return new PagedResultDto<CustomerUserMappingListDto>(count, customerUserMappingListDtos);
        }


        /// <summary>
        /// 通过指定id获取CustomerUserMappingListDto信息
        /// </summary>

        public async Task<CustomerUserMappingListDto> GetById(EntityDto<long> input)
        {
            var entity = await _customerUserMappingRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<CustomerUserMappingListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<GetCustomerUserMappingForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetCustomerUserMappingForEditOutput();
            CustomerUserMappingEditDto editDto;

            if (input.Id.HasValue)
            {


                var entity = await _customerUserMappingRepository.GetAsync(input.Id.Value);
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
        /// 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task CreateOrUpdate(CreateOrUpdateCustomerUserMappingInput input)
        {

            if (input.CustomerUserMapping.Id.HasValue)
            {
                await Update(input.CustomerUserMapping);
            }
            else
            {
                await Create(input.CustomerUserMapping);
            }
        }


        /// <summary>
        /// 新增
        /// </summary>

        protected virtual async Task<CustomerUserMappingEditDto> Create(CustomerUserMappingEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<CustomerUserMapping>(input);
            //调用领域服务
            entity = await _customerUserMappingManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<CustomerUserMappingEditDto>(entity);
            return dto;
        }

        /// <summary>
        /// 编辑
        /// </summary>

        protected virtual async Task Update(CustomerUserMappingEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _customerUserMappingRepository.GetAsync(input.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _customerUserMappingRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customerUserMappingRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除CustomerUserMapping的方法
        /// </summary>

        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _customerUserMappingManager.BatchDelete(input);
        }




        //// custom codes



        //// custom codes end

    }
}


