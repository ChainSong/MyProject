<template>
  <div>
    <Modal :title="L('CustomerQuery')" :value="value" width="80" @on-visible-change="visibleChange">
      <Form label-position="top">
        <Row>
          <Col v-for="i in tableColumnHeaders" v-bind:key="i.id" span="6">
          <FormItem :label="i.displayName" :prop="i.displayName" v-if="i.isCreate" style="width: 90%">
            <template v-if="i.type == 'TextBox'">
              <label v-text="header[i.columnName]"></label>
            </template>
            <!-- <template v-if="i.type == 'DropDownList'">
                <label v-text="i.table_ColumnsDetails"></label>
              </template> -->
            <template v-if="i.type == 'DropDownListInt'">
              <template v-for="DropDown in i.tableColumnsDetails">
                <label v-if="DropDown.codeInt == header[i.columnName]" v-text="DropDown.name"
                  :key="DropDown.codeInt"></label>
              </template>
            </template>
            <template v-if="i.type == 'DropDownListStr'">
              <template v-for="DropDown in i.tableColumnsDetails">
                <label v-if="DropDown.codeStr == header[i.columnName]" v-text="DropDown.name"
                  :key="DropDown.codeStr"></label>
              </template>
            </template>
            <!-- <template v-if="i.type == 'DatePicker'">
                <el-date-picker
                  v-model="header[i.columnName]"
                  v-if="i.isUpdate"
                  type="date"
                  placeholder="选择日期"
                  style="width: 100%"
                >
                </el-date-picker>
              </template>
              <template v-if="i.type == 'DateTimePicker'" span="12">
                <el-date-picker
                  v-model="header[i.columnName]"
                  v-if="i.isUpdate"
                  type="datetime"
                  start-placeholder="选择日期时间"
                  style="width: 100%"
                >
                </el-date-picker>
              </template> -->
            <!-- <el-input
                placeholder="请输入内容"
                v-model="header[i.columnName]"
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
          <el-table :data="detailDatas.details" style="width: 100%" height="250">
            <template v-for="(v, index) in tableColumnDetails">
              <el-table-column v-if="v.isUpdate" :key="index" :fixed="false" :label="v.displayName" width="150">
                <template slot-scope="scope">
                  <label v-text="detailDatas.details[scope.$index][v.columnName]"></label>
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
import Header from "../../store/entities/customer";
import Detail from "../../store/entities/customerDetail";
import TableColumns from "../../store/entities/tableColumns";
@Component
export default class CustomerQuery extends AbpBase {
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
    this.tableColumnHeader.tableName = "Customer";
    this.tableColumnDetail.tableName = "CustomerDetail";
    this.tableColumnHeaders = JSON.parse(
      localStorage.getItem(this.tableColumnHeader.tableName)
    ) as Array<TableColumns>;

    this.tableColumnDetails = JSON.parse(
      localStorage.getItem(this.tableColumnDetail.tableName)
    ) as Array<TableColumns>;

    // this.$store
    //   .dispatch({
    //     type: "tableColumns/GetByTableNameList",
    //     data: this.tableColumnHeader,
    //   })
    //   .then((res) => {
    //     this.tableColumnHeaders = JSON.parse(
    //       localStorage.getItem(this.tableColumnHeader.tableName)
    //     ) as Array<TableColumns>;
    //   })
    //   .catch((err) => {
    //     console.log(err);
    //   });
    // this.$store
    //   .dispatch({
    //     type: "tableColumns/GetByTableNameList",
    //     data: this.tableColumnDetail,
    //   })
    //   .then((res) => {
    //     this.tableColumnDetails = JSON.parse(
    //       localStorage.getItem(this.tableColumnDetail.tableName)
    //     ) as Array<TableColumns>;
    //   })
    //   .catch((err) => {
    //     console.log(err);
    //   });
  }
  get() {
    this.$store
      .dispatch({
        type: "customer/get",
        data: this.header,
      })
      .then((res) => {
        this.header = res;
        this.detailDatas.details = res.customerDetails;
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
        this.$store.state.customer.queryCustomer
      );
      this.get();
    }
  }
  cancel() {
    this.$emit("input", false);
  }

}
</script>
 