

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
"ProductID": "ProductID",
"CustomerID": "CustomerID",
                    
                     "WMS_ProductCustomerName": "CustomerName",
                    "WMS_ProductCustomerNameInputDesc": "请输入CustomerName",
                     
"WarehouseID": "WarehouseID",
                    
                     "WMS_ProductWarehouseName": "WarehouseName",
                    "WMS_ProductWarehouseNameInputDesc": "请输入WarehouseName",
                     
                    
                     "WMS_ProductSKU": "SKU",
                    "WMS_ProductSKUInputDesc": "请输入SKU",
                     
"ProductStatus": "ProductStatus",
                    
                     "WMS_ProductGoodsName": "GoodsName",
                    "WMS_ProductGoodsNameInputDesc": "请输入GoodsName",
                     
                    
                     "WMS_ProductGoodsType": "GoodsType",
                    "WMS_ProductGoodsTypeInputDesc": "请输入GoodsType",
                     
                    
                     "WMS_ProductSKUClassification": "SKUClassification",
                    "WMS_ProductSKUClassificationInputDesc": "请输入SKUClassification",
                     
                    
                     "WMS_ProductSKUGroup": "SKUGroup",
                    "WMS_ProductSKUGroupInputDesc": "请输入SKUGroup",
                     
                    
                     "WMS_ProductManufacturerSKU": "ManufacturerSKU",
                    "WMS_ProductManufacturerSKUInputDesc": "请输入ManufacturerSKU",
                     
                    
                     "WMS_ProductRetailSKU": "RetailSKU",
                    "WMS_ProductRetailSKUInputDesc": "请输入RetailSKU",
                     
                    
                     "WMS_ProductReplaceSKU": "ReplaceSKU",
                    "WMS_ProductReplaceSKUInputDesc": "请输入ReplaceSKU",
                     
                    
                     "WMS_ProductBoxGroup": "BoxGroup",
                    "WMS_ProductBoxGroupInputDesc": "请输入BoxGroup",
                     
                    
                     "WMS_ProductPacking": "Packing",
                    "WMS_ProductPackingInputDesc": "请输入Packing",
                     
                    
                     "WMS_ProductGrade": "Grade",
                    "WMS_ProductGradeInputDesc": "请输入Grade",
                     
                    
                     "WMS_ProductCountry": "Country",
                    "WMS_ProductCountryInputDesc": "请输入Country",
                     
                    
                     "WMS_ProductManufacturer": "Manufacturer",
                    "WMS_ProductManufacturerInputDesc": "请输入Manufacturer",
                     
                    
                     "WMS_ProductDangerCode": "DangerCode",
                    "WMS_ProductDangerCodeInputDesc": "请输入DangerCode",
                     
                    
                     "WMS_ProductVvolume": "Vvolume",
                    "WMS_ProductVvolumeInputDesc": "请输入Vvolume",
                     
                    
                     "WMS_ProductStandardVolume": "StandardVolume",
                    "WMS_ProductStandardVolumeInputDesc": "请输入StandardVolume",
                     
                    
                     "WMS_ProductWeight": "Weight",
                    "WMS_ProductWeightInputDesc": "请输入Weight",
                     
                    
                     "WMS_ProductStandardWeight": "StandardWeight",
                    "WMS_ProductStandardWeightInputDesc": "请输入StandardWeight",
                     
                    
                     "WMS_ProductNetWeight": "NetWeight",
                    "WMS_ProductNetWeightInputDesc": "请输入NetWeight",
                     
                    
                     "WMS_ProductStandardNetWeight": "StandardNetWeight",
                    "WMS_ProductStandardNetWeightInputDesc": "请输入StandardNetWeight",
                     
                    
                     "WMS_ProductPrice": "Price",
                    "WMS_ProductPriceInputDesc": "请输入Price",
                     
"ActualPrice": "ActualPrice",
                    
                     "WMS_ProductCost": "Cost",
                    "WMS_ProductCostInputDesc": "请输入Cost",
                     
                    
                     "WMS_ProductActualCost": "ActualCost",
                    "WMS_ProductActualCostInputDesc": "请输入ActualCost",
                     
                    
                     "WMS_ProductStandardOrderingCost": "StandardOrderingCost",
                    "WMS_ProductStandardOrderingCostInputDesc": "请输入StandardOrderingCost",
                     
                    
                     "WMS_ProductShipmentCost": "ShipmentCost",
                    "WMS_ProductShipmentCostInputDesc": "请输入ShipmentCost",
                     
                    
                     "WMS_ProductQcInSpectionLoc": "QcInSpectionLoc",
                    "WMS_ProductQcInSpectionLocInputDesc": "请输入QcInSpectionLoc",
                     
                    
                     "WMS_ProductQcPercentage": "QcPercentage",
                    "WMS_ProductQcPercentageInputDesc": "请输入QcPercentage",
                     
                    
                     "WMS_ProductReceiptQcUom": "ReceiptQcUom",
                    "WMS_ProductReceiptQcUomInputDesc": "请输入ReceiptQcUom",
                     
                    
                     "WMS_ProductQcEligible": "QcEligible",
                    "WMS_ProductQcEligibleInputDesc": "请输入QcEligible",
                     
                    
                     "WMS_ProductPutArea": "PutArea",
                    "WMS_ProductPutAreaInputDesc": "请输入PutArea",
                     
                    
                     "WMS_ProductPutCode": "PutCode",
                    "WMS_ProductPutCodeInputDesc": "请输入PutCode",
                     
                    
                     "WMS_ProductPutRule": "PutRule",
                    "WMS_ProductPutRuleInputDesc": "请输入PutRule",
                     
                    
                     "WMS_ProductPutStrategy": "PutStrategy",
                    "WMS_ProductPutStrategyInputDesc": "请输入PutStrategy",
                     
                    
                     "WMS_ProductAllocateRule": "AllocateRule",
                    "WMS_ProductAllocateRuleInputDesc": "请输入AllocateRule",
                     
                    
                     "WMS_ProductPickedCode": "PickedCode",
                    "WMS_ProductPickedCodeInputDesc": "请输入PickedCode",
                     
                    
                     "WMS_ProductSKUType": "SKUType",
                    "WMS_ProductSKUTypeInputDesc": "请输入SKUType",
                     
                    
                     "WMS_ProductColor": "Color",
                    "WMS_ProductColorInputDesc": "请输入Color",
                     
                    
                     "WMS_ProductSize_L": "Size_L",
                    "WMS_ProductSize_LInputDesc": "请输入Size_L",
                     
                    
                     "WMS_ProductSize_W": "Size_W",
                    "WMS_ProductSize_WInputDesc": "请输入Size_W",
                     
                    
                     "WMS_ProductSize_H": "Size_H",
                    "WMS_ProductSize_HInputDesc": "请输入Size_H",
                     
"ExpirationDate": "ExpirationDate",
                    
                     "WMS_ProductRemark": "Remark",
                    "WMS_ProductRemarkInputDesc": "请输入Remark",
                     
                    
                     "WMS_ProductCreator": "Creator",
                    "WMS_ProductCreatorInputDesc": "请输入Creator",
                     
"CreateTime": "CreateTime",
                    
                     "WMS_ProductStr1": "Str1",
                    "WMS_ProductStr1InputDesc": "请输入Str1",
                     
                    
                     "WMS_ProductStr2": "Str2",
                    "WMS_ProductStr2InputDesc": "请输入Str2",
                     
                    
                     "WMS_ProductStr3": "Str3",
                    "WMS_ProductStr3InputDesc": "请输入Str3",
                     
                    
                     "WMS_ProductStr4": "Str4",
                    "WMS_ProductStr4InputDesc": "请输入Str4",
                     
                    
                     "WMS_ProductStr5": "Str5",
                    "WMS_ProductStr5InputDesc": "请输入Str5",
                     
                    
                     "WMS_ProductStr6": "Str6",
                    "WMS_ProductStr6InputDesc": "请输入Str6",
                     
                    
                     "WMS_ProductStr7": "Str7",
                    "WMS_ProductStr7InputDesc": "请输入Str7",
                     
                    
                     "WMS_ProductStr8": "Str8",
                    "WMS_ProductStr8InputDesc": "请输入Str8",
                     
                    
                     "WMS_ProductStr9": "Str9",
                    "WMS_ProductStr9InputDesc": "请输入Str9",
                     
                    
                     "WMS_ProductStr10": "Str10",
                    "WMS_ProductStr10InputDesc": "请输入Str10",
                     
                    
                     "WMS_ProductStr11": "Str11",
                    "WMS_ProductStr11InputDesc": "请输入Str11",
                     
                    
                     "WMS_ProductStr12": "Str12",
                    "WMS_ProductStr12InputDesc": "请输入Str12",
                     
                    
                     "WMS_ProductStr13": "Str13",
                    "WMS_ProductStr13InputDesc": "请输入Str13",
                     
                    
                     "WMS_ProductStr14": "Str14",
                    "WMS_ProductStr14InputDesc": "请输入Str14",
                     
                    
                     "WMS_ProductStr15": "Str15",
                    "WMS_ProductStr15InputDesc": "请输入Str15",
                     
                    
                     "WMS_ProductStr16": "Str16",
                    "WMS_ProductStr16InputDesc": "请输入Str16",
                     
                    
                     "WMS_ProductStr17": "Str17",
                    "WMS_ProductStr17InputDesc": "请输入Str17",
                     
                    
                     "WMS_ProductStr18": "Str18",
                    "WMS_ProductStr18InputDesc": "请输入Str18",
                     
                    
                     "WMS_ProductStr19": "Str19",
                    "WMS_ProductStr19InputDesc": "请输入Str19",
                     
                    
                     "WMS_ProductStr20": "Str20",
                    "WMS_ProductStr20InputDesc": "请输入Str20",
                     
"DateTime1": "DateTime1",
"DateTime2": "DateTime2",
"DateTime3": "DateTime3",
"DateTime4": "DateTime4",
"DateTime5": "DateTime5",
"Bigint1": "Bigint1",
"Bigint2": "Bigint2",
"Bigint3": "Bigint3",
"Int1": "Int1",
"Int2": "Int2",
"Int3": "Int3",
"Bit1": "Bit1",
"Bit2": "Bit2",
"Bit3": "Bit3",
"CreationTime": "CreationTime",
					                     
                    "WMS_Product": "",
                    "ManageWMS_Product": "管理",
                    "QueryWMS_Product": "查询",
                    "CreateWMS_Product": "添加",
                    "EditWMS_Product": "编辑",
                    "DeleteWMS_Product": "删除",
                    "BatchDeleteWMS_Product": "批量删除",
                    "ExportWMS_Product": "导出",
                    "WMS_ProductList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyProject.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
"ProductID": "ProductID",
"CustomerID": "CustomerID",
                    
                     "WMS_ProductCustomerName": "WMS_ProductCustomerName",
                    "WMS_ProductCustomerNameInputDesc": "Please input your WMS_ProductCustomerName",
                     
"WarehouseID": "WarehouseID",
                    
                     "WMS_ProductWarehouseName": "WMS_ProductWarehouseName",
                    "WMS_ProductWarehouseNameInputDesc": "Please input your WMS_ProductWarehouseName",
                     
                    
                     "WMS_ProductSKU": "WMS_ProductSKU",
                    "WMS_ProductSKUInputDesc": "Please input your WMS_ProductSKU",
                     
"ProductStatus": "ProductStatus",
                    
                     "WMS_ProductGoodsName": "WMS_ProductGoodsName",
                    "WMS_ProductGoodsNameInputDesc": "Please input your WMS_ProductGoodsName",
                     
                    
                     "WMS_ProductGoodsType": "WMS_ProductGoodsType",
                    "WMS_ProductGoodsTypeInputDesc": "Please input your WMS_ProductGoodsType",
                     
                    
                     "WMS_ProductSKUClassification": "WMS_ProductSKUClassification",
                    "WMS_ProductSKUClassificationInputDesc": "Please input your WMS_ProductSKUClassification",
                     
                    
                     "WMS_ProductSKUGroup": "WMS_ProductSKUGroup",
                    "WMS_ProductSKUGroupInputDesc": "Please input your WMS_ProductSKUGroup",
                     
                    
                     "WMS_ProductManufacturerSKU": "WMS_ProductManufacturerSKU",
                    "WMS_ProductManufacturerSKUInputDesc": "Please input your WMS_ProductManufacturerSKU",
                     
                    
                     "WMS_ProductRetailSKU": "WMS_ProductRetailSKU",
                    "WMS_ProductRetailSKUInputDesc": "Please input your WMS_ProductRetailSKU",
                     
                    
                     "WMS_ProductReplaceSKU": "WMS_ProductReplaceSKU",
                    "WMS_ProductReplaceSKUInputDesc": "Please input your WMS_ProductReplaceSKU",
                     
                    
                     "WMS_ProductBoxGroup": "WMS_ProductBoxGroup",
                    "WMS_ProductBoxGroupInputDesc": "Please input your WMS_ProductBoxGroup",
                     
                    
                     "WMS_ProductPacking": "WMS_ProductPacking",
                    "WMS_ProductPackingInputDesc": "Please input your WMS_ProductPacking",
                     
                    
                     "WMS_ProductGrade": "WMS_ProductGrade",
                    "WMS_ProductGradeInputDesc": "Please input your WMS_ProductGrade",
                     
                    
                     "WMS_ProductCountry": "WMS_ProductCountry",
                    "WMS_ProductCountryInputDesc": "Please input your WMS_ProductCountry",
                     
                    
                     "WMS_ProductManufacturer": "WMS_ProductManufacturer",
                    "WMS_ProductManufacturerInputDesc": "Please input your WMS_ProductManufacturer",
                     
                    
                     "WMS_ProductDangerCode": "WMS_ProductDangerCode",
                    "WMS_ProductDangerCodeInputDesc": "Please input your WMS_ProductDangerCode",
                     
                    
                     "WMS_ProductVvolume": "WMS_ProductVvolume",
                    "WMS_ProductVvolumeInputDesc": "Please input your WMS_ProductVvolume",
                     
                    
                     "WMS_ProductStandardVolume": "WMS_ProductStandardVolume",
                    "WMS_ProductStandardVolumeInputDesc": "Please input your WMS_ProductStandardVolume",
                     
                    
                     "WMS_ProductWeight": "WMS_ProductWeight",
                    "WMS_ProductWeightInputDesc": "Please input your WMS_ProductWeight",
                     
                    
                     "WMS_ProductStandardWeight": "WMS_ProductStandardWeight",
                    "WMS_ProductStandardWeightInputDesc": "Please input your WMS_ProductStandardWeight",
                     
                    
                     "WMS_ProductNetWeight": "WMS_ProductNetWeight",
                    "WMS_ProductNetWeightInputDesc": "Please input your WMS_ProductNetWeight",
                     
                    
                     "WMS_ProductStandardNetWeight": "WMS_ProductStandardNetWeight",
                    "WMS_ProductStandardNetWeightInputDesc": "Please input your WMS_ProductStandardNetWeight",
                     
                    
                     "WMS_ProductPrice": "WMS_ProductPrice",
                    "WMS_ProductPriceInputDesc": "Please input your WMS_ProductPrice",
                     
"ActualPrice": "ActualPrice",
                    
                     "WMS_ProductCost": "WMS_ProductCost",
                    "WMS_ProductCostInputDesc": "Please input your WMS_ProductCost",
                     
                    
                     "WMS_ProductActualCost": "WMS_ProductActualCost",
                    "WMS_ProductActualCostInputDesc": "Please input your WMS_ProductActualCost",
                     
                    
                     "WMS_ProductStandardOrderingCost": "WMS_ProductStandardOrderingCost",
                    "WMS_ProductStandardOrderingCostInputDesc": "Please input your WMS_ProductStandardOrderingCost",
                     
                    
                     "WMS_ProductShipmentCost": "WMS_ProductShipmentCost",
                    "WMS_ProductShipmentCostInputDesc": "Please input your WMS_ProductShipmentCost",
                     
                    
                     "WMS_ProductQcInSpectionLoc": "WMS_ProductQcInSpectionLoc",
                    "WMS_ProductQcInSpectionLocInputDesc": "Please input your WMS_ProductQcInSpectionLoc",
                     
                    
                     "WMS_ProductQcPercentage": "WMS_ProductQcPercentage",
                    "WMS_ProductQcPercentageInputDesc": "Please input your WMS_ProductQcPercentage",
                     
                    
                     "WMS_ProductReceiptQcUom": "WMS_ProductReceiptQcUom",
                    "WMS_ProductReceiptQcUomInputDesc": "Please input your WMS_ProductReceiptQcUom",
                     
                    
                     "WMS_ProductQcEligible": "WMS_ProductQcEligible",
                    "WMS_ProductQcEligibleInputDesc": "Please input your WMS_ProductQcEligible",
                     
                    
                     "WMS_ProductPutArea": "WMS_ProductPutArea",
                    "WMS_ProductPutAreaInputDesc": "Please input your WMS_ProductPutArea",
                     
                    
                     "WMS_ProductPutCode": "WMS_ProductPutCode",
                    "WMS_ProductPutCodeInputDesc": "Please input your WMS_ProductPutCode",
                     
                    
                     "WMS_ProductPutRule": "WMS_ProductPutRule",
                    "WMS_ProductPutRuleInputDesc": "Please input your WMS_ProductPutRule",
                     
                    
                     "WMS_ProductPutStrategy": "WMS_ProductPutStrategy",
                    "WMS_ProductPutStrategyInputDesc": "Please input your WMS_ProductPutStrategy",
                     
                    
                     "WMS_ProductAllocateRule": "WMS_ProductAllocateRule",
                    "WMS_ProductAllocateRuleInputDesc": "Please input your WMS_ProductAllocateRule",
                     
                    
                     "WMS_ProductPickedCode": "WMS_ProductPickedCode",
                    "WMS_ProductPickedCodeInputDesc": "Please input your WMS_ProductPickedCode",
                     
                    
                     "WMS_ProductSKUType": "WMS_ProductSKUType",
                    "WMS_ProductSKUTypeInputDesc": "Please input your WMS_ProductSKUType",
                     
                    
                     "WMS_ProductColor": "WMS_ProductColor",
                    "WMS_ProductColorInputDesc": "Please input your WMS_ProductColor",
                     
                    
                     "WMS_ProductSize_L": "WMS_ProductSize_L",
                    "WMS_ProductSize_LInputDesc": "Please input your WMS_ProductSize_L",
                     
                    
                     "WMS_ProductSize_W": "WMS_ProductSize_W",
                    "WMS_ProductSize_WInputDesc": "Please input your WMS_ProductSize_W",
                     
                    
                     "WMS_ProductSize_H": "WMS_ProductSize_H",
                    "WMS_ProductSize_HInputDesc": "Please input your WMS_ProductSize_H",
                     
"ExpirationDate": "ExpirationDate",
                    
                     "WMS_ProductRemark": "WMS_ProductRemark",
                    "WMS_ProductRemarkInputDesc": "Please input your WMS_ProductRemark",
                     
                    
                     "WMS_ProductCreator": "WMS_ProductCreator",
                    "WMS_ProductCreatorInputDesc": "Please input your WMS_ProductCreator",
                     
"CreateTime": "CreateTime",
                    
                     "WMS_ProductStr1": "WMS_ProductStr1",
                    "WMS_ProductStr1InputDesc": "Please input your WMS_ProductStr1",
                     
                    
                     "WMS_ProductStr2": "WMS_ProductStr2",
                    "WMS_ProductStr2InputDesc": "Please input your WMS_ProductStr2",
                     
                    
                     "WMS_ProductStr3": "WMS_ProductStr3",
                    "WMS_ProductStr3InputDesc": "Please input your WMS_ProductStr3",
                     
                    
                     "WMS_ProductStr4": "WMS_ProductStr4",
                    "WMS_ProductStr4InputDesc": "Please input your WMS_ProductStr4",
                     
                    
                     "WMS_ProductStr5": "WMS_ProductStr5",
                    "WMS_ProductStr5InputDesc": "Please input your WMS_ProductStr5",
                     
                    
                     "WMS_ProductStr6": "WMS_ProductStr6",
                    "WMS_ProductStr6InputDesc": "Please input your WMS_ProductStr6",
                     
                    
                     "WMS_ProductStr7": "WMS_ProductStr7",
                    "WMS_ProductStr7InputDesc": "Please input your WMS_ProductStr7",
                     
                    
                     "WMS_ProductStr8": "WMS_ProductStr8",
                    "WMS_ProductStr8InputDesc": "Please input your WMS_ProductStr8",
                     
                    
                     "WMS_ProductStr9": "WMS_ProductStr9",
                    "WMS_ProductStr9InputDesc": "Please input your WMS_ProductStr9",
                     
                    
                     "WMS_ProductStr10": "WMS_ProductStr10",
                    "WMS_ProductStr10InputDesc": "Please input your WMS_ProductStr10",
                     
                    
                     "WMS_ProductStr11": "WMS_ProductStr11",
                    "WMS_ProductStr11InputDesc": "Please input your WMS_ProductStr11",
                     
                    
                     "WMS_ProductStr12": "WMS_ProductStr12",
                    "WMS_ProductStr12InputDesc": "Please input your WMS_ProductStr12",
                     
                    
                     "WMS_ProductStr13": "WMS_ProductStr13",
                    "WMS_ProductStr13InputDesc": "Please input your WMS_ProductStr13",
                     
                    
                     "WMS_ProductStr14": "WMS_ProductStr14",
                    "WMS_ProductStr14InputDesc": "Please input your WMS_ProductStr14",
                     
                    
                     "WMS_ProductStr15": "WMS_ProductStr15",
                    "WMS_ProductStr15InputDesc": "Please input your WMS_ProductStr15",
                     
                    
                     "WMS_ProductStr16": "WMS_ProductStr16",
                    "WMS_ProductStr16InputDesc": "Please input your WMS_ProductStr16",
                     
                    
                     "WMS_ProductStr17": "WMS_ProductStr17",
                    "WMS_ProductStr17InputDesc": "Please input your WMS_ProductStr17",
                     
                    
                     "WMS_ProductStr18": "WMS_ProductStr18",
                    "WMS_ProductStr18InputDesc": "Please input your WMS_ProductStr18",
                     
                    
                     "WMS_ProductStr19": "WMS_ProductStr19",
                    "WMS_ProductStr19InputDesc": "Please input your WMS_ProductStr19",
                     
                    
                     "WMS_ProductStr20": "WMS_ProductStr20",
                    "WMS_ProductStr20InputDesc": "Please input your WMS_ProductStr20",
                     
"DateTime1": "DateTime1",
"DateTime2": "DateTime2",
"DateTime3": "DateTime3",
"DateTime4": "DateTime4",
"DateTime5": "DateTime5",
"Bigint1": "Bigint1",
"Bigint2": "Bigint2",
"Bigint3": "Bigint3",
"Int1": "Int1",
"Int2": "Int2",
"Int3": "Int3",
"Bit1": "Bit1",
"Bit2": "Bit2",
"Bit3": "Bit3",
"CreationTime": "CreationTime",
					                     
                    "WMS_Product": "WMS_Product",
                    "ManageWMS_Product": "ManageWMS_Product",
                    "QueryWMS_Product": "QueryWMS_Product",
                    "CreateWMS_Product": "CreateWMS_Product",
                    "EditWMS_Product": "EditWMS_Product",
                    "DeleteWMS_Product": "DeleteWMS_Product",
                    "BatchDeleteWMS_Product": "BatchDeleteWMS_Product",
                    "ExportWMS_Product": "ExportWMS_Product",
                    "WMS_ProductList": "WMS_ProductList",
                     //的多语言配置==End
                    




```