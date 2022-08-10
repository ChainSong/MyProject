<template>
  <div>
    <Modal title="客户详情" :value="value" width="80" @on-visible-change="visibleChange">
      <el-container>
        <el-main>
          <el-descriptions class="margin-top" :column="3"  size="small" border>
            <template v-for="i in tableColumnHeaders">
              <el-descriptions-item v-bind:key="i.id" :prop="i.displayName" v-if="i.isCreate">
                <template slot="label" width="100">
                  <i></i>
                  {{ i.displayName }}
                </template>
                <template v-if="i.type == 'TextBox'">
                  <label font-family="Helvetica Neue" v-text="header[i.columnName]"></label>
                </template>
                <template v-if="i.type == 'DropDownListStr'">
                  <template v-for="DropDown in i.tableColumnsDetails">
                    <label v-if="DropDown.codeStr == header[i.columnName]" v-text="DropDown.name" show-icon
                      :type="DropDown.color" :key="DropDown.codeStr"></label>
                  </template>
                </template>
                <template v-if="i.type == 'DropDownListInt'">
                  <template v-for="DropDown in i.tableColumnsDetails">
                    <label v-if="DropDown.codeInt == header[i.columnName]" show-icon :type="DropDown.color"
                      v-text="DropDown.name" :key="DropDown.codeInt"></label>
                  </template>
                </template>
              </el-descriptions-item>
            </template>
          </el-descriptions>
        </el-main>
      </el-container>

      <el-container title="客户明细信息">
        <el-main>
          <template >
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
        </el-main>
      </el-container>
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
      console.log(this.$store.state.customer.queryCustomer)
      this.get();
    }
  }
  cancel() {
    this.$emit("input", false);
  }

}
</script>
 