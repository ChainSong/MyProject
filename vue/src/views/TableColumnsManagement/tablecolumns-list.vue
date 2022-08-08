<template>
  <div>
    <Card dis-hover>
      <div class="page-body">
        <Form ref="queryForm" :label-width="80" label-position="left" inline>
          <Row :gutter="16">
            <Col span="6">
              <FormItem label="表名" style="width: 100%">
                <el-input
                  placeholder="请输入表名"
                  v-model="tableColumn.tableName"
                >
                </el-input>
              </FormItem>
            </Col>
            <!-- <Col span="6">
              <FormItem :label="L('IsActive') + ':'" style="width: 100%">
                <Select :placeholder="L('Select')" @on-change="isActiveChange">
                  <Option value="All">{{ L("All") }}</Option>
                  <Option value="Actived">{{ L("Actived") }}</Option>
                  <Option value="NoActive">{{ L("NoActive") }}</Option>
                </Select>
              </FormItem>
            </Col>
            <Col span="6">
              <FormItem :label="L('CreationTime') + ':'" style="width: 100%">
                <DatePicker
                  v-model="creationTime"
                  type="datetimerange"
                  format="yyyy-MM-dd"
                  style="width: 100%"
                  placement="bottom-end"
                  :placeholder="L('SelectDate')"
                ></DatePicker>
              </FormItem>
            </Col> -->
          </Row>
          <Row>
            <!-- <Button
              @click="create"
              icon="android-add"
              type="primary"
              size="large"
              >{{ L("Add") }}</Button
            > -->
            <Button
              icon="ios-search"
              type="primary"
              size="large"
              @click="getpage"
              class="toolbar-btn"
              >{{ L("Find") }}</Button
            >
            <!-- <Button
              type="primary"
              size="large"
              class="toolbar-btn"
              @click="edit"
              icon="android-edit"
              >{{ L("Edit") }}</Button
            > -->
          </Row>
        </Form>
        <div class="margin-top-10">
          <el-table
            :data="list"
            height="500"
            border
            style="width: 100%"
            @row-dblclick="handleEdit"
          >
            <el-table-column prop="tableName" label="表名" >
            </el-table-column>
            <!-- <el-table-column prop="dbColumnName" label="字段名称" width="180">
            </el-table-column> -->
            <el-table-column
              prop="tableNameCH"
              label="中文名称"
            ></el-table-column>
             <el-table-column  label="操作">
               <el-button @click="cleanCache(scope.row)" type="text" size="small">清理缓存</el-button> 
              </el-table-column>
            <!-- <el-table-column prop="isCreate" label="添加"> </el-table-column>
            <el-table-column prop="isSearchCondition" label="查询条件">
            </el-table-column>
            <el-table-column prop="isShowInList" label="查询列表">
            </el-table-column>
            <el-table-column prop="isUpdate" label="可修改"> </el-table-column>
            <el-table-column prop="order" label="排序"> </el-table-column>
            <el-table-column prop="validation" label="验证"> </el-table-column>
            <el-table-column prop="type" label="类型"> </el-table-column>
            <el-table-column prop="associated" label="下拉"> </el-table-column> -->
          </el-table>
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
      </div>
    </Card>
    <tablecolumns-edit
      v-model="editModalShow"
      @save-success="getpage"
    ></tablecolumns-edit>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../lib/util";
import AbpBase from "../../lib/abpbase";
import TableColumns from "@/store/entities/tableColumns";
import tablecolumnsEdit from "./tablecolumns-edit.vue";
@Component({
  components: { tablecolumnsEdit },
})
export default class TablecolumnsList extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  tableColumn: TableColumns = new TableColumns();
  tableColumns: Array<TableColumns> = new Array<TableColumns>();
  createModalShow: boolean = false;
  editModalShow: boolean = false;
  queryModalShow: boolean = false;

  //分页以及查询需要
  get list() {
    return this.$store.state.tableColumns.list;
  }
  get loading() {
    return this.$store.state.tableColumns.loading;
  }
  get pageSize() {
    return this.$store.state.tableColumns.pageSize;
  }
  get totalCount() {
    return this.$store.state.tableColumns.totalCount;
  }
  get currentPage() {
    
    return this.$store.state.tableColumns.currentPage;
  }
  pageChange(page: number) {
    this.$store.commit("tableColumns/setCurrentPage", page);
    this.getpage();
  }
  pagesizeChange(pagesize: number) {
    this.$store.commit("tableColumns/setPageSize", pagesize);
    this.getpage();
  }
  cleanCache(row)
  {
    this.$store
      .dispatch({
        type: "tableColumns/cleanCache",
        data:row,
      })
      
  }
  // edit(){
  //   this.$store.commit("tablecolumns/edit", this.tableColumn);
  //   this.editModalShow = true;
  // }

  handleEdit(row) {
    this.tableColumn.tableName=row.tableName;
    // this.get();
    this.$store.commit("tableColumns/edit", row);
    this.editModalShow = true;
     this.tableColumn.tableName="";
  }
  created() {
    this.get();
  }
  getpage() {
    // console.log(this.tableColumn)
    this.get();
  }
  get() {
    this.tableColumn.maxResultCount = this.pageSize;
    this.tableColumn.skipCount = (this.currentPage - 1) * this.pageSize;
  
    console.log(this.$store.state.tableColumns);
    this.$store
      .dispatch({
        type: "tableColumns/GetPaged",
        data: this.tableColumn,
      })
      .then((res) => {
        this.tableColumns = res;
      })
      .catch((err) => {
        console.log(err);
      });
  }
}
</script>
 