

# 配置52ABP-PRO的多语言
 
 
**请注意：**
- 从52ABP-PRO 2.5.0的版本开始默认采用json配置多语言
- 属性名和字段不能重复否则框架会验证失败，需要你删除重复的键名

## Json的配置方法如下

在MyProject.Core类库中，找到路径为 Localization->SourceFiles->Json文件夹下的对应文件

### 中文本地化的内容Chinese localized content

找到Json文件夹下的MyProject-zh-Hans.json文件，复制以下代码进入即可。

> 请注意防止键名重复，产生异常

```json
                    //的多语言配置==>中文
"ReceiptId": "ReceiptId",
"ASNId": "ASNId",
"ASNDetailId": "ASNDetailId",
"ExtensionDetailGUID": "ExtensionDetailGUID",
                    
                     "WMS_ReceiptDetailReceiptNumber": "ReceiptNumber",
                    "WMS_ReceiptDetailReceiptNumberInputDesc": "请输入ReceiptNumber",
                     
                    
                     "WMS_ReceiptDetailExternReceiptNumber": "ExternReceiptNumber",
                    "WMS_ReceiptDetailExternReceiptNumberInputDesc": "请输入ExternReceiptNumber",
                     
                    
                     "WMS_ReceiptDetailASNNumber": "ASNNumber",
                    "WMS_ReceiptDetailASNNumberInputDesc": "请输入ASNNumber",
                     
"CustomerId": "CustomerId",
                    
                     "WMS_ReceiptDetailCustomerName": "CustomerName",
                    "WMS_ReceiptDetailCustomerNameInputDesc": "请输入CustomerName",
                     
"WarehouseId": "WarehouseId",
                    
                     "WMS_ReceiptDetailWarehouseName": "WarehouseName",
                    "WMS_ReceiptDetailWarehouseNameInputDesc": "请输入WarehouseName",
                     
                    
                     "WMS_ReceiptDetailLineNumber": "LineNumber",
                    "WMS_ReceiptDetailLineNumberInputDesc": "请输入LineNumber",
                     
                    
                     "WMS_ReceiptDetailSKU": "SKU",
                    "WMS_ReceiptDetailSKUInputDesc": "请输入SKU",
                     
                    
                     "WMS_ReceiptDetailUPC": "UPC",
                    "WMS_ReceiptDetailUPCInputDesc": "请输入UPC",
                     
                    
                     "WMS_ReceiptDetailGoodsType": "GoodsType",
                    "WMS_ReceiptDetailGoodsTypeInputDesc": "请输入GoodsType",
                     
                    
                     "WMS_ReceiptDetailGoodsName": "GoodsName",
                    "WMS_ReceiptDetailGoodsNameInputDesc": "请输入GoodsName",
                     
                    
                     "WMS_ReceiptDetailBoxNumber": "BoxNumber",
                    "WMS_ReceiptDetailBoxNumberInputDesc": "请输入BoxNumber",
                     
                    
                     "WMS_ReceiptDetailBatchNumber": "BatchNumber",
                    "WMS_ReceiptDetailBatchNumberInputDesc": "请输入BatchNumber",
                     
"QtyExpected": "QtyExpected",
"QtyReceived": "QtyReceived",
"QtyReceipt": "QtyReceipt",
                    
                     "WMS_ReceiptDetailUnit": "Unit",
                    "WMS_ReceiptDetailUnitInputDesc": "请输入Unit",
                     
                    
                     "WMS_ReceiptDetailSpecifications": "Specifications",
                    "WMS_ReceiptDetailSpecificationsInputDesc": "请输入Specifications",
                     
"Price": "Price",
"Weight": "Weight",
"Volume": "Volume",
                    
                     "WMS_ReceiptDetailProductionDate": "ProductionDate",
                    "WMS_ReceiptDetailProductionDateInputDesc": "请输入ProductionDate",
                     
                    
                     "WMS_ReceiptDetailExpirationDate": "ExpirationDate",
                    "WMS_ReceiptDetailExpirationDateInputDesc": "请输入ExpirationDate",
                     
                    
                     "WMS_ReceiptDetailCreator": "Creator",
                    "WMS_ReceiptDetailCreatorInputDesc": "请输入Creator",
                     
"CreateTime": "CreateTime",
                    
                     "WMS_ReceiptDetailUpdator": "Updator",
                    "WMS_ReceiptDetailUpdatorInputDesc": "请输入Updator",
                     
"UpdateTime": "UpdateTime",
                    
                     "WMS_ReceiptDetailStr1": "Str1",
                    "WMS_ReceiptDetailStr1InputDesc": "请输入Str1",
                     
                    
                     "WMS_ReceiptDetailStr2": "Str2",
                    "WMS_ReceiptDetailStr2InputDesc": "请输入Str2",
                     
                    
                     "WMS_ReceiptDetailStr3": "Str3",
                    "WMS_ReceiptDetailStr3InputDesc": "请输入Str3",
                     
                    
                     "WMS_ReceiptDetailStr4": "Str4",
                    "WMS_ReceiptDetailStr4InputDesc": "请输入Str4",
                     
                    
                     "WMS_ReceiptDetailStr5": "Str5",
                    "WMS_ReceiptDetailStr5InputDesc": "请输入Str5",
                     
                    
                     "WMS_ReceiptDetailStr6": "Str6",
                    "WMS_ReceiptDetailStr6InputDesc": "请输入Str6",
                     
                    
                     "WMS_ReceiptDetailStr7": "Str7",
                    "WMS_ReceiptDetailStr7InputDesc": "请输入Str7",
                     
                    
                     "WMS_ReceiptDetailStr8": "Str8",
                    "WMS_ReceiptDetailStr8InputDesc": "请输入Str8",
                     
                    
                     "WMS_ReceiptDetailStr9": "Str9",
                    "WMS_ReceiptDetailStr9InputDesc": "请输入Str9",
                     
                    
                     "WMS_ReceiptDetailStr10": "Str10",
                    "WMS_ReceiptDetailStr10InputDesc": "请输入Str10",
                     
                    
                     "WMS_ReceiptDetailStr11": "Str11",
                    "WMS_ReceiptDetailStr11InputDesc": "请输入Str11",
                     
                    
                     "WMS_ReceiptDetailStr12": "Str12",
                    "WMS_ReceiptDetailStr12InputDesc": "请输入Str12",
                     
                    
                     "WMS_ReceiptDetailStr13": "Str13",
                    "WMS_ReceiptDetailStr13InputDesc": "请输入Str13",
                     
                    
                     "WMS_ReceiptDetailStr14": "Str14",
                    "WMS_ReceiptDetailStr14InputDesc": "请输入Str14",
                     
                    
                     "WMS_ReceiptDetailStr15": "Str15",
                    "WMS_ReceiptDetailStr15InputDesc": "请输入Str15",
                     
                    
                     "WMS_ReceiptDetailStr16": "Str16",
                    "WMS_ReceiptDetailStr16InputDesc": "请输入Str16",
                     
                    
                     "WMS_ReceiptDetailStr17": "Str17",
                    "WMS_ReceiptDetailStr17InputDesc": "请输入Str17",
                     
                    
                     "WMS_ReceiptDetailStr18": "Str18",
                    "WMS_ReceiptDetailStr18InputDesc": "请输入Str18",
                     
                    
                     "WMS_ReceiptDetailStr19": "Str19",
                    "WMS_ReceiptDetailStr19InputDesc": "请输入Str19",
                     
                    
                     "WMS_ReceiptDetailStr20": "Str20",
                    "WMS_ReceiptDetailStr20InputDesc": "请输入Str20",
                     
"DateTime1": "DateTime1",
"DateTime2": "DateTime2",
"DateTime3": "DateTime3",
"DateTime4": "DateTime4",
"DateTime5": "DateTime5",
                    
                     "WMS_ReceiptDetailInt1": "Int1",
                    "WMS_ReceiptDetailInt1InputDesc": "请输入Int1",
                     
                    
                     "WMS_ReceiptDetailInt2": "Int2",
                    "WMS_ReceiptDetailInt2InputDesc": "请输入Int2",
                     
                    
                     "WMS_ReceiptDetailInt3": "Int3",
                    "WMS_ReceiptDetailInt3InputDesc": "请输入Int3",
                     
                    
                     "WMS_ReceiptDetailInt4": "Int4",
                    "WMS_ReceiptDetailInt4InputDesc": "请输入Int4",
                     
                    
                     "WMS_ReceiptDetailInt5": "Int5",
                    "WMS_ReceiptDetailInt5InputDesc": "请输入Int5",
                     
"CreationTime": "CreationTime",
					                     
                    "WMS_ReceiptDetail": "",
                    "ManageWMS_ReceiptDetail": "管理",
                    "QueryWMS_ReceiptDetail": "查询",
                    "CreateWMS_ReceiptDetail": "添加",
                    "EditWMS_ReceiptDetail": "编辑",
                    "DeleteWMS_ReceiptDetail": "删除",
                    "BatchDeleteWMS_ReceiptDetail": "批量删除",
                    "ExportWMS_ReceiptDetail": "导出",
                    "WMS_ReceiptDetailList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyProject.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
"ReceiptId": "ReceiptId",
"ASNId": "ASNId",
"ASNDetailId": "ASNDetailId",
"ExtensionDetailGUID": "ExtensionDetailGUID",
                    
                     "WMS_ReceiptDetailReceiptNumber": "WMS_ReceiptDetailReceiptNumber",
                    "WMS_ReceiptDetailReceiptNumberInputDesc": "Please input your WMS_ReceiptDetailReceiptNumber",
                     
                    
                     "WMS_ReceiptDetailExternReceiptNumber": "WMS_ReceiptDetailExternReceiptNumber",
                    "WMS_ReceiptDetailExternReceiptNumberInputDesc": "Please input your WMS_ReceiptDetailExternReceiptNumber",
                     
                    
                     "WMS_ReceiptDetailASNNumber": "WMS_ReceiptDetailASNNumber",
                    "WMS_ReceiptDetailASNNumberInputDesc": "Please input your WMS_ReceiptDetailASNNumber",
                     
"CustomerId": "CustomerId",
                    
                     "WMS_ReceiptDetailCustomerName": "WMS_ReceiptDetailCustomerName",
                    "WMS_ReceiptDetailCustomerNameInputDesc": "Please input your WMS_ReceiptDetailCustomerName",
                     
"WarehouseId": "WarehouseId",
                    
                     "WMS_ReceiptDetailWarehouseName": "WMS_ReceiptDetailWarehouseName",
                    "WMS_ReceiptDetailWarehouseNameInputDesc": "Please input your WMS_ReceiptDetailWarehouseName",
                     
                    
                     "WMS_ReceiptDetailLineNumber": "WMS_ReceiptDetailLineNumber",
                    "WMS_ReceiptDetailLineNumberInputDesc": "Please input your WMS_ReceiptDetailLineNumber",
                     
                    
                     "WMS_ReceiptDetailSKU": "WMS_ReceiptDetailSKU",
                    "WMS_ReceiptDetailSKUInputDesc": "Please input your WMS_ReceiptDetailSKU",
                     
                    
                     "WMS_ReceiptDetailUPC": "WMS_ReceiptDetailUPC",
                    "WMS_ReceiptDetailUPCInputDesc": "Please input your WMS_ReceiptDetailUPC",
                     
                    
                     "WMS_ReceiptDetailGoodsType": "WMS_ReceiptDetailGoodsType",
                    "WMS_ReceiptDetailGoodsTypeInputDesc": "Please input your WMS_ReceiptDetailGoodsType",
                     
                    
                     "WMS_ReceiptDetailGoodsName": "WMS_ReceiptDetailGoodsName",
                    "WMS_ReceiptDetailGoodsNameInputDesc": "Please input your WMS_ReceiptDetailGoodsName",
                     
                    
                     "WMS_ReceiptDetailBoxNumber": "WMS_ReceiptDetailBoxNumber",
                    "WMS_ReceiptDetailBoxNumberInputDesc": "Please input your WMS_ReceiptDetailBoxNumber",
                     
                    
                     "WMS_ReceiptDetailBatchNumber": "WMS_ReceiptDetailBatchNumber",
                    "WMS_ReceiptDetailBatchNumberInputDesc": "Please input your WMS_ReceiptDetailBatchNumber",
                     
"QtyExpected": "QtyExpected",
"QtyReceived": "QtyReceived",
"QtyReceipt": "QtyReceipt",
                    
                     "WMS_ReceiptDetailUnit": "WMS_ReceiptDetailUnit",
                    "WMS_ReceiptDetailUnitInputDesc": "Please input your WMS_ReceiptDetailUnit",
                     
                    
                     "WMS_ReceiptDetailSpecifications": "WMS_ReceiptDetailSpecifications",
                    "WMS_ReceiptDetailSpecificationsInputDesc": "Please input your WMS_ReceiptDetailSpecifications",
                     
"Price": "Price",
"Weight": "Weight",
"Volume": "Volume",
                    
                     "WMS_ReceiptDetailProductionDate": "WMS_ReceiptDetailProductionDate",
                    "WMS_ReceiptDetailProductionDateInputDesc": "Please input your WMS_ReceiptDetailProductionDate",
                     
                    
                     "WMS_ReceiptDetailExpirationDate": "WMS_ReceiptDetailExpirationDate",
                    "WMS_ReceiptDetailExpirationDateInputDesc": "Please input your WMS_ReceiptDetailExpirationDate",
                     
                    
                     "WMS_ReceiptDetailCreator": "WMS_ReceiptDetailCreator",
                    "WMS_ReceiptDetailCreatorInputDesc": "Please input your WMS_ReceiptDetailCreator",
                     
"CreateTime": "CreateTime",
                    
                     "WMS_ReceiptDetailUpdator": "WMS_ReceiptDetailUpdator",
                    "WMS_ReceiptDetailUpdatorInputDesc": "Please input your WMS_ReceiptDetailUpdator",
                     
"UpdateTime": "UpdateTime",
                    
                     "WMS_ReceiptDetailStr1": "WMS_ReceiptDetailStr1",
                    "WMS_ReceiptDetailStr1InputDesc": "Please input your WMS_ReceiptDetailStr1",
                     
                    
                     "WMS_ReceiptDetailStr2": "WMS_ReceiptDetailStr2",
                    "WMS_ReceiptDetailStr2InputDesc": "Please input your WMS_ReceiptDetailStr2",
                     
                    
                     "WMS_ReceiptDetailStr3": "WMS_ReceiptDetailStr3",
                    "WMS_ReceiptDetailStr3InputDesc": "Please input your WMS_ReceiptDetailStr3",
                     
                    
                     "WMS_ReceiptDetailStr4": "WMS_ReceiptDetailStr4",
                    "WMS_ReceiptDetailStr4InputDesc": "Please input your WMS_ReceiptDetailStr4",
                     
                    
                     "WMS_ReceiptDetailStr5": "WMS_ReceiptDetailStr5",
                    "WMS_ReceiptDetailStr5InputDesc": "Please input your WMS_ReceiptDetailStr5",
                     
                    
                     "WMS_ReceiptDetailStr6": "WMS_ReceiptDetailStr6",
                    "WMS_ReceiptDetailStr6InputDesc": "Please input your WMS_ReceiptDetailStr6",
                     
                    
                     "WMS_ReceiptDetailStr7": "WMS_ReceiptDetailStr7",
                    "WMS_ReceiptDetailStr7InputDesc": "Please input your WMS_ReceiptDetailStr7",
                     
                    
                     "WMS_ReceiptDetailStr8": "WMS_ReceiptDetailStr8",
                    "WMS_ReceiptDetailStr8InputDesc": "Please input your WMS_ReceiptDetailStr8",
                     
                    
                     "WMS_ReceiptDetailStr9": "WMS_ReceiptDetailStr9",
                    "WMS_ReceiptDetailStr9InputDesc": "Please input your WMS_ReceiptDetailStr9",
                     
                    
                     "WMS_ReceiptDetailStr10": "WMS_ReceiptDetailStr10",
                    "WMS_ReceiptDetailStr10InputDesc": "Please input your WMS_ReceiptDetailStr10",
                     
                    
                     "WMS_ReceiptDetailStr11": "WMS_ReceiptDetailStr11",
                    "WMS_ReceiptDetailStr11InputDesc": "Please input your WMS_ReceiptDetailStr11",
                     
                    
                     "WMS_ReceiptDetailStr12": "WMS_ReceiptDetailStr12",
                    "WMS_ReceiptDetailStr12InputDesc": "Please input your WMS_ReceiptDetailStr12",
                     
                    
                     "WMS_ReceiptDetailStr13": "WMS_ReceiptDetailStr13",
                    "WMS_ReceiptDetailStr13InputDesc": "Please input your WMS_ReceiptDetailStr13",
                     
                    
                     "WMS_ReceiptDetailStr14": "WMS_ReceiptDetailStr14",
                    "WMS_ReceiptDetailStr14InputDesc": "Please input your WMS_ReceiptDetailStr14",
                     
                    
                     "WMS_ReceiptDetailStr15": "WMS_ReceiptDetailStr15",
                    "WMS_ReceiptDetailStr15InputDesc": "Please input your WMS_ReceiptDetailStr15",
                     
                    
                     "WMS_ReceiptDetailStr16": "WMS_ReceiptDetailStr16",
                    "WMS_ReceiptDetailStr16InputDesc": "Please input your WMS_ReceiptDetailStr16",
                     
                    
                     "WMS_ReceiptDetailStr17": "WMS_ReceiptDetailStr17",
                    "WMS_ReceiptDetailStr17InputDesc": "Please input your WMS_ReceiptDetailStr17",
                     
                    
                     "WMS_ReceiptDetailStr18": "WMS_ReceiptDetailStr18",
                    "WMS_ReceiptDetailStr18InputDesc": "Please input your WMS_ReceiptDetailStr18",
                     
                    
                     "WMS_ReceiptDetailStr19": "WMS_ReceiptDetailStr19",
                    "WMS_ReceiptDetailStr19InputDesc": "Please input your WMS_ReceiptDetailStr19",
                     
                    
                     "WMS_ReceiptDetailStr20": "WMS_ReceiptDetailStr20",
                    "WMS_ReceiptDetailStr20InputDesc": "Please input your WMS_ReceiptDetailStr20",
                     
"DateTime1": "DateTime1",
"DateTime2": "DateTime2",
"DateTime3": "DateTime3",
"DateTime4": "DateTime4",
"DateTime5": "DateTime5",
                    
                     "WMS_ReceiptDetailInt1": "WMS_ReceiptDetailInt1",
                    "WMS_ReceiptDetailInt1InputDesc": "Please input your WMS_ReceiptDetailInt1",
                     
                    
                     "WMS_ReceiptDetailInt2": "WMS_ReceiptDetailInt2",
                    "WMS_ReceiptDetailInt2InputDesc": "Please input your WMS_ReceiptDetailInt2",
                     
                    
                     "WMS_ReceiptDetailInt3": "WMS_ReceiptDetailInt3",
                    "WMS_ReceiptDetailInt3InputDesc": "Please input your WMS_ReceiptDetailInt3",
                     
                    
                     "WMS_ReceiptDetailInt4": "WMS_ReceiptDetailInt4",
                    "WMS_ReceiptDetailInt4InputDesc": "Please input your WMS_ReceiptDetailInt4",
                     
                    
                     "WMS_ReceiptDetailInt5": "WMS_ReceiptDetailInt5",
                    "WMS_ReceiptDetailInt5InputDesc": "Please input your WMS_ReceiptDetailInt5",
                     
"CreationTime": "CreationTime",
					                     
                    "WMS_ReceiptDetail": "WMS_ReceiptDetail",
                    "ManageWMS_ReceiptDetail": "ManageWMS_ReceiptDetail",
                    "QueryWMS_ReceiptDetail": "QueryWMS_ReceiptDetail",
                    "CreateWMS_ReceiptDetail": "CreateWMS_ReceiptDetail",
                    "EditWMS_ReceiptDetail": "EditWMS_ReceiptDetail",
                    "DeleteWMS_ReceiptDetail": "DeleteWMS_ReceiptDetail",
                    "BatchDeleteWMS_ReceiptDetail": "BatchDeleteWMS_ReceiptDetail",
                    "ExportWMS_ReceiptDetail": "ExportWMS_ReceiptDetail",
                    "WMS_ReceiptDetailList": "WMS_ReceiptDetailList",
                     //的多语言配置==End
                    




```