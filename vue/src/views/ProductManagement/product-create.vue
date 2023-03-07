<template>
  <div>
    <Modal title="创建产品" :value="value" width="50" @on-visible-change="visibleChange">
      <Form ref="header" label-position="top" :rules="headerRule" :model="header">
        <Row>
          <Col v-for="i in tableColumnHeaders" v-bind:key="i.id" span="12">
          <FormItem :label="i.displayName" v-if="i.isCreate" style="width: 90%" :prop="i.columnName">
            <template v-if="i.type == 'TextBox'">
              <el-input size="small" placeholder="请输入内容" v-model="header[i.columnName]" v-if="i.isCreate">
              </el-input>

            </template>
            <template v-if="i.type == 'DropDownListInt'">
              <el-select size="small" v-model="header[i.columnName]" v-if="i.isCreate" placeholder="请选择"
                style="width: 100%" filterable>
                <el-option v-for="item in i.tableColumnsDetails" :key="item.codeInt" :label="item.name"
                  :value="item.codeInt">
                </el-option>
              </el-select>
            </template>
            <template v-if="i.type == 'DropDownListStr'">
              <el-select size="small" v-model="header[i.columnName]" v-if="i.isCreate" placeholder="请选择"
                style="width: 100%" filterable>
                <el-option v-for="item in i.tableColumnsDetails" :key="item.codeStr" :label="item.name"
                  :value="item.codeStr">
                </el-option>
              </el-select>
            </template>
            <template v-if="i.type == 'DropDownListStrRemote'">
              <select-tool :objData="i" :valData="header[i.columnName]" v-if="i.isCreate"  :isDisabled="i.isUpdate"
                @getChildrenVal="getChildrenVal" style="width: 90%;" size="small"></select-tool>

              <!-- <select-tool :apiurl=i.associated :column=i.columnName :relationColumn=i.relationDBColumn
                @getChildrenVal="getChildrenVal" :obj="i" style="width: 100%;" size="small"></select-tool> -->
            </template>
            <template v-if="i.type == 'DatePicker'">
              <el-date-picker size="small" v-model="header[i.columnName]" v-if="i.isCreate" type="date"
                placeholder="选择日期" style="width: 100%">
              </el-date-picker>
            </template>
        
            <template v-if="i.type == 'DateTimePicker'" span="12">
              <el-date-picker size="small" v-model="header[i.columnName]" v-if="i.isCreate" type="datetime"
                start-placeholder="选择日期时间" style="width: 100%">
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
import Header from "../../store/entities/product";
// import Detail from "@/store/entities/productDetail";
import TableColumns from "@/store/entities/tableColumns";
import selectTool from "../Tool/select-tool.vue";
@Component({
  components: { selectTool },
})
export default class productCreate extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  tableColumnHeader: TableColumns = new TableColumns();
  tableColumnHeaders: Array<TableColumns> = new Array<TableColumns>();
  tableColumnDetail: TableColumns = new TableColumns();
  tableColumnDetails: Array<TableColumns> = new Array<TableColumns>();
  header: Header = new Header();
  // details = { line: [new Detail()] };
  headerRule = {};
  detailRule = {};
  created() {
    this.gettableColumn();
  }
  gettableColumn() {
    this.tableColumnHeader.tableName = "WMS_Product";
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
    // this.$store
    //   .dispatch({
    //     type: "tableColumns/GetByTableNameList",
    //     data: this.tableColumnDetail,
    //   })
    //   .then((res) => {
    //     this.tableColumnDetails = JSON.parse(
    //       localStorage.getItem(this.tableColumnDetail.tableName)
    //     ) as Array<TableColumns>;
    //     this.tableColumnDetails.forEach((a) => {
    //       if (a.validation.toUpperCase() == "Required".toUpperCase()) {
    //         this.detailRule[a.columnName] = [
    //           {
    //             required: true,
    //             message: this.L("FieldIsRequired", undefined, a.displayName),
    //             trigger: "blur",
    //           },
    //         ];
    //       }
    //     });
    //   })
    //   .catch((err) => {
    //     console.log(err);
    //   });

    // this.$store
    //   .dispatch({
    //     type: "tableColumns/GetByTableNameList",
    //     data: this.tableColumnDetail,
    //   })
    //   .then((res) => {
    //     this.tableColumnDetails = JSON.parse(
    //       localStorage.getItem(this.tableColumnDetail.tableName)
    //     ) as Array<TableColumns>;
    //     this.tableColumnDetails.forEach((a) => {
    //       if (a.validation == "Required")
    //         this.detailRule[a.columnName] = [
    //           {
    //             required: true,
    //             message: this.L("FieldIsRequired", undefined, a.displayName),
    //             trigger: "blur",
    //           },
    //         ];
    //     });
    //   })
    //   .catch((err) => {
    //     console.log(err);
    //   });
  }

  //动态拉下列表子组件回传
  getChildrenVal(column, label, relationColumn, value, row) {
    // console.log("relationColumn")
    // console.log(relationColumn)
    // console.log(label)
    if (label != undefined) {
      if (row < 0) {
        if (column != "" || column != undefined) {
          this.header[column] = label;
        }
        if (relationColumn != "" || relationColumn != undefined) {
          this.header[relationColumn] = value;
        }
      } 
      this.$forceUpdate();

    }
  }
  visibleChange(value: boolean) {
    if (!value) {
      this.$emit("input", value);
    }
  }
  // handleAdd() {
  //   this.details.line.push(new Detail());
  // }
  // handleDelete(index) {
  //   this.details.line.splice(index, 1);
  // }
  cancel() {
    (this.$refs.header as any).resetFields();
    this.header = new Header();
    // this.details = { line: [new Detail()] };
    this.$emit("input", false);
  }
  save() {
    (this.$refs.header as any).validate(async (valid: boolean) => {
      if (valid) {
        // (this.$refs.details as any).validate(async (valid: boolean) => {
        // if (valid) {
        await this.$store.dispatch({
          type: "product/create",
          data: {
            WMS_Product: this.header,
            // WMS_ASNDetails: this.details.line,
          },
        });
        (this.$refs.header as any).resetFields();
        // this.details = { line: [new Detail()] };
        this.$emit("save-success");
        this.$emit("input", false);
        //   }
        // });
      }
    });
    //     }
    // })
  }
}
</script>
 