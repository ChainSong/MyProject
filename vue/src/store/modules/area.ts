import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import area from '../entities/area'
import Ajax from '../../lib/ajax' 
import PageResult from '@/store/entities/page-result';

interface AreaState extends ListState<area>{
    editArea:area;
    queryArea:area;
    permissions:Array<string>
}
class AreaModule extends ListModule<AreaState,any,area>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<area>(),
        map: new Array<area>(),
        loading:false,
        editArea:new area(),
        queryArea:new area(),
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
        async create(context:ActionContext<AreaState,any>,payload:any){

            await Ajax.post('/api/services/app/WMS_Area/CreateOrUpdate',payload.data);
        },
        async update(context:ActionContext<AreaState,any>,payload:any){

            await Ajax.post('/api/services/app/WMS_Area/CreateOrUpdate',payload.data);
        },
        async delete(context:ActionContext<AreaState,any>,payload:any){
            await Ajax.get('/api/services/app/WMS_Area/Delete?Id='+payload.data.id);
        },
        // async update(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.put('/api/services/app/Role/Update',payload.data);
        // },
        // async delete(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.delete('/api/services/app/Role/Delete?Id='+payload.data.id);
        // },
        async get(context:ActionContext<area,any>,payload:any){
            //let reponse=await Ajax.get('/api/services/app/Area/GetById?Id='+payload.data.id);
            let reponse=await Ajax.get('/api/services/app/WMS_Area/GetById?Id='+payload.data.id);
            return reponse.data.result as area;
        },
        // async getAllPermissions(context:ActionContext<RoleState,any>){
        //     let reponse=await Ajax.get('/api/services/app/Role/getAllPermissions');
        //     context.state.permissions=reponse.data.result.items;
        // },

        async GetPaged(context:ActionContext<AreaState,any>,payload:any){
            let reponse= await Ajax.post('/api/services/app/WMS_Area/GetPaged',payload.data);
            context.state.loading=false;
            let page=reponse.data.result as PageResult<area>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items as Array<area>;
            // return reponse.data.result  as Array<TableColumns>;
        }
    };
    mutations={
        setCurrentPage(state:AreaState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:AreaState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:AreaState, AreaState:area){
            state.editArea=AreaState;
        },
        query(state:AreaState, AreaState:area){
            state.queryArea=AreaState;
        }
    }
}
const areaModule=new AreaModule();
export default areaModule;