import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import InventoryUsable from '../entities/inventoryUsable'
import Ajax from '../../lib/ajax' 
import PageResult from '@/store/entities/page-result';

interface InventoryUsableState extends ListState<InventoryUsable>{
    editInventoryUsable:InventoryUsable;
    queryInventoryUsable:InventoryUsable;
    permissions:Array<string>
}
class InventoryUsableModule extends ListModule<InventoryUsableState,any,InventoryUsable>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<InventoryUsable>(),
        map: new Array<InventoryUsable>(),
        loading:false,
        editInventoryUsable:new InventoryUsable(),
        queryInventoryUsable:new InventoryUsable(),
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
        async create(context:ActionContext<InventoryUsableState,any>,payload:any){
            // console.log("dasdasd");
            // console.log(payload.data);
            await Ajax.post('/api/services/app/WMS_Inventory_Usable/CreateOrUpdate',payload.data);
        },
        async update(context:ActionContext<InventoryUsableState,any>,payload:any){
            await Ajax.post('/api/services/app/WMS_Inventory_Usable/CreateOrUpdate',payload.data);
        },
        async delete(context:ActionContext<InventoryUsableState,any>,payload:any){
            console.log(payload.data);
            await Ajax.get('/api/services/app/WMS_Inventory_Usable/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<InventoryUsable,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/WMS_Inventory_Usable/GetById?Id='+payload.data.id);
            return reponse.data.result as InventoryUsable;
        },
        async getAll(context:ActionContext<InventoryUsable,any>,payload:any){
             
            let reponse=await Ajax.get('/api/services/app/WMS_Inventory_Usable/getAll');
            return reponse.data.result as InventoryUsable;
        },
        async GetPaged(context:ActionContext<InventoryUsableState,any>,payload:any){
            let reponse= await Ajax.post('/api/services/app/WMS_Inventory_Usable/GetPaged',payload.data);
            context.state.loading=false;
            let page=reponse.data.result as PageResult<InventoryUsable>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items; 
        }
    };
    mutations={
        setCurrentPage(state:InventoryUsableState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:InventoryUsableState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:InventoryUsableState, inventoryUsableState:InventoryUsable){
            state.editInventoryUsable=inventoryUsableState;
        },
        query(state:InventoryUsableState, inventoryUsableState:InventoryUsable){
            state.queryInventoryUsable=inventoryUsableState;
        }
    }
}
const inventoryUsableModule=new InventoryUsableModule();
export default inventoryUsableModule;