
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
using MyProject.Common.SnowflakeCommon;
using MyProject.ASNCore.Factory;
using MyProject.ASNCore.Interface;
using Microsoft.AspNetCore.Http;
using Magicodes.ExporterAndImporter.Excel;
using System.IO;
using Magicodes.ExporterAndImporter.Core;
using MyProject.ReceiptCore;
using MyProject.ReceiptCore.DomainService;
using MyProject.WarehouseCore.DomainService;
using MyProject.CustomerCore.DomainService;
using MyProject.CommonCore.ExcelHelper;
using MyProject.ASNCore.Strategy;
using MyProject.TableColumns.DomainService;
using MyProject.CommonCore;
using MyProject.ASNCore.Enumerate;
using System.Net.Http;
using Nacos.V2;
using System.Net;
using Nacos.AspNetCore.V2;
using Microsoft.Extensions.Options;
using System.Text;
using RestSharp;
using MyProject.WebApiClient;
using WebApiClient;

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

        private readonly INacosNamingService _svc;
        private readonly IHttpClientFactory _factory;

        /// <summary>
        /// httpClient
        /// </summary>
        private readonly IHttpClientFactory _httpClient;
        /// <summary>
        /// 发现服务
        /// </summary>
        private readonly INacosNamingService _nacosNamingService;
        /// <summary>
        /// 配置
        /// </summary>
        private readonly NacosAspNetOptions _nacosOption;

        /// <summary>
        ///【WMS_ASN】仓储层
        /// </summary>
        private readonly IRepository<WMS_ASN, long> _wms_asnRepository;
        /// <summary>
        ///【WMS_ASNDetail】仓储层
        /// </summary>
        private readonly IRepository<WMS_ASNDetail, long> _wms_asndetailRepository;
        /// <summary>
        ///【WMS_ASN】领域服务
        /// </summary>
        private readonly IWMS_ASNManager _wms_asnManager;

        /// <summary>
        ///【WMS_Receipt】仓储层
        /// </summary>
        private readonly IRepository<WMS_Receipt, long> _wms_receiptRepository;

        /// <summary>
        ///【WMS_Receipt】领域服务
        /// </summary>
        private readonly IWMS_ReceiptManager _wms_receiptManager;

        private readonly IService _IService;



        /// <summary>
        ///【WarehouseUserMapping】领域服务
        /// </summary>
        private readonly IWarehouseUserMappingManager _warehouseusermappingManager;

        private readonly ITable_ColumnsManager _table_ColumnsManager;

        protected IHttpContextAccessor httpContext;

        /// <summary>
        ///【CustomerUserMapping】领域服务
        /// </summary>
        private readonly ICustomerUserMappingManager _customerusermappingManager;
        public WMS_ASNAppService(
            IRepository<WMS_ASN, long> wms_asnRepository,
            IWMS_ASNManager wms_asnManager,
            IRepository<WMS_ASNDetail, long> wms_asndetailRepository,
                IRepository<WMS_Receipt, long> wms_receiptRepository,
            IWMS_ReceiptManager wms_receiptManager,
            ITable_ColumnsManager table_ColumnsManager,
            IWarehouseUserMappingManager warehouseusermappingManager,
            ICustomerUserMappingManager customerusermappingManager
            //INacosNamingService svc, IHttpClientFactory factory,
            //IHttpClientFactory httpClient
            //, INacosNamingService nacosNamingService,
            //IOptions<NacosAspNetOptions> nacosOption,
            //IHttpContextAccessor httpContextAccessor,
            //IService iService
        )
        {
            _wms_asnRepository = wms_asnRepository;
            _wms_asnManager = wms_asnManager;
            _wms_asndetailRepository = wms_asndetailRepository;
            _wms_receiptRepository = wms_receiptRepository;
            _wms_receiptManager = wms_receiptManager;
            //_wms_receiptManager = wms_receiptManager;
            _warehouseusermappingManager = warehouseusermappingManager;
            _customerusermappingManager = customerusermappingManager;
            _table_ColumnsManager = table_ColumnsManager;
            //_svc = svc;
            //_factory = factory;

            //_httpClient = httpClient;
            //_nacosNamingService = nacosNamingService;
            //_nacosOption = nacosOption.Value;
            //httpContext = httpContextAccessor;
            //_IService = iService;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        /// 组装URL
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <param name="groupName">分组名称</param>
        /// <param name="relativeUrl">请求路径</param>
        /// <returns></returns>
        //private async Task<string> AssembleUrl(string serviceName, string groupName, string relativeUrl)
        //{
        //    var instance = await _nacosNamingService.SelectOneHealthyInstance(serviceName, groupName);
        //    var host = string.Format("{0}:{1}", instance.Ip, instance.Port);
        //    var http = instance.Metadata.TryGetValue("secure", out _) ? "https" : "http";
        //    //都是走配置文件
        //    //var http = _nacosOption.Secure ? "https" : "http";
        //    if (string.IsNullOrWhiteSpace(http) || string.IsNullOrWhiteSpace(host))
        //    {
        //        return "";
        //    }
        //    return string.Format("{0}://{1}/{2}", http, host, relativeUrl);
        //}

        /// <summary>
        ///【WMS_ASN】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        //[AbpAuthorize(WMS_ASNPermissions.Node)]
        public async Task<PagedResultDto<WMS_ASNListDto>> GetPaged(GetWMS_ASNsInput input)
        {

            //获取请求路径
            //var url = await this.AssembleUrl("MyProject", "DEFAULT_GROUP", "api/services/app/WMS_ASN/GetPaged");
            //var _IServiceData = _IService.PatchAsync(url, input);
            //return _IServiceData.Result;


            var query = _wms_asnRepository.GetAll()
            //添加查询限制（默认必有的查询条件）
              .Where(a => _warehouseusermappingManager.Query().Where(b => b.UserId == AbpSession.UserId).Select(c => c.WarehouseId).Contains(a.WarehouseId))
             .Where(a => _customerusermappingManager.Query().Where(b => b.UserId == AbpSession.UserId).Select(c => c.CustomerId).Contains(a.CustomerId))
            //模糊搜索 字段ASNNumber
            .WhereIf(!input.ASNNumber.IsNullOrWhiteSpace(), a => a.ASNNumber == (input.ASNNumber))
            //模糊搜索 字段ExternReceiptNumber
            .WhereIf(!input.ExternReceiptNumber.IsNullOrWhiteSpace(), a => a.ExternReceiptNumber == (input.ExternReceiptNumber))
            //模糊搜索 字段CustomerID
            .WhereIf(!input.CustomerName.IsNullOrWhiteSpace(), a => a.CustomerName == (input.CustomerName))
            //模糊搜索 字段CustomerName
            .WhereIf(input.CustomerId != 0, a => a.CustomerId == (input.CustomerId))
            //模糊搜索 WarehouseID
            .WhereIf(input.WarehouseId != 0, a => a.WarehouseId == (input.WarehouseId))
            //模糊搜索 WarehouseName
            .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a => a.WarehouseName == (input.WarehouseName))
            .WhereIf(input.ExpectDate != null && input.ExpectDate.Length > 0, a => a.ExpectDate >= (input.ExpectDate[0]))
            .WhereIf(input.ExpectDate != null && input.ExpectDate.Length > 1, a => a.ExpectDate <= (input.ExpectDate[1]))
            .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a => a.WarehouseName == (input.WarehouseName))
            //模糊搜索 字段ReceiptStatus
            .WhereIf(input.ASNStatus != 0, a => a.ASNStatus == (input.ASNStatus))
            //模糊搜索 字段ReceiptType
            .WhereIf(!input.ReceiptType.IsNullOrWhiteSpace(), a => a.ReceiptType == (input.ReceiptType))
            //模糊搜索 字段Contact
            .WhereIf(!input.Contact.IsNullOrWhiteSpace(), a => a.Contact.Contains(input.Contact))
            //模糊搜索 字段ContactInfo
            .WhereIf(!input.ContactInfo.IsNullOrWhiteSpace(), a => a.ContactInfo.Contains(input.ContactInfo))
            //模糊搜索 字段Remark
            .WhereIf(!input.Remark.IsNullOrWhiteSpace(), a => a.Remark.Contains(input.Remark))
            //模糊搜索 字段Creator
            .WhereIf(!input.Creator.IsNullOrWhiteSpace(), a => a.Creator.Contains(input.Creator))
            //模糊搜索 字段Updator
            .WhereIf(!input.Updator.IsNullOrWhiteSpace(), a => a.Updator.Contains(input.Updator))
            //模糊搜索 字段Str1
            .WhereIf(!input.Str1.IsNullOrWhiteSpace(), a => a.Str1.Contains(input.Str1))
            //模糊搜索 字段Str2
            .WhereIf(!input.Str2.IsNullOrWhiteSpace(), a => a.Str2.Contains(input.Str2))
            //模糊搜索 字段Str3
            .WhereIf(!input.Str3.IsNullOrWhiteSpace(), a => a.Str3.Contains(input.Str3))
            //模糊搜索 字段Str4
            .WhereIf(!input.Str4.IsNullOrWhiteSpace(), a => a.Str4.Contains(input.Str4))
            //模糊搜索 字段Str5
            .WhereIf(!input.Str5.IsNullOrWhiteSpace(), a => a.Str5.Contains(input.Str5))
            //模糊搜索 字段Str6
            .WhereIf(!input.Str6.IsNullOrWhiteSpace(), a => a.Str6.Contains(input.Str6))
            //模糊搜索 字段Str7
            .WhereIf(!input.Str7.IsNullOrWhiteSpace(), a => a.Str7.Contains(input.Str7))
            //模糊搜索 字段Str8
            .WhereIf(!input.Str8.IsNullOrWhiteSpace(), a => a.Str8.Contains(input.Str8))
            //模糊搜索 字段Str9
            .WhereIf(!input.Str9.IsNullOrWhiteSpace(), a => a.Str9.Contains(input.Str9))
            //模糊搜索 字段Str10
            .WhereIf(!input.Str10.IsNullOrWhiteSpace(), a => a.Str10.Contains(input.Str10))
            //模糊搜索 字段Str11
            .WhereIf(!input.Str11.IsNullOrWhiteSpace(), a => a.Str11.Contains(input.Str11))
            //模糊搜索 字段Str12
            .WhereIf(!input.Str12.IsNullOrWhiteSpace(), a => a.Str12.Contains(input.Str12))
            //模糊搜索 字段Str13
            .WhereIf(!input.Str13.IsNullOrWhiteSpace(), a => a.Str13.Contains(input.Str13))
            //模糊搜索 字段Str14
            .WhereIf(!input.Str14.IsNullOrWhiteSpace(), a => a.Str14.Contains(input.Str14))
            //模糊搜索 字段Str15
            .WhereIf(!input.Str15.IsNullOrWhiteSpace(), a => a.Str15.Contains(input.Str15))
            //模糊搜索 字段Str16
            .WhereIf(!input.Str16.IsNullOrWhiteSpace(), a => a.Str16.Contains(input.Str16))
            //模糊搜索 字段Str17
            .WhereIf(!input.Str17.IsNullOrWhiteSpace(), a => a.Str17.Contains(input.Str17))
            //模糊搜索 字段Str18
            .WhereIf(!input.Str18.IsNullOrWhiteSpace(), a => a.Str18.Contains(input.Str18))
            //模糊搜索 字段Str19
            .WhereIf(!input.Str19.IsNullOrWhiteSpace(), a => a.Str19.Contains(input.Str19))
            //模糊搜索 字段Str20
            .WhereIf(!input.Str20.IsNullOrWhiteSpace(), a => a.Str20.Contains(input.Str20))

            ;
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderByDescending(a => a.Id).AsNoTracking()
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
            //var entity = await _wms_asnRepository.GetAsync(input.Id);
            var entity = await _wms_asnRepository.GetAllIncluding(a => a.ASNDetails).Where(b => b.Id == input.Id).FirstAsync();
            //entity.ASNDetails = _wms_asndetailRepository.GetAllList(a => a.ASNId == input.Id);
            var dto = ObjectMapper.Map<WMS_ASNListDto>(entity);
            return dto;

            //var entity = await _wms_asnRepository.GetAllIncluding(a => a.ASNDetails).Where(b => b.Id == input.Id).FirstAsync();
            //var dto = ObjectMapper.Map<WMS_ASNListDto>(entity);
            //return dto;
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
        public async Task<OrderStatusDto> CreateOrUpdate(CreateOrUpdateWMS_ASNInput input)
        {
            //使用简单工厂定制化修改和新增的方法
            //IASNInterface factory = ASNFactory.GetASN(_wms_asnRepository, _wms_asndetailRepository, input.WMS_ASN.CustomerId);
            //var response = factory.Strategy(input, AbpSession);
            if (input.WMS_ASN.Id.HasValue)
            {
                return await Update(input.WMS_ASN);
            }
            else
            {
                return await Create(input.WMS_ASN);
            }
        }
        /// <summary>
        ///【WMS_ASN】新增
        /// </summary>
        //[AbpAuthorize(WMS_ASNPermissions.Node)]
        protected virtual async Task<OrderStatusDto> Create(WMS_ASNEditDto input)
        {
            List<WMS_ASNEditDto> entityListDtos = new List<WMS_ASNEditDto>();
            entityListDtos.Add(input);
            //使用简单工厂定制化修改和新增的方法
            IASNInterface factory = ASNFactory.CreateASN(_wms_asnRepository, _wms_asndetailRepository, _warehouseusermappingManager, _customerusermappingManager, input.CustomerId);
            var response = factory.Strategy(entityListDtos, AbpSession);
            return response.Data.FirstOrDefault();

            //input.ASNNumber = SnowFlakeHelper.GetSnowInstance().NextId().ToString();
            ////TODO:新增前的逻辑判断，是否允许新增
            //int LineNumber = 1;
            //foreach (var item in input.ASNDetails)
            //{
            //    if (!string.IsNullOrWhiteSpace(item.SKU))
            //    {
            //        item.CustomerName = input.CustomerName;
            //        item.CustomerId = input.CustomerId;
            //        item.WarehouseName = input.WarehouseName;
            //        item.WarehouseId = input.WarehouseId;
            //        item.ASNNumber = input.ASNNumber;
            //        item.LineNumber = LineNumber.ToString().PadLeft(5, '0');
            //        item.ExternReceiptNumber = input.ExternReceiptNumber;
            //        item.Creator = AbpSession.UserName;
            //    }
            //}
            //input.ASNStatus = (int)ASNStatusCode.NewASN;
            //input.Contact = AbpSession.UserName;
            //var entity = ObjectMapper.Map<WMS_ASN>(input);
            ////调用领域服务
            //entity = await _wms_asnManager.CreateAsync(entity);

            ////var dto = ObjectMapper.Map<WMS_ASNEditDto>(entity);
            //if (entity != null && !string.IsNullOrEmpty(entity.ExternReceiptNumber))
            //{
            //    return new OrderStatusDto() { Id = entity.Id, ExternOrder = entity.ExternReceiptNumber, SystemOrder = entity.ASNNumber, Code = StatusCode.success };
            //}
            //else
            //{
            //    return new OrderStatusDto() { Id = entity.Id, ExternOrder = entity.ExternReceiptNumber, SystemOrder = entity.ASNNumber, Code = StatusCode.error };
            //}

        }

        /// <summary>
        ///【WMS_ASN】编辑
        /// </summary>
        //[AbpAuthorize(WMS_ASNPermissions.Node)]
        protected virtual async Task<OrderStatusDto> Update(WMS_ASNEditDto input)
        {
            int LineNumber = 1;
            foreach (var item in input.ASNDetails)
            {
                item.CustomerName = input.CustomerName;
                item.CustomerId = input.CustomerId;
                item.WarehouseName = input.WarehouseName;
                item.WarehouseId = input.WarehouseId;
                item.ASNNumber = input.ASNNumber;
                item.ExternReceiptNumber = input.ExternReceiptNumber;
                item.LineNumber = LineNumber.ToString().PadLeft(5, '0');
                item.Updator = AbpSession.UserName;
                item.UpdateTime = DateTime.Now;
            }

            //TODO:更新前的逻辑判断，是否允许更新
            var key = input.Id.Value;
            var entity = await _wms_asnRepository.GetAsync(key);
            if (entity != null && entity.ASNStatus == (int)ASNStatusEnum.新增)
            {
                //  input.MapTo(entity);
                //将input属性的值赋值到entity中
                ObjectMapper.Map(input, entity);
                await _wms_asnManager.UpdateAsync(entity);
                return new OrderStatusDto()
                {
                    Id = entity.Id,
                    ExternOrder = entity.ExternReceiptNumber,
                    SystemOrder = entity.ASNNumber,
                    StatusCode = StatusCode.success,
                    //StatusMsg = StatusCode.success.ToString(),
                    Msg = "成功"
                };
            }
            else
            {
                return new OrderStatusDto()
                {
                    Id = entity.Id,
                    ExternOrder = entity.ExternReceiptNumber,
                    SystemOrder = entity.ASNNumber,
                    StatusCode = StatusCode.warning,
                    //StatusMsg = StatusCode.warning.ToString(),
                    Msg = "订单状态异常"
                };

            }

        }




        /// <summary>
        ///【WMS_ASN】删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ASNPermissions.Node)]
        [HttpGet]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_asndetailRepository.DeleteAsync(a => a.ASNId == input.Id);
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

        /// <summary>
        /// 接收上传文件方法
        /// </summary>
        /// <param name="file">文件内容</param>
        /// <returns>文件名称</returns>
        public async Task<List<OrderStatusDto>> UploadExcelFile(IFormFile file)
        {
            //FileDir是存储临时文件的目录，相对路径
            //private const string FileDir = "/File/ExcelTemp";
            string url = await ImprotExcel.WriteFile(file);
            var dataExcel = ExcelData.ExcelToDataTable(url, null, true);
            //var aaaaa = ExcelData.GetData<DataSet>(url);
            //1根据用户的角色 解析出Excel
            IASNExcelInterface factoryExcel = ASNExcelFactory.GetReceipt(_table_ColumnsManager);
            var data = factoryExcel.Strategy(dataExcel, AbpSession);
            var entityListDtos = data.Data.TableToList<WMS_ASNEditDto>();
            var entityDetailListDtos = data.Data.TableToList<WMS_ASNDetailEditDto>();
            if (entityListDtos.Count > 0)
            {
                //将散装的主表和明细表 组合到一起 
                List<WMS_ASNEditDto> ASNs = entityListDtos.GroupBy(x => x.ExternReceiptNumber).Select(x => x.First()).ToList();
                ASNs.ForEach(item =>
                {
                    item.ASNDetails = entityDetailListDtos.Where(a => a.ExternReceiptNumber == item.ExternReceiptNumber).ToList();
                });

                //获取需要导入的客户，根据客户调用不同的配置方法(根据系统单号获取)
                var CustomerData = _customerusermappingManager.Query().Where(a => a.CustomerName == entityListDtos.First().CustomerName).FirstOrDefault();
                long CustomerId = 0;
                if (CustomerData != null)
                {
                    CustomerId = CustomerData.CustomerId;
                }
                //long CustomerId = _wms_asnRepository.GetAll().Where(a => a.ASNNumber == entityListDtos.First().ASNNumber).FirstOrDefault().CustomerId;
                //使用简单工厂定制化修改和新增的方法
                IASNInterface factory = ASNFactory.CreateASN(_wms_asnRepository, _wms_asndetailRepository, _warehouseusermappingManager, _customerusermappingManager, CustomerId);
                var response = factory.Strategy(entityListDtos, AbpSession);
                return response.Data;
            }
            else
            {
                return new List<OrderStatusDto>();
            }
            //}


            #endregion
        }


        public async Task<OrderStatusDto> ASNForReceipt(List<long> input)
        {
            //var entity = _wms_asnRepository.GetAll().Where(a => input.Contains(a.Id)).FirstOrDefaultAsync();
            var CustomerData = _wms_asnRepository.GetAll().Where(a => a.Id == input.First()).FirstOrDefault();
            long CustomerId = 0;
            if (CustomerData != null)
            {
                CustomerId = CustomerData.CustomerId;
            }
            //使用简单工厂定制化修改和新增的方法
            IASNForReceiptInterface factory = ASNForReceiptFactory.ASNForReceipt(_wms_asnRepository, _wms_asndetailRepository, _wms_receiptRepository, CustomerId);
            var response = factory.Strategy(input, AbpSession);
            //if (response.Code == StatusCode.success)
            //{
            //    response.Data.WMS_Receipts.ForEach(a =>
            //{
            //    a.Creator = AbpSession.UserName;
            //    a.CreationTime = DateTime.Now;
            //    a.WMS_ReceiptDetails.ForEach(b =>
            //    {
            //        b.Creator = AbpSession.UserName;
            //        b.CreationTime = DateTime.Now;
            //    });
            //});
            //    var entityReceipt = ObjectMapper.Map<List<WMS_Receipt>>(response.Data.WMS_Receipts);
            //    //var entityReceipts = ObjectMapper.Map<WMS_Receipt>(response.Data.WMS_Receipts[0]);
            //    await _wms_receiptManager.BulkInsert(entityReceipt);
            //    //调用领域服务
            //    //插入入库单
            //    //修改预入库单状态
            //    //默认全部转换成入库单，将ASN 的状态转换成10
            //    await _wms_asnManager.BatchUpdateStatus(entityASN, ASNStatusCode.WholeReceipt);
            return response.Data.FirstOrDefault();
            //var dto = ObjectMapper.Map<WMS_ReceiptEditDto>(entity);
            //}
            //else
            //{
            //    return new Response() { Code = response.Code, Msg = response.Msg };
            //}

            //entity.ASNDetails = _wms_asndetailRepository.GetAllList(a => a.ASNId == input.Id);
            //var dto = ObjectMapper.Map<WMS_ASNListDto>(entity);

            //_wms_receiptManager.
        }
    }
}
