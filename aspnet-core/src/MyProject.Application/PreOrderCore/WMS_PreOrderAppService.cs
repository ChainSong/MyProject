
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Linq.Extensions;

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
using MyProject.PreOrderCore;
using MyProject.PreOrderCore.Dtos;
using MyProject.PreOrderCore.DomainService;

using MyProject.Authorization;
using MyProject.WarehouseCore.DomainService;
using MyProject.TableColumns.DomainService;
using MyProject.CustomerCore.DomainService;
using MyProject.CommonCore.ExcelHelper;
using Microsoft.AspNetCore.Http;
using MyProject.PreOrderCore.Interface;
using MyProject.PreOrderCore.Factory;
using MyProject.OrderCore;
using MyProject.InventoryCore;
using DotNetCore.CAP;
using Abp.Extensions;
using MyProject.Common.RabbitMQCommon;

namespace MyProject.PreOrderCore
{
    /// <summary>
    /// 【扩展模块】  <br/>
    /// 【功能描述】  ：XXX 模块<br/>
    /// 【创建日期】  ：2020.05.21 <br/>
    /// 【开发人员】  ：static残影<br/>
    ///</summary>
    [ApiExplorerSettings(GroupName = "Manager", IgnoreApi = false)]
    public class WMS_PreOrderAppService : MyProjectAppServiceBase, IWMS_PreOrderAppService
    {
        /// <summary>
        ///【WMS_PreOrder】仓储层
        /// </summary>
        private readonly IRepository<WMS_PreOrder, long> _wms_preorderRepository;

        /// <summary>
        ///【WMS_PreOrder】领域服务
        /// </summary>
        private readonly IWMS_PreOrderManager _wms_preorderManager;

        /// <summary>
        ///【WMS_PreOrderDetail】仓储层
        /// </summary>
        private readonly IRepository<WMS_PreOrderDetail, long> _wms_preorderdetailRepository;

        /// <summary>
        ///【WarehouseUserMapping】领域服务
        /// </summary>
        private readonly IWarehouseUserMappingManager _warehouseusermappingManager;

        private readonly ITable_ColumnsManager _table_ColumnsManager;
        /// <summary>
        ///【CustomerUserMapping】领域服务
        /// </summary>
        private readonly ICustomerUserMappingManager _customerusermappingManager;
        /// <summary>
        ///【WMS_Order】仓储层
        /// </summary>
        private readonly IRepository<WMS_Order, long> _wms_orderRepository;

        /// <summary>
        ///【WMS_Inventory_Usable】仓储层
        /// </summary>
        private readonly IRepository<WMS_Inventory_Usable, long> _wms_inventory_usableRepository;

        public ICapPublisher _publisher { get; set; }


        /// <summary>
        ///【WMS_OrderDetail】仓储层
        /// </summary>
        private readonly IRepository<WMS_OrderDetail, long> _wms_orderdetailRepository;



        public WMS_PreOrderAppService(
            IRepository<WMS_PreOrder, long> wms_preorderRepository,
            IRepository<WMS_PreOrderDetail, long> wms_preorderdetailRepository,
            IRepository<WMS_Order, long> wms_orderRepository,
            IRepository<WMS_OrderDetail, long> wms_orderdetailRepository,
            IRepository<WMS_Inventory_Usable, long> wms_inventory_usableRepository,
            IWMS_PreOrderManager wms_preorderManager,
            ITable_ColumnsManager table_ColumnsManager,
            IWarehouseUserMappingManager warehouseusermappingManager,
            ICustomerUserMappingManager customerusermappingManager,
            ICapPublisher publisher
        )
        {
            _wms_preorderRepository = wms_preorderRepository;
            _wms_preorderdetailRepository = wms_preorderdetailRepository;
            _wms_preorderManager = wms_preorderManager;
            _wms_orderRepository = wms_orderRepository;
            _wms_orderdetailRepository = wms_orderdetailRepository;
            _wms_inventory_usableRepository = wms_inventory_usableRepository;
            _warehouseusermappingManager = warehouseusermappingManager;
            _customerusermappingManager = customerusermappingManager;
            _table_ColumnsManager = table_ColumnsManager;
            _publisher = publisher;
        }

        #region -------------------------------------------------辅助工具生成---------------------------------------------- 

        /// <summary>
        ///【WMS_PreOrder】获取的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_PreOrderPermissions.Node)]
        [HttpPost]
        public async Task<PagedResultDto<WMS_PreOrderListDto>> GetPaged(GetWMS_PreOrdersInput input)
        {
           
            //_publisher.Publish("User.Command.v1", "black.critical.high");
            //IDictionary<string, object> headers = new Dictionary<string, object>();
            //RabbitSenderOption rabbitSender = new RabbitSenderOption("admin", "admin", "admin", "admin", "admin","admin", "admin", "admin" ,"admin",headers);
            //RabbitSender rabbitSenderss = new RabbitSender(rabbitSender);
            //rabbitSenderss.Send();
            var query = _wms_preorderRepository.GetAll()
                            //添加查询限制（默认必有的查询条件）
                            .Where(a => _warehouseusermappingManager.Query().Where(b => b.UserId == AbpSession.UserId).Select(c => c.WarehouseId).Contains(a.WarehouseId))
                           .Where(a => _customerusermappingManager.Query().Where(b => b.UserId == AbpSession.UserId).Select(c => c.CustomerId).Contains(a.CustomerId))
                          //模糊搜索 字段PreOrderNumber
                          .WhereIf(!input.PreOrderNumber.IsNullOrWhiteSpace(), a => a.PreOrderNumber.Contains(input.PreOrderNumber))
                          //模糊搜索 字段ExternOrderNumber
                          .WhereIf(!input.ExternOrderNumber.IsNullOrWhiteSpace(), a => a.ExternOrderNumber.Contains(input.ExternOrderNumber))
                          //模糊搜索 字段CustomerName
                          .WhereIf(!input.CustomerName.IsNullOrWhiteSpace(), a => a.CustomerName.Contains(input.CustomerName))
                          //模糊搜索 字段WarehouseName
                          .WhereIf(!input.WarehouseName.IsNullOrWhiteSpace(), a => a.WarehouseName.Contains(input.WarehouseName))
                          //模糊搜索 字段OrderType
                          .WhereIf(!input.OrderType.IsNullOrWhiteSpace(), a => a.OrderType.Contains(input.OrderType))
                          //模糊搜索 字段Creator
                          .WhereIf(!input.Creator.IsNullOrWhiteSpace(), a => a.Creator.Contains(input.Creator))
                          //模糊搜索 字段Updator
                          .WhereIf(!input.Updator.IsNullOrWhiteSpace(), a => a.Updator.Contains(input.Updator))
                          //模糊搜索 字段Remark
                          .WhereIf(!input.Remark.IsNullOrWhiteSpace(), a => a.Remark.Contains(input.Remark))
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

            var entityListDtos = ObjectMapper.Map<List<WMS_PreOrderListDto>>(entityList);

            return new PagedResultDto<WMS_PreOrderListDto>(count, entityListDtos);
        }

        /// <summary>
        ///【WMS_PreOrder】通过指定id获取MemberListDto信息
        /// </summary>
        //[AbpAuthorize(WMS_PreOrderPermissions.Node)]
        [HttpGet]
        public async Task<WMS_PreOrderListDto> GetById(EntityDto<long> input)
        {
            //var entity = await _wms_preorderRepository(input.Id);
            var entity = await _wms_preorderRepository.GetAllIncluding(a => a.PreOrderDetails).Where(b => b.Id == input.Id).FirstAsync();

            var dto = ObjectMapper.Map<WMS_PreOrderListDto>(entity);
            return dto;
        }

        /// <summary>
        ///【WMS_PreOrder】 获取编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_PreOrderPermissions.Node)]
        [HttpPost]
        public async Task<GetWMS_PreOrderForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetWMS_PreOrderForEditOutput();
            WMS_PreOrderEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _wms_preorderRepository.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<WMS_PreOrderEditDto>(entity);
            }
            else
            {
                editDto = new WMS_PreOrderEditDto();
            }
            output.WMS_PreOrder = editDto;
            return output;
        }
        /// <summary>
        ///【WMS_PreOrder】 添加或者修改的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_PreOrderPermissions.Node)]
        [HttpPost]
        public async Task CreateOrUpdate(CreateOrUpdateWMS_PreOrderInput input)
        {

            if (input.WMS_PreOrder.Id.HasValue)
            {
                await Update(input.WMS_PreOrder);
            }
            else
            {
                await Create(input.WMS_PreOrder);
            }
        }
        /// <summary>
        ///【WMS_PreOrder】新增
        /// </summary>
        //[AbpAuthorize(WMS_PreOrderPermissions.Node)]
        protected virtual async Task<OrderStatusDto> Create(WMS_PreOrderEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            //构造传入集合
            List<WMS_PreOrderEditDto> entityListDtos = new List<WMS_PreOrderEditDto>();
            entityListDtos.Add(input);
            //使用简单工厂定制化修改和新增的方法
            IPreOrderInterface factory = PreOrderFactory.GePreOrder(_wms_preorderRepository, _wms_preorderdetailRepository, _warehouseusermappingManager, _customerusermappingManager, input.CustomerId);
            var response = await factory.Strategy(entityListDtos, AbpSession);

            //var entity = ObjectMapper.Map<WMS_PreOrder>(input);
            ////调用领域服务
            //entity = await _wms_preorderManager.CreateAsync(entity);

            //var dto = ObjectMapper.Map<WMS_PreOrderEditDto>(entity);
            return response.Data.FirstOrDefault();
        }

        /// <summary>
        ///【WMS_PreOrder】编辑
        /// </summary>
        //[AbpAuthorize(WMS_PreOrderPermissions.Node)]
        protected virtual async Task Update(WMS_PreOrderEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var key = input.Id.Value;
            var entity = await _wms_preorderRepository.GetAsync(key);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _wms_preorderManager.UpdateAsync(entity);
        }

        /// <summary>
        ///【WMS_PreOrder】删除信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(WMS_PreOrderPermissions.Node)]
        [HttpGet]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _wms_preorderManager.DeleteAsync(input.Id);
        }

        /// <summary>
        ///【WMS_PreOrder】 批量删除Member的方法
        /// </summary>
        //[AbpAuthorize(WMS_PreOrderPermissions.Node)]
        [HttpPost]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _wms_preorderManager.BatchDelete(input);
        }

        #endregion

        #region -------------------------------------------------用户自定义------------------------------------------------
        /*请在此扩展应用服务实现*/
        //[Route("~/adonet/transaction")]
        /// <summary>
        /// 预出库单转出库单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<OrderStatusDto>> PreOrderForOrder(List<long> input)
        {


            //获取勾选的订单的客户
            //获取需要导入的客户，根据客户调用不同的配置方法(根据系统单号获取)
            var CustomerData = _wms_preorderRepository.GetAll().Where(a => a.Id == input.First()).FirstOrDefault();
            long CustomerId = 0;
            if (CustomerData != null)
            {
                CustomerId = CustomerData.CustomerId;
            }
            IPreOrderForOrderInterface factory = PreOrderForOrderFactory.PreOrderForOrder(_wms_preorderRepository, _wms_preorderdetailRepository, _wms_orderRepository, _wms_orderdetailRepository, _warehouseusermappingManager, _customerusermappingManager, CustomerId);
            var data = factory.Strategy(input, AbpSession);

            return data.Result.Data;
        }


        /// <summary>
        /// 接收上传文件方法
        /// </summary>
        /// <param name="file">文件内容</param>
        /// <param name="Status">提交状态，第一次提交，可能存在校验提示， 用户选择忽略提示可以使用</param>
        /// <returns>文件名称</returns>
        public async Task<List<OrderStatusDto>> UploadExcelFile(IFormFile file, int Status)
        {
            //FileDir是存储临时文件的目录，相对路径
            //private const string FileDir = "/File/ExcelTemp";
            string url = await ImprotExcel.WriteFile(file);
            var dataExcel = ExcelData.ExcelToDataTable(url, null, true);
            //var aaaaa = ExcelData.GetData<DataSet>(url);
            //1根据用户的角色 解析出Excel
            IPreOrderExcelInterface factoryExcel = PreOrderExcelFactory.GePreOrder(_table_ColumnsManager);
            var data = factoryExcel.Strategy(dataExcel, AbpSession);
            var entityListDtos = data.Data.TableToList<WMS_PreOrderEditDto>();
            var entityDetailListDtos = data.Data.TableToList<WMS_PreOrderDetailEditDto>();
            if (entityListDtos.Count > 0)
            {
                //将散装的主表和明细表 组合到一起 
                List<WMS_PreOrderEditDto> PreOrders = entityListDtos.GroupBy(x => x.ExternOrderNumber).Select(x => x.First()).ToList();
                PreOrders.ForEach(item =>
                {
                    item.PreOrderDetails = entityDetailListDtos.Where(a => a.ExternOrderNumber == item.ExternOrderNumber).ToList();
                });

                //获取需要导入的客户，根据客户调用不同的配置方法(根据系统单号获取)
                var CustomerData = _customerusermappingManager.Query().Where(a => a.CustomerName == entityListDtos.First().CustomerName).FirstOrDefault();
                long CustomerId = 0;
                if (CustomerData != null)
                {
                    CustomerId = CustomerData.CustomerId;
                }
                //long CustomerId = _wms_PreOrderRepository.GetAll().Where(a => a.PreOrderNumber == entityListDtos.First().PreOrderNumber).FirstOrDefault().CustomerId;
                //使用简单工厂定制化修改和新增的方法
                IPreOrderInterface factory = PreOrderFactory.GePreOrder(_wms_preorderRepository, _wms_preorderdetailRepository, _warehouseusermappingManager, _customerusermappingManager, CustomerId);
                var response = factory.Strategy(entityListDtos, AbpSession);
                return response.Result.Data;
            }
            else
            {
                return new List<OrderStatusDto>();
            }
        }


        #endregion
    }
}
