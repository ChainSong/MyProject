<template>
  <div>
    <Modal :title="L('CustomerCreate')"  :value="value" width="50" @on-visible-change="visibleChange">
      <Form ref="header" label-position="top" :rules="headerRule" :model="header">
        <Row>
          <Col v-for="i in tableColumnHeaders" v-bind:key="i.id" span="12">
          <FormItem :label="i.displayName" v-if="i.isCreate" style="width: 90%;height: 45px;" :prop="i.columnName">
            <template v-if="i.type == 'TextBox'">
              <el-input placeholder="请输入内容" size="small" style="width:90%"  v-model="header[i.columnName]"
                v-if="i.isCreate">
              </el-input>
            </template>
            <template v-if="i.type == 'DropDownListInt'">
              <el-select v-model="header[i.columnName]" v-if="i.isCreate" placeholder="请选择" size="small"
                style="width:90%" filterable>
                <el-option v-for="item in i.tableColumnsDetails" :key="item.codeInt" :label="item.name"
                  :value="item.codeInt">
                </el-option>
              </el-select>
            </template>
                        <template v-if="i.type == 'DropDownListStrRemote'">
              <select-tool :apiurl=i.associated :column=i.columnName :relationColumn=i.relationColumn 
                @getChildrenVal="getChildrenVal" 
                style="width: 100%;" size="small"></select-tool>
            </template>
            <template v-if="i.type == 'DropDownListStr'">
              <el-select v-model="header[i.columnName]" v-if="i.isCreate" placeholder="请选择" size="small"
                style="width:90%" filterable>
                <el-option v-for="item in i.tableColumnsDetails" :key="item.codeInt" :label="item.name"
                  :value="item.codeInt">
                </el-option>
              </el-select>
            </template>
            <template v-if="i.type == 'DatePicker'">
              <el-date-picker v-model="header[i.columnName]" v-if="i.isCreate" type="date" placeholder="选择日期"
                size="small" style="width:90%">
              </el-date-picker>
            </template>
            <template v-if="i.type == 'DateTimePicker'" span="12">
              <el-date-picker v-model="header[i.columnName]" v-if="i.isCreate" type="datetime"
                start-placeholder="选择日期时间" size="small" style="width:90%">
              </el-date-picker>
            </template>
          </FormItem>
          </Col>
        </Row>
      </Form>
      <el-button @click="handleAdd" type="primary" size="large" class="toolbar-btn">添加一条</el-button>
      <template>
        <el-form label-position="top" :model="details" ref="details" :rules="detailRule">
          <el-table :data="details.line" style="width: 100%" height="250">
            <template v-for="(v, index) in tableColumnDetails">
              <el-table-column v-if="v.isCreate" :key="index" style="margin:0;padding:0;"  :fixed="false" :prop="v.columnName" :label="v.displayName"
                width="150">
                <template slot-scope="scope">
                  <el-form-item :key="scope.row.key" style="margin:0;padding:0;"  :prop="'line.' + scope.$index + '.' + v.columnName"
                    :rules="detailRule[v.columnName]">
                    <template v-if="v.type == 'TextBox'">
                      <el-input placeholder="请输入内容" v-model="details.line[scope.$index][v.columnName]"
                        v-if="v.isCreate">
                      </el-input>
                    </template>
                    <template v-if="v.type == 'DropDownList'">
                      <el-select v-model="scope.row[index]" v-if="v.isCreate" placeholder="请选择" style="width: 100%">
                        <el-option v-for="item in v.tableColumnsDetails" :key="item.code" :label="item.name"
                          :value="item.code">
                        </el-option>
                      </el-select>
                    </template>
                    <template v-if="v.type == 'DatePicker'">
                      <el-date-picker v-model="scope.row[index]" v-if="v.isCreate" type="date" placeholder="选择日期"
                        style="width: 100%">
                      </el-date-picker>
                    </template>
                    <template v-if="v.type == 'DateTimePicker'" span="12">
                      <el-date-picker v-model="scope.row[index]" v-if="v.isCreate" type="datetime"
                        start-placeholder="选择日期时间" style="width: 100%">
                      </el-date-picker>
                    </template>
                  </el-form-item>
                </template>
              </el-table-column>
            </template>
            <template>
              <el-table-column>
                <template slot-scope="scope">
                  <el-button size="mini" type="danger" @click="handleDelete(scope.$index)">删除</el-button>
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
import Header from "../../store/entities/customer";
import Detail from "../../store/entities/customerDetail";
import TableColumns from "@/store/entities/tableColumns";
@Component
export default class CustomerCreate extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  tableColumnHeader: TableColumns = new TableColumns();
  tableColumnHeaders: Array<TableColumns> = new Array<TableColumns>();
  tableColumnDetail: TableColumns = new TableColumns();
  tableColumnDetails: Array<TableColumns> = new Array<TableColumns>();
  header: Header = new Header();
  details = { line: [new Detail()] };
  headerRule = {};
  detailRule = {};
  created() {
    this.gettableColumn();
  }
  gettableColumn() {
    this.tableColumnHeader.tableName = "Customer";
    this.tableColumnDetail.tableName = "CustomerDetail";
    this.$store
      .dispatch({
        type: "tableColumns/GetByTableNameList",
        data: this.tableColumnHeader,
      })
      .then((res) => {
        this.tableColumnHeaders = JSON.parse(
          localStorage.getItem(this.tableColumnHeader.tableName)
        ) as Array<TableColumns>;
        console.log(this.tableColumnHeaders)
        this.tableColumnHeaders.forEach((a) => {
          if (a.validation.toUpperCase() == "Required".toUpperCase()) {
            //  console.log("添加验证"+a.columnName)
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
            // console.log("添加验证"+a.columnName)
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
  getChildrenVal(column, label, relationColumn, value) {
     if (label != undefined) {
      this.header[column] = label;
      this.header[relationColumn] = value;
    }
  
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
    (this.$refs.header as any).validate(async (valid: boolean) => {
      if (valid) {
        (this.$refs.details as any).validate(async (valid: boolean) => {

          if (valid) {
            this.header.customerDetails = this.details.line;
            await this.$store.dispatch({
              type: "customer/create",
              data: {
                Customer: this.header,
                CustomerDetails: this.details.line,
              },
            });
            (this.$refs.header as any).resetFields();
            this.details = { line: [new Detail()] };
            this.$emit("save-success");
            this.$emit("input", false);
          }
        });
      }
    });
    //     }
    // })
  }
}
</script>
 