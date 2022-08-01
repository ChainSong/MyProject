<template>
  <div>
    <Modal
      :title="L('ReceiptQuery')"
      :value="value"
      width="80"
      @on-visible-change="visibleChange"
    >
      <Form label-position="top">
        <Row>
          <Col v-for="i in tableColumnHeaders" v-bind:key="i.id" span="6">
            <FormItem
              :label="i.displayName"
              :prop="i.displayName"
              v-if="i.isCreate"
              style="width: 100%"
            >
              <template v-if="i.type == 'TextBox'">
                <label v-text="header[i.dbColumnName]"></label>
              </template>
              <!-- <template v-if="i.type == 'DropDownList'">
                <label v-text="i.table_ColumnsDetails"></label>
              </template> -->
                <template v-if="i.type == 'DropDownList'">
                  <template v-for="DropDown in i.table_ColumnsDetails">
                    <label v-if="DropDown.codeStr==header[i.dbColumnName]" v-text="DropDown.name" :key="DropDown.codeStr"></label>
                  </template>
                <!-- <el-select
                  v-model="header[i.dbColumnName]"
                  v-if="i.isCreate"
                  placeholder="请选择"
                  style="width: 100%"
                  disabled
                >
                  <el-option
                    v-for="item in i.table_ColumnsDetails"
                    :key="item.code"
                    :label="item.name"
                    :value="item.code"
                  >
                  </el-option>
                </el-select> -->
              </template> 
              <!-- <template v-if="i.type == 'DatePicker'">
                <el-date-picker
                  v-model="header[i.dbColumnName]"
                  v-if="i.isUpdate"
                  type="date"
                  placeholder="选择日期"
                  style="width: 100%"
                >
                </el-date-picker>
              </template>
              <template v-if="i.type == 'DateTimePicker'" span="12">
                <el-date-picker
                  v-model="header[i.dbColumnName]"
                  v-if="i.isUpdate"
                  type="datetime"
                  start-placeholder="选择日期时间"
                  style="width: 100%"
                >
                </el-date-picker>
              </template> -->  
              <!-- <el-input
                placeholder="请输入内容"
                v-model="header[i.dbColumnName]"
                v-if="i.isUpdate"
              >
              </el-input> -->
            </FormItem>
          </Col>
        </Row>
      </Form>
      <!-- <el-button
        @click="handleAdd"
        type="primary"
        size="large"
        class="toolbar-btn"
        >添加一条</el-button
      > -->
      <template>
        <el-form :model="detailDatas" ref="editDetail">
          <el-table
            :data="detailDatas.details"
            style="width: 100%"
            height="250"
          >
            <template v-for="(v, index) in tableColumnDetails">
              <el-table-column
                v-if="v.isUpdate"
                :key="index"
                :fixed="false"
                :label="v.displayName"
                width="150"
              >
              <template slot-scope="scope">
                 <label v-text="detailDatas.details[scope.$index][v.dbColumnName]"></label>
              </template>
              </el-table-column>
            </template>
          </el-table>
        </el-form>
      </template>
      <div slot="footer">
        <Button @click="cancel">{{ L("Cancel") }}</Button>
      </div>
    </Modal>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../lib/util";
import AbpBase from "../../lib/abpbase";
import Header from "../../store/entities/receipt";
import Detail from "../../store/entities/receiptDetail";
import TableColumns from "../../store/entities/tableColumns";
@Component
export default class ReceiptQuery extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  tableColumnHeader: TableColumns = new TableColumns();
  tableColumnHeaders: Array<TableColumns> = new Array<TableColumns>();
  tableColumnDetail: TableColumns = new TableColumns();
  tableColumnDetails: Array<TableColumns> = new Array<TableColumns>();
  header: Header = new Header();
  headers: Array<Header> = new Array<Header>();
  detail: Detail = new Detail();
  details: Array<Detail> = new Array<Detail>();
  detailDatas = { line: null, details: [new Detail()] };
  created() {
    this.gettableColumn();
  }

  gettableColumn() {
    this.tableColumnHeader.tableName = "WMS_Receipt";
    this.tableColumnDetail.tableName = "WMS_ReceiptDetail";
    this.$store
      .dispatch({
        type: "tableColumns/GetByTableNameList",
        data: this.tableColumnHeader,
      })
      .then((res) => {
        this.tableColumnHeaders = JSON.parse(
          localStorage.getItem(this.tableColumnHeader.tableName)
        ) as Array<TableColumns>;
      })
      .catch((err) => {
        console.log(err);
      });
    this.$store
      .dispatch({
        type: "tableColumns/GetByTableNameList",
        data: this.tableColumnDetail,
      })
      .then((res) => {
        this.tableColumnDetails = JSON.parse(
          localStorage.getItem(this.tableColumnDetail.tableName)
        ) as Array<TableColumns>;
      })
      .catch((err) => {
        console.log(err);
      });
  }
  get() {
    this.$store
      .dispatch({
        type: "receipt/get",
        data: this.header,
      })
      .then((res) => {
        this.header = res;
        this.detailDatas.details = res.receiptDetails;
      })
      .catch((err) => {
        console.log(err);
      });
  }
  visibleChange(value: boolean) {
    if (!value) {
      this.$emit("input", value);
    } else {
      this.header = Util.extend(
        true,
        {},
        this.$store.state.receipt.queryReceipt
      );
      this.get();
    }
  }
  cancel() {
    this.$emit("input", false);
  }
  
}
</script>
 