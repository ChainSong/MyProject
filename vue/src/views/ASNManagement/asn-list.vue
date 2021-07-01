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
                    v-model="asn[i.dbColumnName]"
                    v-if="i.isSearchCondition"
                  >
                  </el-input>
                  <!-- <Input
                    v-model="asn[i.dbColumnName]"
                    v-if="i.isSearchCondition"
                  >
                  </Input> -->
                </template>
                <template v-if="i.type == 'DropDownList'">
                  <el-select
                    v-model="asn[i.dbColumnName]"
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
                    v-model="asn[i.dbColumnName]"
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
                    v-model="asn[i.dbColumnName]"
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
    <asn-create
      v-model="createModalShow"
      @save-success="getpage"
    ></asn-create>
    <asn-edit
      v-model="editModalShow"
      @save-success="getpage"
    ></asn-edit>
    <asn-query
      v-model="queryModalShow"
      @save-success="getpage"
    ></asn-query>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import AbpBase from "../../lib/abpbase";
import asn from "@/store/entities/asn";
import TableColumns from "../../store/entities/tableColumns";
import asnCreate from "./asn-create.vue";
import asnEdit from "./asn-edit.vue";
import asnQuery from "./asn-query.vue";
@Component({
    components: { asnCreate,asnEdit,asnQuery},
})
export default class CustomerList extends AbpBase {
  tableColumn: TableColumns = new TableColumns();
  asn: asn = new asn();
  tableColumns: Array<TableColumns> = new Array<TableColumns>();
  customers: Array<asn> = new Array<asn>();
  createModalShow: boolean = false;
  editModalShow: boolean = false;
  queryModalShow: boolean = false;

  columns = [];
  get list() {
    
    return this.$store.state.asn.list;
  }
  get loading() {
    return this.$store.state.asn.loading;
  }
  get pageSize() {
    return this.$store.state.asn.pageSize;
  }
  get totalCount() {
    return this.$store.state.asn.totalCount;
  }
  get currentPage() {
    return this.$store.state.asn.currentPage;
  }
  create() {
    this.createModalShow = true;
  }
  handleEdit(row) {
    this.$store.commit("asn/edit", row);
    this.editModalShow = true;
  }
  async handleDelete(row) {
    await this.$store.dispatch({ type: "asn/delete", data: row });
    await this.getpage();
  }
  handleQuery(row) {
    this.$store.commit("asn/query", row);
    this.queryModalShow = true;
  }
  async getpage() {
      console.log(this.asn);
    this.asn.maxResultCount = this.pageSize;
    this.asn.skipCount = (this.currentPage - 1) * this.pageSize;
    await this.$store.dispatch({
      type: "asn/GetPaged",
      data: this.asn,
    });
  }

  pageChange(page: number) {
    this.$store.commit("asn/setCurrentPage", page);
    this.getpage();
  }
  pagesizeChange(pagesize: number) {
    this.$store.commit("asn/setPageSize", pagesize);
    this.getpage();
  }
  gettableColumn() {
    this.tableColumn.tableName = "WMS_ASN";
    this.$store
      .dispatch({
        type: "tableColumns/GetByTableNameList",
        data: this.tableColumn,
      })
      .then((res) => {
        this.tableColumns = JSON.parse(
          localStorage.getItem(this.tableColumn.tableName)
        ) as Array<TableColumns>;
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

