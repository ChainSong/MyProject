<template>
  <div>

    <Modal :value="value" width="60" :close-on-click-modal="false" @on-visible-change="visibleChange">

      <el-tabs v-model="activeName">
        <el-tab-pane label="页面创建" name="PageCreate">

          <Form ref="header" label-position="top" :rules="headerRule" :model="header">
            <Row>
              <Col v-for="i in tableColumnHeaders" v-bind:key="i.id" span="8">
              <FormItem :label="i.displayName" v-if="i.isCreate" style="height: 45px;" :prop="i.columnName">
                <template v-if="i.type == 'TextBox'">
                  <el-input placeholder="请输入内容" v-model="header[i.columnName]" style="width: 90%;" size="small"
                    v-if="i.isCreate">
                  </el-input>
                </template>
                <template v-if="i.type == 'DropDownListInt'">
                  <el-select v-model="header[i.columnName]" font-family="Helvetica Neue" v-if="i.isCreate"
                    style="width: 90%" size="small" placeholder="请选择" filterable>
                    <el-option v-for="item in i.tableColumnsDetails" :key="item.codeInt" :label="item.name"
                      :value="item.codeInt">
                    </el-option>
                  </el-select>
                </template>
                <template v-if="i.type == 'DropDownListStr'">
                  <el-select v-model="header[i.columnName]" font-family="Helvetica Neue" v-if="i.isCreate" size="small"
                    style="width: 90%" placeholder="请选择" filterable>
                    <el-option v-for="item in i.tableColumnsDetails" :key="item.codeStr" :label="item.name"
                      :value="item.codeStr">
                    </el-option>
                  </el-select>
                </template>
                <template v-if="i.type == 'DropDownListStrRemote'">
                  <!-- <select-tool :apiurl=i.associated :column=i.columnName :relationColumn=i.relationDBColumn
                    @getChildrenVal="getChildrenVal" :obj="i" style="width: 90%;" size="small"></select-tool> -->
                  <select-tool @getChildrenVal="getChildrenVal" :objData="i" :objWhere="header[i.columnName]" valData=""
                    :isDisabled="i.isCreate" style="width: 90%;" size="small"></select-tool>
                </template>
                <template v-if="i.type == 'DatePicker'">
                  <el-date-picker v-model="header[i.columnName]" value-format="yyyy-MM-dd" v-if="i.isCreate"
                    size="small" type="date" placeholder="选择日期" style="width: 90%">
                  </el-date-picker>
                </template>

                <template v-if="i.type == 'DateTimePicker'" span="12">
                  <el-date-picker v-model="header[i.columnName]" v-if="i.isCreate" size="small" type="datetime"
                    start-placeholder="选择日期时间" style="width: 90%">
                  </el-date-picker>
                </template>
              </FormItem>
              </Col>
            </Row>
          </Form>
          <el-button @click="handleAdd" type="primary" class="toolbar-btn">添加一条</el-button>
          <template>
            <el-form label-position="top" :model="details" ref="details" :rules="detailRule">
              <el-table :data="details.line" style="width: 100%;" height="250" size="small">
                <template v-for="(v, index) in tableColumnDetails">
                  <el-table-column v-if="v.isCreate" :key="index" style="margin:0;padding:0;" :fixed="false"
                    :prop="v.columnName" :label="v.displayName" width="150">
                    <template slot-scope="scope">
                      <el-form-item style="margin:0;padding:0;" :key="scope.row.key"
                        :prop="'line.' + scope.$index + '.' + v.columnName" :rules="detailRule[v.columnName]">
                        <template v-if="v.type == 'TextBox'">
                          <el-input placeholder="请输入内容" size="small" v-model="details.line[scope.$index][v.columnName]"
                            v-if="v.isCreate">
                          </el-input>
                        </template>
                        <template v-if="v.type == 'DropDownListInt'">
                          <el-select v-model="details.line[scope.$index][v.columnName]" size="small" v-if="v.isCreate"
                            placeholder="请选择" style="width: 100%">
                            <el-option v-for="item in v.tableColumnsDetails" :key="item.codeInt" :label="item.name"
                              :value="item.codeInt">
                            </el-option>
                          </el-select>
                        </template>
                        <template v-if="v.type == 'DropDownListStr'">
                          <el-select v-model="details.line[scope.$index][v.columnName]" size="small" v-if="v.isCreate"
                            placeholder="请选择" style="width: 100%">
                            <el-option v-for="item in v.tableColumnsDetails" :key="item.codeStr" :label="item.name"
                              :value="item.codeStr">
                            </el-option>
                          </el-select>
                        </template>
                        <template v-if="v.type == 'DropDownListStrRemote'">
                          <select-tool @getChildrenVal="getChildrenVal" :objData="v" valData="" :isDisabled="v.isCreate"
                            :objWhere="header" :row="scope.$index" style="width: 100%;" size="small"></select-tool>
                          <!-- <select-tool :apiurl=v.associated :customerId="header['CustomerId']" :column=v.columnName
                            :relationColumn=v.relationDBColumn @getChildrenVal="getChildrenVal" :row="scope.$index"
                            style="width: 100%;" size="small">
                          </select-tool> -->
                        </template>
                        <template v-if="v.type == 'InputNumber'">
                          <el-input-number placeholder="请输入内容" size="small"
                            v-model="details.line[scope.$index][v.columnName]" v-if="v.isCreate"></el-input-number>
                        </template>
                        <template v-if="v.type == 'DatePicker'">
                          <el-date-picker v-model="details.line[scope.$index][v.columnName]" value-format="yyyy-MM-dd"
                            size="small" v-if="v.isCreate" type="date" placeholder="选择日期" style="width: 100%">
                          </el-date-picker>
                        </template>
                        <template v-if="v.type == 'DateTimePicker'">
                          <el-date-picker v-model="details.line[scope.$index][v.columnName]" size="small"
                            v-if="v.isCreate" type="datetime" start-placeholder="选择日期时间" style="width: 100%">
                          </el-date-picker>
                        </template>
                      </el-form-item>
                    </template>
                  </el-table-column>
                </template>
                <template>
                  <el-table-column fixed="right" label="操作">
                    <template slot-scope="scope">
                      <el-button size="mini" type="danger" @click="handleDelete(scope.$index)">删除</el-button>
                    </template>
                  </el-table-column>
                </template>
              </el-table>
            </el-form>
          </template>
        </el-tab-pane>
        <el-tab-pane label="Excel导入" name="ExcelCreate">
          <el-row>
            <el-col>
            </el-col>
            <el-col>
              <el-upload class="upload-demo" :action="uploadURL" :headers="httpheaders" :on-success="ImportExcel">
                <el-button type="primary">点击上传</el-button>
                <div slot="tip" class="el-upload__tip">只能上传xlsx/xls文件，且不超过500kb</div>
              </el-upload>
            </el-col>
          </el-row>
          <el-link type="primary" @click="GetImportExcelTemplate">下载模板</el-link>
        </el-tab-pane>
      </el-tabs>
      <div slot="footer">
        <Button @click="cancel">{{ L("Cancel") }}</Button>
        <Button @click="save" type="primary">{{ L("OK") }}</Button>
      </div>
    </Modal>
    <el-dialog :visible.sync="resultPopupShow" :append-to-body="true">
      <el-alert v-for="i in orderStatus" v-bind="i" :key="i" :title="i.externOrder + i.msg" :type="i.statusMsg">
      </el-alert>
    </el-dialog>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../lib/util";
import AbpBase from "../../lib/abpbase";
import Header from "../../store/entities/asn";
import Detail from "@/store/entities/asnDetail";
import orderStatus from "@/store/entities/orderStatus";
import TableColumns from "@/store/entities/tableColumns";
// import headerTool from "../Tool/header-tool.vue";
// import resultPopup from "../Tool/result-popup.vue";
import selectTool from "../Tool/select-tool.vue";
import url from '../../lib/url'
@Component({
  components: { selectTool },
})
export default class asnCreate extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  //给上传组件赋值url
  uploadURL = url + "api/services/app/WMS_ASN/UploadExcelFile";
  //给上传组件赋值token
  httpheaders = { Authorization: "Bearer " + window.abp.auth.getToken() }

  tableColumnHeader: TableColumns = new TableColumns();
  tableColumnHeaders: Array<TableColumns> = new Array<TableColumns>();
  tableColumnDetail: TableColumns = new TableColumns();
  tableColumnDetails: Array<TableColumns> = new Array<TableColumns>();
  orderStatus: Array<orderStatus> = new Array<orderStatus>();
  header: Header = new Header();
  details = { line: [new Detail()] };
  headerRule = {};
  detailRule = {};
  activeName: string = 'PageCreate';
  resultPopupShow: boolean = false;

  created() {
    this.gettableColumn();
  }
  gettableColumn() {
    this.tableColumnHeader.tableName = "WMS_ASN";
    this.tableColumnDetail.tableName = "WMS_ASNDetail";
    this.$store
      .dispatch({
        type: "tableColumns/GetByTableNameList",
        data: this.tableColumnHeader,
      })
      .then((res) => {
        this.tableColumnHeaders = JSON.parse(
          localStorage.getItem(this.tableColumnHeader.tableName)
        ) as Array<TableColumns>;
        this.tableColumnHeaders.forEach((a) => {
          if (a.validation.toUpperCase() == "Required".toUpperCase()) {
            this.headerRule[a.columnName] = [
              {
                required: true,
                message: this.L("FieldIsRequired", undefined, a.displayName),
                trigger: "blur",
              },
            ];
          }
        });
        // console.log(this.headerRule);
      })
      .catch((err) => {
        console.log(err);
      });
    this.$store
      .dispatch({
        type: "tableColumns/GetByTableNameList",
        data: this.tableColumnDetail,
      })
      .then((res) => {
        this.tableColumnDetails = JSON.parse(
          localStorage.getItem(this.tableColumnDetail.tableName)
        ) as Array<TableColumns>;
        this.tableColumnDetails.forEach((a) => {
          if (a.validation.toUpperCase() == "Required".toUpperCase()) {
            this.detailRule[a.columnName] = [
              {
                required: true,
                message: this.L("FieldIsRequired", undefined, a.displayName),
                trigger: "blur",
              },
            ];
          }
        });
      })
      .catch((err) => {
        console.log(err);
      });
  }
  //动态拉下列表子组件回传
  getChildrenVal(column, label, relationColumn, value, row) {
    console.log("relationColumn")
    console.log(column, label)
    console.log(relationColumn, value)
    if (label != undefined) {
      if (row < 0) {
        if (column != "" || column != undefined) {
          this.header[column] = label;
          // this.$set( this.header, column,label);
          console.log(this.header);
        }
        if (relationColumn != "" || relationColumn != undefined) {
          this.header[relationColumn] = value;
        }
      } else {
        // console.log(row)
        // console.log(column, label)
        // console.log(relationColumn, value)
        if (column != "" || column != undefined) {
          this.details.line[row][column] = label;
        }
        if (relationColumn != "" || relationColumn != undefined) {
          this.details.line[row][relationColumn] = value;
        }
        this.$set(this.details, Math.ceil(Math.random() * 1000), this.details.line);
        // console.log(this.details);
      }
      this.$forceUpdate();
    }
  }
  //获取导入的模板
  GetImportExcelTemplate() {
    // console.log("准备开始下载模板")
    this.$store
      .dispatch({
        type: "tableColumns/GetImportExcelTemplate",
        data: { CustomerId: this.header.customerId, TableName: "WMS_ASN" },
      })
      .then((res) => {

      })
      .catch((err) => {
        console.log(err);
      });
  }

  visibleChange(value: boolean) {
    if (!value) {
      this.$emit("input", value);
    }
  }
  handleAdd() {
    this.details.line.push(new Detail());
  }
  handleDelete(index) {
    this.details.line.splice(index, 1);
  }
  cancel() {
    (this.$refs.header as any).resetFields();
    this.header = new Header();
    this.details = { line: [new Detail()] };
    this.$emit("input", false);
  }
  save() {
    this.header.asnDetails = this.details.line;
    // console.log("this.header");
    // console.log(JSON.stringify(this.header))
    (this.$refs.header as any).validate(async (valid: boolean) => {
      if (valid) {
        (this.$refs.details as any).validate(async (valid: boolean) => {
          if (valid) {
            await this.$store.dispatch({
              type: "asn/create",
              data: {
                WMS_ASN: this.header,
                // WMS_ASNDetails: this.details.line,
              },
            }).then((res) => {
              console.log("res");
              console.log(res);
              (this.$refs.header as any).resetFields();
              this.details = { line: [new Detail()] };
              this.orderStatus = [];
              this.orderStatus.push(res);

              this.resultPopupShow = true;
              this.$emit("save-success");
              this.$emit("input", false);
            })
              .catch((err) => {
                console.log(err);
              });

          }
        });
      }
    });
    //     }
    // })
  }

  // -------------------------------非可公用部分----------------------------------------
  // 上传结果
  ImportExcel(response, file, fileList) {
    console.log(response)
    this.orderStatus = response.result;
    this.resultPopupShow = true;
  }
}
</script>
<style scoped>

</style>