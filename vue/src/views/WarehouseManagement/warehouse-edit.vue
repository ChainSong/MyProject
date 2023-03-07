<template>
  <div>
    <Modal title="编辑仓库" :value="value" width="50" @on-visible-change="visibleChange">
      <Form ref="editHeader" label-position="top" :rules="headerRule">
        <Row>
          <Col v-for="i in tableColumnHeaders" v-bind:key="i.id" span="12">
          <FormItem :label="i.displayName" v-if="i.isCreate" style="width: 90%;height: 45px;">
            <template v-if="i.type == 'TextBox'">
              <el-input placeholder="请输入内容" v-model="header[i.columnName]" v-if="i.isCreate" size="small"
                v-bind:disabled="i.isUpdate == 0">
              </el-input>
            </template>
            <template v-if="i.type == 'DropDownListInt'">
              <el-select v-model="header[i.columnName]" v-if="i.isCreate" v-bind:disabled="i.isUpdate == 1" size="small"
                placeholder="请选择" style="width: 100%">
                <el-option v-for="item in i.tableColumnsDetails" :key="item.codeInt" :label="item.name"
                  :value="item.codeInt">
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
               <!-- <template v-if="i.type == 'DropDownListStr'">
              <el-select v-model="header[i.columnName]" v-if="i.isCreate" v-bind:disabled="i.isUpdate == 1" size="small"
                placeholder="请选择" style="width: 100%">
                <el-option v-for="item in  aaaaaaa('xxxxxx/api/xxxxlist')" :key="item.codeStr" :label="item.name"
                  :value="item.codeStr">
                </el-option>
              </el-select>
            </template> -->
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
import Header from "../../store/entities/warehouse";
import TableColumns from "@/store/entities/tableColumns";
@Component
export default class warehouseEdit extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  tableColumnHeader: TableColumns = new TableColumns();
  tableColumnHeaders: Array<TableColumns> = new Array<TableColumns>();
  tableColumnDetail: TableColumns = new TableColumns();
  tableColumnDetails: Array<TableColumns> = new Array<TableColumns>();
  header: Header = new Header();
  headers: Array<Header> = new Array<Header>();
  headerRule = {};
  detailRule = {};
  created() {
    this.gettableColumn();
  }
//    id = 0;
// data() {
//   const _this=this;
//       return {
//         props: {
//           lazy: true,
//           lazyLoad (node, resolve) {
//             const { level } = node;
//             setTimeout(() => {
//               const nodes = Array.from({ length: level + 1 })
//                 .map(item => ({
//                   value: ++_this.id,
//                   label: `选项${_this.id}`,
//                   leaf: level >= 2
//                 }));
//               // 通过调用resolve将子节点数据返回，通知组件数据加载完成
//               resolve(nodes);
//             }, 1000);
//           }
//         }
//       };
//     }
//  aaaaaaa( ){
//    this.tableColumnHeader.tableName = "WMS_Warehouse";
//     this.$store
//       .dispatch({
//         type: "tableColumns/GetByTableNameList",
//         data: this.tableColumnHeader,
//       })
//       .then((res) => {

//         return    this.tableColumnHeaders = JSON.parse(
//           localStorage.getItem(this.tableColumnHeader.tableName)
//         ) as Array<TableColumns>;
        
//       })
//       .catch((err) => {
//         console.log(err);
//       }); 
  
        
//  }

  gettableColumn() {
    this.tableColumnHeader.tableName = "WMS_Warehouse";
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

  get() {
    this.$store
      .dispatch({
        type: "warehouse/get",
        data: this.header,
      })
      .then((res) => {
        this.header = res;
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
        this.$store.state.warehouse.editWarehouse
      );
      this.get();
    }
  }
  cancel() {
    (this.$refs.editHeader as any).resetFields();
    // (this.$refs.editDetail as any).resetFields();
    this.$emit("input", false);
  }
  save() {
    this.$store.dispatch({
      type: "warehouse/update",
      data: {
        WMS_Warehouse: this.header,
      },
    });
    this.$emit("save-success");
    this.$emit("input", false);
  }

}
</script>
 