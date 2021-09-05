<template>
  <div>
    <Card dis-hover>
      <div class="page-body">
        <Form ref="queryForm" :label-width="90" label-position="left" inline>
          <Row>
            <Col v-for="i in tableColumns" v-bind:key="i.id" span="6">
              <FormItem
                :label="i.displayName"
                v-if="i.isSearchCondition"
                style="width: 100%"
              >
                <template v-if="i.type == 'TextBox'">
                  <el-input
                    placeholder="请输入内容"
                    v-model="receipt[i.dbColumnName]"
                    v-if="i.isSearchCondition"
                  >
                  </el-input>
                  <!-- <Input
                    v-model="receipt[i.dbColumnName]"
                    v-if="i.isSearchCondition"
                  >
                  </Input> -->
                </template>
                <template v-if="i.type == 'DropDownList'">
                  <el-select
                    v-model="receipt[i.dbColumnName]"
                    v-if="i.isSearchCondition"
                    placeholder="请选择"
                  >
                    <el-option
                      v-for="item in i.table_ColumnsDetails"
                      :key="item.code"
                      :label="item.name"
                      :value="item.code"
                    >
                    </el-option>
                  </el-select>
                </template>
                <template v-if="i.type == 'DatePicker'">
                  <el-date-picker
                    v-model="receipt[i.dbColumnName]"
                    type="daterange"
                    v-if="i.isSearchCondition"
                    range-separator="~"
                    start-placeholder="开始日期"
                    end-placeholder="结束日期"
                    style="width: 100%"
                  >
                  </el-date-picker>
                </template>
                <template v-if="i.type == 'DateTimePicker'" span="12">
                  <el-date-picker
                    v-model="receipt[i.dbColumnName]"
                    v-if="i.isSearchCondition"
                    type="datetimerange"
                    range-separator="~"
                    start-placeholder="开始日期"
                    end-placeholder="结束日期"
                    style="width: 100%"
                  >
                  </el-date-picker>
                </template>
              </FormItem>
            </Col>
          </Row>
          <Row>
            <Button
              icon="ios-search"
              type="primary"
              size="large"
              class="toolbar-btn"
              @click="getpage"
              >{{ L("Find") }}</Button
            >
            <Button
              type="primary"
              size="large"
              class="toolbar-btn"
              @click="create"
              icon="android-add"
              >{{ L("Add") }}</Button
            >
          </Row>
        </Form>
      </div>
      <div class="margin-top-10">
        <el-table :data="list" style="width: 100%" max-height="300">
          <template v-for="v in tableColumns">
            <template v-if="v.isShowInList">
              <el-table-column
                v-if="v.type == 'DropDownList'"
                v-bind:key="v.dbColumnName"
                :fixed="false"
                :prop="v.dbColumnName"
                :label="v.displayName"
                width="150"
                max-height="50"
              >
                <template
                  slot-scope="scope" >
                 <el-select
                    v-model="list[scope.$index][v.dbColumnName]"
                    v-bind:disabled="true"
                  >
                    <el-option
                      v-for="item in v.table_ColumnsDetails"
                      :key="item.codeN"
                      :label="item.name"
                      :value="item.codeN"
                    >
                    </el-option>
                  </el-select>
                </template>
              </el-table-column>
              <el-table-column
                v-else
                v-bind:key="v.dbColumnName"
                :fixed="false"
                :prop="v.dbColumnName"
                :label="v.displayName"
                width="150"
                max-height="50"
              >
              </el-table-column>
            </template>
          </template>
          <el-table-column fixed="right" label="操作" width="130">
            <template slot-scope="scope">
              <el-button
                @click="handleQuery(scope.row)"
                type="text"
                size="small"
                >查看</el-button
              >
              <el-button @click="handleEdit(scope.row)" type="text" size="small"
                >编辑</el-button
              >

              <el-popconfirm
                confirm-button-text="确定"
                cancel-button-text="取消"
                icon="el-icon-info"
                icon-color="red"
                @confirm="handleDelete(scope.row)"
                title="确定删除吗？"
              >
                <el-button slot="reference" type="text" size="small"
                  >删除</el-button
                >
              </el-popconfirm>
            </template>
          </el-table-column>
        </el-table>
        <!-- <Table :loading="loading" :columns="columns" :no-data-text="L('NoDatas')" border :data="list">
                    </Table> -->
        <Page
          show-sizer
          class-name="fengpage"
          :total="totalCount"
          class="margin-top-10"
          @on-change="pageChange"
          @on-page-size-change="pagesizeChange"
          :page-size="pageSize"
          :current="currentPage"
        ></Page>
      </div>
    </Card>
    <receipt-create
      v-model="createModalShow"
      @save-success="getpage"
    ></receipt-create>
    <receipt-edit
      v-model="editModalShow"
      @save-success="getpage"
    ></receipt-edit>
    <receipt-query
      v-model="queryModalShow"
      @save-success="getpage"
    ></receipt-query>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import AbpBase from "../../lib/abpbase";
import Receipt from "@/store/entities/receipt";
import CustomerUserMapping from "../../store/entities/customerUserMapping";
import TableColumns from "../../store/entities/tableColumns";
import ReceiptCreate from "./receipt-create.vue";
import ReceiptEdit from "./receipt-edit.vue";
import ReceiptQuery from "./receipt-query.vue";
@Component({
   components: { ReceiptCreate,ReceiptEdit,ReceiptQuery},
})
export default class ReceiptList extends AbpBase {
  tableColumn: TableColumns = new TableColumns();
  customerUserMapping: CustomerUserMapping = new CustomerUserMapping();
  receiptUserMappings: Array<CustomerUserMapping> = new Array<CustomerUserMapping> ();
  receipt: Receipt = new Receipt();
  tableColumns: Array<TableColumns> = new Array<TableColumns>();
  receipts: Array<Receipt> = new Array<Receipt>();
  createModalShow: boolean = false;
  editModalShow: boolean = false;
  queryModalShow: boolean = false;

  columns = [];
  get list() {
    return this.$store.state.receipt.list;
  }
  get loading() {
    return this.$store.state.receipt.loading;
  }
  get pageSize() {
    return this.$store.state.receipt.pageSize;
  }
  get totalCount() {
    return this.$store.state.receipt.totalCount;
  }
  get currentPage() {
    return this.$store.state.receipt.currentPage;
  }
  create() {
    this.createModalShow = true;
  }
  handleEdit(row) {
    this.$store.commit("receipt/edit", row);
    this.editModalShow = true;
  }
  async handleDelete(row) {
    await this.$store.dispatch({ type: "receipt/delete", data: row });
    await this.getpage();
  }
  handleQuery(row) {
    this.$store.commit("receipt/query", row);
    this.queryModalShow = true;
  }
  async getpage() {
    this.receipt.maxResultCount = this.pageSize;
    this.receipt.skipCount = (this.currentPage - 1) * this.pageSize;
    await this.$store.dispatch({
      type: "receipt/GetPaged",
      data: this.receipt,
    });
  }

  pageChange(page: number) {
    this.$store.commit("receipt/setCurrentPage", page);
    this.getpage();
  }
  pagesizeChange(pagesize: number) {
    this.$store.commit("receipt/setPageSize", pagesize);
    this.getpage();
  }
  gettableColumn() {
    this.tableColumn.tableName = "WMS_Receipt";
    this.$store
      .dispatch({
        type: "tableColumns/GetByTableNameList",
        data: this.tableColumn,
      })
      .then((res) => {
          console.log(res);
        this.tableColumns = JSON.parse(
          localStorage.getItem(this.tableColumn.tableName)
        ) as Array<TableColumns>;
        console.log( this.tableColumns);
      })
      .catch((err) => {
        console.log(err);
      });
      

      // this.$store
      // .dispatch({
      //   type: "receiptUserMapping/GetPaged",
      //   data: this.customerUserMapping,
      // })
      // .then((res) => {
      //   console.log("res");
      //   console.log(res);
      //   //  this.receiptUserMappings=this.$store.state.receiptUserMapping.list;
      //   //  this.receiptUserMappings=res
      //   // this.tableColumns = JSON.parse(
      //   //   localStorage.getItem(this.tableColumn.tableName)
      //   // ) as Array<TableColumns>;
      //   // console.log( this.tableColumns);
      // })
      // .catch((err) => {
      //   console.log(err);
      // });
      
  }
  created() {
    this.gettableColumn();
    this.getpage();
  }
}
</script>

