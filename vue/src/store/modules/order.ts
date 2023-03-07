import { Store, Module, ActionContext } from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import order from '../entities/order'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';

interface OrderState extends ListState<order> {
    editOrder: order;
    queryOrder: order;
    permissions: Array<string>
}
class OrderModule extends ListModule<OrderState, any, order>{
    state = {
        totalCount: 0,
        currentPage: 1,
        pageSize: 10,
        list: new Array<order>(),
        map: new Array<order>(),
        loading: false,
        editOrder: new order(),
        queryOrder: new order(),
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
        async create(context: ActionContext<OrderState, any>, payload: any) {
            await Ajax.post('/api/services/app/WMS_Order/CreateOrUpdate', payload.data);
        },
        async update(context: ActionContext<OrderState, any>, payload: any) {
            return await Ajax.post('/api/services/app/WMS_Order/CreateOrUpdate', payload.data);
        },
        async delete(context: ActionContext<OrderState, any>, payload: any) {
            await Ajax.get('/api/services/app/WMS_Order/Delete?Id=' + payload.data.id);
        },
        async get(context: ActionContext<order, any>, payload: any) {
            let reponse = await Ajax.get('/api/services/app/WMS_Order/GetById?Id=' + payload.data.id);
            return reponse.data.result as order;
        },
        async importExcel(context: ActionContext<order, any>, payload: any) {
            let reponse = await Ajax.post('/api/services/app/WMS_Order/ImportExcel=' + payload.data);
            return reponse.data.result as order;
        },

        async batchAutomatedOutbound(context: ActionContext<order, any>, payload: any) {
            return await Ajax.post('/api/services/app/WMS_Order/BatchAutomatedAllocation', payload.data);
        },
        async GetPaged(context: ActionContext<OrderState, any>, payload: any) {

            let reponse = await Ajax.post('/api/services/app/WMS_Order/GetPaged', payload.data);
            context.state.loading = false;
            let page = reponse.data.result as PageResult<order>;
            context.state.totalCount = page.totalCount;
            context.state.list = page.items;
        }
    };
    mutations = {
        setCurrentPage(state: OrderState, page: number) {
            state.currentPage = page;
        },
        setPageSize(state: OrderState, pagesize: number) {
            state.pageSize = pagesize;
        },
        edit(state: OrderState, OrderState: order) {
            state.editOrder = OrderState;
        },
        query(state: OrderState, OrderState: order) {
            state.queryOrder = OrderState;
        }
    }
}
const preorderModule = new OrderModule();
export default preorderModule;