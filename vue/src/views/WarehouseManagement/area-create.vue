<template>
  <div>
    <Modal title="创建库区" :value="value" width="50" @on-visible-change="visibleChange">
      <Form ref="header" label-position="top" :rules="headerRule" :model="header">
        <Row>
          <Col v-for="i in tableColumnHeaders" v-bind:key="i.id" span="11">
          <FormItem :label="i.displayName" v-if="i.isCreate" style="width: 90%" :prop="i.columnName">
            <template v-if="i.type == 'TextBox'">
              <el-input placeholder="请输入内容" v-model="header[i.columnName]" v-if="i.isCreate" size="small">
              </el-input>

            </template>
            <template v-if="i.type == 'DropDownListInt'">
              <el-select v-model="header[i.columnName]" v-if="i.isCreate" placeholder="请选择" style="width: 100%"
                size="small" filterable>
                <el-option v-for="item in i.tableColumnsDetails" :key="item.codeInt" :label="item.name"
                  :value="item.codeInt">
                </el-option>
              </el-select>
            </template>
            <template v-if="i.type == 'DropDownListStr'">
              <el-select v-model="header[i.columnName]" v-if="i.isCreate" placeholder="请选择" style="width: 100%"
                size="small" filterable>
                <el-option v-for="item in i.tableColumnsDetails" :key="item.codeStr" :label="item.name"
                  :value="item.codeStr" size="small">
                </el-option>
              </el-select>
            </template>
            <template v-if="i.type == 'DropDownListStrRemote'">
              <select-tool @getChildrenVal="getChildrenVal" :objData="i"  :isDisabled="i.isCreate" style="width: 100%;" size="small">
                    </select-tool>
              <!-- <select-tool :apiurl=i.associated :column=i.columnName :relationColumn=i.relationColumn
                @getChildrenVal="getChildrenVal" 
                style="width: 100%;" size="small"></select-tool> -->
            </template>
            <template v-if="i.type == 'DatePicker'">
              <el-date-picker v-model="header[i.columnName]" v-if="i.isCreate" type="date" placeholder="选择日期"
                style="width: 100%" size="small">
              </el-date-picker>
            </template>
            <template v-if="i.type == 'DateTimePicker'" span="12">
              <el-date-picker v-model="header[i.columnName]" v-if="i.isCreate" type="datetime"
                start-placeholder="选择日期时间" style="width: 100%" size="small">
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
import selectTool from "../Tool/select-tool.vue";
import TableColumns from "@/store/entities/tableColumns";
@Component({
  components: { selectTool },
})
export default class areaCreate extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  tableColumnHeader: TableColumns = new TableColumns();
  tableColumnHeaders: Array<TableColumns> = new Array<TableColumns>();
  tableColumnDetail: TableColumns = new TableColumns();
  tableColumnDetails: Array<TableColumns> = new Array<TableColumns>();
  header: Header = new Header();
  headerRule = {};
  detailRule = {};
  created() {
    this.gettableColumn();
  }
  //获取表头字段信息
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
        console.log(this.headerRule);
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
  //动态拉下列表子组件回传
  getChildrenVal(column, label, relationColumn, value) {
     if (label != undefined) {
      this.header[column] = label;
      this.header[relationColumn] = value;
    }
  
  }
  cancel() {
    (this.$refs.header as any).resetFields();
    this.header = new Header();
    this.$emit("input", false);
  }
  save() {

    (this.$refs.header as any).validate(async (valid: boolean) => {
      if (valid) {
        await this.$store.dispatch({
          type: "area/create",
          data: {
            WMS_Area: this.header,
          },
        });
        (this.$refs.header as any).resetFields();
        this.$emit("save-success");
        this.$emit("input", false);
      }
    });
  }
}
</script>
 