

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
"ExtensionDetailGUID": "ExtensionDetailGUID",
                    
                     "WMS_ASNDetailASNNumber": "ASNNumber",
                    "WMS_ASNDetailASNNumberInputDesc": "请输入ASNNumber",
                     
                    
                     "WMS_ASNDetailExternReceiptNumber": "ExternReceiptNumber",
                    "WMS_ASNDetailExternReceiptNumberInputDesc": "请输入ExternReceiptNumber",
                     
"CustomerId": "CustomerId",
                    
                     "WMS_ASNDetailCustomerName": "CustomerName",
                    "WMS_ASNDetailCustomerNameInputDesc": "请输入CustomerName",
                     
"WarehouseId": "WarehouseId",
                    
                     "WMS_ASNDetailWarehouseName": "WarehouseName",
                    "WMS_ASNDetailWarehouseNameInputDesc": "请输入WarehouseName",
                     
                    
                     "WMS_ASNDetailLineNumber": "LineNumber",
                    "WMS_ASNDetailLineNumberInputDesc": "请输入LineNumber",
                     
                    
                     "WMS_ASNDetailSKU": "SKU",
                    "WMS_ASNDetailSKUInputDesc": "请输入SKU",
                     
                    
                     "WMS_ASNDetailUPC": "UPC",
                    "WMS_ASNDetailUPCInputDesc": "请输入UPC",
                     
                    
                     "WMS_ASNDetailGoodsType": "GoodsType",
                    "WMS_ASNDetailGoodsTypeInputDesc": "请输入GoodsType",
                     
                    
                     "WMS_ASNDetailGoodsName": "GoodsName",
                    "WMS_ASNDetailGoodsNameInputDesc": "请输入GoodsName",
                     
                    
                     "WMS_ASNDetailBoxNumber": "BoxNumber",
                    "WMS_ASNDetailBoxNumberInputDesc": "请输入BoxNumber",
                     
                    
                     "WMS_ASNDetailBatchNumber": "BatchNumber",
                    "WMS_ASNDetailBatchNumberInputDesc": "请输入BatchNumber",
                     
"QtyExpected": "QtyExpected",
"QtyReceived": "QtyReceived",
"QtyReceipt": "QtyReceipt",
                    
                     "WMS_ASNDetailUnit": "Unit",
                    "WMS_ASNDetailUnitInputDesc": "请输入Unit",
                     
                    
                     "WMS_ASNDetailSpecifications": "Specifications",
                    "WMS_ASNDetailSpecificationsInputDesc": "请输入Specifications",
                     
"Price": "Price",
"ProductionDate": "ProductionDate",
"ExpirationDate": "ExpirationDate",
                    
                     "WMS_ASNDetailCreator": "Creator",
                    "WMS_ASNDetailCreatorInputDesc": "请输入Creator",
                     
"CreationTime": "CreationTime",
                    
                     "WMS_ASNDetailUpdator": "Updator",
                    "WMS_ASNDetailUpdatorInputDesc": "请输入Updator",
                     
"UpdateTime": "UpdateTime",
                    
                     "WMS_ASNDetailStr1": "Str1",
                    "WMS_ASNDetailStr1InputDesc": "请输入Str1",
                     
                    
                     "WMS_ASNDetailStr2": "Str2",
                    "WMS_ASNDetailStr2InputDesc": "请输入Str2",
                     
                    
                     "WMS_ASNDetailStr3": "Str3",
                    "WMS_ASNDetailStr3InputDesc": "请输入Str3",
                     
                    
                     "WMS_ASNDetailStr4": "Str4",
                    "WMS_ASNDetailStr4InputDesc": "请输入Str4",
                     
                    
                     "WMS_ASNDetailStr5": "Str5",
                    "WMS_ASNDetailStr5InputDesc": "请输入Str5",
                     
                    
                     "WMS_ASNDetailStr6": "Str6",
                    "WMS_ASNDetailStr6InputDesc": "请输入Str6",
                     
                    
                     "WMS_ASNDetailStr7": "Str7",
                    "WMS_ASNDetailStr7InputDesc": "请输入Str7",
                     
                    
                     "WMS_ASNDetailStr8": "Str8",
                    "WMS_ASNDetailStr8InputDesc": "请输入Str8",
                     
                    
                     "WMS_ASNDetailStr9": "Str9",
                    "WMS_ASNDetailStr9InputDesc": "请输入Str9",
                     
                    
                     "WMS_ASNDetailStr10": "Str10",
                    "WMS_ASNDetailStr10InputDesc": "请输入Str10",
                     
                    
                     "WMS_ASNDetailStr11": "Str11",
                    "WMS_ASNDetailStr11InputDesc": "请输入Str11",
                     
                    
                     "WMS_ASNDetailStr12": "Str12",
                    "WMS_ASNDetailStr12InputDesc": "请输入Str12",
                     
                    
                     "WMS_ASNDetailStr13": "Str13",
                    "WMS_ASNDetailStr13InputDesc": "请输入Str13",
                     
                    
                     "WMS_ASNDetailStr14": "Str14",
                    "WMS_ASNDetailStr14InputDesc": "请输入Str14",
                     
                    
                     "WMS_ASNDetailStr15": "Str15",
                    "WMS_ASNDetailStr15InputDesc": "请输入Str15",
                     
                    
                     "WMS_ASNDetailStr16": "Str16",
                    "WMS_ASNDetailStr16InputDesc": "请输入Str16",
                     
                    
                     "WMS_ASNDetailStr17": "Str17",
                    "WMS_ASNDetailStr17InputDesc": "请输入Str17",
                     
                    
                     "WMS_ASNDetailStr18": "Str18",
                    "WMS_ASNDetailStr18InputDesc": "请输入Str18",
                     
                    
                     "WMS_ASNDetailStr19": "Str19",
                    "WMS_ASNDetailStr19InputDesc": "请输入Str19",
                     
                    
                     "WMS_ASNDetailStr20": "Str20",
                    "WMS_ASNDetailStr20InputDesc": "请输入Str20",
                     
"DateTime1": "DateTime1",
"DateTime2": "DateTime2",
"DateTime3": "DateTime3",
"DateTime4": "DateTime4",
"DateTime5": "DateTime5",
"Int1": "Int1",
"Int2": "Int2",
"Int3": "Int3",
"Int4": "Int4",
"Int5": "Int5",
					                     
                    "WMS_ASNDetail": "",
                    "ManageWMS_ASNDetail": "管理",
                    "QueryWMS_ASNDetail": "查询",
                    "CreateWMS_ASNDetail": "添加",
                    "EditWMS_ASNDetail": "编辑",
                    "DeleteWMS_ASNDetail": "删除",
                    "BatchDeleteWMS_ASNDetail": "批量删除",
                    "ExportWMS_ASNDetail": "导出",
                    "WMS_ASNDetailList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyProject.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
"ExtensionDetailGUID": "ExtensionDetailGUID",
                    
                     "WMS_ASNDetailASNNumber": "WMS_ASNDetailASNNumber",
                    "WMS_ASNDetailASNNumberInputDesc": "Please input your WMS_ASNDetailASNNumber",
                     
                    
                     "WMS_ASNDetailExternReceiptNumber": "WMS_ASNDetailExternReceiptNumber",
                    "WMS_ASNDetailExternReceiptNumberInputDesc": "Please input your WMS_ASNDetailExternReceiptNumber",
                     
"CustomerId": "CustomerId",
                    
                     "WMS_ASNDetailCustomerName": "WMS_ASNDetailCustomerName",
                    "WMS_ASNDetailCustomerNameInputDesc": "Please input your WMS_ASNDetailCustomerName",
                     
"WarehouseId": "WarehouseId",
                    
                     "WMS_ASNDetailWarehouseName": "WMS_ASNDetailWarehouseName",
                    "WMS_ASNDetailWarehouseNameInputDesc": "Please input your WMS_ASNDetailWarehouseName",
                     
                    
                     "WMS_ASNDetailLineNumber": "WMS_ASNDetailLineNumber",
                    "WMS_ASNDetailLineNumberInputDesc": "Please input your WMS_ASNDetailLineNumber",
                     
                    
                     "WMS_ASNDetailSKU": "WMS_ASNDetailSKU",
                    "WMS_ASNDetailSKUInputDesc": "Please input your WMS_ASNDetailSKU",
                     
                    
                     "WMS_ASNDetailUPC": "WMS_ASNDetailUPC",
                    "WMS_ASNDetailUPCInputDesc": "Please input your WMS_ASNDetailUPC",
                     
                    
                     "WMS_ASNDetailGoodsType": "WMS_ASNDetailGoodsType",
                    "WMS_ASNDetailGoodsTypeInputDesc": "Please input your WMS_ASNDetailGoodsType",
                     
                    
                     "WMS_ASNDetailGoodsName": "WMS_ASNDetailGoodsName",
                    "WMS_ASNDetailGoodsNameInputDesc": "Please input your WMS_ASNDetailGoodsName",
                     
                    
                     "WMS_ASNDetailBoxNumber": "WMS_ASNDetailBoxNumber",
                    "WMS_ASNDetailBoxNumberInputDesc": "Please input your WMS_ASNDetailBoxNumber",
                     
                    
                     "WMS_ASNDetailBatchNumber": "WMS_ASNDetailBatchNumber",
                    "WMS_ASNDetailBatchNumberInputDesc": "Please input your WMS_ASNDetailBatchNumber",
                     
"QtyExpected": "QtyExpected",
"QtyReceived": "QtyReceived",
"QtyReceipt": "QtyReceipt",
                    
                     "WMS_ASNDetailUnit": "WMS_ASNDetailUnit",
                    "WMS_ASNDetailUnitInputDesc": "Please input your WMS_ASNDetailUnit",
                     
                    
                     "WMS_ASNDetailSpecifications": "WMS_ASNDetailSpecifications",
                    "WMS_ASNDetailSpecificationsInputDesc": "Please input your WMS_ASNDetailSpecifications",
                     
"Price": "Price",
"ProductionDate": "ProductionDate",
"ExpirationDate": "ExpirationDate",
                    
                     "WMS_ASNDetailCreator": "WMS_ASNDetailCreator",
                    "WMS_ASNDetailCreatorInputDesc": "Please input your WMS_ASNDetailCreator",
                     
"CreationTime": "CreationTime",
                    
                     "WMS_ASNDetailUpdator": "WMS_ASNDetailUpdator",
                    "WMS_ASNDetailUpdatorInputDesc": "Please input your WMS_ASNDetailUpdator",
                     
"UpdateTime": "UpdateTime",
                    
                     "WMS_ASNDetailStr1": "WMS_ASNDetailStr1",
                    "WMS_ASNDetailStr1InputDesc": "Please input your WMS_ASNDetailStr1",
                     
                    
                     "WMS_ASNDetailStr2": "WMS_ASNDetailStr2",
                    "WMS_ASNDetailStr2InputDesc": "Please input your WMS_ASNDetailStr2",
                     
                    
                     "WMS_ASNDetailStr3": "WMS_ASNDetailStr3",
                    "WMS_ASNDetailStr3InputDesc": "Please input your WMS_ASNDetailStr3",
                     
                    
                     "WMS_ASNDetailStr4": "WMS_ASNDetailStr4",
                    "WMS_ASNDetailStr4InputDesc": "Please input your WMS_ASNDetailStr4",
                     
                    
                     "WMS_ASNDetailStr5": "WMS_ASNDetailStr5",
                    "WMS_ASNDetailStr5InputDesc": "Please input your WMS_ASNDetailStr5",
                     
                    
                     "WMS_ASNDetailStr6": "WMS_ASNDetailStr6",
                    "WMS_ASNDetailStr6InputDesc": "Please input your WMS_ASNDetailStr6",
                     
                    
                     "WMS_ASNDetailStr7": "WMS_ASNDetailStr7",
                    "WMS_ASNDetailStr7InputDesc": "Please input your WMS_ASNDetailStr7",
                     
                    
                     "WMS_ASNDetailStr8": "WMS_ASNDetailStr8",
                    "WMS_ASNDetailStr8InputDesc": "Please input your WMS_ASNDetailStr8",
                     
                    
                     "WMS_ASNDetailStr9": "WMS_ASNDetailStr9",
                    "WMS_ASNDetailStr9InputDesc": "Please input your WMS_ASNDetailStr9",
                     
                    
                     "WMS_ASNDetailStr10": "WMS_ASNDetailStr10",
                    "WMS_ASNDetailStr10InputDesc": "Please input your WMS_ASNDetailStr10",
                     
                    
                     "WMS_ASNDetailStr11": "WMS_ASNDetailStr11",
                    "WMS_ASNDetailStr11InputDesc": "Please input your WMS_ASNDetailStr11",
                     
                    
                     "WMS_ASNDetailStr12": "WMS_ASNDetailStr12",
                    "WMS_ASNDetailStr12InputDesc": "Please input your WMS_ASNDetailStr12",
                     
                    
                     "WMS_ASNDetailStr13": "WMS_ASNDetailStr13",
                    "WMS_ASNDetailStr13InputDesc": "Please input your WMS_ASNDetailStr13",
                     
                    
                     "WMS_ASNDetailStr14": "WMS_ASNDetailStr14",
                    "WMS_ASNDetailStr14InputDesc": "Please input your WMS_ASNDetailStr14",
                     
                    
                     "WMS_ASNDetailStr15": "WMS_ASNDetailStr15",
                    "WMS_ASNDetailStr15InputDesc": "Please input your WMS_ASNDetailStr15",
                     
                    
                     "WMS_ASNDetailStr16": "WMS_ASNDetailStr16",
                    "WMS_ASNDetailStr16InputDesc": "Please input your WMS_ASNDetailStr16",
                     
                    
                     "WMS_ASNDetailStr17": "WMS_ASNDetailStr17",
                    "WMS_ASNDetailStr17InputDesc": "Please input your WMS_ASNDetailStr17",
                     
                    
                     "WMS_ASNDetailStr18": "WMS_ASNDetailStr18",
                    "WMS_ASNDetailStr18InputDesc": "Please input your WMS_ASNDetailStr18",
                     
                    
                     "WMS_ASNDetailStr19": "WMS_ASNDetailStr19",
                    "WMS_ASNDetailStr19InputDesc": "Please input your WMS_ASNDetailStr19",
                     
                    
                     "WMS_ASNDetailStr20": "WMS_ASNDetailStr20",
                    "WMS_ASNDetailStr20InputDesc": "Please input your WMS_ASNDetailStr20",
                     
"DateTime1": "DateTime1",
"DateTime2": "DateTime2",
"DateTime3": "DateTime3",
"DateTime4": "DateTime4",
"DateTime5": "DateTime5",
"Int1": "Int1",
"Int2": "Int2",
"Int3": "Int3",
"Int4": "Int4",
"Int5": "Int5",
					                     
                    "WMS_ASNDetail": "WMS_ASNDetail",
                    "ManageWMS_ASNDetail": "ManageWMS_ASNDetail",
                    "QueryWMS_ASNDetail": "QueryWMS_ASNDetail",
                    "CreateWMS_ASNDetail": "CreateWMS_ASNDetail",
                    "EditWMS_ASNDetail": "EditWMS_ASNDetail",
                    "DeleteWMS_ASNDetail": "DeleteWMS_ASNDetail",
                    "BatchDeleteWMS_ASNDetail": "BatchDeleteWMS_ASNDetail",
                    "ExportWMS_ASNDetail": "ExportWMS_ASNDetail",
                    "WMS_ASNDetailList": "WMS_ASNDetailList",
                     //的多语言配置==End
                    




```