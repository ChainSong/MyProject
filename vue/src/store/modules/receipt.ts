import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import receipt from '../entities/receipt'
import Ajax from '../../lib/ajax' 
import PageResult from '@/store/entities/page-result';

interface ReceiptState extends ListState<receipt>{
    editReceipt:receipt;
    queryReceipt:receipt;
    permissions:Array<string>
}
class ReceiptModule extends ListModule<ReceiptState,any,receipt>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<receipt>(),
        map: new Array<receipt>(),
        loading:false,
        editReceipt:new receipt(),
        queryReceipt:new receipt(),
        permissions:new Array<string>(),
    }
    actions={
        // async getAll(context:ActionContext<TableColumnsState,any>,payload:any){
        //     context.state.loading=true;
        //     let reponse=await Ajax.get('/api/services/app/Role/GetAll',{params:payload.data});
        //     context.state.loading=false;
        //     let page=reponse.data.result as PageResult<Role>;
        //     context.state.totalCount=page.totalCount;
        //     context.state.list=page.items;
        // },
        async create(context:ActionContext<ReceiptState,any>,payload:any){
            // console.log("dasdasd");
            // console.log(payload.data);
            await Ajax.post('/api/services/app/WMS_Receipt/CreateOrUpdate',payload.data);
        },
        async update(context:ActionContext<ReceiptState,any>,payload:any){
            // console.log("dasdasd");
            // console.log(payload.data);
            await Ajax.post('/api/services/app/WMS_Receipt/CreateOrUpdate',payload.data);
        },
        async delete(context:ActionContext<ReceiptState,any>,payload:any){
            await Ajax.delete('/api/services/app/WMS_Receipt/Delete?Id='+payload.data.id);
        },
        // async update(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.put('/api/services/app/Role/Update',payload.data);
        // },
        // async delete(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.delete('/api/services/app/Role/Delete?Id='+payload.data.id);
        // },
        async get(context:ActionContext<receipt,any>,payload:any){
            //let reponse=await Ajax.get('/api/services/app/Receipt/GetById?Id='+payload.data.id);
            let reponse=await Ajax.get('/api/services/app/WMS_Receipt/GetById?Id='+payload.data.id);
            return reponse.data.result as receipt;
        },
        // async getAllPermissions(context:ActionContext<RoleState,any>){
        //     let reponse=await Ajax.get('/api/services/app/Role/getAllPermissions');
        //     context.state.permissions=reponse.data.result.items;
        // },

        async GetPaged(context:ActionContext<ReceiptState,any>,payload:any){
           
            let reponse= await Ajax.post('/api/services/app/WMS_Receipt/GetPaged',payload.data);
            context.state.loading=false;
            let page=reponse.data.result as PageResult<receipt>;
            context.state.totalCount=page.totalCount;
            // console.log("context.state.list");
            context.state.list=page.items;
            // console.log(context.state.list);
            // console.log(reponse.data.result.items)
            // let page=reponse.data.result.items as Array<ReceiptInfo>;
            // context.state.list=page;
            // console.log(context.state.list);
            // return reponse.data.result  as Array<TableColumns>;
        }
    };
    mutations={
        setCurrentPage(state:ReceiptState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:ReceiptState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:ReceiptState, ReceiptState:receipt){
            state.editReceipt=ReceiptState;
        },
        query(state:ReceiptState, ReceiptState:receipt){
            state.queryReceipt=ReceiptState;
        }
    }
}
const receiptModule=new ReceiptModule();
export default receiptModule;