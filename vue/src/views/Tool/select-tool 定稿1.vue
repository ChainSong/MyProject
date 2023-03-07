<template font-family="Helvetica Neue">
  <el-select v-model="value" style="width: 100%;" ref='mySelected' filterable remote v-bind:disabled="isDisabledData == 0"
    font-family="Helvetica Neue" placeholder="请选择" size="small" :remote-method="getDropDownListRemoteData">
    <el-option v-for="item in options" :key="item.value" @change="getChildrenVal" :label="item.label" :value="item">
    </el-option>
  </el-select>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../lib/util";
import AbpBase from "../../lib/abpbase";
import TableColumns from "../../store/entities/tableColumns";
import SelectListItem from "../../store/entities/selectListItem";
@Component
export default class selecttool extends AbpBase {
  //字段的值
  @Prop({ type: Object, default: new TableColumns() }) objData: TableColumns;
  //本身的值
  @Prop({ type: String, default: "" }) valData: String;
  // //字段
  // @Prop({ type: String, default: "" }) column: String;
  // //关联的字段
  // @Prop({ type: String, default: "" }) relationColumn: String;
  // //是否可用
  @Prop({ type: Number, default: 1 }) isDisabled: Number;
  //在集合中的位置
  @Prop({ type: Number, default: -1 }) row: Number;

  @Prop({ type: Number, default: 0 }) cstomerId: Number;

  @Prop({ type: Number, default: 0 }) warehouseId: Number;
  // @Prop({ type: String, default: "" }) table: String;
  value: String = "";
  options: Array<{ value: string; label: string }>;
  tableColumnHeaders: Array<TableColumns> = new Array<TableColumns>();
  tableColumn: TableColumns = new TableColumns();
  tableColumns: Array<TableColumns> = new Array<TableColumns>();
  selectListItem: SelectListItem = new SelectListItem();
  apiUrl: string = '';
  isDisabledData:Number=1;
  @Watch("value", { immediate: true, deep: true })
  getChildrenVal(e) {
    this.$emit("getChildrenVal", this.objData.columnName, e.label, this.objData.relationColumn, e.value, this.row);
    // console.log("this.objData");
    // console.log(this.objData);
  }
  @Watch("objData.associated", { immediate: true, deep: true })
  getDropDownListRemote() {
    
    this.selectListItem.cstomerId = this.cstomerId as number;
    this.selectListItem.warehouseId = this.warehouseId as number;
    this.options = [];
    this.$store
      .dispatch({
        type: "tableColumns/getselect",
        data: { "apiurl": this.objData.associated, "column": this.selectListItem },
      })
      .then((res) => {
        this.options = res.result;
        // if (this.value == '' && this.value.length < 1) {
        //   this.$emit("getChildrenVal", this.objData.columnName, this.options[0].label, this.objData.relationColumn, this.options[0].value, this.row);
        // }
      

        this.$forceUpdate()
      })
      .catch((err) => {
        console.log("err");
        console.log(err);
      });
  }

  getDropDownListRemoteData(query) {
    this.selectListItem.cstomerId = this.cstomerId as number;
    this.selectListItem.warehouseId = this.warehouseId as number;
    if (query != '' && query.length > 4) {
      this.selectListItem.input = query;
      this.options = [];
      this.$store
        .dispatch({
          type: "tableColumns/getselect",
          data: { "apiurl": this.objData.associated, "column": this.selectListItem },
        })
        .then((res) => {
          this.options = res.result;
          this.$forceUpdate()
        })
        .catch((err) => {
          console.log("err");
          console.log(err);
        });
    }

  }
  created() {
    // console.log("this.valData")
    // console.log(this.valData);
    // if (this.valData != '' && this.valData.length > 0) {
      this.value = this.valData;
    // }
    this.isDisabledData=this.isDisabled;
    

  
    // this.value = this.columndata;
    //  console.log("this.obj");
    //  console.log("this.cstomerId")
    //  console.log(this.cstomerId)
    //  console.log(this.obj);
  }
}
</script>
 