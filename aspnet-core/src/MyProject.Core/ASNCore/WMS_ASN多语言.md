

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
"ExtensionGUID": "ExtensionGUID",
                    
                     "WMS_ASNASNNumber": "ASNNumber",
                    "WMS_ASNASNNumberInputDesc": "请输入ASNNumber",
                     
                    
                     "WMS_ASNExternReceiptNumber": "ExternReceiptNumber",
                    "WMS_ASNExternReceiptNumberInputDesc": "请输入ExternReceiptNumber",
                     
"CustomerID": "CustomerID",
                    
                     "WMS_ASNCustomerName": "CustomerName",
                    "WMS_ASNCustomerNameInputDesc": "请输入CustomerName",
                     
"WarehouseID": "WarehouseID",
                    
                     "WMS_ASNWarehouseName": "WarehouseName",
                    "WMS_ASNWarehouseNameInputDesc": "请输入WarehouseName",
                     
"ExpectDate": "ExpectDate",
"ASNStatus": "ASNStatus",
                    
                     "WMS_ASNASNType": "ASNType",
                    "WMS_ASNASNTypeInputDesc": "请输入ASNType",
                     
                    
                     "WMS_ASNPO": "PO",
                    "WMS_ASNPOInputDesc": "请输入PO",
                     
                    
                     "WMS_ASNContact": "Contact",
                    "WMS_ASNContactInputDesc": "请输入Contact",
                     
                    
                     "WMS_ASNContactInfo": "ContactInfo",
                    "WMS_ASNContactInfoInputDesc": "请输入ContactInfo",
                     
"CompleteDate": "CompleteDate",
                    
                     "WMS_ASNRemark": "Remark",
                    "WMS_ASNRemarkInputDesc": "请输入Remark",
                     
                    
                     "WMS_ASNCreator": "Creator",
                    "WMS_ASNCreatorInputDesc": "请输入Creator",
                     
"CreationTime": "CreationTime",
                    
                     "WMS_ASNUpdator": "Updator",
                    "WMS_ASNUpdatorInputDesc": "请输入Updator",
                     
"UpdateTime": "UpdateTime",
                    
                     "WMS_ASNStr1": "Str1",
                    "WMS_ASNStr1InputDesc": "请输入Str1",
                     
                    
                     "WMS_ASNStr2": "Str2",
                    "WMS_ASNStr2InputDesc": "请输入Str2",
                     
                    
                     "WMS_ASNStr3": "Str3",
                    "WMS_ASNStr3InputDesc": "请输入Str3",
                     
                    
                     "WMS_ASNStr4": "Str4",
                    "WMS_ASNStr4InputDesc": "请输入Str4",
                     
                    
                     "WMS_ASNStr5": "Str5",
                    "WMS_ASNStr5InputDesc": "请输入Str5",
                     
                    
                     "WMS_ASNStr6": "Str6",
                    "WMS_ASNStr6InputDesc": "请输入Str6",
                     
                    
                     "WMS_ASNStr7": "Str7",
                    "WMS_ASNStr7InputDesc": "请输入Str7",
                     
                    
                     "WMS_ASNStr8": "Str8",
                    "WMS_ASNStr8InputDesc": "请输入Str8",
                     
                    
                     "WMS_ASNStr9": "Str9",
                    "WMS_ASNStr9InputDesc": "请输入Str9",
                     
                    
                     "WMS_ASNStr10": "Str10",
                    "WMS_ASNStr10InputDesc": "请输入Str10",
                     
                    
                     "WMS_ASNStr11": "Str11",
                    "WMS_ASNStr11InputDesc": "请输入Str11",
                     
                    
                     "WMS_ASNStr12": "Str12",
                    "WMS_ASNStr12InputDesc": "请输入Str12",
                     
                    
                     "WMS_ASNStr13": "Str13",
                    "WMS_ASNStr13InputDesc": "请输入Str13",
                     
                    
                     "WMS_ASNStr14": "Str14",
                    "WMS_ASNStr14InputDesc": "请输入Str14",
                     
                    
                     "WMS_ASNStr15": "Str15",
                    "WMS_ASNStr15InputDesc": "请输入Str15",
                     
                    
                     "WMS_ASNStr16": "Str16",
                    "WMS_ASNStr16InputDesc": "请输入Str16",
                     
                    
                     "WMS_ASNStr17": "Str17",
                    "WMS_ASNStr17InputDesc": "请输入Str17",
                     
                    
                     "WMS_ASNStr18": "Str18",
                    "WMS_ASNStr18InputDesc": "请输入Str18",
                     
                    
                     "WMS_ASNStr19": "Str19",
                    "WMS_ASNStr19InputDesc": "请输入Str19",
                     
                    
                     "WMS_ASNStr20": "Str20",
                    "WMS_ASNStr20InputDesc": "请输入Str20",
                     
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
"WMS_ASNDetails": "WMS_ASNDetails",
					                     
                    "WMS_ASN": "",
                    "ManageWMS_ASN": "管理",
                    "QueryWMS_ASN": "查询",
                    "CreateWMS_ASN": "添加",
                    "EditWMS_ASN": "编辑",
                    "DeleteWMS_ASN": "删除",
                    "BatchDeleteWMS_ASN": "批量删除",
                    "ExportWMS_ASN": "导出",
                    "WMS_ASNList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyProject.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
"ExtensionGUID": "ExtensionGUID",
                    
                     "WMS_ASNASNNumber": "WMS_ASNASNNumber",
                    "WMS_ASNASNNumberInputDesc": "Please input your WMS_ASNASNNumber",
                     
                    
                     "WMS_ASNExternReceiptNumber": "WMS_ASNExternReceiptNumber",
                    "WMS_ASNExternReceiptNumberInputDesc": "Please input your WMS_ASNExternReceiptNumber",
                     
"CustomerID": "CustomerID",
                    
                     "WMS_ASNCustomerName": "WMS_ASNCustomerName",
                    "WMS_ASNCustomerNameInputDesc": "Please input your WMS_ASNCustomerName",
                     
"WarehouseID": "WarehouseID",
                    
                     "WMS_ASNWarehouseName": "WMS_ASNWarehouseName",
                    "WMS_ASNWarehouseNameInputDesc": "Please input your WMS_ASNWarehouseName",
                     
"ExpectDate": "ExpectDate",
"ASNStatus": "ASNStatus",
                    
                     "WMS_ASNASNType": "WMS_ASNASNType",
                    "WMS_ASNASNTypeInputDesc": "Please input your WMS_ASNASNType",
                     
                    
                     "WMS_ASNPO": "WMS_ASNPO",
                    "WMS_ASNPOInputDesc": "Please input your WMS_ASNPO",
                     
                    
                     "WMS_ASNContact": "WMS_ASNContact",
                    "WMS_ASNContactInputDesc": "Please input your WMS_ASNContact",
                     
                    
                     "WMS_ASNContactInfo": "WMS_ASNContactInfo",
                    "WMS_ASNContactInfoInputDesc": "Please input your WMS_ASNContactInfo",
                     
"CompleteDate": "CompleteDate",
                    
                     "WMS_ASNRemark": "WMS_ASNRemark",
                    "WMS_ASNRemarkInputDesc": "Please input your WMS_ASNRemark",
                     
                    
                     "WMS_ASNCreator": "WMS_ASNCreator",
                    "WMS_ASNCreatorInputDesc": "Please input your WMS_ASNCreator",
                     
"CreationTime": "CreationTime",
                    
                     "WMS_ASNUpdator": "WMS_ASNUpdator",
                    "WMS_ASNUpdatorInputDesc": "Please input your WMS_ASNUpdator",
                     
"UpdateTime": "UpdateTime",
                    
                     "WMS_ASNStr1": "WMS_ASNStr1",
                    "WMS_ASNStr1InputDesc": "Please input your WMS_ASNStr1",
                     
                    
                     "WMS_ASNStr2": "WMS_ASNStr2",
                    "WMS_ASNStr2InputDesc": "Please input your WMS_ASNStr2",
                     
                    
                     "WMS_ASNStr3": "WMS_ASNStr3",
                    "WMS_ASNStr3InputDesc": "Please input your WMS_ASNStr3",
                     
                    
                     "WMS_ASNStr4": "WMS_ASNStr4",
                    "WMS_ASNStr4InputDesc": "Please input your WMS_ASNStr4",
                     
                    
                     "WMS_ASNStr5": "WMS_ASNStr5",
                    "WMS_ASNStr5InputDesc": "Please input your WMS_ASNStr5",
                     
                    
                     "WMS_ASNStr6": "WMS_ASNStr6",
                    "WMS_ASNStr6InputDesc": "Please input your WMS_ASNStr6",
                     
                    
                     "WMS_ASNStr7": "WMS_ASNStr7",
                    "WMS_ASNStr7InputDesc": "Please input your WMS_ASNStr7",
                     
                    
                     "WMS_ASNStr8": "WMS_ASNStr8",
                    "WMS_ASNStr8InputDesc": "Please input your WMS_ASNStr8",
                     
                    
                     "WMS_ASNStr9": "WMS_ASNStr9",
                    "WMS_ASNStr9InputDesc": "Please input your WMS_ASNStr9",
                     
                    
                     "WMS_ASNStr10": "WMS_ASNStr10",
                    "WMS_ASNStr10InputDesc": "Please input your WMS_ASNStr10",
                     
                    
                     "WMS_ASNStr11": "WMS_ASNStr11",
                    "WMS_ASNStr11InputDesc": "Please input your WMS_ASNStr11",
                     
                    
                     "WMS_ASNStr12": "WMS_ASNStr12",
                    "WMS_ASNStr12InputDesc": "Please input your WMS_ASNStr12",
                     
                    
                     "WMS_ASNStr13": "WMS_ASNStr13",
                    "WMS_ASNStr13InputDesc": "Please input your WMS_ASNStr13",
                     
                    
                     "WMS_ASNStr14": "WMS_ASNStr14",
                    "WMS_ASNStr14InputDesc": "Please input your WMS_ASNStr14",
                     
                    
                     "WMS_ASNStr15": "WMS_ASNStr15",
                    "WMS_ASNStr15InputDesc": "Please input your WMS_ASNStr15",
                     
                    
                     "WMS_ASNStr16": "WMS_ASNStr16",
                    "WMS_ASNStr16InputDesc": "Please input your WMS_ASNStr16",
                     
                    
                     "WMS_ASNStr17": "WMS_ASNStr17",
                    "WMS_ASNStr17InputDesc": "Please input your WMS_ASNStr17",
                     
                    
                     "WMS_ASNStr18": "WMS_ASNStr18",
                    "WMS_ASNStr18InputDesc": "Please input your WMS_ASNStr18",
                     
                    
                     "WMS_ASNStr19": "WMS_ASNStr19",
                    "WMS_ASNStr19InputDesc": "Please input your WMS_ASNStr19",
                     
                    
                     "WMS_ASNStr20": "WMS_ASNStr20",
                    "WMS_ASNStr20InputDesc": "Please input your WMS_ASNStr20",
                     
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
"WMS_ASNDetails": "WMS_ASNDetails",
					                     
                    "WMS_ASN": "WMS_ASN",
                    "ManageWMS_ASN": "ManageWMS_ASN",
                    "QueryWMS_ASN": "QueryWMS_ASN",
                    "CreateWMS_ASN": "CreateWMS_ASN",
                    "EditWMS_ASN": "EditWMS_ASN",
                    "DeleteWMS_ASN": "DeleteWMS_ASN",
                    "BatchDeleteWMS_ASN": "BatchDeleteWMS_ASN",
                    "ExportWMS_ASN": "ExportWMS_ASN",
                    "WMS_ASNList": "WMS_ASNList",
                     //的多语言配置==End
                    




```