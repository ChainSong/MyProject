import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import warehouse from '../entities/warehouse'
import Ajax from '../../lib/ajax' 
import PageResult from '@/store/entities/page-result';

interface WarehouseState extends ListState<warehouse>{
    editWarehouse:warehouse;
    queryWarehouse:warehouse;
    permissions:Array<string>
}
class WarehouseModule extends ListModule<WarehouseState,any,warehouse>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<warehouse>(),
        map: new Array<warehouse>(),
        loading:false,
        editWarehouse:new warehouse(),
        queryWarehouse:new warehouse(),
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
        async create(context:ActionContext<WarehouseState,any>,payload:any){
            console.log("dasdasd");
            console.log(payload.data);
            await Ajax.post('/api/services/app/WMS_Warehouse/CreateOrUpdate',payload.data);
        },
        async update(context:ActionContext<WarehouseState,any>,payload:any){
            // console.log("dasdasd");
            // console.log(payload.data);
            await Ajax.post('/api/services/app/WMS_Warehouse/CreateOrUpdate',payload.data);
        },
        async delete(context:ActionContext<WarehouseState,any>,payload:any){
            await Ajax.delete('/api/services/app/WMS_Warehouse/Delete?Id='+payload.data.id);
        },
        // async update(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.put('/api/services/app/Role/Update',payload.data);
        // },
        // async delete(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.delete('/api/services/app/Role/Delete?Id='+payload.data.id);
        // },
        async get(context:ActionContext<warehouse,any>,payload:any){
            console.log(payload.data)
            //let reponse=await Ajax.get('/api/services/app/Warehouse/GetById?Id='+payload.data.id);
            let reponse=await Ajax.get('/api/services/app/WMS_Warehouse/GetById?Id='+payload.data.id);
            return reponse.data.result as warehouse;
        },
        // async getAllPermissions(context:ActionContext<RoleState,any>){
        //     let reponse=await Ajax.get('/api/services/app/Role/getAllPermissions');
        //     context.state.permissions=reponse.data.result.items;
        // },

        async GetPaged(context:ActionContext<WarehouseState,any>,payload:any){
            console.log("开始请求");
            console.log(JSON.stringify(payload.data));
            let reponse= await Ajax.post('/api/services/app/WMS_Warehouse/GetPaged',payload.data);
            context.state.loading=false;
            let page=reponse.data.result as PageResult<warehouse>;
            console.log(page);
            context.state.totalCount=page.totalCount;
            context.state.list=page.items as Array<warehouse>;
            // return reponse.data.result  as Array<TableColumns>;
        }
    };
    mutations={
        setCurrentPage(state:WarehouseState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:WarehouseState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:WarehouseState, WarehouseState:warehouse){
            state.editWarehouse=WarehouseState;
        },
        query(state:WarehouseState, WarehouseState:warehouse){
            state.queryWarehouse=WarehouseState;
        }
    }
}
const warehouseModule=new WarehouseModule();
export default warehouseModule;