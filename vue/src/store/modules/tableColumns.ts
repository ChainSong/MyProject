import { Store, Module, ActionContext } from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import TableColumns from '../entities/tableColumns'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import axios from 'axios'

interface TableColumnsState extends ListState<TableColumns> {
    editTableColumns: TableColumns;
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
        permissions: new Array<string>()
    }
    actions = {
        // async getAll(context:ActionContext<TableColumnsState,any>,payload:any){
        //     context.state.loading=true;
        //     let reponse=await Ajax.get('/api/services/app/Role/GetAll',{params:payload.data});
        //     context.state.loading=false;
        //     let page=reponse.data.result as PageResult<Role>;
        //     context.state.totalCount=page.totalCount;
        //     context.state.list=page.items;
        // },
        // async create(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.post('/api/services/app/Role/Create',payload.data);
        // },
        // async update(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.put('/api/services/app/Role/Update',payload.data);
        // },
        // async delete(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.delete('/api/services/app/Role/Delete?Id='+payload.data.id);
        // },
        // async get(context:ActionContext<RoleState,any>,payload:any){
        //     let reponse=await Ajax.get('/api/services/app/Role/Get?Id='+payload.id);
        //     return reponse.data.result as Role;
        // },
        // async getAllPermissions(context:ActionContext<RoleState,any>){
        //     let reponse=await Ajax.get('/api/services/app/Role/getAllPermissions');
        //     context.state.permissions=reponse.data.result.items;
        // },
        async GetByTableNameList(context: ActionContext<TableColumnsState, any>, payload: any) {
            var tableColumnsStorage = localStorage.getItem(payload.data.tableName);
           console.log(payload.data);
            // if (tableColumnsStorage != null && tableColumnsStorage.length > 10) {
            if (tableColumnsStorage != null && tableColumnsStorage.length == 10) {
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
        edit(state: TableColumnsState, tableColumnsState: TableColumns) {
            state.editTableColumns = tableColumnsState;
        }
    }
}
const tableColumnsModule = new TableColumnsModule();
export default tableColumnsModule;