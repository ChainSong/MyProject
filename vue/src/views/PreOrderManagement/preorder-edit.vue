<template>
  <div>
    <Modal title="编辑预入库单" :value="value" width="60" @on-visible-change="visibleChange">
      <Form ref="header" label-position="top" :rules="headerRule" :model="header">
        <Row>
          <Col v-for="i in tableColumnHeaders" v-bind:key="i.id" span="8">
          <FormItem :label="i.displayName" v-if="i.isCreate" v-bind:disabled="i.isUpdate == 1" style="height: 45px;"
            :prop="i.columnName">
            <template v-if="i.type == 'TextBox'">
              <el-input placeholder="请输入内容" size="small" v-model="header[i.columnName]" v-if="i.isCreate"
                style="width: 90%" v-bind:disabled="i.isUpdate == 0">
              </el-input>
            </template>
            <template v-if="i.type == 'DropDownListInt'">
              <el-select v-model="header[i.columnName]" v-if="i.isCreate" size="small" v-bind:disabled="i.isUpdate == 1"
                placeholder="请选择" style="width: 90%">
                <el-option v-for="item in i.tableColumnsDetails" :key="item.codeInt" :label="item.name"
                  :value="item.codeInt">
                </el-option>
              </el-select>
            </template>
            <template v-if="i.type == 'DropDownListStr'">
              <el-select v-model="header[i.columnName]" v-if="i.isCreate" size="small" v-bind:disabled="i.isUpdate == 1"
                placeholder="请选择" style="width: 90%">
                <el-option v-for="item in i.tableColumnsDetails" :key="item.codeStr" :label="item.name"
                  :value="item.codeStr">
                </el-option>
              </el-select>
            </template>
            <template v-if="i.type == 'DropDownListStrRemote'">
              <select-tool :objData="i" :valData="header[i.columnName]" v-if="i.isCreate" :isDisabled="i.isUpdate"
                @getChildrenVal="getChildrenVal" style="width: 90%;" size="small"></select-tool>

            </template>
            <template v-if="i.type == 'DatePicker'">
              <el-date-picker v-model="header[i.columnName]" value-format="yyyy-MM-dd" v-if="i.isCreate" size="small"
                v-bind:disabled="i.isUpdate == 0" type="date" placeholder="选择日期" style="width: 90%">
              </el-date-picker>
            </template>
            <template v-if="i.type == 'DateTimePicker'" span="12">
              <el-date-picker v-model="header[i.columnName]" v-if="i.isCreate" size="small"
                v-bind:disabled="i.isUpdate == 0" type="datetime" start-placeholder="选择日期时间" style="width: 90%">
              </el-date-picker>
            </template>
          </FormItem>
          </Col>
        </Row>
      </Form>
      <el-button @click="handleAdd" type="primary" size="small" class="toolbar-btn">添加一条</el-button>
      <template>
        <el-form label-position="top" :model="details" ref="details" :rules="detailRule">
          <el-table :data="details.line" show-overflow-tooltip style="width: 100%" height="250" size="small">
            <template v-for="(v, index) in tableColumnDetails">
              <el-table-column v-if="v.isCreate" v-bind:disabled="v.isUpdate == 1" :key="index" :fixed="false"
                :prop="v.columnName" :label="v.displayName" width="150" height="150">
                <template slot-scope="scope">

                  <el-form-item :key="scope.row.key" style="margin:0;padding:0;"
                    :prop="'line.' + scope.$index + '.' + v.columnName" :rules="detailRule[v.columnName]">
                    <template v-if="v.type == 'TextBox'">
                      <el-input size="small" v-model="details.line[scope.$index][v.columnName]" v-if="v.isCreate"
                        v-bind:disabled="v.isUpdate == 1">
                      </el-input>
                    </template>

                    <template v-if="v.type == 'DropDownListStr'">
                      <el-select v-model="details.line[scope.$index][v.columnName]" v-if="v.isCreate" size="small"
                        v-bind:disabled="v.isUpdate == 1" placeholder="请选择" style="width: 95%">
                        <el-option v-for="item in v.tableColumnsDetails" :key="item.codeStr" :label="item.name"
                          :value="item.codeStr">
                        </el-option>
                      </el-select>
                    </template>
                    <template v-if="v.type == 'DropDownListInt'">
                      <el-select v-model="details.line[scope.$index][v.columnName]" v-if="v.isCreate" size="small"
                        v-bind:disabled="v.isUpdate == 1" placeholder="请选择" style="width: 95%">
                        <el-option v-for="item in v.tableColumnsDetails" :key="item.codeInt" :label="item.name"
                          :value="item.codeInt">
                        </el-option>
                      </el-select>
                    </template>
                    <template v-if="v.type == 'DropDownListStrRemote'">
                      <select-tool :objData="v" :valData="details.line[scope.$index][v.columnName]"
                        :isDisabled="v.isUpdate" @getChildrenVal="getChildrenVal" :row="scope.$index"
                        style="width: 90%;" size="small"></select-tool>
                    </template>
                    <template v-if="v.type == 'InputNumber'">
                      <el-input-number size="small" v-model="details.line[scope.$index][v.columnName]"
                        v-bind:disabled="v.isUpdate == 1" v-if="v.isCreate"></el-input-number>
                    </template>
                    <template v-if="v.type == 'DatePicker'">
                      <el-date-picker v-model="details.line[scope.$index][v.columnName]" value-format="yyyy-MM-dd"
                        v-if="v.isCreate" size="small" v-bind:disabled="v.isUpdate == 1" type="date" placeholder="选择日期"
                        style="width: 100%">
                      </el-date-picker>
                    </template>
                    <template v-if="v.type == 'DateTimePicker'">
                      <el-date-picker v-model="details.line[scope.$index][v.columnName]" v-if="v.isCreate" size="small"
                        v-bind:disabled="v.isUpdate == 1" type="datetime" start-placeholder="选择日期时间"
                        style="width: 100%">
                      </el-date-picker>
                    </template>
                  </el-form-item>
                </template>
              </el-table-column>
            </template>
            <template>
              <el-table-column fixed="right">
                <template slot-scope="scope">
                  <el-button size="small" type="danger" @click="handleDelete(scope.$index)">删除</el-button>
                </template>
              </el-table-column>
            </template>
          </el-table>
        </el-form>
      </template>
      <div slot="footer">
        <Button @click="cancel">{{ L("Cancel") }}</Button>
        <Button @click="save" type="primary">{{ L("OK") }}</Button>
      </div>
    </Modal>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../lib/util";
import AbpBase from "../../lib/abpbase";
import Header from "../../store/entities/preorder";
import Detail from "../../store/entities/preorderDetail";
import TableColumns from "@/store/entities/tableColumns";
import selectTool from "../Tool/select-tool.vue";
@Component({
  components: { selectTool },
})
export default class PreOrderEdit extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  tableColumnHeader: TableColumns = new TableColumns();
  tableColumnHeaders: Array<TableColumns> = new Array<TableColumns>();
  tableColumnDetail: TableColumns = new TableColumns();
  tableColumnDetails: Array<TableColumns> = new Array<TableColumns>();
  header: Header = new Header();
  details = { line: [new Detail()] };
  headerRule = {};
  detailRule = {};
  refurbish: number = 0;
  created() {

  }
  gettableColumn() {
    this.tableColumnHeader.tableName = "WMS_PreOrder";
    this.tableColumnDetail.tableName = "WMS_PreOrderDetail";
    //构建主表的信息

    //构建主表信息
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
      })
      .catch((err) => {
        console.log(err);
      });
    //构建明细表信息
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

  //动态拉下列表子组件回传（通过row 来判断数据所处位置 -1 说明数据不是数组）
  getChildrenVal(column, label, relationColumn, value, row) {
    if (row < 0) {
      if (column != "" && column != undefined && label! + "" && label != undefined) {
        this.header[column] = label;
      }
      if (relationColumn != "" && relationColumn != undefined && value! + "" && value != undefined) {
        this.header[relationColumn] = value;
      }
    } else {
      if (column != "" && column != undefined && label! + "" && label != undefined) {
        this.details.line[row][column] = label;
      }
      if (relationColumn != "" && relationColumn != undefined && value! + "" && value != undefined) {
        this.details.line[row][relationColumn] = value;
      }
      this.$set(this.details, Math.ceil(Math.random() * 1000), this.details.line);
    }

  }

  get() {
    this.$store
      .dispatch({
        type: "preorder/get",
        data: this.header,
      })
      .then((res) => {
        // console.log("this.header")
        // console.log(res)
        this.header = res;
        this.details.line = res.preOrderDetails;
        //给自定义组件重新赋值Key 让子组件重新加载
        this.refurbish = Math.ceil(Math.random() * 1000);
        this.gettableColumn();
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
        this.$store.state.preorder.editPreOrder
      );
      this.get();

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
    this.header.preorderDetails = this.details.line;
    console.log(this.header);
    (this.$refs.header as any).validate(async (valid: boolean) => {
      if (valid) {
        (this.$refs.details as any).validate(async (valid: boolean) => {
          if (valid) {
            this.$store.dispatch({
              type: "preorder/update",
              data: {
                WMS_PreOrder: this.header
              },
            }).then((res) => {

              if (res.data.result != undefined && res.data.result != null) {
                this.$message({
                  message: '操作成功',
                  type: 'success'
                });
                this.$emit("save-success");
                this.$emit("input", false);
              } else {
             
                this.$message.error('操作失败');
            
              }
              // console.log("保存编辑");
              // console.log(res);
            })
              .catch((err) => {
                console.log(err);
              });

          }
        });
      }
    });
  }
}
</script>
 