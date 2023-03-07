import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import CustomerUserMapping from '../entities/customerUserMapping'
import Ajax from '../../lib/ajax' 
import PageResult from '@/store/entities/page-result';

interface CustomerUserMappingState extends ListState<CustomerUserMapping>{
    editCustomerUserMapping:CustomerUserMapping;
    queryCustomerUserMapping:CustomerUserMapping;
    permissions:Array<string>
}
class CustomerUserMappingModule extends ListModule<CustomerUserMappingState,any,CustomerUserMapping>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<CustomerUserMapping>(),
        map: new Array<CustomerUserMapping>(),
        loading:false,
        editCustomerUserMapping:new CustomerUserMapping(),
        queryCustomerUserMapping:new CustomerUserMapping(),
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
        async create(context:ActionContext<CustomerUserMappingState,any>,payload:any){
            // console.log("dasdasd");
            // console.log(payload.data);
            await Ajax.post('/api/services/app/CustomerUserMapping/CreateOrUpdate',payload.data);
        },
        async update(context:ActionContext<CustomerUserMappingState,any>,payload:any){
            await Ajax.post('/api/services/app/CustomerUserMapping/CreateOrUpdate',payload.data);
        },
        async delete(context:ActionContext<CustomerUserMappingState,any>,payload:any){
            await Ajax.delete('/api/services/app/CustomerUserMapping/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<CustomerUserMapping,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/CustomerUserMapping/GetById?Id='+payload.data.id);
            return reponse.data.result as CustomerUserMapping;
        },
        async getMapping(context:ActionContext<CustomerUserMapping,any>,payload:any){
            let reponse=await Ajax.post('/api/services/app/CustomerUserMapping/GetMapping',payload.data);
            return reponse.data.result as CustomerUserMapping;
        },
        async GetPaged(context:ActionContext<CustomerUserMappingState,any>,payload:any){
            let reponse= await Ajax.post('/api/services/app/CustomerUserMapping/GetPaged',payload.data);
            context.state.loading=false;
            let page=reponse.data.result as PageResult<CustomerUserMapping>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items; 
        }
    };
    mutations={
        setCurrentPage(state:CustomerUserMappingState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:CustomerUserMappingState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:CustomerUserMappingState, customerUserMappingState:CustomerUserMapping){
            state.editCustomerUserMapping=customerUserMappingState;
        },
        query(state:CustomerUserMappingState, customerUserMappingState:CustomerUserMapping){
            state.queryCustomerUserMapping=customerUserMappingState;
        }
    }
}
const customerUserMappingModule=new CustomerUserMappingModule();
export default customerUserMappingModule;