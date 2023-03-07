<template>
  <div>
    <Modal title="编辑库区" :value="value" width="50" @on-visible-change="visibleChange">
      <Form ref="editHeader" label-position="top" :rules="headerRule">
        <Row>
          <Col v-for="i in tableColumnHeaders" v-bind:key="i.id" span="12">
          <FormItem :label="i.displayName" v-if="i.isCreate" style="width: 90%">
            <template v-if="i.type == 'TextBox'">
              <el-input placeholder="请输入内容" v-model="header[i.columnName]" v-if="i.isCreate" size="small"
                v-bind:disabled="i.isUpdate == 0">
              </el-input>
            </template>
            <template v-if="i.type == 'DropDownListInt'">
              <el-select v-model="header[i.columnName]" v-if="i.isCreate" v-bind:disabled="i.isUpdate == 1" size="small"
                placeholder="请选择" style="width: 100%">
                <el-option v-for="item in i.tableColumnsDetails" :key="item.codeStr" :label="item.name"
                  :value="item.codeStr">
                </el-option>
              </el-select>
            </template>
            <template v-if="i.type == 'DropDownListStr'">
              <el-select v-model="header[i.columnName]" v-if="i.isCreate" v-bind:disabled="i.isUpdate == 1" size="small"
                placeholder="请选择" style="width: 100%">
                <el-option v-for="item in i.tableColumnsDetails" :key="item.codeStr" :label="item.name"
                  :value="item.codeStr">
                </el-option>
              </el-select>
            </template>
            <template v-if="i.type == 'DropDownListStrRemote'">
              <select-tool  :key="refurbish" :apiurl=i.associated :column=i.columnName :columndata="header[i.columnName]"
                :relationColumn=i.relationColumn @getChildrenVal="getChildrenVal" style="width: 100%;" size="small">
              </select-tool>
            </template>
            <template v-if="i.type == 'DatePicker'">
              <el-date-picker v-model="header[i.columnName]" v-if="i.isCreate" v-bind:disabled="i.isUpdate == 1"
                size="small" type="date" placeholder="选择日期" style="width: 100%">
              </el-date-picker>
            </template>
            <template v-if="i.type == 'DateTimePicker'" span="12">
              <el-date-picker v-model="header[i.columnName]" v-if="i.isCreate" v-bind:disabled="i.isUpdate == 1"
                size="small" type="datetime" start-placeholder="选择日期时间" style="width: 100%">
              </el-date-picker>
            </template>
          </FormItem>
          </Col>
        </Row>
      </Form>

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
import Header from "../../store/entities/area";
import TableColumns from "@/store/entities/tableColumns";
import selectTool from "../Tool/select-tool.vue";
@Component({
  components: { selectTool },
})
export default class areaEdit extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  tableColumnHeader: TableColumns = new TableColumns();
  tableColumnHeaders: Array<TableColumns> = new Array<TableColumns>();
  tableColumnDetail: TableColumns = new TableColumns();
  tableColumnDetails: Array<TableColumns> = new Array<TableColumns>();
  header: Header = new Header();
  headers: Array<Header> = new Array<Header>();
  headerRule = {};
  detailRule = {};
  refurbish:number;
  created() {
    this.gettableColumn();
  }

  gettableColumn() {
    this.tableColumnHeader.tableName = "WMS_Area";
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

  }
  //动态拉下列表子组件回传
  getChildrenVal(column, label, relationColumn, value) {
     if (label != undefined) {
      this.header[column] = label;
      this.header[relationColumn] = value;
    }
  }
  get() {
    this.$store
      .dispatch({
        type: "area/get",
        data: this.header,
      })
      .then((res) => {
        this.header = res;
        console.log("this.timer=2;")
        //给自定义组件重新赋值Key 让子组件重新加载
        this.refurbish=Math.ceil(Math.random()*1000);;
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
        this.$store.state.area.editArea
      );
      this.get();
    }
  }
  cancel() {
    (this.$refs.editHeader as any).resetFields();
    this.$emit("input", false);
  }
  save() {
    this.$store.dispatch({
      type: "area/update",
      data: {
        WMS_Area: this.header,
      },
    });
    this.$emit("save-success");
    this.$emit("input", false);
  }

}
</script>
 