<template>
  <div>
    <Modal :title="L('EditTableColumns') + ':' + tableColumn.tableNameCH" :value="value" width="65"
      @on-visible-change="visibleChange">
      <template>
        <el-table :data="tableColumns" show-overflow-tooltip border style="width: 150%">
          <!-- <el-table-column prop="tableName" label="表名" width="180">
          </el-table-column> -->
          <el-table-column fixed="left" prop="dbColumnName" label="字段名称" width="180">
          </el-table-column>
          <el-table-column prop="displayName" label="显示名称" width="150">
            <template slot-scope="scope">
              <el-input size="small" v-model="scope.row.displayName"></el-input>
            </template>
          </el-table-column>
           <el-table-column prop="isCreate" label="关键字(后台生成)">
            <template slot-scope="scope">
              <el-switch v-model="scope.row.isKey" active-color="#13ce66" inactive-color="#ff4949" :active-value="1"
                :inactive-value="0">
              </el-switch>
            </template>
           </el-table-column>
          <el-table-column prop="isCreate" label="添加">
            <template slot-scope="scope">
              <el-switch v-model="scope.row.isCreate" active-color="#13ce66" inactive-color="#ff4949" :active-value="1"
                :inactive-value="0" @change="CreateClose(scope.row, scope.$index)">
              </el-switch>
            </template>
          </el-table-column>
          <el-table-column prop="isSearchCondition" label="查询条件">
            <template slot-scope="scope">
              <el-switch v-model="scope.row.isSearchCondition" active-color="#13ce66" inactive-color="#ff4949"
                :active-value="1" :inactive-value="0">
              </el-switch>
            </template>
          </el-table-column>
          <el-table-column prop="isShowInList" label="查询列表">
            <template slot-scope="scope">
              <el-switch v-model="scope.row.isShowInList" active-color="#13ce66" inactive-color="#ff4949"
                :active-value="1" :inactive-value="0">
              </el-switch>
            </template>
          </el-table-column>
          <el-table-column prop="isUpdate" label="可修改">
            <template slot-scope="scope">
              <el-switch v-model="scope.row.isUpdate" active-color="#13ce66" inactive-color="#ff4949" :active-value="1"
                :inactive-value="0">
              </el-switch>
            </template>
          </el-table-column>
          <el-table-column prop="isImportColumn" label="可导入">
            <template slot-scope="scope">
              <el-switch v-model="scope.row.isImportColumn" active-color="#13ce66" inactive-color="#ff4949" :active-value="1"
                :inactive-value="0">
              </el-switch>
            </template>
          </el-table-column>
          <el-table-column prop="order" width="120px" label="排序">
            <template slot-scope="scope">
              <el-input-number v-model="scope.row.order" style="width: 100px" size="mini" :min="1" :max="100"
                label="描述文字"></el-input-number>
            </template>
          </el-table-column>
          <el-table-column prop="validation" label="验证">
            <template slot-scope="scope">
              <el-select v-model="scope.row.validation" size="small" placeholder="请选择">
                <el-option label="无" value=""> </el-option>
                <el-option label="Required" value="Required"> </el-option>
              </el-select>
              <!-- <el-input
                v-model="scope.row.validation"
                placeholder="请输入内容"
              ></el-input> -->
            </template>
          </el-table-column>
          <el-table-column prop="type" width="150px" label="类型">
            <template slot-scope="scope">
              <el-select v-model="scope.row.type" size="small" placeholder="请选择">
                <el-option label="TextBox" value="TextBox"> </el-option>
                <el-option label="InputNumber " value="InputNumber"> </el-option>
                <el-option label="DropDownListInt" value="DropDownListInt"></el-option>
                <el-option label="DropDownListStr" value="DropDownListStr"></el-option>
                <el-option label="DropDownListStrRemote" value="DropDownListStrRemote"></el-option>
                <el-option label="DatePicker" value="DatePicker"> </el-option>
                <el-option label="DateTimePicker" value="DateTimePicker">
                </el-option>
              </el-select>
            </template>
          </el-table-column>
          <el-table-column prop="associated" width="180px" label="拉下列表数据源">
            <template slot-scope="scope">
              <!-- <el-input-number v-model="scope.row.associated" style="width: 100px" size="mini" :min="1" :max="100"
                label="拉下列表数据源"></el-input-number> -->
              <el-input size="small" v-model="scope.row.associated"></el-input>
            </template>
          </el-table-column>
          <el-table-column prop="relationColumn" width="180px" label="拉下列表关联字段">
            <template slot-scope="scope">
              <el-input size="small" v-model="scope.row.relationColumn"></el-input>
              <!-- <el-input-number v-model="scope.row.relationColumn" style="width: 100px" size="mini" :min="1" :max="100"
                label="拉下列表关联字段"></el-input-number> -->
            </template>
          </el-table-column>
          <el-table-column prop="relationColumn" width="120px" label="操作">
            <template slot-scope="scope">
              <el-button @click="addDetailShow(scope.row,scope.$index)" type="text" size="small">添加明细</el-button>
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

    <el-dialog title="添加" style="width:100%" :visible.sync="dialogDetail" append-to-body :before-close="detailClose"
      width="30%">
      <template>
        <el-table :data="tableColumnsDetails" border>
          <el-table-column prop="CodeInt" label="Int类型值" width="100">
            <template slot-scope="scope">
              <el-input size="small" v-model="scope.row.codeInt"></el-input>
            </template>
          </el-table-column>
          <el-table-column prop="CodeStr" label="Str类型值" width="100">
            <template slot-scope="scope">
              <el-input size="small" v-model="scope.row.codeStr"></el-input>
            </template>
          </el-table-column>
          <el-table-column prop="Name" label="显示描述">
            <template slot-scope="scope">
              <el-input size="small" v-model="scope.row.name"></el-input>
            </template>
          </el-table-column>
          <el-table-column prop="Color" label="颜色">
            <template slot-scope="scope">
              <el-input size="small" v-model="scope.row.color"></el-input>
            </template>
          </el-table-column>
          <el-table-column prop="Associated" label="关联数据源" width="180">
            <template slot-scope="scope">
              <el-input size="small" v-model="scope.row.associated"></el-input>
            </template>
          </el-table-column>

        </el-table>
      </template>
      <span slot="footer" class="dialog-footer">
        <el-button @click="addDetailLine" type="primary">添加一行</el-button>
        <el-button @click="addDetail" type="primary">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../lib/util";
import AbpBase from "../../lib/abpbase";
import Header from "../../store/entities/asn";
import Detail from "../../store/entities/asnDetail";
import TableColumns from "@/store/entities/tableColumns";
import TableColumnsDetails from "@/store/entities/tableColumnsDetails";
@Component
export default class tablecolumnsEdit extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  tableColumn: TableColumns = new TableColumns();
  tableColumns: Array<TableColumns> = new Array<TableColumns>();
  tableColumnsDetails: Array<TableColumnsDetails> = new Array<TableColumnsDetails>();
  tableColumnsDetail: TableColumnsDetails = new TableColumnsDetails();
  dialogDetail: boolean = false;
  index:number=0;
  created() { }

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
  addDetailShow(row,index) {
    this.tableColumnsDetails=new Array<TableColumnsDetails>();
    this.index=index;
    this.dialogDetail = true;
    if (row.tableColumnsDetails.length > 0) {
      this.tableColumnsDetails = row.tableColumnsDetails;
    } else {
      this.tableColumnsDetails.push(new TableColumnsDetails());
    }
    console.log(this.tableColumnsDetails);
    // this.$store
    //   .dispatch({
    //     type: "tableColumnsDetails/GetAll",
    //     data: {"associated":row.associated},
    //   })
    //   .then((res) => {
    //     console.log(res.items);
    //     if(res.items.length>0){
    //     this.tableColumnsDetails = res.items;
    //     }else{
    //       // this.tableColumnsDetails=new
    //     }
    //     // this.detailDatas.details = res.receiptDetails;
    //   })
    //   .catch((err) => {
    //     console.log(err);
    //   });
  }
  addDetail() {
     this.tableColumns[this.index].tableColumnsDetails=this.tableColumnsDetails;
     this.dialogDetail = false;
  }
  addDetailLine(){
     this.tableColumnsDetails.push(new TableColumnsDetails());
  }
  detailClose() {
    this.tableColumnsDetails=new Array<TableColumnsDetails>();
    this.dialogDetail = false;
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
        tableColumns: this.tableColumns,
      },
    });
    this.$emit("save-success");
    this.$emit("input", false);
    //     }
    // })
  }
  CreateClose(row, index) {
    if (row.isCreate == 0) {
      this.tableColumns[index].isUpdate = 0;
      this.tableColumns[index].isSearchCondition = 0;
      this.tableColumns[index].isShowInList = 0;
    }
  }
}
</script>
 