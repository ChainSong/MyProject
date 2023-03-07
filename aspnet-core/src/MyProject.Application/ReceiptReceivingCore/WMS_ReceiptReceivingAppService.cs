
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
using MyProject.ReceiptReceivingCore;
using MyProject.ReceiptReceivingCore.Dtos;
using MyProject.ReceiptReceivingCore.DomainService;

using MyProject.Authorization;
using Microsoft.AspNetCore.Http;
using MyProject.CommonCore.ExcelHelper;
using System.IO;
using MyProject.ReceiptReceivingCore.Factory;
using MyProject.ReceiptReceivingCore.Interface;
using MyProject.ReceiptCore;
using MyProject.ReceiptCore.DomainService;
using MyProject.TableColumns.DomainService;
using MyProject.CommonCore;
using MyProject.WarehouseCore;
using AutoMapper;

namespace MyProject.ReceiptReceivingCore
{
    /// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
    [ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
    public class WMS_ReceiptReceivingAppService : MyProjectAppServiceBase, IWMS_ReceiptReceivingAppService
    {
        /// <summary>
        ///【WMS_ReceiptReceiving】仓储层
        /// </summary>
        private readonly IRepository<WMS_ReceiptReceiving, long> _wms_receiptreceivingRepository;

        /// <summary>
		///【WMS_ReceiptDetail】仓储层
		/// </summary>
		private readonly IRepository<WMS_ReceiptDetail, long> _wms_receiptdetailRepository;
        /// <summary>
        ///【WMS_Receipt】仓储层
        /// </summary>
        private readonly IRepository<WMS_Receipt, long> _wms_receiptRepository;

        /// <summary>
        ///【WMS_Location】仓储层
        /// </summary>
        private readonly IRepository<WMS_Location, long> _wms_locationRepository;


        /// <summary>
        ///【WMS_Receipt】领域服务
        /// </summary>
        private readonly IWMS_ReceiptManager _wms_receiptManager;

        private readonly ITable_ColumnsManager _table_ColumnsManager;

        /// <summary>
        ///【WMS_ReceiptReceiving】领域服务
        /// </summary>
        private readonly IWMS_ReceiptReceivingManager _wms_receiptreceivingManager;

        public WMS_ReceiptReceivingAppService(
            IRepository<WMS_ReceiptReceiving, long> wms_receiptreceivingRepository,
            IWMS_ReceiptReceivingManager wms_receiptreceivingManager,
              IRepository<WMS_Receipt, long> wms_receiptRepository,
            IWMS_ReceiptManager wms_receiptManager,
              ITable_ColumnsManager table_ColumnsManager,
              IRepository<WMS_ReceiptDetail, long> wms_receiptdetailRepository,
               IRepository<WMS_Location, long> wms_locationRepository
        )
        {
            _wms_receiptreceivingRepository = wms_receiptreceivingRepository;
            _wms_receiptreceivingManager = wms_receiptreceivingManager;
            _wms_receiptreceivingRepository = wms_receiptreceivingRepository;
            _wms_receiptRepository = wms_receiptRepository;
            _wms_receiptManager = wms_receiptManager;
            _table_ColumnsManager = table_ColumnsManager;
            _wms_receiptdetailRepository = wms_receiptdetailRepository;
            _wms_locationRepository = wms_locationRepository;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        ///【WMS_ReceiptReceiving】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ReceiptReceivingPermissions.Node)]
        [HttpPost]
        public async Task<PagedResultDto<WMS_ReceiptReceivingListDto>> GetPaged(GetWMS_ReceiptReceivingsInput input)
        {
            var query = _wms_receiptreceivingRepository.GetAll()
                          //模糊搜索 字段ReceiptNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ReceiptNumber.Contains(input.FilterText))
                          //模糊搜索 字段ExternReceiptNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ExternReceiptNumber.Contains(input.FilterText))
                          //模糊搜索 字段ASNNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ASNNumber.Contains(input.FilterText))
                          //模糊搜索 字段CustomerName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.CustomerName.Contains(input.FilterText))
                          //模糊搜索 字段WarehouseName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.WarehouseName.Contains(input.FilterText))
                          //模糊搜索 字段LineNumber
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.LineNumber.Contains(input.FilterText))
                          //模糊搜索 字段SKU
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.SKU.Contains(input.FilterText))
                          //模糊搜索 字段UPC
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.UPC.Contains(input.FilterText))
                          //模糊搜索 字段GoodsType
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.GoodsType.Contains(input.FilterText))
                          //模糊搜索 字段GoodsName
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.GoodsName.Contains(input.FilterText))
                          //模糊搜索 字段BoxCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.BoxCode.Contains(input.FilterText))
                          //模糊搜索 字段TrayCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.TrayCode.Contains(input.FilterText))
                          //模糊搜索 字段BatchCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.BatchCode.Contains(input.FilterText))
                          //模糊搜索 字段UnitCode
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.UnitCode.Contains(input.FilterText))
                          //模糊搜索 字段Onwer
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Onwer.Contains(input.FilterText))
                          //模糊搜索 字段Area
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Area.Contains(input.FilterText))
                          //模糊搜索 字段Location
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Location.Contains(input.FilterText))
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

            var entityListDtos = ObjectMapper.Map<List<WMS_ReceiptReceivingListDto>>(entityList);

            return new PagedResultDto<WMS_ReceiptReceivingListDto>(count, entityListDtos);
        }

        /// <summary>
        ///【WMS_ReceiptReceiving】通过指定id获取MemberListDto信息
        /// </summary>
        //[AbpAuthorize(WMS_ReceiptReceivingPermissions.Node)]
        [HttpGet]
        public async Task<WMS_ReceiptReceivingListDto> GetById(EntityDto<long> input)
        {
            var entity = await _wms_receiptreceivingRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<WMS_ReceiptReceivingListDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_ReceiptReceiving】 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ReceiptReceivingPermissions.Node)]
        [HttpGet]
        public async Task<GetWMS_ReceiptReceivingForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_ReceiptReceivingForEditOutput();
            WMS_ReceiptReceivingEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _wms_receiptreceivingRepository.GetAsync(input.Id.Value);
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
        ///【WMS_ReceiptReceiving】 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ReceiptReceivingPermissions.Node)]
        [HttpPost]
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
        ///【WMS_ReceiptReceiving】新增
        /// </summary>
        //[AbpAuthorize(WMS_ReceiptReceivingPermissions.Node)]
        protected virtual async Task<WMS_ReceiptReceivingEditDto> Create(WMS_ReceiptReceivingEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_ReceiptReceiving>(input);
            //调用领域服务
            entity = await _wms_receiptreceivingManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WMS_ReceiptReceivingEditDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_ReceiptReceiving】编辑
        /// </summary>
        //[AbpAuthorize(WMS_ReceiptReceivingPermissions.Node)]
        protected virtual async Task Update(WMS_ReceiptReceivingEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var key = input.Id.Value;
            var entity = await _wms_receiptreceivingRepository.GetAsync(key);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_receiptreceivingManager.UpdateAsync(entity);
        }

        /// <summary>
        ///【WMS_ReceiptReceiving】删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ReceiptReceivingPermissions.Node)]
        [HttpGet]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_receiptreceivingManager.DeleteAsync(input.Id);
        }

        /// <summary>
        ///【WMS_ReceiptReceiving】 批量删除Member的方法
        /// </summary>
        //[AbpAuthorize(WMS_ReceiptReceivingPermissions.Node)]
        [HttpPost]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_receiptreceivingManager.BatchDelete(input);
        }

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展应用服务实现*/
        /// <summary>
        /// 接收上传文件方法
        /// </summary>
        /// <param name="file">文件内容</param>
        /// <returns>文件名称</returns>
        public async Task<string> UploadExcelFile(IFormFile file)
        {
            try
            {


                //FileDir是存储临时文件的目录，相对路径
                //private const string FileDir = "/File/ExcelTemp";
                string url = await ImprotExcel.WriteFile(file);
                var dataExcel = ExcelData.ExcelToDataTable(url, null, true);
                //1根据用户的角色 解析出Excel
                IReceiptReceivingExcelInterface factoryExcel = ReceiptReceivingExcelFactory.GetReceipt(_table_ColumnsManager);
                var data = factoryExcel.Strategy(dataExcel, AbpSession);
                 

                var entityListDtos = data.Data.TableToList<WMS_ReceiptReceivingEditDto>();
                //var entityListDtos = ObjectMapper.Map<List<WMS_ReceiptReceivingListDto>>(data.Data);

                //获取需要导入的客户，根据客户调用不同的配置方法(根据系统单号获取)
                long CustomerId = _wms_receiptRepository.GetAll().Where(a => a.ReceiptNumber == entityListDtos.First().ReceiptNumber).FirstOrDefault().CustomerId;
                //使用简单工厂定制化修改和新增的方法
                IReceiptReceivingInterface factory = ReceiptReceivingFactory.GetReceiptReceiving(_wms_receiptManager, _wms_receiptreceivingRepository, _table_ColumnsManager, _wms_receiptdetailRepository, _wms_locationRepository, CustomerId);
                var response = factory.Strategy(entityListDtos, AbpSession);

                return StatusCode.success.ToString();
            }
            catch (Exception asdas)
            {

                throw;
            }
        }


        [HttpPost]
        public async Task<List<OrderStatusDto>> ReturnReceiptReceiving(long input)
        {

            //获取客户的id
            var CustomerData = _wms_receiptRepository.GetAll().Where(a => a.Id == input).FirstOrDefault();
            long CustomerId = 0;
            if (CustomerData != null)
            {
                CustomerId = CustomerData.CustomerId;
            }
            //使用简单工厂定制化  /
            //不同的仓库存在不同的上架推荐库位的逻辑，这个地方按照实际的情况实现自己的业务逻辑，

            IReceiptReceivingReturnInterface factory = ReceiptReceivingReturnFactory.ReturnReceiptReceiving(_wms_receiptRepository, _wms_receiptdetailRepository, _wms_receiptreceivingRepository, CustomerId);
            var response = await factory.Strategy(AbpSession, input);

            return response.Data;
        }


        #endregion
    }
}
