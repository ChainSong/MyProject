<template>
  <div>
    <Modal title="产品详情" :value="value" width="80" @on-visible-change="visibleChange">
      <Form label-position="top">
        <Row>
          <Col v-for="i in tableColumnHeaders" v-bind:key="i.id" span="6">
          <FormItem :label="i.displayName" :prop="i.displayName" v-if="i.isCreate" style="width: 90%">
            <template v-if="i.type == 'TextBox'">
              <label v-text="header[i.columnName]"></label>
            </template>
            <template v-if="i.type == 'DropDownListStr'">
              <template v-for="DropDown in i.tableColumnsDetails">
                <label v-if="DropDown.codeStr == header[i.columnName]" v-text="DropDown.name" show-icon :type="DropDown.color"
                  :key="DropDown.codeStr"></label>
              </template>
            </template>
             <template v-if="i.type == 'DropDownListInt'">
              <template v-for="DropDown in i.tableColumnsDetails">
                <label v-if="DropDown.codeInt == header[i.columnName]" show-icon :type="DropDown.color" v-text="DropDown.name"
                  :key="DropDown.codeInt"></label>
              </template>
            </template>
          </FormItem>
          </Col>
        </Row>
      </Form>

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
import Header from "../../store/entities/product";
// import Detail from "../../store/entities/productDetail";
import TableColumns from "@/store/entities/tableColumns";
@Component
export default class ProductQuery extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  tableColumnHeader: TableColumns = new TableColumns();
  tableColumnHeaders: Array<TableColumns> = new Array<TableColumns>();
  tableColumnDetail: TableColumns = new TableColumns();
  tableColumnDetails: Array<TableColumns> = new Array<TableColumns>();
  header: Header = new Header();
  headers: Array<Header> = new Array<Header>();
  // detail: Detail = new Detail();
  // details: Array<Detail> = new Array<Detail>();
  // detailDatas = { line: null, details: [new Detail()] };
  created() {
    this.gettableColumn();
  }

  gettableColumn() {
    this.tableColumnHeader.tableName = "WMS_Product";
    this.tableColumnHeaders = JSON.parse(
      localStorage.getItem(this.tableColumnHeader.tableName)
    ) as Array<TableColumns>;
  }
  get() {
    this.$store
      .dispatch({
        type: "product/get",
        data: this.header,
      })
      .then((res) => {
        this.header = res;
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
        this.$store.state.product.queryProduct
      );
      this.get();
    }
  }
  cancel() {
    this.$emit("input", false);
  }

}
</script>
 