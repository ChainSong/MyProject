

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
                    
                     "Table_ColumnsRoleName": "RoleName",
                    "Table_ColumnsRoleNameInputDesc": "请输入RoleName",
                     
"CustomerID": "CustomerID",
                    
                     "Table_ColumnsTableName": "TableName",
                    "Table_ColumnsTableNameInputDesc": "请输入TableName",
                     
                    
                     "Table_ColumnsTableNameCH": "TableNameCH",
                    "Table_ColumnsTableNameCHInputDesc": "请输入TableNameCH",
                     
                    
                     "Table_ColumnsDisplayName": "DisplayName",
                    "Table_ColumnsDisplayNameInputDesc": "请输入DisplayName",
                     
                    
                     "Table_ColumnsDbColumnName": "DbColumnName",
                    "Table_ColumnsDbColumnNameInputDesc": "请输入DbColumnName",
                     
"IsKey": "IsKey",
"IsSearchCondition": "IsSearchCondition",
"IsHide": "IsHide",
"IsReadOnly": "IsReadOnly",
"IsShowInList": "IsShowInList",
"IsImportColumn": "IsImportColumn",
"IsDropDownList": "IsDropDownList",
"IsCreate": "IsCreate",
"IsUpdate": "IsUpdate",
"SearchConditionOrder": "SearchConditionOrder",
                    
                     "Table_ColumnsGroup": "Group",
                    "Table_ColumnsGroupInputDesc": "请输入Group",
                     
                    
                     "Table_ColumnsType": "Type",
                    "Table_ColumnsTypeInputDesc": "请输入Type",
                     
"Order": "Order",
"ForView": "ForView",
"CreationTime": "CreationTime",
"TableID": "TableID",
					                     
                    "Table_Columns": "",
                    "ManageTable_Columns": "管理",
                    "QueryTable_Columns": "查询",
                    "CreateTable_Columns": "添加",
                    "EditTable_Columns": "编辑",
                    "DeleteTable_Columns": "删除",
                    "BatchDeleteTable_Columns": "批量删除",
                    "ExportTable_Columns": "导出",
                    "Table_ColumnsList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyProject.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
"ProjectID": "ProjectID",
                    
                     "Table_ColumnsRoleName": "Table_ColumnsRoleName",
                    "Table_ColumnsRoleNameInputDesc": "Please input your Table_ColumnsRoleName",
                     
"CustomerID": "CustomerID",
                    
                     "Table_ColumnsTableName": "Table_ColumnsTableName",
                    "Table_ColumnsTableNameInputDesc": "Please input your Table_ColumnsTableName",
                     
                    
                     "Table_ColumnsTableNameCH": "Table_ColumnsTableNameCH",
                    "Table_ColumnsTableNameCHInputDesc": "Please input your Table_ColumnsTableNameCH",
                     
                    
                     "Table_ColumnsDisplayName": "Table_ColumnsDisplayName",
                    "Table_ColumnsDisplayNameInputDesc": "Please input your Table_ColumnsDisplayName",
                     
                    
                     "Table_ColumnsDbColumnName": "Table_ColumnsDbColumnName",
                    "Table_ColumnsDbColumnNameInputDesc": "Please input your Table_ColumnsDbColumnName",
                     
"IsKey": "IsKey",
"IsSearchCondition": "IsSearchCondition",
"IsHide": "IsHide",
"IsReadOnly": "IsReadOnly",
"IsShowInList": "IsShowInList",
"IsImportColumn": "IsImportColumn",
"IsDropDownList": "IsDropDownList",
"IsCreate": "IsCreate",
"IsUpdate": "IsUpdate",
"SearchConditionOrder": "SearchConditionOrder",
                    
                     "Table_ColumnsGroup": "Table_ColumnsGroup",
                    "Table_ColumnsGroupInputDesc": "Please input your Table_ColumnsGroup",
                     
                    
                     "Table_ColumnsType": "Table_ColumnsType",
                    "Table_ColumnsTypeInputDesc": "Please input your Table_ColumnsType",
                     
"Order": "Order",
"ForView": "ForView",
"CreationTime": "CreationTime",
"TableID": "TableID",
					                     
                    "Table_Columns": "Table_Columns",
                    "ManageTable_Columns": "ManageTable_Columns",
                    "QueryTable_Columns": "QueryTable_Columns",
                    "CreateTable_Columns": "CreateTable_Columns",
                    "EditTable_Columns": "EditTable_Columns",
                    "DeleteTable_Columns": "DeleteTable_Columns",
                    "BatchDeleteTable_Columns": "BatchDeleteTable_Columns",
                    "ExportTable_Columns": "ExportTable_Columns",
                    "Table_ColumnsList": "Table_ColumnsList",
                     //的多语言配置==End
                    




```