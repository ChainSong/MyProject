import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import WarehouseUserMapping from '../entities/warehouseUserMapping'
import Ajax from '../../lib/ajax' 
import PageResult from '@/store/entities/page-result';

interface WarehouseUserMappingState extends ListState<WarehouseUserMapping>{
    editWarehouseUserMapping:WarehouseUserMapping;
    queryWarehouseUserMapping:WarehouseUserMapping;
    permissions:Array<string>
}
class WarehouseUserMappingModule extends ListModule<WarehouseUserMappingState,any,WarehouseUserMapping>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<WarehouseUserMapping>(),
        map: new Array<WarehouseUserMapping>(),
        loading:false,
        editWarehouseUserMapping:new WarehouseUserMapping(),
        queryWarehouseUserMapping:new WarehouseUserMapping(),
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
        async create(context:ActionContext<WarehouseUserMappingState,any>,payload:any){
            // console.log("dasdasd");
            // console.log(payload.data);
            console.log( JSON.stringify(payload.data))
            await Ajax.post('/api/services/app/WarehouseUserMapping/CreateOrUpdate',payload.data);
        },
        async update(context:ActionContext<WarehouseUserMappingState,any>,payload:any){
            await Ajax.post('/api/services/app/WarehouseUserMapping/CreateOrUpdate',payload.data);
        },
        async delete(context:ActionContext<WarehouseUserMappingState,any>,payload:any){
            await Ajax.delete('/api/services/app/WarehouseUserMapping/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<WarehouseUserMapping,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/WarehouseUserMapping/GetById?Id='+payload.data.id);
            return reponse.data.result as WarehouseUserMapping;
        },
        async getMapping(context:ActionContext<WarehouseUserMapping,any>,payload:any){
            let reponse=await Ajax.post('/api/services/app/WarehouseUserMapping/GetMapping',payload.data);
            return reponse.data.result as WarehouseUserMapping;
        },
        async GetPaged(context:ActionContext<WarehouseUserMappingState,any>,payload:any){
            let reponse= await Ajax.post('/api/services/app/WarehouseUserMapping/GetPaged',payload.data);
            context.state.loading=false;
            let page=reponse.data.result as PageResult<WarehouseUserMapping>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items; 
        }
    };
    mutations={
        setCurrentPage(state:WarehouseUserMappingState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:WarehouseUserMappingState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:WarehouseUserMappingState, warehouseUserMappingState:WarehouseUserMapping){
            state.editWarehouseUserMapping=warehouseUserMappingState;
        },
        query(state:WarehouseUserMappingState, warehouseUserMappingState:WarehouseUserMapping){
            state.queryWarehouseUserMapping=warehouseUserMappingState;
        }
    }
}
const warehouseUserMappingModule=new WarehouseUserMappingModule();
export default warehouseUserMappingModule;