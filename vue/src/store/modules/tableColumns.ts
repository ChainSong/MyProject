import { Store, Module, ActionContext } from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
// import session from '/session'
import Util from '../../lib/util';
import TableColumns from '../entities/tableColumns'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import axios from 'axios'

interface TableColumnsState extends ListState<TableColumns> {
    editTableColumns: TableColumns;
    queryTableColumns: TableColumns;
    permissions: Array<string>
}
class TableColumnsModule extends ListModule<TableColumnsState, any, TableColumns>{
    state = {
        totalCount: 0,
        currentPage: 1,
        pageSize: 10,
        list: new Array<TableColumns>(),
        map: new Array<TableColumns>(),
        loading: false,
        editTableColumns: new TableColumns(),
        queryTableColumns: new TableColumns(),
        permissions: new Array<string>()
    }
    actions = {
        async GetPaged(context: ActionContext<TableColumnsState, any>, payload: any) {
            context.state.loading = true;
            // console.log("GetPaged");
            // console.log(payload.data);
            let reponse = await Ajax.post('/api/services/app/Table_Columns/GetPaged', payload.data);
            context.state.loading = false;
            // console.log("reponse.data.result");
            // console.log(reponse.data.result);
            let page = reponse.data.result as PageResult<TableColumns>;
            context.state.totalCount = page.totalCount;
            context.state.list = page.items;
            // console.log( context.state.list);
            // console.log(page);
        },
        async GetAll(context: ActionContext<TableColumnsState, any>, payload: any) {
            //  Ajax.post('/api/services/app/Table_Columns/GetAll',payload.data);
            let reponse = await Ajax.post('/api/services/app/Table_Columns/GetAll', payload.data);
            console.log("reponse");
            console.log(reponse);
            return reponse.data.result as PageResult<TableColumns>;
        },
        async cleanCache(context: ActionContext<TableColumnsState, any>, payload: any) {
            console.log(payload.data);
            localStorage.removeItem(payload.data.tableName);
            console.log("payload.data");
            var tableColumnsStorage = localStorage.getItem(payload.data.tableName);
            console.log(tableColumnsStorage);

            await Ajax.post('/api/services/app/Table_Columns/CleanTableColumnsCache', payload.data);
        },
        async update(context: ActionContext<TableColumnsState, any>, payload: any) {
            
            localStorage.removeItem(payload.data.tableColumns[0].tableName);
            await Ajax.post('/api/services/app/Table_Columns/BatchUpdate', payload.data);
        },
        async getselect(context: ActionContext<TableColumnsState, any>, payload: any) {
            console.log("getselect payload.data");
            console.log(payload.data);
            let reponse = await Ajax.post(payload.data.apiurl, payload.data.column);
            return reponse.data;
        },
        // async delete(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.delete('/api/services/app/Role/Delete?Id='+payload.data.id);
        // },
        // async get(context:ActionContext<TableColumnsState,any>,payload:any){
        //     let reponse=await Ajax.get('/api/services/app/Role/Get?Id='+payload.id);
        //     return reponse.data.result asas PageResult<TableColumns>;
        // },
        // async getAllPermissions(context:ActionContext<RoleState,any>){
        //     let reponse=await Ajax.get('/api/services/app/Role/getAllPermissions');
        //     context.state.permissions=reponse.data.result.items;
        // },
        async GetImportExcelTemplate(context: ActionContext<TableColumnsState, any>, payload: any) {
            //  Ajax.post('/api/services/app/Table_ColumnsDetail/GetAll',payload.data);
            Ajax.defaults.responseType = 'blob';
            let reponse = await Ajax.post('/api/services/app/Table_Columns/ImportExcelTemplate', payload.data);
            let blob = new Blob([reponse.data], {
                type: 'application/vnd.ms-excel'
            })
            let fileName = "导入模板" + '.xlsx'
            // 允许用户在客户端上保存文件
            if (window.navigator.msSaveOrOpenBlob) { 
                navigator.msSaveBlob(blob, fileName)
            } else {
                var link = document.createElement('a')
                link.href = window.URL.createObjectURL(blob)
                link.download = fileName
                link.click()
                //释放内存
                window.URL.revokeObjectURL(link.href)
            }
 
            // console.log("reponse");
            // console.log(reponse);

            // reponse.data.result as PageResult<string>;
            // console.log(reponse.data);
            // // 兼容不同浏览器的URL对象
            // const windowurl = window.URL || window.webkitURL || window.moxURL;
            // var bytechars = (reponse.data);
            // var byteNumbers = new Array(bytechars.length);
            // for (var i = 0; i < bytechars.length; i++) {
            //     byteNumbers[i] = bytechars.charCodeAt(i);
            // }
            // var byteArray = new Uint8Array(byteNumbers);
            // var blob = new Blob([byteArray], {type: 'application/x-pkcs12'});
            // let url = windowurl.createObjectURL(byteArray);
            // console.log(url);
            // let link = document.createElement('a')
            // link.style.display = 'none'
            // link.href = url
            // link.setAttribute('download', '导入模板' + '.xlsx')
            // document.body.appendChild(link)
            // link.click();
        },
        async GetByTableNameList(context: ActionContext<TableColumnsState, any>, payload: any) {
            // console.log("Util.abp.session.tenant.tenantId");

            var tableColumnsStorage = localStorage.getItem(payload.data.tableName);
            console.log(payload.data);
             if (tableColumnsStorage != null && tableColumnsStorage.length > 10) {
            // if (tableColumnsStorage != null && tableColumnsStorage.length == 10) {
              if (context.state.list == null && context.state.list.length == 0) {
                    localStorage.setItem(payload.data.tableName, null);
                 }
                 context.state.list = JSON.parse(tableColumnsStorage) as Array<TableColumns>;
            } else {
                let reponse = await Ajax.post('/api/services/app/Table_Columns/GetByTableNameList', payload.data);
                let page = reponse.data.result as PageResult<TableColumns>;
                localStorage.setItem(payload.data.tableName, JSON.stringify(page.items));
                context.state.list = page.items;
            }
        },
        // GetByTableNameListAll(context: ActionContext<TableColumnsState, any>, payload: any) {
        //     // console.log(payload.data.tableName)
        //     var tableColumnsStorage =  localStorage.getItem(payload.data.tableName);
        //     // console.log(tableColumnsStorage);
        //     if (tableColumnsStorage != null && tableColumnsStorage.length > 10) {
        //         if (context.state.list == null && context.state.list.length == 0) {
        //             localStorage.setItem(payload.data.tableName, null);
        //         }
        //         context.state.list = JSON.parse(tableColumnsStorage) as Array<TableColumns>;

        //     } else {
        //         let reponse =axios.post('/api/services/app/Table_Columns/GetByTableNameList', payload.data);
        //            console.log(reponse);
        //         // let page = reponse as PageResult<TableColumns>;
        //         // localStorage.setItem(payload.data.tableName, JSON.stringify(page.items));
        //         // context.state.list = page.items;
        //     }

        // }
    };
    mutations = {
        setCurrentPage(state: TableColumnsState, page: number) {
            state.currentPage = page;
        },
        setPageSize(state: TableColumnsState, pagesize: number) {
            state.pageSize = pagesize;
        },
        query(state: TableColumnsState, tableColumnsState: TableColumns) {
            state.queryTableColumns = tableColumnsState;
        },
        edit(state: TableColumnsState, tableColumnsState: TableColumns) {
            state.editTableColumns = tableColumnsState;
        }
    }
}
const tableColumnsModule = new TableColumnsModule();
export default tableColumnsModule;