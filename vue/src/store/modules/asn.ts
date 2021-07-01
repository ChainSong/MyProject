import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import asn from '../entities/asn'
import Ajax from '../../lib/ajax' 
import PageResult from '@/store/entities/page-result';

interface ASNState extends ListState<asn>{
    editASN:asn;
    queryASN:asn;
    permissions:Array<string>
}
class ASNModule extends ListModule<ASNState,any,asn>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<asn>(),
        map: new Array<asn>(),
        loading:false,
        editASN:new asn(),
        queryASN:new asn(),
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
        async create(context:ActionContext<ASNState,any>,payload:any){
            // console.log("dasdasd");
            // console.log(payload.data);
            await Ajax.post('/api/services/app/WMS_ASN/CreateOrUpdate',payload.data);
        },
        async update(context:ActionContext<ASNState,any>,payload:any){
            // console.log("dasdasd");
            // console.log(payload.data);
            await Ajax.post('/api/services/app/WMS_ASN/CreateOrUpdate',payload.data);
        },
        async delete(context:ActionContext<ASNState,any>,payload:any){
            await Ajax.delete('/api/services/app/WMS_ASN/Delete?Id='+payload.data.id);
        },
        // async update(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.put('/api/services/app/Role/Update',payload.data);
        // },
        // async delete(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.delete('/api/services/app/Role/Delete?Id='+payload.data.id);
        // },
        async get(context:ActionContext<asn,any>,payload:any){
            //let reponse=await Ajax.get('/api/services/app/ASN/GetById?Id='+payload.data.id);
            let reponse=await Ajax.get('/api/services/app/WMS_ASN/GetById?Id='+payload.data.id);
            return reponse.data.result as asn;
        },
        // async getAllPermissions(context:ActionContext<RoleState,any>){
        //     let reponse=await Ajax.get('/api/services/app/Role/getAllPermissions');
        //     context.state.permissions=reponse.data.result.items;
        // },

        async GetPaged(context:ActionContext<ASNState,any>,payload:any){
           
            let reponse= await Ajax.post('/api/services/app/WMS_ASN/GetPaged',payload.data);
            context.state.loading=false;
            let page=reponse.data.result as PageResult<asn>;
            context.state.totalCount=page.totalCount;
            // console.log("context.state.list");
            context.state.list=page.items;
            // console.log(context.state.list);
            // console.log(reponse.data.result.items)
            // let page=reponse.data.result.items as Array<ASNInfo>;
            // context.state.list=page;
            // console.log(context.state.list);
            // return reponse.data.result  as Array<TableColumns>;
        }
    };
    mutations={
        setCurrentPage(state:ASNState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:ASNState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:ASNState, ASNState:asn){
            state.editASN=ASNState;
        },
        query(state:ASNState, ASNState:asn){
            state.queryASN=ASNState;
        }
    }
}
const asnModule=new ASNModule();
export default asnModule;