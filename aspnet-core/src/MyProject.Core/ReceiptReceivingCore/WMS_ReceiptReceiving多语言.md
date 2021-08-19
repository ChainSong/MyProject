

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
"ReceiptDetailId": "ReceiptDetailId",
"ReceiptId": "ReceiptId",
"ASNId": "ASNId",
"ASNDetailId": "ASNDetailId",
"ExtensionDetailGUID": "ExtensionDetailGUID",
                    
                     "WMS_ReceiptReceivingReceiptNumber": "ReceiptNumber",
                    "WMS_ReceiptReceivingReceiptNumberInputDesc": "请输入ReceiptNumber",
                     
                    
                     "WMS_ReceiptReceivingExternReceiptNumber": "ExternReceiptNumber",
                    "WMS_ReceiptReceivingExternReceiptNumberInputDesc": "请输入ExternReceiptNumber",
                     
                    
                     "WMS_ReceiptReceivingASNNumber": "ASNNumber",
                    "WMS_ReceiptReceivingASNNumberInputDesc": "请输入ASNNumber",
                     
"CustomerId": "CustomerId",
                    
                     "WMS_ReceiptReceivingCustomerName": "CustomerName",
                    "WMS_ReceiptReceivingCustomerNameInputDesc": "请输入CustomerName",
                     
"WarehouseId": "WarehouseId",
                    
                     "WMS_ReceiptReceivingWarehouseName": "WarehouseName",
                    "WMS_ReceiptReceivingWarehouseNameInputDesc": "请输入WarehouseName",
                     
                    
                     "WMS_ReceiptReceivingLineNumber": "LineNumber",
                    "WMS_ReceiptReceivingLineNumberInputDesc": "请输入LineNumber",
                     
                    
                     "WMS_ReceiptReceivingSKU": "SKU",
                    "WMS_ReceiptReceivingSKUInputDesc": "请输入SKU",
                     
                    
                     "WMS_ReceiptReceivingUPC": "UPC",
                    "WMS_ReceiptReceivingUPCInputDesc": "请输入UPC",
                     
"RRStatus": "RRStatus",
                    
                     "WMS_ReceiptReceivingGoodsType": "GoodsType",
                    "WMS_ReceiptReceivingGoodsTypeInputDesc": "请输入GoodsType",
                     
                    
                     "WMS_ReceiptReceivingGoodsName": "GoodsName",
                    "WMS_ReceiptReceivingGoodsNameInputDesc": "请输入GoodsName",
                     
                    
                     "WMS_ReceiptReceivingBoxNumber": "BoxNumber",
                    "WMS_ReceiptReceivingBoxNumberInputDesc": "请输入BoxNumber",
                     
                    
                     "WMS_ReceiptReceivingBatchNumber": "BatchNumber",
                    "WMS_ReceiptReceivingBatchNumberInputDesc": "请输入BatchNumber",
                     
"QtyReceived": "QtyReceived",
                    
                     "WMS_ReceiptReceivingUnit": "Unit",
                    "WMS_ReceiptReceivingUnitInputDesc": "请输入Unit",
                     
                    
                     "WMS_ReceiptReceivingSpecifications": "Specifications",
                    "WMS_ReceiptReceivingSpecificationsInputDesc": "请输入Specifications",
                     
                    
                     "WMS_ReceiptReceivingArea": "Area",
                    "WMS_ReceiptReceivingAreaInputDesc": "请输入Area",
                     
                    
                     "WMS_ReceiptReceivingLocation": "Location",
                    "WMS_ReceiptReceivingLocationInputDesc": "请输入Location",
                     
"Price": "Price",
"Weight": "Weight",
"Volume": "Volume",
"ProductionDate": "ProductionDate",
"ExpirationDate": "ExpirationDate",
                    
                     "WMS_ReceiptReceivingRemark": "Remark",
                    "WMS_ReceiptReceivingRemarkInputDesc": "请输入Remark",
                     
                    
                     "WMS_ReceiptReceivingCreator": "Creator",
                    "WMS_ReceiptReceivingCreatorInputDesc": "请输入Creator",
                     
"CreateTime": "CreateTime",
                    
                     "WMS_ReceiptReceivingUpdator": "Updator",
                    "WMS_ReceiptReceivingUpdatorInputDesc": "请输入Updator",
                     
"UpdateTime": "UpdateTime",
                    
                     "WMS_ReceiptReceivingStr1": "Str1",
                    "WMS_ReceiptReceivingStr1InputDesc": "请输入Str1",
                     
                    
                     "WMS_ReceiptReceivingStr2": "Str2",
                    "WMS_ReceiptReceivingStr2InputDesc": "请输入Str2",
                     
                    
                     "WMS_ReceiptReceivingStr3": "Str3",
                    "WMS_ReceiptReceivingStr3InputDesc": "请输入Str3",
                     
                    
                     "WMS_ReceiptReceivingStr4": "Str4",
                    "WMS_ReceiptReceivingStr4InputDesc": "请输入Str4",
                     
                    
                     "WMS_ReceiptReceivingStr5": "Str5",
                    "WMS_ReceiptReceivingStr5InputDesc": "请输入Str5",
                     
                    
                     "WMS_ReceiptReceivingStr6": "Str6",
                    "WMS_ReceiptReceivingStr6InputDesc": "请输入Str6",
                     
                    
                     "WMS_ReceiptReceivingStr7": "Str7",
                    "WMS_ReceiptReceivingStr7InputDesc": "请输入Str7",
                     
                    
                     "WMS_ReceiptReceivingStr8": "Str8",
                    "WMS_ReceiptReceivingStr8InputDesc": "请输入Str8",
                     
                    
                     "WMS_ReceiptReceivingStr9": "Str9",
                    "WMS_ReceiptReceivingStr9InputDesc": "请输入Str9",
                     
                    
                     "WMS_ReceiptReceivingStr10": "Str10",
                    "WMS_ReceiptReceivingStr10InputDesc": "请输入Str10",
                     
                    
                     "WMS_ReceiptReceivingStr11": "Str11",
                    "WMS_ReceiptReceivingStr11InputDesc": "请输入Str11",
                     
                    
                     "WMS_ReceiptReceivingStr12": "Str12",
                    "WMS_ReceiptReceivingStr12InputDesc": "请输入Str12",
                     
                    
                     "WMS_ReceiptReceivingStr13": "Str13",
                    "WMS_ReceiptReceivingStr13InputDesc": "请输入Str13",
                     
                    
                     "WMS_ReceiptReceivingStr14": "Str14",
                    "WMS_ReceiptReceivingStr14InputDesc": "请输入Str14",
                     
                    
                     "WMS_ReceiptReceivingStr15": "Str15",
                    "WMS_ReceiptReceivingStr15InputDesc": "请输入Str15",
                     
                    
                     "WMS_ReceiptReceivingStr16": "Str16",
                    "WMS_ReceiptReceivingStr16InputDesc": "请输入Str16",
                     
                    
                     "WMS_ReceiptReceivingStr17": "Str17",
                    "WMS_ReceiptReceivingStr17InputDesc": "请输入Str17",
                     
                    
                     "WMS_ReceiptReceivingStr18": "Str18",
                    "WMS_ReceiptReceivingStr18InputDesc": "请输入Str18",
                     
                    
                     "WMS_ReceiptReceivingStr19": "Str19",
                    "WMS_ReceiptReceivingStr19InputDesc": "请输入Str19",
                     
                    
                     "WMS_ReceiptReceivingStr20": "Str20",
                    "WMS_ReceiptReceivingStr20InputDesc": "请输入Str20",
                     
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
					                     
                    "WMS_ReceiptReceiving": "",
                    "ManageWMS_ReceiptReceiving": "管理",
                    "QueryWMS_ReceiptReceiving": "查询",
                    "CreateWMS_ReceiptReceiving": "添加",
                    "EditWMS_ReceiptReceiving": "编辑",
                    "DeleteWMS_ReceiptReceiving": "删除",
                    "BatchDeleteWMS_ReceiptReceiving": "批量删除",
                    "ExportWMS_ReceiptReceiving": "导出",
                    "WMS_ReceiptReceivingList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyProject.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
"ReceiptDetailId": "ReceiptDetailId",
"ReceiptId": "ReceiptId",
"ASNId": "ASNId",
"ASNDetailId": "ASNDetailId",
"ExtensionDetailGUID": "ExtensionDetailGUID",
                    
                     "WMS_ReceiptReceivingReceiptNumber": "WMS_ReceiptReceivingReceiptNumber",
                    "WMS_ReceiptReceivingReceiptNumberInputDesc": "Please input your WMS_ReceiptReceivingReceiptNumber",
                     
                    
                     "WMS_ReceiptReceivingExternReceiptNumber": "WMS_ReceiptReceivingExternReceiptNumber",
                    "WMS_ReceiptReceivingExternReceiptNumberInputDesc": "Please input your WMS_ReceiptReceivingExternReceiptNumber",
                     
                    
                     "WMS_ReceiptReceivingASNNumber": "WMS_ReceiptReceivingASNNumber",
                    "WMS_ReceiptReceivingASNNumberInputDesc": "Please input your WMS_ReceiptReceivingASNNumber",
                     
"CustomerId": "CustomerId",
                    
                     "WMS_ReceiptReceivingCustomerName": "WMS_ReceiptReceivingCustomerName",
                    "WMS_ReceiptReceivingCustomerNameInputDesc": "Please input your WMS_ReceiptReceivingCustomerName",
                     
"WarehouseId": "WarehouseId",
                    
                     "WMS_ReceiptReceivingWarehouseName": "WMS_ReceiptReceivingWarehouseName",
                    "WMS_ReceiptReceivingWarehouseNameInputDesc": "Please input your WMS_ReceiptReceivingWarehouseName",
                     
                    
                     "WMS_ReceiptReceivingLineNumber": "WMS_ReceiptReceivingLineNumber",
                    "WMS_ReceiptReceivingLineNumberInputDesc": "Please input your WMS_ReceiptReceivingLineNumber",
                     
                    
                     "WMS_ReceiptReceivingSKU": "WMS_ReceiptReceivingSKU",
                    "WMS_ReceiptReceivingSKUInputDesc": "Please input your WMS_ReceiptReceivingSKU",
                     
                    
                     "WMS_ReceiptReceivingUPC": "WMS_ReceiptReceivingUPC",
                    "WMS_ReceiptReceivingUPCInputDesc": "Please input your WMS_ReceiptReceivingUPC",
                     
"RRStatus": "RRStatus",
                    
                     "WMS_ReceiptReceivingGoodsType": "WMS_ReceiptReceivingGoodsType",
                    "WMS_ReceiptReceivingGoodsTypeInputDesc": "Please input your WMS_ReceiptReceivingGoodsType",
                     
                    
                     "WMS_ReceiptReceivingGoodsName": "WMS_ReceiptReceivingGoodsName",
                    "WMS_ReceiptReceivingGoodsNameInputDesc": "Please input your WMS_ReceiptReceivingGoodsName",
                     
                    
                     "WMS_ReceiptReceivingBoxNumber": "WMS_ReceiptReceivingBoxNumber",
                    "WMS_ReceiptReceivingBoxNumberInputDesc": "Please input your WMS_ReceiptReceivingBoxNumber",
                     
                    
                     "WMS_ReceiptReceivingBatchNumber": "WMS_ReceiptReceivingBatchNumber",
                    "WMS_ReceiptReceivingBatchNumberInputDesc": "Please input your WMS_ReceiptReceivingBatchNumber",
                     
"QtyReceived": "QtyReceived",
                    
                     "WMS_ReceiptReceivingUnit": "WMS_ReceiptReceivingUnit",
                    "WMS_ReceiptReceivingUnitInputDesc": "Please input your WMS_ReceiptReceivingUnit",
                     
                    
                     "WMS_ReceiptReceivingSpecifications": "WMS_ReceiptReceivingSpecifications",
                    "WMS_ReceiptReceivingSpecificationsInputDesc": "Please input your WMS_ReceiptReceivingSpecifications",
                     
                    
                     "WMS_ReceiptReceivingArea": "WMS_ReceiptReceivingArea",
                    "WMS_ReceiptReceivingAreaInputDesc": "Please input your WMS_ReceiptReceivingArea",
                     
                    
                     "WMS_ReceiptReceivingLocation": "WMS_ReceiptReceivingLocation",
                    "WMS_ReceiptReceivingLocationInputDesc": "Please input your WMS_ReceiptReceivingLocation",
                     
"Price": "Price",
"Weight": "Weight",
"Volume": "Volume",
"ProductionDate": "ProductionDate",
"ExpirationDate": "ExpirationDate",
                    
                     "WMS_ReceiptReceivingRemark": "WMS_ReceiptReceivingRemark",
                    "WMS_ReceiptReceivingRemarkInputDesc": "Please input your WMS_ReceiptReceivingRemark",
                     
                    
                     "WMS_ReceiptReceivingCreator": "WMS_ReceiptReceivingCreator",
                    "WMS_ReceiptReceivingCreatorInputDesc": "Please input your WMS_ReceiptReceivingCreator",
                     
"CreateTime": "CreateTime",
                    
                     "WMS_ReceiptReceivingUpdator": "WMS_ReceiptReceivingUpdator",
                    "WMS_ReceiptReceivingUpdatorInputDesc": "Please input your WMS_ReceiptReceivingUpdator",
                     
"UpdateTime": "UpdateTime",
                    
                     "WMS_ReceiptReceivingStr1": "WMS_ReceiptReceivingStr1",
                    "WMS_ReceiptReceivingStr1InputDesc": "Please input your WMS_ReceiptReceivingStr1",
                     
                    
                     "WMS_ReceiptReceivingStr2": "WMS_ReceiptReceivingStr2",
                    "WMS_ReceiptReceivingStr2InputDesc": "Please input your WMS_ReceiptReceivingStr2",
                     
                    
                     "WMS_ReceiptReceivingStr3": "WMS_ReceiptReceivingStr3",
                    "WMS_ReceiptReceivingStr3InputDesc": "Please input your WMS_ReceiptReceivingStr3",
                     
                    
                     "WMS_ReceiptReceivingStr4": "WMS_ReceiptReceivingStr4",
                    "WMS_ReceiptReceivingStr4InputDesc": "Please input your WMS_ReceiptReceivingStr4",
                     
                    
                     "WMS_ReceiptReceivingStr5": "WMS_ReceiptReceivingStr5",
                    "WMS_ReceiptReceivingStr5InputDesc": "Please input your WMS_ReceiptReceivingStr5",
                     
                    
                     "WMS_ReceiptReceivingStr6": "WMS_ReceiptReceivingStr6",
                    "WMS_ReceiptReceivingStr6InputDesc": "Please input your WMS_ReceiptReceivingStr6",
                     
                    
                     "WMS_ReceiptReceivingStr7": "WMS_ReceiptReceivingStr7",
                    "WMS_ReceiptReceivingStr7InputDesc": "Please input your WMS_ReceiptReceivingStr7",
                     
                    
                     "WMS_ReceiptReceivingStr8": "WMS_ReceiptReceivingStr8",
                    "WMS_ReceiptReceivingStr8InputDesc": "Please input your WMS_ReceiptReceivingStr8",
                     
                    
                     "WMS_ReceiptReceivingStr9": "WMS_ReceiptReceivingStr9",
                    "WMS_ReceiptReceivingStr9InputDesc": "Please input your WMS_ReceiptReceivingStr9",
                     
                    
                     "WMS_ReceiptReceivingStr10": "WMS_ReceiptReceivingStr10",
                    "WMS_ReceiptReceivingStr10InputDesc": "Please input your WMS_ReceiptReceivingStr10",
                     
                    
                     "WMS_ReceiptReceivingStr11": "WMS_ReceiptReceivingStr11",
                    "WMS_ReceiptReceivingStr11InputDesc": "Please input your WMS_ReceiptReceivingStr11",
                     
                    
                     "WMS_ReceiptReceivingStr12": "WMS_ReceiptReceivingStr12",
                    "WMS_ReceiptReceivingStr12InputDesc": "Please input your WMS_ReceiptReceivingStr12",
                     
                    
                     "WMS_ReceiptReceivingStr13": "WMS_ReceiptReceivingStr13",
                    "WMS_ReceiptReceivingStr13InputDesc": "Please input your WMS_ReceiptReceivingStr13",
                     
                    
                     "WMS_ReceiptReceivingStr14": "WMS_ReceiptReceivingStr14",
                    "WMS_ReceiptReceivingStr14InputDesc": "Please input your WMS_ReceiptReceivingStr14",
                     
                    
                     "WMS_ReceiptReceivingStr15": "WMS_ReceiptReceivingStr15",
                    "WMS_ReceiptReceivingStr15InputDesc": "Please input your WMS_ReceiptReceivingStr15",
                     
                    
                     "WMS_ReceiptReceivingStr16": "WMS_ReceiptReceivingStr16",
                    "WMS_ReceiptReceivingStr16InputDesc": "Please input your WMS_ReceiptReceivingStr16",
                     
                    
                     "WMS_ReceiptReceivingStr17": "WMS_ReceiptReceivingStr17",
                    "WMS_ReceiptReceivingStr17InputDesc": "Please input your WMS_ReceiptReceivingStr17",
                     
                    
                     "WMS_ReceiptReceivingStr18": "WMS_ReceiptReceivingStr18",
                    "WMS_ReceiptReceivingStr18InputDesc": "Please input your WMS_ReceiptReceivingStr18",
                     
                    
                     "WMS_ReceiptReceivingStr19": "WMS_ReceiptReceivingStr19",
                    "WMS_ReceiptReceivingStr19InputDesc": "Please input your WMS_ReceiptReceivingStr19",
                     
                    
                     "WMS_ReceiptReceivingStr20": "WMS_ReceiptReceivingStr20",
                    "WMS_ReceiptReceivingStr20InputDesc": "Please input your WMS_ReceiptReceivingStr20",
                     
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
					                     
                    "WMS_ReceiptReceiving": "WMS_ReceiptReceiving",
                    "ManageWMS_ReceiptReceiving": "ManageWMS_ReceiptReceiving",
                    "QueryWMS_ReceiptReceiving": "QueryWMS_ReceiptReceiving",
                    "CreateWMS_ReceiptReceiving": "CreateWMS_ReceiptReceiving",
                    "EditWMS_ReceiptReceiving": "EditWMS_ReceiptReceiving",
                    "DeleteWMS_ReceiptReceiving": "DeleteWMS_ReceiptReceiving",
                    "BatchDeleteWMS_ReceiptReceiving": "BatchDeleteWMS_ReceiptReceiving",
                    "ExportWMS_ReceiptReceiving": "ExportWMS_ReceiptReceiving",
                    "WMS_ReceiptReceivingList": "WMS_ReceiptReceivingList",
                     //的多语言配置==End
                    




```