<template>
  <div>
    <Modal title="上架详情" :value="value" width="60" @on-visible-change="visibleChange">
      <!-- <el-container>
        <el-main> -->
      <el-descriptions class="margin-top" :column="3" size="small" border>
        <template v-for="i in tableColumnHeaders">
          <el-descriptions-item v-bind:key="i.id" :prop="i.displayName" v-if="i.isCreate == 1 || i.isKey == 1">
            <template slot="label" width="100">
              <i></i>
              {{ i.displayName }}
            </template>
            <template v-if="i.type == 'TextBox'">
              <label font-family="Helvetica Neue" v-text="header[i.columnName]"></label>
            </template>
            <template v-else-if="i.type == 'DropDownListStrRemote'">
              <label font-family="Helvetica Neue" v-text="header[i.columnName]"></label>
            </template>
            <template v-else-if="i.type == 'DatePicker'">
              <label font-family="Helvetica Neue" v-text="getformatDate(header[i.columnName])"></label>
            </template>
            <template v-else-if="i.type == 'DateTimePicker'">
              <label font-family="Helvetica Neue" v-text="getformatTime(header[i.columnName])"></label>
            </template>
            <template v-else-if="i.type == 'DropDownListStr'">
              <template v-for="DropDown in i.tableColumnsDetails">
                <label v-if="DropDown.codeStr == header[i.columnName]" v-text="DropDown.name" show-icon
                  :type="DropDown.color" :key="DropDown.codeStr"></label>
              </template>
            </template>
            <template v-else-if="i.type == 'DropDownListInt'">
              <el-tag size="medium" v-for="item in i.tableColumnsDetails" v-if="item.codeInt == header[i.columnName]"
                v-bind="item.codeInt" :key="item.codeInt" show-icon :type="item.color">
                {{ item.name }}
              </el-tag>
              <!-- <template v-for="DropDown in i.tableColumnsDetails">
                <label v-if="DropDown.codeInt == header[i.columnName]" show-icon :type="DropDown.color"
                  v-text="DropDown.name" :key="DropDown.codeInt"></label>
              </template> -->
            </template>
          </el-descriptions-item>
        </template>
      </el-descriptions>
      <!-- </el-main>
      </el-container> -->
      <el-container title="预入库明细信息">
        <el-main>
          <template>
            <el-form :model="detailDatas" ref="editDetail">
              <el-table :data="detailDatas.details" size="small" height="250" show-overflow-tooltip>
                <template v-for="(v, index) in tableColumnDetails">
                  <el-table-column v-if="v.type == 'DatePicker' && v.isCreate" v-bind:key="v.id" :fixed="false"
                    :formatter="formatDate" :prop="v.columnName" :label="v.displayName" min-width="100" max-height="50">
                    <template slot-scope="scope">
                      {{getformatDate(detailDatas.details[scope.$index][v.columnName])}}
                    </template>
                  </el-table-column>
                  <el-table-column v-else-if="v.type == 'DateTimePicker' && v.isCreate" v-bind:key="v.id" :fixed="false"
                    :formatter="formatDate" :prop="v.columnName" :label="v.displayName" min-width="100" max-height="50">
                    <template slot-scope="scope">
                      {{getformatTime(list[scope.$index][v.columnName])}}
                    </template>
                  </el-table-column>
                  <el-table-column v-else-if="v.isCreate" :key="index" :fixed="false" :label="v.displayName"
                    width="120">
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
import Header from "../../store/entities/receipt";
import Detail from "../../store/entities/receiptReceiving";
import TableColumns from "@/store/entities/tableColumns";
import { getformatDate, getformatTime } from "@/utils/formatDateTime";
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
    this.tableColumnDetail.tableName = "WMS_ReceiptReceiving";
    // this.tableColumnHeaders = JSON.parse(
    //   localStorage.getItem(this.tableColumnHeader.tableName)
    // ) as Array<TableColumns>;
    // this.tableColumnDetails = JSON.parse(
    //   localStorage.getItem(this.tableColumnDetail.tableName)
    // ) as Array<TableColumns>;


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
          // console.log(this.tableColumnDetails );
      })
      .catch((err) => {
        console.log(err);
      });
  }
  get() {
    console.log("this.header");
    console.log(this.header);
    this.$store
      .dispatch({
        type: "receiptReceiving/get",
        data: this.header,
      })
      .then((res) => {

        this.header = res;
        // console.log(this.header);
        this.detailDatas.details = res.receiptReceivings;
        // console.log("res");
        // console.log(this.detailDatas.details);
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
        this.$store.state.receiptReceiving.queryReceipt
      );
      // console.log(this.header);
      this.get();
    }
  }
  cancel() {
    this.$emit("input", false);
  }
  //方法区
  formatDate(row, column) {
    // 获取单元格数据
    let data = row[column.property]
    if (data == null) {
      return null
    }
    let dt = new Date(data);
    // console.log("row");
    // console.log(row);
    return dt.getFullYear() + '-' + (dt.getMonth() + 1) + '-' + dt.getDate();
  }
}
</script>
 