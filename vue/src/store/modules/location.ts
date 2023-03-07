import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import location from '../entities/location'
import Ajax from '../../lib/ajax' 
import PageResult from '@/store/entities/page-result';

interface LocationState extends ListState<location>{
    editLocation:location;
    queryLocation:location;
    permissions:Array<string>
}
class LocationModule extends ListModule<LocationState,any,location>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<location>(),
        map: new Array<location>(),
        loading:false,
        editLocation:new location(),
        queryLocation:new location(),
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
        async create(context:ActionContext<LocationState,any>,payload:any){
            console.log("dasdasd");
            console.log(payload.data);
            await Ajax.post('/api/services/app/WMS_Location/CreateOrUpdate',payload.data);
        },
        async update(context:ActionContext<LocationState,any>,payload:any){
            // console.log("dasdasd");
            // console.log(payload.data);
            await Ajax.post('/api/services/app/WMS_Location/CreateOrUpdate',payload.data);
        },
        async delete(context:ActionContext<LocationState,any>,payload:any){
            await Ajax.get('/api/services/app/WMS_Location/Delete?Id='+payload.data.id);
        },
        // async update(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.put('/api/services/app/Role/Update',payload.data);
        // },
        // async delete(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.delete('/api/services/app/Role/Delete?Id='+payload.data.id);
        // },
        async get(context:ActionContext<location,any>,payload:any){
            console.log(payload.data)
            //let reponse=await Ajax.get('/api/services/app/Location/GetById?Id='+payload.data.id);
            let reponse=await Ajax.get('/api/services/app/WMS_Location/GetById?Id='+payload.data.id);
            return reponse.data.result as location;
        },
        // async getAllPermissions(context:ActionContext<RoleState,any>){
        //     let reponse=await Ajax.get('/api/services/app/Role/getAllPermissions');
        //     context.state.permissions=reponse.data.result.items;
        // },

        async GetPaged(context:ActionContext<LocationState,any>,payload:any){
            console.log("开始请求");
            console.log(JSON.stringify(payload.data));
            let reponse= await Ajax.post('/api/services/app/WMS_Location/GetPaged',payload.data);
            context.state.loading=false;
            let page=reponse.data.result as PageResult<location>;
            console.log(page);
            context.state.totalCount=page.totalCount;
            context.state.list=page.items as Array<location>;
            // return reponse.data.result  as Array<TableColumns>;
        }
    };
    mutations={
        setCurrentPage(state:LocationState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:LocationState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:LocationState, LocationState:location){
            state.editLocation=LocationState;
        },
        query(state:LocationState, LocationState:location){
            state.queryLocation=LocationState;
        }
    }
}
const locationModule=new LocationModule();
export default locationModule;