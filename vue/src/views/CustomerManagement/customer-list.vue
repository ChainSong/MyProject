<template>
  <div>
    <Card dis-hover>
      <el-collapse accordion>
        <el-collapse-item>
          <template slot="title">
            <label style="color:#409EFF"> 查询条件<i class="el-icon-search"></i></label>
          </template>
          <div class="page-body">
            <Form ref="queryForm" :label-width="90" label-position="left" inline>
              <Row>
                <Col v-for="i in tableColumns" v-bind:key="i.id" span="6">
                <FormItem :label="i.displayName" v-if="i.isSearchCondition" style="width: 95%">
                  <template v-if="i.type == 'TextBox'">
                    <el-input placeholder="请输入内容" v-model="customer[i.columnName]" size="small"
                      v-if="i.isSearchCondition">
                    </el-input>
                  </template>
                  <template v-if="i.type == 'DropDownListInt'">
                    <el-select v-model="customer[i.columnName]" v-if="i.isSearchCondition" size="small"
                      placeholder="请选择">
                      <el-option v-for="item in i.tableColumnsDetails" :key="item.codeInt" style="width: 100%"
                        :label="item.name" :value="item.codeInt">
                      </el-option>
                    </el-select>
                  </template>
                  <template v-if="i.type == 'DropDownListStr'">
                    <el-select v-model="customer[i.columnName]" v-if="i.isSearchCondition" size="small"
                      placeholder="请选择">
                      <el-option v-for="item in i.tableColumnsDetails" :key="item.codeStr" style="width: 100%"
                        :label="item.name" :value="item.codeStr">
                      </el-option>
                    </el-select>
                  </template>
                  <template v-if="i.type == 'DatePicker'">
                    <el-date-picker v-model="customer[i.columnName]" type="daterange" size="small"
                      v-if="i.isSearchCondition" range-separator="~" start-placeholder="开始日期" end-placeholder="结束日期"
                      style="width: 100%">
                    </el-date-picker>
                  </template>
                  <template v-if="i.type == 'DateTimePicker'" span="12">
                    <el-date-picker v-model="customer[i.columnName]" v-if="i.isSearchCondition" size="small"
                      type="datetimerange" range-separator="~" start-placeholder="开始日期" end-placeholder="结束日期"
                      style="width: 100%">
                    </el-date-picker>
                  </template>
                </FormItem>
                </Col>
              </Row>
              <!-- <Row>
              
              </Row> -->
            </Form>
          </div>
        </el-collapse-item>
      </el-collapse>
      <el-button icon="el-icon-search" type="primary" class="toolbar-btn" @click="getpage">{{ L("Find")
      }}</el-button>
      <el-button type="primary" class="toolbar-btn" v-if="isGranted('Pages.Customer.Create')" @click="create"
        icon="el-icon-plus">{{ L("Add")
        }}</el-button>
      <div class="margin-top-10">
        <el-table :data="list" show-overflow-tooltip style="width: 100%">
          <template v-for="v in tableColumns">
            <template v-if="v.isShowInList">
              <el-table-column v-if="v.type == 'DropDownListInt'" v-bind:key="v.columnName" :fixed="false"
                :prop="v.columnName" :label="v.displayName" width="150" max-height="50">
                <template slot-scope="scope">
                  <el-tag size="medium" v-for="item in v.tableColumnsDetails"
                    v-if="item.codeInt == list[scope.$index][v.columnName]" v-bind:key="item.codeInt"
                    show-icon :type="item.color">
                    {{ item.name }}
                  </el-tag>
                </template>
              </el-table-column>
              <el-table-column v-else-if="v.type == 'DropDownListStr'" v-bind:key="v.columnName" :fixed="false"
                :prop="v.columnName" :label="v.displayName" width="150" max-height="50">
                <template slot-scope="scope">
                  <el-tag size="medium" v-for="item in v.tableColumnsDetails"
                    v-if="item.codeStr == list[scope.$index][v.columnName]" v-bind:key="item.codeStr" 
                    show-icon :type="item.color">
                    {{ item.name }}
                  </el-tag>
                </template>
              </el-table-column>
              <el-table-column v-else v-bind:key="v.id" :fixed="false" :prop="v.columnName" :label="v.displayName"
                width="150" max-height="50">
              </el-table-column>
            </template>
          </template>
          <el-table-column fixed="right" label="操作" width="200">

            <template slot-scope="scope">

              <el-button @click="handleQuery(scope.row)" class="el-icon-s-comment" type="text" size="small">查看
              </el-button>
              <el-button @click="handleEdit(scope.row)" class="el-icon-edit" v-if="isGranted('Pages.Customer.Edit')"
                type="text" size="small">编辑</el-button>
              <el-popconfirm confirm-button-text="确定" v-if="isGranted('Pages.Customer.Delete')" cancel-button-text="取消"
                icon="el-icon-info" icon-color="red" @confirm="handleDelete(scope.row)" title="确定删除吗？">
                <el-button slot="reference" type="text" class="el-icon-delete" style="color:#F56C6C;margin-left: 10px;"
                  size="small">删除</el-button>
              </el-popconfirm>

            </template>
          </el-table-column>
        </el-table>
        <!-- <Table :loading="loading" :columns="columns" :no-data-text="L('NoDatas')" border :data="list">
                    </Table> -->
        <Page show-sizer class-name="fengpage" :total="totalCount" class="margin-top-10" @on-change="pageChange"
          @on-page-size-change="pagesizeChange" :page-size="pageSize" :current="currentPage"></Page>
      </div>
    </Card>
    <customer-create v-model="createModalShow" @save-success="getpage"></customer-create>
    <customer-edit v-model="editModalShow" @save-success="getpage"></customer-edit>
    <customer-query v-model="queryModalShow" @save-success="getpage"></customer-query>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import AbpBase from "../../lib/abpbase";
import Customer from "@/store/entities/customer";
import CustomerUserMapping from "../../store/entities/customerUserMapping";
import TableColumns from "../../store/entities/tableColumns";
import CustomerCreate from "./customer-create.vue";
import CustomerEdit from "./customer-edit.vue";
import CustomerQuery from "./customer-query.vue";
@Component({
  components: { CustomerCreate, CustomerEdit, CustomerQuery },
})
export default class CustomerList extends AbpBase {
  tableColumn: TableColumns = new TableColumns();
  customerUserMapping: CustomerUserMapping = new CustomerUserMapping();
  customerUserMappings: Array<CustomerUserMapping> = new Array<CustomerUserMapping>();
  customer: Customer = new Customer();
  tableColumns: Array<TableColumns> = new Array<TableColumns>();
  customers: Array<Customer> = new Array<Customer>();
  createModalShow: boolean = false;
  editModalShow: boolean = false;
  queryModalShow: boolean = false;

  columns = [];
  get list() {

    return this.$store.state.customer.list;
  }
  get loading() {
    return this.$store.state.customer.loading;
  }
  get pageSize() {
    return this.$store.state.customer.pageSize;
  }
  get totalCount() {
    return this.$store.state.customer.totalCount;
  }
  get currentPage() {
    return this.$store.state.customer.currentPage;
  }
  //显示操作的按钮
  // isOpertion(){

  // }
  //判断按钮权限
  isGranted(Granted) {
    // console.log(Granted);
    // console.log(abp.auth.isGranted(Granted));
    return abp.auth.isGranted(Granted)
  }
  create() {
    this.createModalShow = true;
  }
  handleEdit(row) {
    this.$store.commit("customer/edit", row);
    this.editModalShow = true;
  }
  async handleDelete(row) {
    await this.$store.dispatch({ type: "customer/delete", data: row });
    await this.getpage();
  }
  handleQuery(row) {
    this.$store.commit("customer/query", row);
    this.queryModalShow = true;
  }
  async getpage() {

    this.customer.maxResultCount = this.pageSize;
    this.customer.skipCount = (this.currentPage - 1) * this.pageSize;
    await this.$store.dispatch({
      type: "customer/GetPaged",
      data: this.customer,
    });
  }

  pageChange(page: number) {
    this.$store.commit("customer/setCurrentPage", page);
    this.getpage();
  }
  pagesizeChange(pagesize: number) {
    this.$store.commit("customer/setPageSize", pagesize);
    this.getpage();
  }
  gettableColumn() {
    this.tableColumn.tableName = "Customer";
    this.$store
      .dispatch({
        type: "tableColumns/GetByTableNameList",
        data: this.tableColumn,
      })
      .then((res) => {
        console.log("tableColumn");
        console.log(res);
        this.tableColumns = JSON.parse(
          localStorage.getItem(this.tableColumn.tableName)
        ) as Array<TableColumns>;
        console.log(this.tableColumns);
      })
      .catch((err) => {
        console.log(err);
      });
  }
  created() {
    this.gettableColumn();
    this.getpage();
  }
}
</script>

