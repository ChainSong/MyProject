

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
                    
                     "WarehouseUserMappingUserName": "UserName",
                    "WarehouseUserMappingUserNameInputDesc": "请输入UserName",
                     
"WarehouseId": "WarehouseId",
                    
                     "WarehouseUserMappingWarehouseName": "WarehouseName",
                    "WarehouseUserMappingWarehouseNameInputDesc": "请输入WarehouseName",
                     
"Status": "Status",
                    
                     "WarehouseUserMappingCreator": "Creator",
                    "WarehouseUserMappingCreatorInputDesc": "请输入Creator",
                     
"CreateTime": "CreateTime",
                    
                     "WarehouseUserMappingUpdator": "Updator",
                    "WarehouseUserMappingUpdatorInputDesc": "请输入Updator",
                     
"UpdateTime": "UpdateTime",
					                     
                    "WarehouseUserMapping": "",
                    "ManageWarehouseUserMapping": "管理",
                    "QueryWarehouseUserMapping": "查询",
                    "CreateWarehouseUserMapping": "添加",
                    "EditWarehouseUserMapping": "编辑",
                    "DeleteWarehouseUserMapping": "删除",
                    "BatchDeleteWarehouseUserMapping": "批量删除",
                    "ExportWarehouseUserMapping": "导出",
                    "WarehouseUserMappingList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyProject.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
"UserId": "UserId",
                    
                     "WarehouseUserMappingUserName": "WarehouseUserMappingUserName",
                    "WarehouseUserMappingUserNameInputDesc": "Please input your WarehouseUserMappingUserName",
                     
"WarehouseId": "WarehouseId",
                    
                     "WarehouseUserMappingWarehouseName": "WarehouseUserMappingWarehouseName",
                    "WarehouseUserMappingWarehouseNameInputDesc": "Please input your WarehouseUserMappingWarehouseName",
                     
"Status": "Status",
                    
                     "WarehouseUserMappingCreator": "WarehouseUserMappingCreator",
                    "WarehouseUserMappingCreatorInputDesc": "Please input your WarehouseUserMappingCreator",
                     
"CreateTime": "CreateTime",
                    
                     "WarehouseUserMappingUpdator": "WarehouseUserMappingUpdator",
                    "WarehouseUserMappingUpdatorInputDesc": "Please input your WarehouseUserMappingUpdator",
                     
"UpdateTime": "UpdateTime",
					                     
                    "WarehouseUserMapping": "WarehouseUserMapping",
                    "ManageWarehouseUserMapping": "ManageWarehouseUserMapping",
                    "QueryWarehouseUserMapping": "QueryWarehouseUserMapping",
                    "CreateWarehouseUserMapping": "CreateWarehouseUserMapping",
                    "EditWarehouseUserMapping": "EditWarehouseUserMapping",
                    "DeleteWarehouseUserMapping": "DeleteWarehouseUserMapping",
                    "BatchDeleteWarehouseUserMapping": "BatchDeleteWarehouseUserMapping",
                    "ExportWarehouseUserMapping": "ExportWarehouseUserMapping",
                    "WarehouseUserMappingList": "WarehouseUserMappingList",
                     //的多语言配置==End
                    




```