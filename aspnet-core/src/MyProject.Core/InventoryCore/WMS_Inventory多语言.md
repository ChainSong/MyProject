

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
"ReceiptReceivingId": "ReceiptReceivingId",
"ReceiptDetailId": "ReceiptDetailId",
"ReceiptId": "ReceiptId",
"ASNId": "ASNId",
"ASNDetailId": "ASNDetailId",
"ExtensionDetailGUID": "ExtensionDetailGUID",
                    
                     "WMS_InventoryReceiptNumber": "ReceiptNumber",
                    "WMS_InventoryReceiptNumberInputDesc": "请输入ReceiptNumber",
                     
                    
                     "WMS_InventoryExternReceiptNumber": "ExternReceiptNumber",
                    "WMS_InventoryExternReceiptNumberInputDesc": "请输入ExternReceiptNumber",
                     
                    
                     "WMS_InventoryASNNumber": "ASNNumber",
                    "WMS_InventoryASNNumberInputDesc": "请输入ASNNumber",
                     
"CustomerId": "CustomerId",
                    
                     "WMS_InventoryCustomerName": "CustomerName",
                    "WMS_InventoryCustomerNameInputDesc": "请输入CustomerName",
                     
"WarehouseId": "WarehouseId",
                    
                     "WMS_InventoryWarehouseName": "WarehouseName",
                    "WMS_InventoryWarehouseNameInputDesc": "请输入WarehouseName",
                     
                    
                     "WMS_InventoryLineNumber": "LineNumber",
                    "WMS_InventoryLineNumberInputDesc": "请输入LineNumber",
                     
                    
                     "WMS_InventorySKU": "SKU",
                    "WMS_InventorySKUInputDesc": "请输入SKU",
                     
                    
                     "WMS_InventoryUPC": "UPC",
                    "WMS_InventoryUPCInputDesc": "请输入UPC",
                     
"RRStatus": "RRStatus",
                    
                     "WMS_InventoryGoodsType": "GoodsType",
                    "WMS_InventoryGoodsTypeInputDesc": "请输入GoodsType",
                     
"InventoryType": "InventoryType",
                    
                     "WMS_InventoryGoodsName": "GoodsName",
                    "WMS_InventoryGoodsNameInputDesc": "请输入GoodsName",
                     
                    
                     "WMS_InventoryBoxNumber": "BoxNumber",
                    "WMS_InventoryBoxNumberInputDesc": "请输入BoxNumber",
                     
                    
                     "WMS_InventoryBatchNumber": "BatchNumber",
                    "WMS_InventoryBatchNumberInputDesc": "请输入BatchNumber",
                     
"QtyReceived": "QtyReceived",
                    
                     "WMS_InventoryUnit": "Unit",
                    "WMS_InventoryUnitInputDesc": "请输入Unit",
                     
                    
                     "WMS_InventorySpecifications": "Specifications",
                    "WMS_InventorySpecificationsInputDesc": "请输入Specifications",
                     
                    
                     "WMS_InventoryArea": "Area",
                    "WMS_InventoryAreaInputDesc": "请输入Area",
                     
                    
                     "WMS_InventoryLocation": "Location",
                    "WMS_InventoryLocationInputDesc": "请输入Location",
                     
"Price": "Price",
"Weight": "Weight",
"Volume": "Volume",
"ProductionDate": "ProductionDate",
"ExpirationDate": "ExpirationDate",
                    
                     "WMS_InventoryRemark": "Remark",
                    "WMS_InventoryRemarkInputDesc": "请输入Remark",
                     
"InventoryTime": "InventoryTime",
                    
                     "WMS_InventoryCreator": "Creator",
                    "WMS_InventoryCreatorInputDesc": "请输入Creator",
                     
"CreateTime": "CreateTime",
                    
                     "WMS_InventoryUpdator": "Updator",
                    "WMS_InventoryUpdatorInputDesc": "请输入Updator",
                     
"UpdateTime": "UpdateTime",
                    
                     "WMS_InventoryStr1": "Str1",
                    "WMS_InventoryStr1InputDesc": "请输入Str1",
                     
                    
                     "WMS_InventoryStr2": "Str2",
                    "WMS_InventoryStr2InputDesc": "请输入Str2",
                     
                    
                     "WMS_InventoryStr3": "Str3",
                    "WMS_InventoryStr3InputDesc": "请输入Str3",
                     
                    
                     "WMS_InventoryStr4": "Str4",
                    "WMS_InventoryStr4InputDesc": "请输入Str4",
                     
                    
                     "WMS_InventoryStr5": "Str5",
                    "WMS_InventoryStr5InputDesc": "请输入Str5",
                     
                    
                     "WMS_InventoryStr6": "Str6",
                    "WMS_InventoryStr6InputDesc": "请输入Str6",
                     
                    
                     "WMS_InventoryStr7": "Str7",
                    "WMS_InventoryStr7InputDesc": "请输入Str7",
                     
                    
                     "WMS_InventoryStr8": "Str8",
                    "WMS_InventoryStr8InputDesc": "请输入Str8",
                     
                    
                     "WMS_InventoryStr9": "Str9",
                    "WMS_InventoryStr9InputDesc": "请输入Str9",
                     
                    
                     "WMS_InventoryStr10": "Str10",
                    "WMS_InventoryStr10InputDesc": "请输入Str10",
                     
                    
                     "WMS_InventoryStr11": "Str11",
                    "WMS_InventoryStr11InputDesc": "请输入Str11",
                     
                    
                     "WMS_InventoryStr12": "Str12",
                    "WMS_InventoryStr12InputDesc": "请输入Str12",
                     
                    
                     "WMS_InventoryStr13": "Str13",
                    "WMS_InventoryStr13InputDesc": "请输入Str13",
                     
                    
                     "WMS_InventoryStr14": "Str14",
                    "WMS_InventoryStr14InputDesc": "请输入Str14",
                     
                    
                     "WMS_InventoryStr15": "Str15",
                    "WMS_InventoryStr15InputDesc": "请输入Str15",
                     
                    
                     "WMS_InventoryStr16": "Str16",
                    "WMS_InventoryStr16InputDesc": "请输入Str16",
                     
                    
                     "WMS_InventoryStr17": "Str17",
                    "WMS_InventoryStr17InputDesc": "请输入Str17",
                     
                    
                     "WMS_InventoryStr18": "Str18",
                    "WMS_InventoryStr18InputDesc": "请输入Str18",
                     
                    
                     "WMS_InventoryStr19": "Str19",
                    "WMS_InventoryStr19InputDesc": "请输入Str19",
                     
                    
                     "WMS_InventoryStr20": "Str20",
                    "WMS_InventoryStr20InputDesc": "请输入Str20",
                     
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
					                     
                    "WMS_Inventory": "",
                    "ManageWMS_Inventory": "管理",
                    "QueryWMS_Inventory": "查询",
                    "CreateWMS_Inventory": "添加",
                    "EditWMS_Inventory": "编辑",
                    "DeleteWMS_Inventory": "删除",
                    "BatchDeleteWMS_Inventory": "批量删除",
                    "ExportWMS_Inventory": "导出",
                    "WMS_InventoryList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyProject.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
"ReceiptReceivingId": "ReceiptReceivingId",
"ReceiptDetailId": "ReceiptDetailId",
"ReceiptId": "ReceiptId",
"ASNId": "ASNId",
"ASNDetailId": "ASNDetailId",
"ExtensionDetailGUID": "ExtensionDetailGUID",
                    
                     "WMS_InventoryReceiptNumber": "WMS_InventoryReceiptNumber",
                    "WMS_InventoryReceiptNumberInputDesc": "Please input your WMS_InventoryReceiptNumber",
                     
                    
                     "WMS_InventoryExternReceiptNumber": "WMS_InventoryExternReceiptNumber",
                    "WMS_InventoryExternReceiptNumberInputDesc": "Please input your WMS_InventoryExternReceiptNumber",
                     
                    
                     "WMS_InventoryASNNumber": "WMS_InventoryASNNumber",
                    "WMS_InventoryASNNumberInputDesc": "Please input your WMS_InventoryASNNumber",
                     
"CustomerId": "CustomerId",
                    
                     "WMS_InventoryCustomerName": "WMS_InventoryCustomerName",
                    "WMS_InventoryCustomerNameInputDesc": "Please input your WMS_InventoryCustomerName",
                     
"WarehouseId": "WarehouseId",
                    
                     "WMS_InventoryWarehouseName": "WMS_InventoryWarehouseName",
                    "WMS_InventoryWarehouseNameInputDesc": "Please input your WMS_InventoryWarehouseName",
                     
                    
                     "WMS_InventoryLineNumber": "WMS_InventoryLineNumber",
                    "WMS_InventoryLineNumberInputDesc": "Please input your WMS_InventoryLineNumber",
                     
                    
                     "WMS_InventorySKU": "WMS_InventorySKU",
                    "WMS_InventorySKUInputDesc": "Please input your WMS_InventorySKU",
                     
                    
                     "WMS_InventoryUPC": "WMS_InventoryUPC",
                    "WMS_InventoryUPCInputDesc": "Please input your WMS_InventoryUPC",
                     
"RRStatus": "RRStatus",
                    
                     "WMS_InventoryGoodsType": "WMS_InventoryGoodsType",
                    "WMS_InventoryGoodsTypeInputDesc": "Please input your WMS_InventoryGoodsType",
                     
"InventoryType": "InventoryType",
                    
                     "WMS_InventoryGoodsName": "WMS_InventoryGoodsName",
                    "WMS_InventoryGoodsNameInputDesc": "Please input your WMS_InventoryGoodsName",
                     
                    
                     "WMS_InventoryBoxNumber": "WMS_InventoryBoxNumber",
                    "WMS_InventoryBoxNumberInputDesc": "Please input your WMS_InventoryBoxNumber",
                     
                    
                     "WMS_InventoryBatchNumber": "WMS_InventoryBatchNumber",
                    "WMS_InventoryBatchNumberInputDesc": "Please input your WMS_InventoryBatchNumber",
                     
"QtyReceived": "QtyReceived",
                    
                     "WMS_InventoryUnit": "WMS_InventoryUnit",
                    "WMS_InventoryUnitInputDesc": "Please input your WMS_InventoryUnit",
                     
                    
                     "WMS_InventorySpecifications": "WMS_InventorySpecifications",
                    "WMS_InventorySpecificationsInputDesc": "Please input your WMS_InventorySpecifications",
                     
                    
                     "WMS_InventoryArea": "WMS_InventoryArea",
                    "WMS_InventoryAreaInputDesc": "Please input your WMS_InventoryArea",
                     
                    
                     "WMS_InventoryLocation": "WMS_InventoryLocation",
                    "WMS_InventoryLocationInputDesc": "Please input your WMS_InventoryLocation",
                     
"Price": "Price",
"Weight": "Weight",
"Volume": "Volume",
"ProductionDate": "ProductionDate",
"ExpirationDate": "ExpirationDate",
                    
                     "WMS_InventoryRemark": "WMS_InventoryRemark",
                    "WMS_InventoryRemarkInputDesc": "Please input your WMS_InventoryRemark",
                     
"InventoryTime": "InventoryTime",
                    
                     "WMS_InventoryCreator": "WMS_InventoryCreator",
                    "WMS_InventoryCreatorInputDesc": "Please input your WMS_InventoryCreator",
                     
"CreateTime": "CreateTime",
                    
                     "WMS_InventoryUpdator": "WMS_InventoryUpdator",
                    "WMS_InventoryUpdatorInputDesc": "Please input your WMS_InventoryUpdator",
                     
"UpdateTime": "UpdateTime",
                    
                     "WMS_InventoryStr1": "WMS_InventoryStr1",
                    "WMS_InventoryStr1InputDesc": "Please input your WMS_InventoryStr1",
                     
                    
                     "WMS_InventoryStr2": "WMS_InventoryStr2",
                    "WMS_InventoryStr2InputDesc": "Please input your WMS_InventoryStr2",
                     
                    
                     "WMS_InventoryStr3": "WMS_InventoryStr3",
                    "WMS_InventoryStr3InputDesc": "Please input your WMS_InventoryStr3",
                     
                    
                     "WMS_InventoryStr4": "WMS_InventoryStr4",
                    "WMS_InventoryStr4InputDesc": "Please input your WMS_InventoryStr4",
                     
                    
                     "WMS_InventoryStr5": "WMS_InventoryStr5",
                    "WMS_InventoryStr5InputDesc": "Please input your WMS_InventoryStr5",
                     
                    
                     "WMS_InventoryStr6": "WMS_InventoryStr6",
                    "WMS_InventoryStr6InputDesc": "Please input your WMS_InventoryStr6",
                     
                    
                     "WMS_InventoryStr7": "WMS_InventoryStr7",
                    "WMS_InventoryStr7InputDesc": "Please input your WMS_InventoryStr7",
                     
                    
                     "WMS_InventoryStr8": "WMS_InventoryStr8",
                    "WMS_InventoryStr8InputDesc": "Please input your WMS_InventoryStr8",
                     
                    
                     "WMS_InventoryStr9": "WMS_InventoryStr9",
                    "WMS_InventoryStr9InputDesc": "Please input your WMS_InventoryStr9",
                     
                    
                     "WMS_InventoryStr10": "WMS_InventoryStr10",
                    "WMS_InventoryStr10InputDesc": "Please input your WMS_InventoryStr10",
                     
                    
                     "WMS_InventoryStr11": "WMS_InventoryStr11",
                    "WMS_InventoryStr11InputDesc": "Please input your WMS_InventoryStr11",
                     
                    
                     "WMS_InventoryStr12": "WMS_InventoryStr12",
                    "WMS_InventoryStr12InputDesc": "Please input your WMS_InventoryStr12",
                     
                    
                     "WMS_InventoryStr13": "WMS_InventoryStr13",
                    "WMS_InventoryStr13InputDesc": "Please input your WMS_InventoryStr13",
                     
                    
                     "WMS_InventoryStr14": "WMS_InventoryStr14",
                    "WMS_InventoryStr14InputDesc": "Please input your WMS_InventoryStr14",
                     
                    
                     "WMS_InventoryStr15": "WMS_InventoryStr15",
                    "WMS_InventoryStr15InputDesc": "Please input your WMS_InventoryStr15",
                     
                    
                     "WMS_InventoryStr16": "WMS_InventoryStr16",
                    "WMS_InventoryStr16InputDesc": "Please input your WMS_InventoryStr16",
                     
                    
                     "WMS_InventoryStr17": "WMS_InventoryStr17",
                    "WMS_InventoryStr17InputDesc": "Please input your WMS_InventoryStr17",
                     
                    
                     "WMS_InventoryStr18": "WMS_InventoryStr18",
                    "WMS_InventoryStr18InputDesc": "Please input your WMS_InventoryStr18",
                     
                    
                     "WMS_InventoryStr19": "WMS_InventoryStr19",
                    "WMS_InventoryStr19InputDesc": "Please input your WMS_InventoryStr19",
                     
                    
                     "WMS_InventoryStr20": "WMS_InventoryStr20",
                    "WMS_InventoryStr20InputDesc": "Please input your WMS_InventoryStr20",
                     
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
					                     
                    "WMS_Inventory": "WMS_Inventory",
                    "ManageWMS_Inventory": "ManageWMS_Inventory",
                    "QueryWMS_Inventory": "QueryWMS_Inventory",
                    "CreateWMS_Inventory": "CreateWMS_Inventory",
                    "EditWMS_Inventory": "EditWMS_Inventory",
                    "DeleteWMS_Inventory": "DeleteWMS_Inventory",
                    "BatchDeleteWMS_Inventory": "BatchDeleteWMS_Inventory",
                    "ExportWMS_Inventory": "ExportWMS_Inventory",
                    "WMS_InventoryList": "WMS_InventoryList",
                     //的多语言配置==End
                    




```