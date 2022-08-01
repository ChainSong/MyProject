<template>
  <div>
    <Modal
      :title="L('EditTableColumns') + ':' + tableColumn.tableNameCH"
      :value="value"
      width="90"
      @on-visible-change="visibleChange"
    >
      <template>
        <el-table :data="tableColumns" height="500" border style="width: 100%">
          <!-- <el-table-column prop="tableName" label="表名" width="180">
          </el-table-column> -->
          <el-table-column prop="dbColumnName" label="字段名称" width="180">
          </el-table-column>
          <el-table-column prop="displayName" label="中文名称" width="180">
            <template slot-scope="scope">
              <el-input
                v-model="scope.row.displayName"
                placeholder="请输入内容"
              ></el-input>
            </template>
          </el-table-column>
          <el-table-column prop="isCreate" label="添加">
            <template slot-scope="scope">
              <el-switch
                v-model="scope.row.isCreate"
                active-color="#13ce66"
                inactive-color="#ff4949"
                :active-value="1"
                :inactive-value="0"
                @change="CreateClose(scope.row, scope.$index)"
              >
              </el-switch>
            </template>
          </el-table-column>
          <el-table-column prop="isSearchCondition" label="查询条件">
            <template slot-scope="scope">
              <el-switch
                v-model="scope.row.isSearchCondition"
                active-color="#13ce66"
                inactive-color="#ff4949"
                :active-value="1"
                :inactive-value="0"
              >
              </el-switch>
            </template>
          </el-table-column>
          <el-table-column prop="isShowInList" label="查询列表">
            <template slot-scope="scope">
              <el-switch
                v-model="scope.row.isShowInList"
                active-color="#13ce66"
                inactive-color="#ff4949"
                :active-value="1"
                :inactive-value="0"
              >
              </el-switch>
            </template>
          </el-table-column>
          <el-table-column prop="isUpdate" label="可修改">
            <template slot-scope="scope">
              <el-switch
                v-model="scope.row.isUpdate"
                active-color="#13ce66"
                inactive-color="#ff4949"
                :active-value="1"
                :inactive-value="0"
              >
              </el-switch>
            </template>
          </el-table-column>
          <el-table-column prop="order" width="120px" label="排序">
            <template slot-scope="scope">
              <el-input-number
                v-model="scope.row.order"
                style="width: 100px"
                size="mini"
                :min="1"
                :max="100"
                label="描述文字"
              ></el-input-number>
            </template>
          </el-table-column>
          <el-table-column prop="validation" label="验证">
            <template slot-scope="scope">
              <el-select v-model="scope.row.validation" placeholder="请选择">
                <el-option label="Required" value="Required"> </el-option>
              </el-select>
              <!-- <el-input
                v-model="scope.row.validation"
                placeholder="请输入内容"
              ></el-input> -->
            </template>
          </el-table-column>
          <el-table-column prop="type" width="120px" label="类型">
            <template slot-scope="scope">
              <el-select v-model="scope.row.type" placeholder="请选择">
                <el-option label="TextBox" value="TextBox"> </el-option>
                <el-option label="DropDownList" value="DropDownList">
                </el-option>
                <el-option label="DatePicker" value="DatePicker"> </el-option>
                <el-option label="DateTimePicker" value="DateTimePicker">
                </el-option>
              </el-select>
              <!-- <el-dropdown size="small" width="100px" split-button type="primary"> -->
              <!-- <el-dropdown-menu  width="120px" v-model="scope.row.type" slot="dropdown">
                  <el-dropdown-item>TextBox</el-dropdown-item>
                  <el-dropdown-item>DropDownList</el-dropdown-item>
                  <el-dropdown-item>DatePicker</el-dropdown-item>
                  <el-dropdown-item>DateTimePicker</el-dropdown-item>
                </el-dropdown-menu> -->
              <!-- </el-dropdown> -->
            </template>
          </el-table-column>
          <!-- <el-table-column prop="associated" label="下拉"> </el-table-column> -->
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
  // get list() {
  //   return this.$store.state.tableColumns.list;
  // }
  // get loading() {
  //   return this.$store.state.tableColumns.loading;
  // }

  created() {}

  visibleChange(value: boolean) {
    console.log("进来了1");
    if (!value) {
      this.$emit("input", value);
    } else {
      this.tableColumn = Util.extend(
        true,
        {},
        this.$store.state.tableColumns.editTableColumns
      );
      console.log("this.tableColumn");
      console.log(this.tableColumn);
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
        this.tableColumns = res.items;
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
  
    this.$store.dispatch({
      type: "tableColumns/update",
      data: {
        table_Columnss: this.tableColumns, 
      },
    });
    this.$emit("save-success");
    this.$emit("input", false);
    //     }
    // })
  }
  CreateClose(row,index){
      if(row.isCreate==0){
             this.tableColumns[index].isUpdate=0;
             this.tableColumns[index].isSearchCondition=0;
             this.tableColumns[index].isShowInList=0;
      }
  }
}
</script>
 