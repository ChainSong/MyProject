<template>
  <div>
    <Card dis-hover>
      <div class="page-body">
        <Form ref="queryForm" :label-width="80" label-position="left" inline>
          <el-collapse accordion>
            <el-collapse-item>
              <template slot="title">
                <label style="color:#409EFF">查询条件<i class="el-icon-search"></i></label>
              </template>
              <Row>
                <Col v-for="i in tableColumns" v-bind:key="i.id" span="6">
                <FormItem :label="i.displayName" v-if="i.isSearchCondition" style="width:95%;height: 30px;">
                  <template v-if="i.type == 'TextBox'">
                    <el-input placeholder="请输入内容" size="small" v-model="asn[i.columnName]" v-if="i.isSearchCondition">
                    </el-input>
                  </template>
                  <template v-if="i.type == 'DropDownListInt'">
                    <el-select v-model="asn[i.columnName]" clearable size="small" v-if="i.isSearchCondition"
                      style="width:100%;height: auto;" placeholder="请选择">
                      <el-option v-for="item in i.tableColumnsDetails" :key="item.codeInt" :label="item.name"
                        :value="item.codeInt">
                      </el-option>
                    </el-select>
                  </template>
                  <template v-if="i.type == 'DropDownListStr'">
                    <el-select v-model="asn[i.columnName]" clearable size="small" v-if="i.isSearchCondition"
                      style="width:100%" placeholder="请选择">
                      <el-option v-for="item in i.tableColumnsDetails" :key="item.codeStr" :label="item.name"
                        :value="item.codeStr">
                      </el-option>
                    </el-select>
                  </template>
                  <template v-if="i.type == 'DropDownListStrRemote'">
                    <select-tool @getChildrenVal="getChildrenVal" :objData="i" style="width: 100%;" size="small">
                    </select-tool>
                    <!-- <select-tool :apiurl=i.associated :column=i.columnName :relationColumn=i.relationColumn
                      @getChildrenVal="getChildrenVal" style="width: 100%;" size="small"></select-tool> -->
                  </template>
                  <template v-if="i.type == 'DatePicker'">
                    <el-date-picker v-model="asn[i.columnName]" type="daterange" value-format="yyyy-MM-dd" size="small"
                      v-if="i.isSearchCondition" range-separator="~" start-placeholder="开始日期" end-placeholder="结束日期"
                      style="width: 100%">
                    </el-date-picker>
                  </template>
                  <template v-if="i.type == 'DateTimePicker'" span="12">
                    <el-date-picker v-model="asn[i.columnName]" size="small" v-if="i.isSearchCondition"
                      type="datetimerange" range-separator="~" start-placeholder="开始日期" end-placeholder="结束日期"
                      style="width: 100%">
                    </el-date-picker>
                  </template>
                </FormItem>
                </Col>
              </Row>
            </el-collapse-item>
          </el-collapse>
        </Form>
      </div>
      <el-button icon="el-icon-search" type="primary" class="toolbar-btn" @click="getpage">{{ L("Find")
      }}</el-button>
      <el-button type="primary" class="toolbar-btn" v-if="isGranted('Pages.ASN.Create')" @click="create"
        icon="el-icon-plus">{{ L("Add")
        }}</el-button>
      <el-button type="primary" class="toolbar-btn" v-if="isGranted('Pages.ASN.Create')"
        @click="dialogASNForReceipt = true" icon="android-add">转入库单</el-button>
      <div class="margin-top-10">
        <el-table :data="list" ref="multipleTable" show-overflow-tooltip style="width:auto">
          <el-table-column type="selection" width="55">
          </el-table-column>
          <template v-for="v in tableColumns">
            <template v-if="v.isShowInList">
              <el-table-column v-if="v.type == 'DropDownListInt'" v-bind:key="v.columnName" :fixed="false"
                :prop="v.columnName" :label="v.displayName" max-height="50" width="120">
                <template slot-scope="scope">
                  <el-tag size="medium" v-for="item in v.tableColumnsDetails"
                    v-if="item.codeInt == list[scope.$index][v.columnName]" v-bind:key="item.codeInt" show-icon
                    :type="item.color">
                    {{ item.name }}
                  </el-tag>
                </template>
              </el-table-column>
              <el-table-column v-else-if="v.type == 'DropDownListStr'" v-bind:key="v.columnName" :fixed="false"
                :prop="v.columnName" :label="v.displayName" max-height="50">
                <template slot-scope="scope">
                  <el-tag size="medium" v-for="item in v.tableColumnsDetails"
                    v-if="item.codeStr == list[scope.$index][v.columnName]" v-bind:key="item.codeStr" show-icon
                    :type="item.color">
                    {{ item.name }}
                  </el-tag>
                </template>
              </el-table-column>
              <el-table-column v-else-if="v.type == 'DropDownListStrRemote'" v-bind:key="v.id" :fixed="false"
                :prop="v.columnName" :label="v.displayName" min-width="100" max-height="50">
              </el-table-column>
              <el-table-column v-else-if="v.type == 'DatePicker'" v-bind:key="v.id" :fixed="false" :prop="v.columnName"
                :label="v.displayName" min-width="160" max-height="50" >
                <template slot-scope="scope">
                    {{getformatDate(list[scope.$index][v.columnName])}}
                </template>
              </el-table-column>
              <el-table-column v-else-if="v.type == 'DateTimePicker'" v-bind:key="v.id" :fixed="false" :prop="v.columnName"
                :label="v.displayName" min-width="160" max-height="50" >
                <template slot-scope="scope">
                    {{getformatTime(list[scope.$index][v.columnName])}}
                </template>
              </el-table-column>
              <el-table-column v-else v-bind:key="v.id" :fixed="false" :prop="v.columnName" :label="v.displayName"
                min-width="150" max-height="50">
              </el-table-column>
            </template>
          </template>
          <el-table-column fixed="right" label="操作" width="200">
            <template slot-scope="scope">
              <el-button @click="handleQuery(scope.row)" class="el-icon-s-comment" type="text" size="small">查看
              </el-button>
              <el-button @click="handleEdit(scope.row)" class="el-icon-edit" v-if="isGranted('Pages.ASN.Edit')"
                type="text" size="small">编辑</el-button>
              <el-popconfirm confirm-button-text="确定" v-if="isGranted('Pages.ASN.Delete')" cancel-button-text="取消"
                icon="el-icon-info" icon-color="red" @confirm="handleDelete(scope.row)" title="确定删除吗？">
                <el-button slot="reference" type="text" class="el-icon-delete" style="color:#F56C6C;margin-left: 10px;"
                  size="small">删除</el-button>
              </el-popconfirm>
            </template>
          </el-table-column>
        </el-table>
        <Page show-sizer class-name="fengpage" :total="totalCount" class="margin-top-10" @on-change="pageChange"
          @on-page-size-change="pagesizeChange" :page-size="pageSize" :current="currentPage"></Page>
      </div>
    </Card>

    <asn-create :close-on-click-modal="false" v-model="createModalShow" @save-success="getpage"></asn-create>
    <asn-edit :close-on-click-modal="false" v-model="editModalShow" @save-success="getpage"></asn-edit>
    <asn-query :close-on-click-modal="false" v-model="queryModalShow" @save-success="getpage"></asn-query>


    <el-dialog title="提示" :visible.sync="dialogASNForReceipt" :append-to-body="true" width="30%">
      <span>确认将ASN 转入库单</span>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogASNForReceipt = false">取 消</el-button>
        <el-button type="primary" @click="asnForReceipt">确 定</el-button>
      </span>
    </el-dialog>

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
import selectTool from "../Tool/select-tool.vue";
@Component({
  components: { selectTool,asnCreate, asnEdit, asnQuery },
})
export default class asnList extends AbpBase {
  tableColumn: TableColumns = new TableColumns();
  asn: asn = new asn();
  tableColumns: Array<TableColumns> = new Array<TableColumns>();
  asns: Array<asn> = new Array<asn>();
  createModalShow: boolean = false;
  editModalShow: boolean = false;
  queryModalShow: boolean = false;
  dialogASNForReceipt: boolean = false;
  columns = [];

  //-------------------------------可共用部分的方法-------------------------------------------//
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
  //判断按钮权限
  isGranted(Granted) {
    return abp.auth.isGranted(Granted)
  }
  //动态拉下列表子组件回传
  getChildrenVal(column, label, relationColumn, value) {
    if (column != "" && column != undefined && label! + "" && label != undefined) {
      this.asn[column] = label;
    }
    if (relationColumn != "" && relationColumn != undefined && value! + "" && value != undefined) {
      this.asn[relationColumn] = value;
    }
  }
  //子组件创建完成后执行
  childrenCreate() {

  }

  async handleDelete(row) {
    await this.$store.dispatch({ type: "asn/delete", data: row });
    await this.getpage();
  }
  handleQuery(row) {
    this.$store.commit("asn/query", row);
    this.queryModalShow = true;
  }
  //获取页面数据

  async getpage() {
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
        this.getpage();
      })
      .catch((err) => {
        console.log(err);
      });
  }
  beforeCreate() {

  }
  created() {
    this.gettableColumn();

  }
  beforeUpdate() {

  }

  //----------------------------非可公用部分--------------------------------//
  //ASN转入库单
  asnForReceipt() {
    //1 获取选中的订单ID
    let ids = new Array<Number>();
    this.$refs.multipleTable.selection.forEach(a => {
      ids.push(a.id);
    });
    // 2,验证数据有没有勾选
    if (ids.length < 1) {
      this.$message({
        message: '请勾选订单',
        type: 'warning'
      });
      return;
    }
    this.$store.dispatch({
      type: "asn/asnForReceipt",
      data: ids,
    }).then((res) => {
      // console.log("res");
      // console.log(res);
      if (res) {
        //成功
        this.dialogASNForReceipt = false;
        this.$message({
          message: '转入库单成功',
          type: 'success'
        });
        this.getpage();
      } else {
        //失败
        this.$message('转入库单失败:' + res.msg);
      }

    })
      .catch((err) => {
        console.log(err);
        this.$message.error('系统错误');
      });
    // this.$emit("save-success");
    // this.$emit("input", false);
  }
}
</script>

