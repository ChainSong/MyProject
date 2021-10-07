<template>
  <div>
    <Modal
      :title="L('asnEdit')"
      :value="value"
      width="80"
      @on-visible-change="visibleChange"
    >
      <Form ref="editHeader" label-position="top" :rules="rule">
        <Row>
          <Col v-for="i in tableColumnHeaders" v-bind:key="i.id" span="6">
            <FormItem
              :label="i.displayName"
              v-if="i.isCreate"
              style="width: 100%"
            >
              <template v-if="i.type == 'TextBox'">
                <el-input
                  placeholder="请输入内容"
                  v-model="header[i.dbColumnName]"
                  v-if="i.isCreate"
                  v-bind:disabled="i.isUpdate==1"
                >
                </el-input>
                <!-- <Input
                    v-model="asn[i.dbColumnName]"
                    v-if="i.isSearchCondition"
                  >
                  </Input> -->
              </template>
              <template v-if="i.type == 'DropDownList'">
                <el-select
                  v-model="header[i.dbColumnName]"
                  v-if="i.isCreate"
                  v-bind:disabled="i.isUpdate==1"
                  placeholder="请选择"
                  style="width: 100%"
                >
                  <el-option
                    v-for="item in i.table_ColumnsDetails"
                    :key="item.codeN"
                    :label="item.name"
                    :value="item.codeN"
                  >
                  </el-option>
                </el-select>
              </template>
              <template v-if="i.type == 'DatePicker'">
                <el-date-picker
                  v-model="header[i.dbColumnName]"
                  v-if="i.isCreate"
                  v-bind:disabled="i.isUpdate==1"
                  type="date"
                  placeholder="选择日期"
                  style="width: 100%"
                >
                </el-date-picker>
              </template>
              <template v-if="i.type == 'DateTimePicker'" span="12">
                <el-date-picker
                  v-model="header[i.dbColumnName]"
                  v-if="i.isCreate"
                  v-bind:disabled="i.isUpdate==1"
                  type="datetime"
                  start-placeholder="选择日期时间"
                  style="width: 100%"
                >
                </el-date-picker>
              </template>
              <!-- <el-input
                placeholder="请输入内容"
                v-model="header[i.dbColumnName]"
                v-if="i.isUpdate"
              >
              </el-input> -->
            </FormItem>
          </Col>
        </Row>
      </Form>
      <el-button
        @click="handleAdd"
        type="primary"
        size="large"
        class="toolbar-btn"
        >添加一条</el-button
      >
      <template>
        <el-form :model="detailDatas" ref="editDetail">
          <el-table
            :data="detailDatas.details"
            style="width: 100%"
            height="250"
          >
            <template v-for="(v, index) in tableColumnDetails">
              <el-table-column
                v-if="v.isUpdate"
                :key="index"
                :fixed="false"
                :prop="v.dbColumnName"
                :label="v.displayName"
                width="150"
              >
                <template slot-scope="scope">
                  <el-form-item
                    :key="scope.row.key"
                    :prop="'details.' + scope.$index + '.' + index"
                  >
                    <template v-if="v.type == 'TextBox'">
                      <el-input
                        placeholder="请输入内容"
                        v-model="
                          detailDatas.details[scope.$index][v.dbColumnName]
                        "
                        v-if="v.isUpdate"
                      >
                      </el-input>
                      <!-- <Input
                    v-model="asn[i.dbColumnName]"
                    v-if="i.isSearchCondition"
                  >
                  </Input> -->
                    </template>
                    <template v-if="v.type == 'DropDownList'">
                      <el-select
                        v-model="
                          detailDatas.details[scope.$index][v.dbColumnName]
                        "
                        v-if="v.isUpdate"
                        placeholder="请选择"
                        style="width: 100%"
                      >
                        <el-option
                          v-for="item in v.table_ColumnsDetails"
                          :key="item.code"
                          :label="item.name"
                          :value="item.code"
                        >
                        </el-option>
                      </el-select>
                    </template>
                    <template v-if="v.type == 'DatePicker'">
                      <el-date-picker
                        v-model="
                          detailDatas.details[scope.$index][v.dbColumnName]
                        "
                        v-if="v.isUpdate"
                        type="date"
                        placeholder="选择日期"
                        style="width: 100%"
                      >
                      </el-date-picker>
                    </template>
                    <template v-if="v.type == 'DateTimePicker'" span="12">
                      <el-date-picker
                        v-model="
                          detailDatas.details[scope.$index][v.dbColumnName]
                        "
                        v-if="v.isUpdate"
                        type="datetime"
                        start-placeholder="选择日期时间"
                        style="width: 100%"
                      >
                      </el-date-picker>
                    </template>
                  </el-form-item>
                </template>
              </el-table-column>
            </template>
            <template>
              <el-table-column>
                <template slot-scope="scope">
                  <el-button
                    size="mini"
                    type="danger"
                    @click="handleDelete(scope.$index)"
                    >Delete</el-button
                  >
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
import Header from "../../store/entities/asn";
import Detail from "../../store/entities/asnDetail";
import TableColumns from "@/store/entities/tableColumns";
@Component
export default class asnEdit extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  tableColumnHeader: TableColumns = new TableColumns();
  tableColumnHeaders: Array<TableColumns> = new Array<TableColumns>();
  tableColumnDetail: TableColumns = new TableColumns();
  tableColumnDetails: Array<TableColumns> = new Array<TableColumns>();
  header: Header = new Header();
  headers: Array<Header> = new Array<Header>();
  detail: Detail = new Detail();
  details: Array<Detail> = new Array<Detail>();
  detailDatas = { line: null, details: [new Detail()] };
  headerRule = {};
  detailRule = {};
  created() {
    this.gettableColumn();
  }

  gettableColumn() {
    this.tableColumnHeader.tableName = "asn";
    this.tableColumnDetail.tableName = "asnDetail";
    this.$store
      .dispatch({
        type: "Table_Columns/GetByTableNameList",
        data: this.tableColumnHeader,
      })
      .then((res) => {
        this.tableColumnHeaders = JSON.parse(
          localStorage.getItem(this.tableColumnHeader.tableName)
        ) as Array<TableColumns>;
        this.tableColumnHeaders.forEach((a) => {
          if (a.validation == "Required")
            this.headerRule[a.dbColumnName] = [
              {
                required: true,
                message: this.L("FieldIsRequired", undefined, a.displayName),
                trigger: "blur",
              },
            ];
        });
      })
      .catch((err) => {
        console.log(err);
      });
    this.$store
      .dispatch({
        type: "Table_Columns/GetByTableNameList",
        data: this.tableColumnDetail,
      })
      .then((res) => {
        this.tableColumnDetails = JSON.parse(
          localStorage.getItem(this.tableColumnDetail.tableName)
        ) as Array<TableColumns>;
        this.tableColumnDetails.forEach((a) => {
          if (a.validation == "Required")
            this.detailRule[a.dbColumnName] = [
              {
                required: true,
                message: this.L("FieldIsRequired", undefined, a.displayName),
                trigger: "blur",
              },
            ];
        });
      })
      .catch((err) => {
        console.log(err);
      });
  
  }
  get() {
    this.$store
      .dispatch({
        type: "asn/get",
        data: this.header,
      })
      .then((res) => {
        this.header = res;
        this.detailDatas.details = res.asnDetails;
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
        this.$store.state.asn.editasn
      );
      this.get();
    }
  }
  handleAdd() {
    this.detailDatas.details.push(new Detail());
  }
  handleDelete(index) {
    this.detailDatas.details.splice(index, 1);
  }
  cancel() {
    (this.$refs.editHeader as any).resetFields();
    (this.$refs.editDetail as any).resetFields();
    this.$emit("input", false);
  }
  save() {
    this.$store.dispatch({
      type: "asn/update",
      data: {
        asn: this.header,
        asnDetails: this.detailDatas.details,
      },
    });
    // (this.$refs.Form as any).resetFields();
    this.$emit("save-success");
    this.$emit("input", false);
    //     }
    // })
  }
  // rule = {
  //   asnCode: [
  //     {
  //       required: true,
  //       message: this.L("FieldIsRequired", undefined, this.L("asnCode")),
  //       trigger: "blur",
  //     },
  //   ],
  // };
}
</script>
 