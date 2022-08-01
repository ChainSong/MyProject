<template>
  <div>
    <Modal
      :title="L('ASNQuery')"
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
             
                <template v-if="i.type == 'DropDownList'">
                  <template v-for="DropDown in i.table_ColumnsDetails">
                    <label v-if="DropDown.codeStr==header[i.dbColumnName]" v-text="DropDown.name" :key="DropDown.code"></label>
                  </template>
              
              </template> 
              
            </FormItem>
          </Col>
        </Row>
      </Form> 
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
              <!-- <template slot-scope="scope">
                  <el-form-item
                    :key="scope.row.key"
                    :prop="'details.' + scope.$index + '.' + index"
                  >
                    <template v-if="v.type == 'TextBox'">
                      <el-input
                        placeholder="请输入内容"
                        v-model="
                          detailDatas.details[scope.$index][v.dbColumnName]
                        "
                        v-if="v.isUpdate"
                      >
                      </el-input>
                    </template>
                </template> -->
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
import Header from "../../store/entities/asn";
import Detail from "../../store/entities/asnDetail";
import TableColumns from "@/store/entities/tableColumns";
@Component
export default class ASNQuery extends AbpBase {
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
    this.tableColumnHeader.tableName = "WMS_ASN";
    this.tableColumnDetail.tableName = "WMS_ASNDetail";
    this.$store
      .dispatch({
        type: "Table_Columns/GetByTableNameList",
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
        type: "Table_Columns/GetByTableNameList",
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
        type: "ASN/get",
        data: this.header,
      })
      .then((res) => {
        this.header = res;
        this.detailDatas.details = res.asnDetails;
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
        this.$store.state.asn.queryASN
      );
      // console.log(this.header);
      this.get();
    }
  }
  cancel() {
    this.$emit("input", false);
  }
  
}
</script>
 