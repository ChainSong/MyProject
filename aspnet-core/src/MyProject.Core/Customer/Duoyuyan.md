

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
"ProjectID": "ProjectID",
                    
                     "CustomerDetailCustomerCode": "CustomerCode",
                    "CustomerDetailCustomerCodeInputDesc": "请输入CustomerCode",
                     
                    
                     "CustomerDetailCustomerName": "CustomerName",
                    "CustomerDetailCustomerNameInputDesc": "请输入CustomerName",
                     
                    
                     "CustomerDetailContact": "Contact",
                    "CustomerDetailContactInputDesc": "请输入Contact",
                     
                    
                     "CustomerDetailTEL": "TEL",
                    "CustomerDetailTELInputDesc": "请输入TEL",
                     
                    
                     "CustomerDetailCreator": "Creator",
                    "CustomerDetailCreatorInputDesc": "请输入Creator",
                     
"CreationTime": "CreationTime",
"CustomerId": "CustomerId",
"Customer": "Customer",
					                     
                    "CustomerDetail": "",
                    "ManageCustomerDetail": "管理",
                    "QueryCustomerDetail": "查询",
                    "CreateCustomerDetail": "添加",
                    "EditCustomerDetail": "编辑",
                    "DeleteCustomerDetail": "删除",
                    "BatchDeleteCustomerDetail": "批量删除",
                    "ExportCustomerDetail": "导出",
                    "CustomerDetailList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyProject.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
"ProjectID": "ProjectID",
                    
                     "CustomerDetailCustomerCode": "CustomerDetailCustomerCode",
                    "CustomerDetailCustomerCodeInputDesc": "Please input your CustomerDetailCustomerCode",
                     
                    
                     "CustomerDetailCustomerName": "CustomerDetailCustomerName",
                    "CustomerDetailCustomerNameInputDesc": "Please input your CustomerDetailCustomerName",
                     
                    
                     "CustomerDetailContact": "CustomerDetailContact",
                    "CustomerDetailContactInputDesc": "Please input your CustomerDetailContact",
                     
                    
                     "CustomerDetailTEL": "CustomerDetailTEL",
                    "CustomerDetailTELInputDesc": "Please input your CustomerDetailTEL",
                     
                    
                     "CustomerDetailCreator": "CustomerDetailCreator",
                    "CustomerDetailCreatorInputDesc": "Please input your CustomerDetailCreator",
                     
"CreationTime": "CreationTime",
"CustomerId": "CustomerId",
"Customer": "Customer",
					                     
                    "CustomerDetail": "CustomerDetail",
                    "ManageCustomerDetail": "ManageCustomerDetail",
                    "QueryCustomerDetail": "QueryCustomerDetail",
                    "CreateCustomerDetail": "CreateCustomerDetail",
                    "EditCustomerDetail": "EditCustomerDetail",
                    "DeleteCustomerDetail": "DeleteCustomerDetail",
                    "BatchDeleteCustomerDetail": "BatchDeleteCustomerDetail",
                    "ExportCustomerDetail": "ExportCustomerDetail",
                    "CustomerDetailList": "CustomerDetailList",
                     //的多语言配置==End
                    




```