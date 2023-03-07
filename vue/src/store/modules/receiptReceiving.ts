import { Store, Module, ActionContext } from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import receipt from '../entities/receipt'
import orderStatus from '../entities/orderStatus'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';

interface ReceiptReceivingState extends ListState<receipt> {
    editReceipt: receipt;
    queryReceipt: receipt;
    permissions: Array<string>
}
class ReceiptReceivingModule extends ListModule<ReceiptReceivingState, any, receipt>{
    state = {
        totalCount: 0,
        currentPage: 1,
        pageSize: 10,
        list: new Array<receipt>(),
        map: new Array<receipt>(),
        loading: false,
        editReceipt: new receipt(),
        queryReceipt: new receipt(),
        permissions: new Array<string>(),
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
        // async create(context: ActionContext<ReceiptReceivingState, any>, payload: any) {
        //     // console.log("dasdasd");
        //     // console.log(payload.data);
        //     await Ajax.post('/api/services/app/WMS_Receipt/CreateOrUpdate', payload.data);
        // },
        // async update(context: ActionContext<ReceiptReceivingState, any>, payload: any) {
        //     // console.log("dasdasd");
        //     // console.log(payload.data);
        //     await Ajax.post('/api/services/app/WMS_Receipt/CreateOrUpdate', payload.data);
        // },
        async delete(context: ActionContext<ReceiptReceivingState, any>, payload: any) {
            let reponse =await Ajax.post('/api/services/app/WMS_ReceiptReceiving/ReturnReceiptReceiving?input=' + payload.data.id);
            return reponse.data.result as Array<orderStatus>;
        },
        // async asnForReceipt(context: ActionContext<ReceiptReceivingState, any>, payload: any) {
        //     let reponse = await Ajax.post('/api/services/app/WMS_Receipt/ASNForReceipt', payload.data);
        //     // console.log(reponse.data);
        //     return reponse.data.result;
        // },
        // async update(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.put('/api/services/app/Role/Update',payload.data);
        // },
        // async delete(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.delete('/api/services/app/Role/Delete?Id='+payload.data.id);
        // },
        // async get(context: ActionContext<receipt, any>, payload: any) {
        //     //let reponse=await Ajax.get('/api/services/app/Receipt/GetById?Id='+payload.data.id);
        //     let reponse = await Ajax.get('/api/services/app/WMS_Receipt/GetById?Id=' + payload.data.id);
        //     return reponse.data.result as receipt;
        // },
        // async getAllPermissions(context:ActionContext<RoleState,any>){
        //     let reponse=await Ajax.get('/api/services/app/Role/getAllPermissions');
        //     context.state.permissions=reponse.data.result.items;
        // },

        // async exportReceipt(context: ActionContext<receipt, any>, payload: any) {
        //     //let reponse=await Ajax.get('/api/services/app/Receipt/GetById?Id='+payload.data.id);
        //     // let reponse=await Ajax.get('/api/services/app/WMS_Receipt/GetById?Id='+payload.data.id);
        //     // return reponse.data.result as receipt;
        //     //  Ajax.post('/api/services/app/Table_ColumnsDetail/GetAll',payload.data);
        //     Ajax.defaults.responseType = 'blob';
        //     let reponse = await Ajax.post('/api/services/app/WMS_Receipt/ExportReceipt', payload.data);
        //     let blob = new Blob([reponse.data], {
        //         type: 'application/vnd.ms-excel'
        //     })
        //     let fileName = "入库单" + '.xlsx'
        //     // 允许用户在客户端上保存文件
        //     if (window.navigator.msSaveOrOpenBlob) {
        //         navigator.msSaveBlob(blob, fileName)
        //     } else {
        //         var link = document.createElement('a')
        //         link.href = window.URL.createObjectURL(blob)
        //         link.download = fileName
        //         link.click()
        //         //释放内存
        //         window.URL.revokeObjectURL(link.href)
        //     }

        // },
        async get(context: ActionContext<receipt, any>, payload: any) {
            //let reponse=await Ajax.get('/api/services/app/Receipt/GetById?Id='+payload.data.id);
            let reponse = await Ajax.get('/api/services/app/WMS_Receipt/GetReceiptReceivingById?Id=' + payload.data.id);
            return reponse.data.result as receipt;
        },
        async addInventory(context: ActionContext<receipt, any>, payload: any) {
            //let reponse=await Ajax.get('/api/services/app/Receipt/GetById?Id='+payload.data.id);
            console.log(payload.data);
            let reponse = await Ajax.get('/api/services/app/WMS_Receipt/AddInventory?Id=' + payload.data.id);
            return reponse.data.result as receipt;
        },
        async GetPaged(context: ActionContext<ReceiptReceivingState, any>, payload: any) {

            let reponse = await Ajax.post('/api/services/app/WMS_Receipt/GetReceiptReceivingPaged', payload.data);
            context.state.loading = false;
            let page = reponse.data.result as PageResult<receipt>;
            context.state.totalCount = page.totalCount;
            // console.log("context.state.list");
            context.state.list = page.items;
            // console.log(context.state.list);
            // console.log(reponse.data.result.items)
            // let page=reponse.data.result.items as Array<ReceiptInfo>;
            // context.state.list=page;
            // console.log(context.state.list);
            // return reponse.data.result  as Array<TableColumns>;
        }
    };
    mutations = {
        setCurrentPage(state: ReceiptReceivingState, page: number) {
            state.currentPage = page;
        },
        setPageSize(state: ReceiptReceivingState, pagesize: number) {
            state.pageSize = pagesize;
        },
        edit(state: ReceiptReceivingState, ReceiptState: receipt) {
            state.editReceipt = ReceiptState;
        },
        query(state: ReceiptReceivingState, ReceiptState: receipt) {
            state.queryReceipt = ReceiptState;
        }
    }
}
const receiptModule = new ReceiptReceivingModule();
export default receiptModule;