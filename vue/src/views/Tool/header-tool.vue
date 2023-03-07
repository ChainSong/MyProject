<template  >
    <Form ref="header" label-position="top" :rules="headerRule" :model="header">
        <Row>
            <Col v-for="i in tableColumnHeaders" v-bind:key="i.id" span="6">
            <FormItem :label="i.displayName" v-if="i.isCreate" style="width: 90%" :prop="i.dbColumnName">
                <template v-if="i.type == 'TextBox'">
                    <el-input placeholder="请输入内容" v-model="header[i.dbColumnName]" size="small" v-if="i.isCreate">
                    </el-input>
                </template>
                <template v-if="i.type == 'DropDownListInt'">
                    <el-select v-model="header[i.dbColumnName]" font-family="Helvetica Neue" v-if="i.isCreate"
                        style="width: 90%" size="small" placeholder="请选择" filterable>
                        <el-option v-for="item in i.tableColumnsDetails" :key="item.codeInt" :label="item.name"
                            :value="item.codeInt">
                        </el-option>
                    </el-select>
                </template>
                <template v-if="i.type == 'DropDownListStr'">
                    <el-select v-model="header[i.dbColumnName]" font-family="Helvetica Neue" v-if="i.isCreate"
                        size="small" style="width: 90%" placeholder="请选择" filterable>
                        <el-option v-for="item in i.tableColumnsDetails" :key="item.codeStr" :label="item.name"
                            :value="item.codeStr">
                        </el-option>
                    </el-select>
                </template>
                <template v-if="i.type == 'DropDownListStrRemote'">
                    <select-tool :apiurl=i.associated :column=i.columnName :relationColumn=i.relationColumn
                        @getChildrenVal="getChildrenVal" style="width: 100%;" size="small"></select-tool>
                </template>
                <template v-if="i.type == 'DatePicker'">
                    <el-date-picker v-model="header[i.dbColumnName]" v-if="i.isCreate" size="small" type="date"
                        placeholder="选择日期" style="width: 90%">
                    </el-date-picker>
                </template>

                <template v-if="i.type == 'DateTimePicker'" span="12">
                    <el-date-picker v-model="header[i.dbColumnName]" v-if="i.isCreate" size="small" type="datetime"
                        start-placeholder="选择日期时间" style="width: 90%">
                    </el-date-picker>
                </template>
            </FormItem>
            </Col>
        </Row>
    </Form>

</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../lib/util";
import AbpBase from "../../lib/abpbase";
import TableColumns from "../../store/entities/tableColumns";
import Header from "../../store/entities/asn";
import Detail from "@/store/entities/asnDetail";
import selectTool from "./select-tool.vue";
@Component({
    components: { selectTool },
})
export default class selecttool extends AbpBase {
    @Prop({ type: String, default: "" }) tableName: String;
    tableColumnHeader: TableColumns = new TableColumns();
    tableColumnHeaders: Array<TableColumns> = new Array<TableColumns>();
    tableColumnDetail: TableColumns = new TableColumns();
    tableColumnDetails: Array<TableColumns> = new Array<TableColumns>();
    header: Header = new Header();
    details = { line: [new Detail()] };
    headerRule = {};
    detailRule = {};

    //动态拉下列表子组件回传
    getChildrenVal(column, label, relationColumn, value) {
        if (label != undefined) {
            this.header[column] = label;
            this.header[relationColumn] = value;
        }
    }
    gettableColumn() {
        this.tableColumnHeader.tableName = this.tableName as string;
        // this.tableColumnDetail.tableName = "WMS_ASNDetail";
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
                        this.headerRule[a.dbColumnName] = [
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
        //         this.detailRule[a.dbColumnName] = [
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
    }
    created() {
        this.gettableColumn(); 
    }
}
</script>
 