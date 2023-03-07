import { Store, Module, ActionContext } from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import preorder from '../entities/preorder'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';

interface PreOrderState extends ListState<preorder> {
    editPreOrder: preorder;
    queryPreOrder: preorder;
    permissions: Array<string>
}
class PreOrderModule extends ListModule<PreOrderState, any, preorder>{
    state = {
        totalCount: 0,
        currentPage: 1,
        pageSize: 10,
        list: new Array<preorder>(),
        map: new Array<preorder>(),
        loading: false,
        editPreOrder: new preorder(),
        queryPreOrder: new preorder(),
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
        async create(context: ActionContext<PreOrderState, any>, payload: any) {
            await Ajax.post('/api/services/app/WMS_PreOrder/CreateOrUpdate', payload.data);
        },
        async update(context: ActionContext<PreOrderState, any>, payload: any) {
            return await Ajax.post('/api/services/app/WMS_PreOrder/CreateOrUpdate', payload.data);
        },
        async delete(context: ActionContext<PreOrderState, any>, payload: any) {
            await Ajax.get('/api/services/app/WMS_PreOrder/Delete?Id=' + payload.data.id);
        },
        async get(context: ActionContext<preorder, any>, payload: any) {
            let reponse = await Ajax.get('/api/services/app/WMS_PreOrder/GetById?Id=' + payload.data.id);
            return reponse.data.result as preorder;
        },
        async importExcel(context: ActionContext<preorder, any>, payload: any) {
            // console.log("payload.data");
            // console.log(payload.data);
            
            let reponse = await Ajax.post('/api/services/app/WMS_PreOrder/ImportExcel=' + payload.data);
            return reponse.data.result as preorder;
        },
        
        async preOrderForOrder(context: ActionContext<preorder, any>, payload: any) {
            // let reponse=await Ajax.get('/api/services/app/Receipt/GetById?Id='+payload.data.id);
            return await Ajax.post('/api/services/app/WMS_PreOrder/PreOrderForOrder', payload.data);
            // return reponse.data.result as preorder;
            //  Ajax.post('/api/services/app/Table_ColumnsDetail/GetAll',payload.data);
            // Ajax.defaults.responseType = 'blob';
            // let reponse = await Ajax.post('/api/services/app/WMS_Receipt/ExportReceipt', payload.data);
            

        },
        async GetPaged(context: ActionContext<PreOrderState, any>, payload: any) {

            let reponse = await Ajax.post('/api/services/app/WMS_PreOrder/GetPaged', payload.data);
            context.state.loading = false;
            let page = reponse.data.result as PageResult<preorder>;
            context.state.totalCount = page.totalCount;
            // console.log("context.state.list");
            context.state.list = page.items;
            // console.log(context.state.list);
            // console.log(reponse.data.result.items)
            // let page=reponse.data.result.items as Array<PreOrderInfo>;
            // context.state.list=page;
            // console.log(context.state.list);
            // return reponse.data.result  as Array<TableColumns>;
        }
    };
    mutations = {
        setCurrentPage(state: PreOrderState, page: number) {
            state.currentPage = page;
        },
        setPageSize(state: PreOrderState, pagesize: number) {
            state.pageSize = pagesize;
        },
        edit(state: PreOrderState, PreOrderState: preorder) {
            state.editPreOrder = PreOrderState;
        },
        query(state: PreOrderState, PreOrderState: preorder) {
            state.queryPreOrder = PreOrderState;
        }
    }
}
const preorderModule = new PreOrderModule();
export default preorderModule;