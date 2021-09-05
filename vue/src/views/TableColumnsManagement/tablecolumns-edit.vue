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
          </Row>
        </Form>
        <div class="margin-top-10">
          <el-table
            :data="tableColumns"
            height="250"
            border
            style="width: 100%"
          >
            <el-table-column prop="TableName" label="表名" width="180">
            </el-table-column>
            <el-table-column prop="DbColumnName" label="字段名称" width="180">
            </el-table-column>
            <el-table-column
              prop="DisplayName"
              label="中文名称"
              width="180"
            ></el-table-column>
            <el-table-column prop="IsCreate" label="添加"> </el-table-column>
            <el-table-column prop="IsSearchCondition" label="查询条件">
            </el-table-column>
            <el-table-column prop="IsShowInList" label="查询结果">
            </el-table-column>
            <el-table-column prop="IsUpdate" label="可修改"> </el-table-column>
            <el-table-column prop="Order" label="排序"> </el-table-column>
            <el-table-column prop="Validation" label="验证"> </el-table-column>
            <el-table-column prop="Type" label="类型"> </el-table-column>
            <el-table-column prop="Associated" label="下拉"> </el-table-column>
          </el-table>
        </div>
      </div>
    </Card>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../lib/util";
import AbpBase from "../../lib/abpbase";
import TableColumns from "@/store/entities/tableColumns";
@Component
export default class TablecolumnsEdit extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  tableColumn: TableColumns = new TableColumns();
  tableColumns: Array<TableColumns> = new Array<TableColumns>();
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
  created() {
    this.get();
  }
  getpage() {
    this.get();
  }
  get() {
    this.$store
      .dispatch({
        type: "tableColumns/GetPaged",
        data: this.tableColumn,
      })
      .then((res) => {
        this.tableColumns = res;
        // this.detailDatas.details = res.receiptDetails;
      })
      .catch((err) => {
        console.log(err);
      });
  }
}
</script>
 