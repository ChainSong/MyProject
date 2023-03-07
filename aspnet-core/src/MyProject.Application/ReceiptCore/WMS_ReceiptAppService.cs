
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
using MyProject.ReceiptCore;
using MyProject.ReceiptCore.Dtos;
using MyProject.ReceiptCore.DomainService;
using MyProject.Authorization;
using MyProject.ASNCore;
using MyProject.ReceiptCore.Interface;
using MyProject.ReceiptCore.Factory;
using MyProject.CommonCore;
using MyProject.ASNCore.DomainService;
using MyProject.WarehouseCore.DomainService;
using MyProject.CustomerCore.DomainService;
using Abp.Runtime.Caching;
using MyProject.ReceiptCore.Strategy;
using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using System.IO;
using Magicodes.ExporterAndImporter.Excel.AspNetCore;
using MyProject.TableColumns;
using MyProject.TableColumns.DomainService;
using MyProject.ReceiptCore.Enumerate;
using MyProject.InventoryCore;
using MyProject.ReceiptReceivingCore;

namespace MyProject.ReceiptCore
{
    /// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
    [ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
    public class WMS_ReceiptAppService : MyProjectAppServiceBase, IWMS_ReceiptAppService
    {
        /// <summary>
        ///【WMS_Receipt】仓储层
        /// </summary>
        private readonly IRepository<WMS_Receipt, long> _wms_receiptRepository;

        /// <summary>
        ///【WMS_Receipt】领域服务
        /// </summary>
        private readonly IWMS_ReceiptManager _wms_receiptManager;

        /// <summary>
        ///【WMS_ReceiptReceiving】仓储层
        /// </summary>
        private readonly IRepository<WMS_ReceiptReceiving, long> _wms_receiptreceivingRepository;

        /// <summary>
        ///【WMS_ASN】仓储层
        /// </summary>
        //private readonly IRepository<WMS_ASN, long> _wms_asnRepository;
        /// <summary>
        ///【WMS_ReceiptDetail】仓储层
        /// </summary>
        private readonly IRepository<WMS_ReceiptDetail, long> _wms_receiptdetailRepository;
        /// <summary>
        ///【WarehouseUserMapping】领域服务
        /// </summary>
        private readonly IWarehouseUserMappingManager _warehouseusermappingManager;

        private readonly ICacheManager _cacheManage;
        /// <summary>
        ///【CustomerUserMapping】领域服务
        /// </summary>
        private readonly ICustomerUserMappingManager _customerusermappingManager;
        /// <summary>
        ///【WMS_ASN】领域服务
        /// </summary>
        //private readonly IWMS_ASNManager _wms_asnManager;

        //private readonly IRepository<Table_Columns, long> _table_ColumnsRepository;

        private readonly ITable_ColumnsManager _table_ColumnsManager;

        /// <summary>
        ///【WMS_Inventory_Usable】仓储层
        /// </summary>
        private readonly IRepository<WMS_Inventory_Usable, long> _wms_inventory_usableRepository;

        /// <summary>
        ///【WMS_ASNDetail】仓储层
        /// </summary>
        private readonly IRepository<WMS_ASNDetail, long> _wms_asndetailRepository;

        /// <summary>
        ///【WMS_ASN】仓储层
        /// </summary>
        private readonly IRepository<WMS_ASN, long> _wms_asnRepository;

        private readonly ITable_ColumnsDetailManager _table_ColumnsDetailManager;

        public WMS_ReceiptAppService(
            IRepository<WMS_Receipt, long> wms_receiptRepository,
            IWMS_ReceiptManager wms_receiptManager,
            //IRepository<WMS_ASN, long> wms_asnRepository,
            IWMS_ASNManager wms_asnManager,
            ICacheManager cacheManage,
            ITable_ColumnsManager table_ColumnsManager,
            IWarehouseUserMappingManager warehouseusermappingManager,
            ICustomerUserMappingManager customerusermappingManager,
            IRepository<WMS_ReceiptReceiving, long> wms_receiptreceivingRepository,
            IRepository<WMS_Inventory_Usable, long> wms_inventory_usableRepository,
            IRepository<WMS_ReceiptDetail, long> wms_receiptdetailRepository,
            IRepository<WMS_ASN, long> wms_asnRepository,
            IRepository<WMS_ASNDetail, long> wms_asndetailRepository,
            ITable_ColumnsDetailManager table_ColumnsDetailManager
        )
        {
            _wms_receiptRepository = wms_receiptRepository;
            _wms_receiptManager = wms_receiptManager;
            //_wms_asnRepository = wms_asnRepository;
            //_wms_asnManager = wms_asnManager;
            _warehouseusermappingManager = warehouseusermappingManager;
            _customerusermappingManager = customerusermappingManager;
            _cacheManage = cacheManage;
            _table_ColumnsManager = table_ColumnsManager;
            _wms_receiptreceivingRepository = wms_receiptreceivingRepository;
            _wms_inventory_usableRepository = wms_inventory_usableRepository;
            _wms_receiptdetailRepository = wms_receiptdetailRepository;
            _wms_asnRepository = wms_asnRepository;
            _wms_asndetailRepository = wms_asndetailRepository;
            _table_ColumnsDetailManager = table_ColumnsDetailManager;

        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        ///【WMS_Receipt】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ReceiptPermissions.Node)]
        [HttpPost]
        public async Task<PagedResultDto<WMS_ReceiptListDto>> GetPaged(GetWMS_ReceiptsInput input)
        {
            var query = _wms_receiptRepository.GetAll()
                           //添加查询限制（默认必有的查询条件）
                           .Where(a => _warehouseusermappingManager.Query().Where(b => b.UserId == AbpSession.UserId).Select(c => c.WarehouseId).Contains(a.WarehouseId))
                           .Where(a => _customerusermappingManager.Query().Where(b => b.UserId == AbpSession.UserId).Select(c => c.CustomerId).Contains(a.CustomerId))

                          //模糊搜索 字段ASNNumber
                          .WhereIf(!input.ASNNumber.IsNullOrWhiteSpace(), a => a.ASNNumber == (input.ASNNumber))
                          //模糊搜索 字段ReceiptNumber
                          .WhereIf(!input.ReceiptNumber.IsNullOrWhiteSpace(), a => a.ReceiptNumber == (input.ReceiptNumber))
                          //模糊搜索 字段ExternReceiptNumber
                          .WhereIf(!input.ExternReceiptNumber.IsNullOrWhiteSpace(), a => a.ExternReceiptNumber == (input.ExternReceiptNumber))
                          //模糊搜索 字段CustomerName
                          .WhereIf(input.CustomerId != 0, a => a.CustomerId == (input.CustomerId))
                          //模糊搜索 WarehouseID
                          .WhereIf(input.WarehouseId != 0, a => a.WarehouseId == (input.WarehouseId))
                          //模糊搜索 WarehouseName
                          .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a => a.WarehouseName == (input.WarehouseName))
                          .WhereIf(input.ReceiptTime != null && input.ReceiptTime.Length > 0, a => a.ReceiptTime >= (input.ReceiptTime[0]))
                          .WhereIf(input.ReceiptTime != null && input.ReceiptTime.Length > 1, a => a.ReceiptTime <= (input.ReceiptTime[1]))
                          .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a => a.WarehouseName == (input.WarehouseName))
                          //模糊搜索 字段ReceiptStatus
                          .WhereIf(input.ReceiptStatus != 0, a => a.ReceiptStatus == (input.ReceiptStatus))
                          //模糊搜索 字段ReceiptType
                          .WhereIf(!input.ReceiptType.IsNullOrWhiteSpace(), a => a.ReceiptType == (input.ReceiptType))
                          //模糊搜索 字段Contact
                          .WhereIf(!input.Contact.IsNullOrWhiteSpace(), a => a.Contact == (input.Contact))
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

            var entityListDtos = ObjectMapper.Map<List<WMS_ReceiptListDto>>(entityList);

            return new PagedResultDto<WMS_ReceiptListDto>(count, entityListDtos);
        }

        /// <summary>
        ///【WMS_Receipt】通过指定id获取MemberListDto信息
        /// </summary>
        //[AbpAuthorize(WMS_ReceiptPermissions.Node)]
        [HttpGet]
        public async Task<WMS_ReceiptListDto> GetById(EntityDto<long> input)
        {
            var entity = await _wms_receiptRepository.GetAllIncluding(a => a.ReceiptDetails).Where(b => b.Id == input.Id).FirstAsync();

            var dto = ObjectMapper.Map<WMS_ReceiptListDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_Receipt】 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ReceiptPermissions.Node)]
        [HttpPost]
        public async Task<GetWMS_ReceiptForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_ReceiptForEditOutput();
            WMS_ReceiptEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _wms_receiptRepository.GetAsync(input.Id.Value);
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
        ///【WMS_Receipt】 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ReceiptPermissions.Node)]
        [HttpPost]
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
        ///【WMS_Receipt】新增
        /// </summary>
        //[AbpAuthorize(WMS_ReceiptPermissions.Node)]
        protected virtual async Task<WMS_ReceiptEditDto> Create(WMS_ReceiptEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<WMS_Receipt>(input);
            //调用领域服务
            entity = await _wms_receiptManager.CreateAsync(entity);

            var dto = ObjectMapper.Map<WMS_ReceiptEditDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_Receipt】编辑
        /// </summary>
        //[AbpAuthorize(WMS_ReceiptPermissions.Node)]
        protected virtual async Task Update(WMS_ReceiptEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var key = input.Id.Value;
            var entity = await _wms_receiptRepository.GetAsync(key);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_receiptManager.UpdateAsync(entity);
        }

        /// <summary>
        ///【WMS_Receipt】删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ReceiptPermissions.Node)]
        [HttpGet]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_receiptManager.DeleteAsync(input.Id);
        }
        /// <summary>
        ///【WMS_Receipt】 批量删除Member的方法
        /// </summary>
        //[AbpAuthorize(WMS_ReceiptPermissions.Node)]
        [HttpPost]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_receiptManager.BatchDelete(input);
        }

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展应用服务实现*/
        /// <summary>
        ///【WMS_Receipt】获取的分页列表信息(上架单页面显示)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_ReceiptPermissions.Node)]
        [HttpPost]
        public async Task<PagedResultDto<WMS_ReceiptListDto>> GetReceiptReceivingPaged(GetWMS_ReceiptsInput input)
        {
            var query = _wms_receiptRepository.GetAll()
                          //添加查询限制（默认必有的查询条件）
                          .Where(a => _warehouseusermappingManager.Query().Where(b => b.UserId == AbpSession.UserId).Select(c => c.WarehouseId).Contains(a.WarehouseId))
                          .Where(a => _customerusermappingManager.Query().Where(b => b.UserId == AbpSession.UserId).Select(c => c.CustomerId).Contains(a.CustomerId))
                          .Where(a => a.ReceiptStatus >= (int)ReceiptStatusEnum.上架)

                          //模糊搜索 字段ASNNumber
                          .WhereIf(!input.ASNNumber.IsNullOrWhiteSpace(), a => a.ASNNumber == (input.ASNNumber))
                          //模糊搜索 字段ReceiptNumber
                          .WhereIf(!input.ReceiptNumber.IsNullOrWhiteSpace(), a => a.ReceiptNumber == (input.ReceiptNumber))
                          //模糊搜索 字段ExternReceiptNumber
                          .WhereIf(!input.ExternReceiptNumber.IsNullOrWhiteSpace(), a => a.ExternReceiptNumber == (input.ExternReceiptNumber))
                          //模糊搜索 字段CustomerName
                          .WhereIf(input.CustomerId != 0, a => a.CustomerId == (input.CustomerId))
                          //模糊搜索 WarehouseID
                          .WhereIf(input.WarehouseId != 0, a => a.WarehouseId == (input.WarehouseId))
                          //模糊搜索 WarehouseName
                          .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a => a.WarehouseName == (input.WarehouseName))
                          .WhereIf(input.ReceiptTime != null && input.ReceiptTime.Length > 0, a => a.ReceiptTime >= (input.ReceiptTime[0]))
                          .WhereIf(input.ReceiptTime != null && input.ReceiptTime.Length > 1, a => a.ReceiptTime <= (input.ReceiptTime[1]))
                          .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a => a.WarehouseName == (input.WarehouseName))
                          //模糊搜索 字段ReceiptStatus
                          .WhereIf(input.ReceiptStatus != 0, a => a.ReceiptStatus == (input.ReceiptStatus))
                          //模糊搜索 字段ReceiptType
                          .WhereIf(!input.ReceiptType.IsNullOrWhiteSpace(), a => a.ReceiptType == (input.ReceiptType))
                          //模糊搜索 字段Contact
                          .WhereIf(!input.Contact.IsNullOrWhiteSpace(), a => a.Contact == (input.Contact))
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

            var entityListDtos = ObjectMapper.Map<List<WMS_ReceiptListDto>>(entityList);

            return new PagedResultDto<WMS_ReceiptListDto>(count, entityListDtos);
        }


        /// <summary>
        ///【WMS_Receipt】通过指定id获取MemberListDto信息
        /// </summary>
        //[AbpAuthorize(WMS_ReceiptPermissions.Node)]
        [HttpGet]
        public async Task<WMS_ReceiptListDto> GetReceiptReceivingById(EntityDto<long> input)
        {
            var entity = await _wms_receiptRepository.GetAllIncluding(a => a.ReceiptReceivings).Where(b => b.Id == input.Id).FirstAsync();
            var dto = ObjectMapper.Map<WMS_ReceiptListDto>(entity);
            return dto;
        }
        /// <summary>
        ///【WMS_Receipt】通过id 加入库存
        /// </summary>
        //[AbpAuthorize(WMS_ReceiptPermissions.Node)]
        [HttpGet]
        public async Task<OrderStatusDto> AddInventory(EntityDto<long> input)
        {
            var receipt = _wms_receiptRepository.GetAll().Where(a => a.Id == input.Id).FirstOrDefaultAsync();
            if (receipt.Result == null)
            {
                return new OrderStatusDto() { Msg = "订单不存在" };
            }
            if (receipt.Result.ReceiptStatus != (int)ReceiptStatusEnum.上架)
            {
                return new OrderStatusDto()
                {
                    Id = receipt.Result.Id,
                    ExternOrder = receipt.Result.ExternReceiptNumber,
                    SystemOrder = receipt.Result.ReceiptNumber,
                    StatusCode = StatusCode.error,
                    //StatusMsg = StatusCode.error.ToString(),
                    Msg = "请检查订单状态"
                };
            }

            //使用简单工厂定制化修改和新增的方法
            IReceiptInventoryInterface factory = ReceiptInventoryFactory.AddInventory(_wms_receiptRepository, _wms_receiptreceivingRepository, _wms_receiptdetailRepository, _wms_inventory_usableRepository, _wms_asnRepository, _wms_asndetailRepository, receipt.Result.CustomerId);
            List<long> ids = new List<long>();
            ids.Add(input.Id);
            var response = factory.Strategy(ids, AbpSession);

            //var entity = await _wms_receiptRepository.GetAllIncluding(a => a.ReceiptReceivings).Where(b => b.Id == input.Id).FirstAsync();
            //var dto = ObjectMapper.Map<WMS_ReceiptListDto>(entity);
            return response.Data.FirstOrDefault();
        }

        /// <summary>
        /// 预入库单转入库单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>


        /// <summary>
        /// 导出上架单模板
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ExportReceipt(List<long> input)
        {
            //使用简单工厂定制化
            IReceiptExportInterface factory = ReceiptExportFactory.ExportReceipt(_wms_receiptManager, _cacheManage, ObjectMapper, _table_ColumnsManager, _table_ColumnsDetailManager);
            var response = factory.Strategy(input, AbpSession);
            IExporter exporter = new ExcelExporter();
            var result = exporter.ExportAsByteArray<DataTable>(response.Data);
            var fs = new MemoryStream(result.Result);
            return new XlsxFileResult(stream: fs, fileDownloadName: "下载文件");
        }

        [HttpPost]
        public ActionResult ExportReceiptReceiving(List<long> input)
        {
            //使用简单工厂定制化  /
            //不同的仓库存在不同的上架推荐库位的逻辑，这个地方按照实际的情况实现自己的业务逻辑，
            //默认：1，按照已有库存，且库存最小推荐
            //默认：2，没有库存，以前有库存
            //默认：3，随便推荐
            IReceiptReceivingExportInterface factory = ReceiptReceivingExportFactory.GetReceiptReceiving(_wms_receiptRepository, _wms_receiptdetailRepository, _wms_receiptreceivingRepository, _wms_inventory_usableRepository, _cacheManage, _table_ColumnsManager);
            var response = factory.Strategy(input, AbpSession);
            IExporter exporter = new ExcelExporter();
            var result = exporter.ExportAsByteArray<DataTable>(response.Data);
            var fs = new MemoryStream(result.Result);
            return new XlsxFileResult(stream: fs, fileDownloadName: "下载文件");
        }


        [HttpPost]
        public async Task<List<OrderStatusDto>> ReturnReceipt(long input)
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

            IReceiptReturnInterface factory = ReceiptReturnFactory.ReturnReceipt(_wms_asnRepository, _wms_asndetailRepository,_wms_receiptRepository, _wms_receiptdetailRepository, CustomerId);
            var response = await factory.Strategy(AbpSession, input);

            return response.Data;
        }
        #endregion
    }
}
