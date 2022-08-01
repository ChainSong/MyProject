

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
                    
                     "Table_ColumnsDetailCode": "Code",
                    "Table_ColumnsDetailCodeInputDesc": "请输入Code",
                     
                    
                     "Table_ColumnsDetailName": "Name",
                    "Table_ColumnsDetailNameInputDesc": "请输入Name",
                     
                    
                     "Table_ColumnsDetailType": "Type",
                    "Table_ColumnsDetailTypeInputDesc": "请输入Type",
                     
                    
                     "Table_ColumnsDetailStatus": "Status",
                    "Table_ColumnsDetailStatusInputDesc": "请输入Status",
                     
"Creator": "Creator",
"CreationTime": "CreationTime",
"CodeN": "CodeN",
                    
                     "Table_ColumnsDetailAssociated": "Associated",
                    "Table_ColumnsDetailAssociatedInputDesc": "请输入Associated",
                     
"Table_Columns": "Table_Columns",
					                     
                    "Table_ColumnsDetail": "",
                    "ManageTable_ColumnsDetail": "管理",
                    "QueryTable_ColumnsDetail": "查询",
                    "CreateTable_ColumnsDetail": "添加",
                    "EditTable_ColumnsDetail": "编辑",
                    "DeleteTable_ColumnsDetail": "删除",
                    "BatchDeleteTable_ColumnsDetail": "批量删除",
                    "ExportTable_ColumnsDetail": "导出",
                    "Table_ColumnsDetailList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyProject.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "Table_ColumnsDetailCode": "Table_ColumnsDetailCode",
                    "Table_ColumnsDetailCodeInputDesc": "Please input your Table_ColumnsDetailCode",
                     
                    
                     "Table_ColumnsDetailName": "Table_ColumnsDetailName",
                    "Table_ColumnsDetailNameInputDesc": "Please input your Table_ColumnsDetailName",
                     
                    
                     "Table_ColumnsDetailType": "Table_ColumnsDetailType",
                    "Table_ColumnsDetailTypeInputDesc": "Please input your Table_ColumnsDetailType",
                     
                    
                     "Table_ColumnsDetailStatus": "Table_ColumnsDetailStatus",
                    "Table_ColumnsDetailStatusInputDesc": "Please input your Table_ColumnsDetailStatus",
                     
"Creator": "Creator",
"CreationTime": "CreationTime",
"CodeN": "CodeN",
                    
                     "Table_ColumnsDetailAssociated": "Table_ColumnsDetailAssociated",
                    "Table_ColumnsDetailAssociatedInputDesc": "Please input your Table_ColumnsDetailAssociated",
                     
"Table_Columns": "Table_Columns",
					                     
                    "Table_ColumnsDetail": "Table_ColumnsDetail",
                    "ManageTable_ColumnsDetail": "ManageTable_ColumnsDetail",
                    "QueryTable_ColumnsDetail": "QueryTable_ColumnsDetail",
                    "CreateTable_ColumnsDetail": "CreateTable_ColumnsDetail",
                    "EditTable_ColumnsDetail": "EditTable_ColumnsDetail",
                    "DeleteTable_ColumnsDetail": "DeleteTable_ColumnsDetail",
                    "BatchDeleteTable_ColumnsDetail": "BatchDeleteTable_ColumnsDetail",
                    "ExportTable_ColumnsDetail": "ExportTable_ColumnsDetail",
                    "Table_ColumnsDetailList": "Table_ColumnsDetailList",
                     //的多语言配置==End
                    




```