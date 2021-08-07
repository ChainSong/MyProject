

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
"UserId": "UserId",
                    
                     "CustomerUserMappingUserName": "UserName",
                    "CustomerUserMappingUserNameInputDesc": "请输入UserName",
                     
"CustomerId": "CustomerId",
                    
                     "CustomerUserMappingCustomerName": "CustomerName",
                    "CustomerUserMappingCustomerNameInputDesc": "请输入CustomerName",
                     
"Status": "Status",
                    
                     "CustomerUserMappingCreator": "Creator",
                    "CustomerUserMappingCreatorInputDesc": "请输入Creator",
                     
"CreateTime": "CreateTime",
                    
                     "CustomerUserMappingUpdator": "Updator",
                    "CustomerUserMappingUpdatorInputDesc": "请输入Updator",
                     
"UpdateTime": "UpdateTime",
					                     
                    "CustomerUserMapping": "",
                    "ManageCustomerUserMapping": "管理",
                    "QueryCustomerUserMapping": "查询",
                    "CreateCustomerUserMapping": "添加",
                    "EditCustomerUserMapping": "编辑",
                    "DeleteCustomerUserMapping": "删除",
                    "BatchDeleteCustomerUserMapping": "批量删除",
                    "ExportCustomerUserMapping": "导出",
                    "CustomerUserMappingList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyProject.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
"UserId": "UserId",
                    
                     "CustomerUserMappingUserName": "CustomerUserMappingUserName",
                    "CustomerUserMappingUserNameInputDesc": "Please input your CustomerUserMappingUserName",
                     
"CustomerId": "CustomerId",
                    
                     "CustomerUserMappingCustomerName": "CustomerUserMappingCustomerName",
                    "CustomerUserMappingCustomerNameInputDesc": "Please input your CustomerUserMappingCustomerName",
                     
"Status": "Status",
                    
                     "CustomerUserMappingCreator": "CustomerUserMappingCreator",
                    "CustomerUserMappingCreatorInputDesc": "Please input your CustomerUserMappingCreator",
                     
"CreateTime": "CreateTime",
                    
                     "CustomerUserMappingUpdator": "CustomerUserMappingUpdator",
                    "CustomerUserMappingUpdatorInputDesc": "Please input your CustomerUserMappingUpdator",
                     
"UpdateTime": "UpdateTime",
					                     
                    "CustomerUserMapping": "CustomerUserMapping",
                    "ManageCustomerUserMapping": "ManageCustomerUserMapping",
                    "QueryCustomerUserMapping": "QueryCustomerUserMapping",
                    "CreateCustomerUserMapping": "CreateCustomerUserMapping",
                    "EditCustomerUserMapping": "EditCustomerUserMapping",
                    "DeleteCustomerUserMapping": "DeleteCustomerUserMapping",
                    "BatchDeleteCustomerUserMapping": "BatchDeleteCustomerUserMapping",
                    "ExportCustomerUserMapping": "ExportCustomerUserMapping",
                    "CustomerUserMappingList": "CustomerUserMappingList",
                     //的多语言配置==End
                    




```