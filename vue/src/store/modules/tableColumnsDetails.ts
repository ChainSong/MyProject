import { Store, Module, ActionContext } from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
// import session from '/session'
import Util from '../../lib/util';
import TableColumnsDetails from '../entities/tableColumnsDetails'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import axios from 'axios'

interface TableColumnsDetailsState extends ListState<TableColumnsDetails> {
    editTableColumnsDetails: TableColumnsDetails;
    queryTableColumnsDetails: TableColumnsDetails;
    permissions: Array<string>
}
class TableColumnsDetailsModule extends ListModule<TableColumnsDetailsState, any, TableColumnsDetails>{
    state = {
        totalCount: 0,
        currentPage: 1,
        pageSize: 10,
        list: new Array<TableColumnsDetails>(),
        map: new Array<TableColumnsDetails>(),
        loading: false,
        editTableColumnsDetails: new TableColumnsDetails(),
        queryTableColumnsDetails: new TableColumnsDetails(),
        permissions: new Array<string>()
    }
    actions = {
        async GetPaged(context:ActionContext<TableColumnsDetailsState,any>,payload:any){
            context.state.loading=true;
            // console.log("GetPaged");
            // console.log(payload.data);
            let reponse=await Ajax.post('/api/services/app/Table_ColumnsDetail/GetPaged',payload.data);
            context.state.loading=false;
            // console.log("reponse.data.result");
            // console.log(reponse.data.result);
            let page=reponse.data.result as PageResult<TableColumnsDetails>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
            // console.log( context.state.list);
            // console.log(page);
        },
        
        async GetAll(context:ActionContext<TableColumnsDetailsState,any>,payload:any){
            //  Ajax.post('/api/services/app/Table_ColumnsDetail/GetAll',payload.data);
            let reponse=await Ajax.post('/api/services/app/Table_ColumnsDetail/GetAll',payload.data);
            console.log("reponse");
            console.log(reponse);
            return reponse.data.result as PageResult<TableColumnsDetails>;
        },
        async cleanCache(context:ActionContext<TableColumnsDetailsState,any>,payload:any){
            console.log(payload.data);
            localStorage.removeItem(payload.data.tableName);
            console.log("payload.data");
            var tableColumnsDetailsStorage = localStorage.getItem(payload.data.tableName);
            console.log(tableColumnsDetailsStorage);

            await Ajax.post('/api/services/app/Table_ColumnsDetail/CleanTableColumnsDetailsCache',payload.data);
        },
        async update(context:ActionContext<TableColumnsDetailsState,any>,payload:any){
            console.log("xiugai");
            console.log(payload.data);
            localStorage.removeItem(payload.data.tableColumnsDetails[0].tableName);
            await Ajax.post('/api/services/app/Table_ColumnsDetail/BatchUpdate',payload.data);
        },
        async getselect(context:ActionContext<TableColumnsDetailsState,any>,payload:any){
            console.log("getselect payload.data");
            console.log(payload.data);
            let reponse =  await Ajax.post(payload.data.apiurl,payload.data);
            return reponse.data;
        },
        // async delete(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.delete('/api/services/app/Role/Delete?Id='+payload.data.id);
        // },
        // async get(context:ActionContext<TableColumnsDetailsState,any>,payload:any){
        //     let reponse=await Ajax.get('/api/services/app/Role/Get?Id='+payload.id);
        //     return reponse.data.result asas PageResult<TableColumnsDetails>;
        // },
        // async getAllPermissions(context:ActionContext<RoleState,any>){
        //     let reponse=await Ajax.get('/api/services/app/Role/getAllPermissions');
        //     context.state.permissions=reponse.data.result.items;
        // },
        async GetByTableNameList(context: ActionContext<TableColumnsDetailsState, any>, payload: any) {
            // console.log("Util.abp.session.tenant.tenantId");
            
            var tableColumnsDetailsStorage = localStorage.getItem(payload.data.tableName);
           console.log(payload.data);
           // if (tableColumnsDetailsStorage != null && tableColumnsDetailsStorage.length > 10) {
             if (tableColumnsDetailsStorage != null && tableColumnsDetailsStorage.length ==10) {
                if (context.state.list == null && context.state.list.length == 0) {
                    localStorage.setItem(payload.data.tableName, null);
                }
                context.state.list = JSON.parse(tableColumnsDetailsStorage) as Array<TableColumnsDetails>;
            } else {
                let reponse = await Ajax.post('/api/services/app/Table_ColumnsDetail/GetByTableNameList', payload.data);
                let page = reponse.data.result as PageResult<TableColumnsDetails>;
                localStorage.setItem(payload.data.tableName, JSON.stringify(page.items));
                context.state.list = page.items;
            }
        },
        // GetByTableNameListAll(context: ActionContext<TableColumnsDetailsState, any>, payload: any) {
        //     // console.log(payload.data.tableName)
        //     var tableColumnsDetailsStorage =  localStorage.getItem(payload.data.tableName);
        //     // console.log(tableColumnsDetailsStorage);
        //     if (tableColumnsDetailsStorage != null && tableColumnsDetailsStorage.length > 10) {
        //         if (context.state.list == null && context.state.list.length == 0) {
        //             localStorage.setItem(payload.data.tableName, null);
        //         }
        //         context.state.list = JSON.parse(tableColumnsDetailsStorage) as Array<TableColumnsDetails>;

        //     } else {
        //         let reponse =axios.post('/api/services/app/Table_ColumnsDetail/GetByTableNameList', payload.data);
        //            console.log(reponse);
        //         // let page = reponse as PageResult<TableColumnsDetails>;
        //         // localStorage.setItem(payload.data.tableName, JSON.stringify(page.items));
        //         // context.state.list = page.items;
        //     }

        // }
    };
    mutations = {
        setCurrentPage(state: TableColumnsDetailsState, page: number) {
            state.currentPage = page;
        },
        setPageSize(state: TableColumnsDetailsState, pagesize: number) {
            state.pageSize = pagesize;
        },
        query(state:TableColumnsDetailsState, tableColumnsDetailsState:TableColumnsDetails){
            state.queryTableColumnsDetails=tableColumnsDetailsState;
        },
        edit(state: TableColumnsDetailsState, tableColumnsDetailsState: TableColumnsDetails) {
            state.editTableColumnsDetails = tableColumnsDetailsState;
        }
    }
}
const tableColumnsDetailsModule = new TableColumnsDetailsModule();
export default tableColumnsDetailsModule;