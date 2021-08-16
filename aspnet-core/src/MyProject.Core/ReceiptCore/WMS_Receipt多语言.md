

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
                    
                     "WMS_ReceiptReceiptNumber": "ReceiptNumber",
                    "WMS_ReceiptReceiptNumberInputDesc": "请输入ReceiptNumber",
                     
                    
                     "WMS_ReceiptExternReceiptNumber": "ExternReceiptNumber",
                    "WMS_ReceiptExternReceiptNumberInputDesc": "请输入ExternReceiptNumber",
                     
"ExtensionGUID": "ExtensionGUID",
"ASNId": "ASNId",
                    
                     "WMS_ReceiptASNNumber": "ASNNumber",
                    "WMS_ReceiptASNNumberInputDesc": "请输入ASNNumber",
                     
"CustomerId": "CustomerId",
                    
                     "WMS_ReceiptCustomerName": "CustomerName",
                    "WMS_ReceiptCustomerNameInputDesc": "请输入CustomerName",
                     
"WarehouseId": "WarehouseId",
                    
                     "WMS_ReceiptWarehouseName": "WarehouseName",
                    "WMS_ReceiptWarehouseNameInputDesc": "请输入WarehouseName",
                     
"ReceiptDate": "ReceiptDate",
"ReceiptStatus": "ReceiptStatus",
                    
                     "WMS_ReceiptReceiptType": "ReceiptType",
                    "WMS_ReceiptReceiptTypeInputDesc": "请输入ReceiptType",
                     
                    
                     "WMS_ReceiptPO": "PO",
                    "WMS_ReceiptPOInputDesc": "请输入PO",
                     
                    
                     "WMS_ReceiptContact": "Contact",
                    "WMS_ReceiptContactInputDesc": "请输入Contact",
                     
                    
                     "WMS_ReceiptContactInfo": "ContactInfo",
                    "WMS_ReceiptContactInfoInputDesc": "请输入ContactInfo",
                     
                    
                     "WMS_ReceiptCompleteDate": "CompleteDate",
                    "WMS_ReceiptCompleteDateInputDesc": "请输入CompleteDate",
                     
                    
                     "WMS_ReceiptRemark": "Remark",
                    "WMS_ReceiptRemarkInputDesc": "请输入Remark",
                     
                    
                     "WMS_ReceiptCreator": "Creator",
                    "WMS_ReceiptCreatorInputDesc": "请输入Creator",
                     
"CreateTime": "CreateTime",
                    
                     "WMS_ReceiptUpdator": "Updator",
                    "WMS_ReceiptUpdatorInputDesc": "请输入Updator",
                     
"UpdateTime": "UpdateTime",
                    
                     "WMS_ReceiptStr1": "Str1",
                    "WMS_ReceiptStr1InputDesc": "请输入Str1",
                     
                    
                     "WMS_ReceiptStr2": "Str2",
                    "WMS_ReceiptStr2InputDesc": "请输入Str2",
                     
                    
                     "WMS_ReceiptStr3": "Str3",
                    "WMS_ReceiptStr3InputDesc": "请输入Str3",
                     
                    
                     "WMS_ReceiptStr4": "Str4",
                    "WMS_ReceiptStr4InputDesc": "请输入Str4",
                     
                    
                     "WMS_ReceiptStr5": "Str5",
                    "WMS_ReceiptStr5InputDesc": "请输入Str5",
                     
                    
                     "WMS_ReceiptStr6": "Str6",
                    "WMS_ReceiptStr6InputDesc": "请输入Str6",
                     
                    
                     "WMS_ReceiptStr7": "Str7",
                    "WMS_ReceiptStr7InputDesc": "请输入Str7",
                     
                    
                     "WMS_ReceiptStr8": "Str8",
                    "WMS_ReceiptStr8InputDesc": "请输入Str8",
                     
                    
                     "WMS_ReceiptStr9": "Str9",
                    "WMS_ReceiptStr9InputDesc": "请输入Str9",
                     
                    
                     "WMS_ReceiptStr10": "Str10",
                    "WMS_ReceiptStr10InputDesc": "请输入Str10",
                     
                    
                     "WMS_ReceiptStr11": "Str11",
                    "WMS_ReceiptStr11InputDesc": "请输入Str11",
                     
                    
                     "WMS_ReceiptStr12": "Str12",
                    "WMS_ReceiptStr12InputDesc": "请输入Str12",
                     
                    
                     "WMS_ReceiptStr13": "Str13",
                    "WMS_ReceiptStr13InputDesc": "请输入Str13",
                     
                    
                     "WMS_ReceiptStr14": "Str14",
                    "WMS_ReceiptStr14InputDesc": "请输入Str14",
                     
                    
                     "WMS_ReceiptStr15": "Str15",
                    "WMS_ReceiptStr15InputDesc": "请输入Str15",
                     
                    
                     "WMS_ReceiptStr16": "Str16",
                    "WMS_ReceiptStr16InputDesc": "请输入Str16",
                     
                    
                     "WMS_ReceiptStr17": "Str17",
                    "WMS_ReceiptStr17InputDesc": "请输入Str17",
                     
                    
                     "WMS_ReceiptStr18": "Str18",
                    "WMS_ReceiptStr18InputDesc": "请输入Str18",
                     
                    
                     "WMS_ReceiptStr19": "Str19",
                    "WMS_ReceiptStr19InputDesc": "请输入Str19",
                     
                    
                     "WMS_ReceiptStr20": "Str20",
                    "WMS_ReceiptStr20InputDesc": "请输入Str20",
                     
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
					                     
                    "WMS_Receipt": "",
                    "ManageWMS_Receipt": "管理",
                    "QueryWMS_Receipt": "查询",
                    "CreateWMS_Receipt": "添加",
                    "EditWMS_Receipt": "编辑",
                    "DeleteWMS_Receipt": "删除",
                    "BatchDeleteWMS_Receipt": "批量删除",
                    "ExportWMS_Receipt": "导出",
                    "WMS_ReceiptList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyProject.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "WMS_ReceiptReceiptNumber": "WMS_ReceiptReceiptNumber",
                    "WMS_ReceiptReceiptNumberInputDesc": "Please input your WMS_ReceiptReceiptNumber",
                     
                    
                     "WMS_ReceiptExternReceiptNumber": "WMS_ReceiptExternReceiptNumber",
                    "WMS_ReceiptExternReceiptNumberInputDesc": "Please input your WMS_ReceiptExternReceiptNumber",
                     
"ExtensionGUID": "ExtensionGUID",
"ASNId": "ASNId",
                    
                     "WMS_ReceiptASNNumber": "WMS_ReceiptASNNumber",
                    "WMS_ReceiptASNNumberInputDesc": "Please input your WMS_ReceiptASNNumber",
                     
"CustomerId": "CustomerId",
                    
                     "WMS_ReceiptCustomerName": "WMS_ReceiptCustomerName",
                    "WMS_ReceiptCustomerNameInputDesc": "Please input your WMS_ReceiptCustomerName",
                     
"WarehouseId": "WarehouseId",
                    
                     "WMS_ReceiptWarehouseName": "WMS_ReceiptWarehouseName",
                    "WMS_ReceiptWarehouseNameInputDesc": "Please input your WMS_ReceiptWarehouseName",
                     
"ReceiptDate": "ReceiptDate",
"ReceiptStatus": "ReceiptStatus",
                    
                     "WMS_ReceiptReceiptType": "WMS_ReceiptReceiptType",
                    "WMS_ReceiptReceiptTypeInputDesc": "Please input your WMS_ReceiptReceiptType",
                     
                    
                     "WMS_ReceiptPO": "WMS_ReceiptPO",
                    "WMS_ReceiptPOInputDesc": "Please input your WMS_ReceiptPO",
                     
                    
                     "WMS_ReceiptContact": "WMS_ReceiptContact",
                    "WMS_ReceiptContactInputDesc": "Please input your WMS_ReceiptContact",
                     
                    
                     "WMS_ReceiptContactInfo": "WMS_ReceiptContactInfo",
                    "WMS_ReceiptContactInfoInputDesc": "Please input your WMS_ReceiptContactInfo",
                     
                    
                     "WMS_ReceiptCompleteDate": "WMS_ReceiptCompleteDate",
                    "WMS_ReceiptCompleteDateInputDesc": "Please input your WMS_ReceiptCompleteDate",
                     
                    
                     "WMS_ReceiptRemark": "WMS_ReceiptRemark",
                    "WMS_ReceiptRemarkInputDesc": "Please input your WMS_ReceiptRemark",
                     
                    
                     "WMS_ReceiptCreator": "WMS_ReceiptCreator",
                    "WMS_ReceiptCreatorInputDesc": "Please input your WMS_ReceiptCreator",
                     
"CreateTime": "CreateTime",
                    
                     "WMS_ReceiptUpdator": "WMS_ReceiptUpdator",
                    "WMS_ReceiptUpdatorInputDesc": "Please input your WMS_ReceiptUpdator",
                     
"UpdateTime": "UpdateTime",
                    
                     "WMS_ReceiptStr1": "WMS_ReceiptStr1",
                    "WMS_ReceiptStr1InputDesc": "Please input your WMS_ReceiptStr1",
                     
                    
                     "WMS_ReceiptStr2": "WMS_ReceiptStr2",
                    "WMS_ReceiptStr2InputDesc": "Please input your WMS_ReceiptStr2",
                     
                    
                     "WMS_ReceiptStr3": "WMS_ReceiptStr3",
                    "WMS_ReceiptStr3InputDesc": "Please input your WMS_ReceiptStr3",
                     
                    
                     "WMS_ReceiptStr4": "WMS_ReceiptStr4",
                    "WMS_ReceiptStr4InputDesc": "Please input your WMS_ReceiptStr4",
                     
                    
                     "WMS_ReceiptStr5": "WMS_ReceiptStr5",
                    "WMS_ReceiptStr5InputDesc": "Please input your WMS_ReceiptStr5",
                     
                    
                     "WMS_ReceiptStr6": "WMS_ReceiptStr6",
                    "WMS_ReceiptStr6InputDesc": "Please input your WMS_ReceiptStr6",
                     
                    
                     "WMS_ReceiptStr7": "WMS_ReceiptStr7",
                    "WMS_ReceiptStr7InputDesc": "Please input your WMS_ReceiptStr7",
                     
                    
                     "WMS_ReceiptStr8": "WMS_ReceiptStr8",
                    "WMS_ReceiptStr8InputDesc": "Please input your WMS_ReceiptStr8",
                     
                    
                     "WMS_ReceiptStr9": "WMS_ReceiptStr9",
                    "WMS_ReceiptStr9InputDesc": "Please input your WMS_ReceiptStr9",
                     
                    
                     "WMS_ReceiptStr10": "WMS_ReceiptStr10",
                    "WMS_ReceiptStr10InputDesc": "Please input your WMS_ReceiptStr10",
                     
                    
                     "WMS_ReceiptStr11": "WMS_ReceiptStr11",
                    "WMS_ReceiptStr11InputDesc": "Please input your WMS_ReceiptStr11",
                     
                    
                     "WMS_ReceiptStr12": "WMS_ReceiptStr12",
                    "WMS_ReceiptStr12InputDesc": "Please input your WMS_ReceiptStr12",
                     
                    
                     "WMS_ReceiptStr13": "WMS_ReceiptStr13",
                    "WMS_ReceiptStr13InputDesc": "Please input your WMS_ReceiptStr13",
                     
                    
                     "WMS_ReceiptStr14": "WMS_ReceiptStr14",
                    "WMS_ReceiptStr14InputDesc": "Please input your WMS_ReceiptStr14",
                     
                    
                     "WMS_ReceiptStr15": "WMS_ReceiptStr15",
                    "WMS_ReceiptStr15InputDesc": "Please input your WMS_ReceiptStr15",
                     
                    
                     "WMS_ReceiptStr16": "WMS_ReceiptStr16",
                    "WMS_ReceiptStr16InputDesc": "Please input your WMS_ReceiptStr16",
                     
                    
                     "WMS_ReceiptStr17": "WMS_ReceiptStr17",
                    "WMS_ReceiptStr17InputDesc": "Please input your WMS_ReceiptStr17",
                     
                    
                     "WMS_ReceiptStr18": "WMS_ReceiptStr18",
                    "WMS_ReceiptStr18InputDesc": "Please input your WMS_ReceiptStr18",
                     
                    
                     "WMS_ReceiptStr19": "WMS_ReceiptStr19",
                    "WMS_ReceiptStr19InputDesc": "Please input your WMS_ReceiptStr19",
                     
                    
                     "WMS_ReceiptStr20": "WMS_ReceiptStr20",
                    "WMS_ReceiptStr20InputDesc": "Please input your WMS_ReceiptStr20",
                     
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
					                     
                    "WMS_Receipt": "WMS_Receipt",
                    "ManageWMS_Receipt": "ManageWMS_Receipt",
                    "QueryWMS_Receipt": "QueryWMS_Receipt",
                    "CreateWMS_Receipt": "CreateWMS_Receipt",
                    "EditWMS_Receipt": "EditWMS_Receipt",
                    "DeleteWMS_Receipt": "DeleteWMS_Receipt",
                    "BatchDeleteWMS_Receipt": "BatchDeleteWMS_Receipt",
                    "ExportWMS_Receipt": "ExportWMS_Receipt",
                    "WMS_ReceiptList": "WMS_ReceiptList",
                     //的多语言配置==End
                    




```