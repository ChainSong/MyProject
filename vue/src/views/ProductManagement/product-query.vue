<template>
  <div>
    <Modal title="产品详情" :value="value" width="50" @on-visible-change="visibleChange">
      <el-descriptions class="margin-top" :column="2" size="small" border>
        <template v-for="i in tableColumnHeaders">
          <el-descriptions-item v-bind:key="i.id" style="width:500px" labelStyle="width:'200px'" :prop="i.displayName"
            v-if="i.isCreate">
            <template slot="label">
              <i></i>
              {{ i.displayName }}
            </template>
            <template v-if="i.type == 'TextBox'">
              <label>{{ header[i.columnName] }}</label>
            </template>
            <template slot-scope="scope" v-else-if="i.type == 'DropDownListInt'">
              <el-tag size="medium" v-for="item in i.tableColumnsDetails" v-if="item.codeInt == header[i.columnName]"
                v-bind="item.codeInt" :key="item.codeInt" show-icon :type="item.color">
                {{ item.name }}
              </el-tag>
            </template>

            <template slot-scope="scope" v-else-if="i.type == 'DropDownListStr'">
              <el-tag size="medium" v-for="item in i.tableColumnsDetails" v-if="item.codeStr == header[i.columnName]"
                v-bind="item.codeStr" :key="item.codeStr" show-icon :type="item.color">
                {{ item.name }}
              </el-tag>
            </template>

            <template v-else-if="i.type == 'DropDownListStrRemote'">
              <label>{{ header[i.columnName] }}</label>
            </template>
          </el-descriptions-item>
        </template>
      </el-descriptions>
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
 
<style scoped>
.el-descriptions__body {
  width: 70%;
}
</style>
