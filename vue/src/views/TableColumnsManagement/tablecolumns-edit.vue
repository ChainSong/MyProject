<template>
  <div>
    <Modal
      :title="L('asnEdit')"
      :value="value"
      width="80"
      @on-visible-change="visibleChange"
    >
      <template>
        <el-table :data="tableColumns" height="500" border style="width: 100%">
          <el-table-column prop="tableName" label="表名" width="180">
          </el-table-column>
          <el-table-column prop="dbColumnName" label="字段名称" width="180">
          </el-table-column>
          <el-table-column
            prop="displayName"
            label="中文名称"
            width="180"
          ></el-table-column>
          <el-table-column prop="isCreate" label="添加"> </el-table-column>
          <el-table-column prop="isSearchCondition" label="查询条件">
          </el-table-column>
          <el-table-column prop="isShowInList" label="查询列表">
          </el-table-column>
          <el-table-column prop="isUpdate" label="可修改"> </el-table-column>
          <el-table-column prop="order" label="排序"> </el-table-column>
          <el-table-column prop="validation" label="验证"> </el-table-column>
          <el-table-column prop="type" label="类型"> </el-table-column>
          <el-table-column prop="associated" label="下拉"> </el-table-column>
        </el-table>
      </template>
      <div slot="footer">
        <Button @click="cancel">{{ L("Cancel") }}</Button>
        <Button @click="save" type="primary">{{ L("OK") }}</Button>
      </div>
    </Modal>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../lib/util";
import AbpBase from "../../lib/abpbase";
import Header from "../../store/entities/asn";
import Detail from "../../store/entities/asnDetail";
import TableColumns from "@/store/entities/tableColumns";
@Component
export default class tablecolumnsEdit extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  tableColumn: TableColumns = new TableColumns();
  tableColumns: Array<TableColumns> = new Array<TableColumns>();
  // createModalShow: boolean = false;
  // editModalShow: boolean = false;
  // queryModalShow: boolean = false;

  
  //分页以及查询需要
  get list() {
    return this.$store.state.tableColumns.list;
  }
  get loading() {
    return this.$store.state.tableColumns.loading;
  }

  created() {
     
  }
 
  visibleChange(value: boolean) {
    console.log("进来了1");
    if (!value) {
      this.$emit("input", value);
    } else {
      this.tableColumn = Util.extend(true, {}, this.$store.state.tableColumns);
      console.log( "this.tableColumn");
      console.log( this.tableColumn);
      this.get();
    }
  }
  get() {
     this.$store
      .dispatch({
        type: "tableColumns/GetAll",
        data: this.tableColumn,
      })
      .then((res) => {
        console.log("tableColumns/GetAll");
        console.log(res);
        this.tableColumns = res;
        // this.detailDatas.details = res.receiptDetails;
      })
      .catch((err) => {
        console.log(err);
      });
  }
  cancel() {
    (this.$refs.editHeader as any).resetFields();
    (this.$refs.editDetail as any).resetFields();
    this.$emit("input", false);
  }
  save() {
    // this.$store.dispatch({
    //   type: "asn/update",
    //   data: {
    //     asn: this.header,
    //     asnDetails: this.detailDatas.details,
    //   },
    // });
    this.$emit("save-success");
    this.$emit("input", false);
    //     }
    // })
  }
}
</script>
 