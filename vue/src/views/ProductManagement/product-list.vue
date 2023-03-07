<template>
  <div>
    <Card dis-hover>
      <el-collapse accordion>
        <el-collapse-item>
          <template slot="title">
        <label style="color:#409EFF"> 查询条件<i class="el-icon-search" ></i></label>
          </template>
          <div class="page-body">
            <Form ref="queryForm" :label-width="80" label-position="left" inline>
              <Row>
                <Col v-for="i in tableColumns" v-bind:key="i.id" span="6">
                <FormItem :label="i.displayName" v-if="i.isSearchCondition" style="width:95%">
                  <template v-if="i.type == 'TextBox'">
                    <el-input placeholder="请输入内容" size="small" v-model="product[i.columnName]"
                      v-if="i.isSearchCondition">
                    </el-input>
                  </template>
                  <template v-if="i.type == 'DropDownListInt'">
                    <el-select v-model="product[i.columnName]" size="small" v-if="i.isSearchCondition"
                      style="width:100%" placeholder="请选择">
                      <el-option v-for="item in i.tableColumnsDetails" :key="item.codeInt" :label="item.name"
                        :value="item.codeInt">
                      </el-option>
                    </el-select>
                  </template>
                  <template v-if="i.type == 'DropDownListStr'">
                    <el-select v-model="product[i.columnName]" size="small" v-if="i.isSearchCondition"
                      style="width:100%" placeholder="请选择">
                      <el-option v-for="item in i.tableColumnsDetails" :key="item.codeStr" :label="item.name"
                        :value="item.codeStr">
                      </el-option>
                    </el-select>
                  </template>
                    <template v-if="i.type == 'DropDownListStrRemote'">
                      <select-tool 
                    @getChildrenVal="getChildrenVal" :objData="i" valData=""    style="width: 100%;" size="small"></select-tool>
                 
                    <!-- <select-tool :apiurl=i.associated :column=i.columnName :relationColumn=i.relationColumn
                      @getChildrenVal="getChildrenVal" style="width: 100%;" size="small"></select-tool> -->
                  </template>
                  <template v-if="i.type == 'DatePicker'">
                    <el-date-picker v-model="product[i.columnName]" type="daterange" v-if="i.isSearchCondition"
                      range-separator="~" start-placeholder="开始日期" end-placeholder="结束日期" style="width: 95%">
                    </el-date-picker>
                  </template>
                  <template v-if="i.type == 'DateTimePicker'" span="12">
                    <el-date-picker v-model="product[i.columnName]" v-if="i.isSearchCondition" type="datetimerange"
                      range-separator="~" start-placeholder="开始日期" end-placeholder="结束日期" style="width: 95%">
                    </el-date-picker>
                  </template>
                </FormItem>
                </Col>
              </Row>
              <!-- <Row>
                <Button icon="ios-search" type="primary" size="large" class="toolbar-btn" @click="getpage">{{ L("Find")
                }}</Button>
                <Button type="primary" size="large" class="toolbar-btn" @click="create" icon="android-add">{{ L("Add")
                }}</Button>
              </Row> -->
            </Form>
          </div>
        </el-collapse-item>
      </el-collapse>
       <el-button icon="el-icon-search" type="primary"  class="toolbar-btn" @click="getpage">{{ L("Find")
      }}</el-button>
      <el-button type="primary"   class="toolbar-btn"
        @click="create" icon="el-icon-plus">{{ L("Add")
        }}</el-button>
      <div class="margin-top-10">
        <el-table :data="list" style="width: 100%" >
           <template v-for="v in tableColumns">
            <template v-if="v.isShowInList">
              <el-table-column v-if="v.type == 'DropDownListInt'" v-bind:key="v.id" :fixed="false" :prop="v.columnName"
                :label="v.displayName" width="150" max-height="50">
                <template slot-scope="scope">
                  <el-tag size="medium" v-for="item in v.tableColumnsDetails"
                    v-if="item.codeInt == list[scope.$index][v.columnName]" v-bind="item.codeInt" :key="item.codeInt"
                    show-icon :type="item.color">
                    {{ item.name }}
                  </el-tag>
                </template>
              </el-table-column>
              <el-table-column v-else-if="v.type == 'DropDownListStr'" v-bind:key="v.columnName" :fixed="false"
                :prop="v.columnName" :label="v.displayName" width="150" max-height="50">
                <template slot-scope="scope">
                  <el-tag size="medium" v-for="item in v.tableColumnsDetails"
                    v-if="item.codeStr == list[scope.$index][v.columnName]" v-bind="item.codeStr" :key="item.codeStr"
                    show-icon :type="item.color">
                    {{ item.name }}
                  </el-tag>
                </template>
              </el-table-column>
              <el-table-column sortable v-else-if="v.type == 'DropDownListStrRemote'" :fixed="false"
                :prop="v.columnName" :label="v.displayName" width="150" max-height="50">
              </el-table-column>
              <el-table-column sortable v-else v-bind:key="v.id" :fixed="false" :prop="v.columnName"
                :label="v.displayName" width="150" max-height="50">
              </el-table-column>
            </template>
          </template>
          <el-table-column fixed="right" label="操作" width="200">
            <template slot-scope="scope">
              <el-button @click="handleQuery(scope.row)" type="text" class="el-icon-s-comment" size="small">查看
              </el-button>
              <el-button @click="handleEdit(scope.row)" class="el-icon-edit" type="text" size="small">编辑</el-button>
              
              <el-popconfirm confirm-button-text="确定" cancel-button-text="取消"  icon="el-icon-info" icon-color="red"
                @confirm="handleDelete(scope.row)" title="确定删除吗？">
                <el-button slot="reference" type="text"   style="color:#F56C6C;margin-left: 10px;" class="el-icon-delete" size="small">删除</el-button>
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
    <product-create v-model="createModalShow" @save-success="getpage"></product-create>
    <product-edit v-model="editModalShow" @save-success="getpage"></product-edit>
    <product-query v-model="queryModalShow" @save-success="getpage"></product-query>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import AbpBase from "../../lib/abpbase";
import product from "@/store/entities/product";
import TableColumns from "../../store/entities/tableColumns";
import productCreate from "./product-create.vue";
import productEdit from "./product-edit.vue";
import productQuery from "./product-query.vue";
import selectTool from "../Tool/select-tool.vue";
@Component({
  components: { productCreate, productEdit, productQuery,selectTool },
})
export default class ProductList extends AbpBase {
  tableColumn: TableColumns = new TableColumns();
  product: product = new product();
  tableColumns: Array<TableColumns> = new Array<TableColumns>();
  customers: Array<product> = new Array<product>();
  createModalShow: boolean = false;
  editModalShow: boolean = false;
  queryModalShow: boolean = false;

  columns = [];
  get list() {
    console.log("this.$store.state.product.list");
    console.log(this.$store.state.product.list);
    return this.$store.state.product.list;
  }
  get loading() {
    return this.$store.state.product.loading;
  }
  get pageSize() {
    return this.$store.state.product.pageSize;
  }
  get totalCount() {
    return this.$store.state.product.totalCount;
  }
  get currentPage() {
    return this.$store.state.product.currentPage;
  }
  create() {
    this.createModalShow = true;
  }
  handleEdit(row) {
    console.log("row")
    console.log(row)
    this.$store.commit("product/edit", row);
    this.editModalShow = true;
  }
  async handleDelete(row) {
    await this.$store.dispatch({ type: "product/delete", data: row });
    await this.getpage();
  }
  handleQuery(row) {
    this.$store.commit("product/query", row);
    this.queryModalShow = true;
  }
  async getpage() {

    this.product.maxResultCount = this.pageSize;
    this.product.skipCount = (this.currentPage - 1) * this.pageSize;
    await this.$store.dispatch({
      type: "product/GetPaged",
      data: this.product,
    });
  }
  //动态拉下列表子组件回传
  getChildrenVal(column, label, relationColumn, value) {
    this.product[column] = label;
    this.product[relationColumn] = value;
  }
  pageChange(page: number) {
    this.$store.commit("product/setCurrentPage", page);
    this.getpage();
  }
  pagesizeChange(pagesize: number) {
    this.$store.commit("product/setPageSize", pagesize);
    this.getpage();
  }
  gettableColumn() {
    this.tableColumn.tableName = "WMS_Product";
    this.$store
      .dispatch({
        type: "tableColumns/GetByTableNameList",
        data: this.tableColumn,
      })
      .then((res) => {
        this.tableColumns = JSON.parse(
          localStorage.getItem(this.tableColumn.tableName)
        ) as Array<TableColumns>;
        console.log("tableColumns")
        console.log(this.tableColumns)
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

