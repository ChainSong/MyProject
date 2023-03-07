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
                    <el-input placeholder="请输入内容" size="small" v-model="receipt[i.columnName]"
                      v-if="i.isSearchCondition">
                    </el-input>
                  </template>
                  <template v-if="i.type == 'DropDownListInt'">
                    <el-select v-model="receipt[i.columnName]" clearable size="small" v-if="i.isSearchCondition"
                      style="width:100%;height: auto;" placeholder="请选择">
                      <el-option v-for="item in i.tableColumnsDetails" :key="item.codeInt" :label="item.name"
                        :value="item.codeInt">
                      </el-option>
                    </el-select>
                  </template>
                  <template v-if="i.type == 'DropDownListStr'">
                    <el-select v-model="receipt[i.columnName]" clearable size="small" v-if="i.isSearchCondition"
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
                    <el-date-picker v-model="receipt[i.columnName]" type="daterange" value-format="yyyy-MM-dd"
                      size="small" v-if="i.isSearchCondition" range-separator="~" start-placeholder="开始日期"
                      end-placeholder="结束日期" style="width: 100%">
                    </el-date-picker>
                  </template>
                  <template v-if="i.type == 'DateTimePicker'" span="12">
                    <el-date-picker v-model="receipt[i.columnName]" size="small" v-if="i.isSearchCondition"
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

      <el-button icon="el-icon-search" type="primary" class="toolbar-btn" @click="BatchAddInventory">加入库存
      </el-button>

      <el-button icon="el-icon-search" type="primary" class="toolbar-btn" @click="exportReceiptReceivingDialog">导入上架单
      </el-button>
      <!-- <el-button type="primary" class="toolbar-btn" v-if="isGranted('Pages.Receipt.Create')" @click="create"
        icon="el-icon-plus">{{ L("Add")
        }}</el-button> -->
      <el-button type="primary" class="toolbar-btn" v-if="isGranted('Pages.Receipt.Create')"
        @click="dialogReceiptForReceipt = true" icon="android-add">转入库单</el-button>
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
                :label="v.displayName" min-width="160" max-height="50">
                <template slot-scope="scope">
                  {{ getformatDate(list[scope.$index][v.columnName]) }}
                </template>
              </el-table-column>
              <el-table-column v-else-if="v.type == 'DateTimePicker'" v-bind:key="v.id" :fixed="false"
                :prop="v.columnName" :label="v.displayName" min-width="160" max-height="50">
                <template slot-scope="scope">
                  {{ getformatTime(list[scope.$index][v.columnName]) }}
                </template>
              </el-table-column>
              <el-table-column v-else v-bind:key="v.id" :fixed="false" :prop="v.columnName" :label="v.displayName"
                min-width="160" max-height="50">
              </el-table-column>
            </template>
          </template>
          <el-table-column fixed="right" label="操作" width="200">
            <template slot-scope="scope">
              <el-button @click="handleQuery(scope.row)" class="el-icon-s-comment" type="text" size="small">查看
              </el-button>
              <el-button @click="AddInventory(scope.row)" class="el-icon-edit"
                v-if="isGranted('Pages.Receipt.AddInventory')" type="text" size="small">加入库存</el-button>
              <el-popconfirm confirm-button-text="确定" v-if="isGranted('Pages.Receipt.Delete')" cancel-button-text="取消"
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

    <!-- <receipt-create :close-on-click-modal="false" v-model="createModalShow" @save-success="getpage"></receipt-create> -->
    <!-- <receiptreceiving-edit :close-on-click-modal="false" v-model="editModalShow" @save-success="getpage"></receiptreceiving-edit> -->
    <receiptreceiving-query :close-on-click-modal="false" v-model="queryModalShow" @save-success="getpage">
    </receiptreceiving-query>


    <!-- ----------------------------非可公用部分-------------------------------- -->
    <el-dialog title="上传上架信息" :visible.sync="dialogVisible" :append-to-body="true" width="30%">
      <el-upload class="upload-demo" :action="uploadURL" :headers="httpheaders">
        <el-button type="primary">点击上传</el-button>
        <div slot="tip" class="el-upload__tip">只能上传xlsx/xls文件，且不超过500kb</div>
      </el-upload>
      <span slot="footer" class="dialog-footer">
        <!-- <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="dialogVisible = false">确 定</el-button> -->
      </span>
    </el-dialog>
    <!-- <result-popup :objData="orderStatus" :visible.sync="resultPopupShow" ></result-popup> -->
    <el-dialog :visible.sync="resultPopupShow" :append-to-body="true">
      <el-alert v-for="i in orderStatus" v-bind="i" :key="i" :title="i.externOrder + i.msg" :type="i.StatusMsg">
      </el-alert>
    </el-dialog>

  </div>
</template>

<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import AbpBase from "../../lib/abpbase";
import receipt from "@/store/entities/receipt";
import TableColumns from "../../store/entities/tableColumns";
// import resultPopup from "../Tool/result-popup.vue";
import orderStatus from "@/store/entities/orderStatus";
// import receiptCreate from "./receipt-create.vue";
// import receiptreceivingEdit from "../ReceiptReceivingManagement/receiptreceiving-edit.vue";
import receiptreceivingQuery from "./receiptreceiving-query.vue";
import selectTool from "../Tool/select-tool.vue";
import url from '../../lib/url';
import Util from '../../lib/util';
@Component({
  components: { selectTool, receiptreceivingQuery },
})
export default class receiptreceivingList extends AbpBase {
  //给上传组件赋值url
  uploadURL = url + "api/services/app/WMS_ReceiptReceiving/UploadExcelFile";
  //给上传组件赋值token
  httpheaders = { Authorization: "Bearer " + window.abp.auth.getToken() }

  tableColumn: TableColumns = new TableColumns();
  receipt: receipt = new receipt();
  tableColumns: Array<TableColumns> = new Array<TableColumns>();
  receipts: Array<receipt> = new Array<receipt>();
  orderStatus: Array<orderStatus> = new Array<orderStatus>();
  createModalShow: boolean = false;
  editModalShow: boolean = false;
  queryModalShow: boolean = false;
  dialogReceiptForReceipt: boolean = false;
  columns = [];
  dialogVisible: boolean = false;
  resultPopupShow: boolean = false;

  //-------------------------------可公用部分的方法-------------------------------------------//
  get list() {
    return this.$store.state.receiptReceiving.list;
  }
  get loading() {
    return this.$store.state.receiptReceiving.loading;
  }
  get pageSize() {
    return this.$store.state.receiptReceiving.pageSize;
  }
  get totalCount() {
    return this.$store.state.receiptReceiving.totalCount;
  }
  get currentPage() {
    return this.$store.state.receiptReceiving.currentPage;
  }
  create() {
    this.createModalShow = true;
  }
  //加入库存
  AddInventory(row) {
    console.log(row);
    this.$store.dispatch({ type: "receiptReceiving/addInventory", data: row });
    // this.$store.commit("receiptReceiving/edit", row);
    // this.editModalShow = true;
  }
  //批量加入库存
  BatchAddInventory() {

  }
  //判断按钮权限
  isGranted(Granted) {
    return abp.auth.isGranted(Granted)
  }
  //动态拉下列表子组件回传
  getChildrenVal(column, label, relationColumn, value) {
    if (column != "" && column != undefined && label! + "" && label != undefined) {
      this.receipt[column] = label;
    }
    if (relationColumn != "" && relationColumn != undefined && value! + "" && value != undefined) {
      this.receipt[relationColumn] = value;
    }
  }
  //子组件创建完成后执行
  childrenCreate() {

  }

  async handleDelete(row) {
    await this.$store.dispatch({ type: "receiptReceiving/delete", data: row }).then((res) => {
      console.log(res);
      this.orderStatus = res;
      this.resultPopupShow = true;
    });
    await this.getpage();
  }
  handleQuery(row) {
    this.$store.commit("receiptReceiving/query", row);
    this.queryModalShow = true;
  }
  //获取页面数据

  async getpage() {
    this.receipt.maxResultCount = this.pageSize;
    this.receipt.skipCount = (this.currentPage - 1) * this.pageSize;
    await this.$store.dispatch({
      type: "receiptReceiving/GetPaged",
      data: this.receipt,
    });
  }

  pageChange(page: number) {
    this.$store.commit("receiptReceiving/setCurrentPage", page);
    this.getpage();
  }
  pagesizeChange(pagesize: number) {
    this.$store.commit("receiptReceiving/setPageSize", pagesize);
    this.getpage();
  }
  gettableColumn() {
    this.tableColumn.tableName = "WMS_Receipt_ReceiptDetail";
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
  //弹出导入框
  exportReceiptReceivingDialog() {
    //  console.log( abp.utils.getCookieValue('enc_auth_token'));
    //  console.log( abp.auth.getToken);
    this.dialogVisible = true;
  }
}
</script>

