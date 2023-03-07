import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import Customer from '../entities/customer'
import Ajax from '../../lib/ajax' 
import PageResult from '@/store/entities/page-result';

interface CustomerState extends ListState<Customer>{
    editCustomer:Customer;
    queryCustomer:Customer;
    permissions:Array<string>
}
class CustomerModule extends ListModule<CustomerState,any,Customer>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<Customer>(),
        map: new Array<Customer>(),
        loading:false,
        editCustomer:new Customer(),
        queryCustomer:new Customer(),
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
        async create(context:ActionContext<CustomerState,any>,payload:any){
            // console.log("dasdasd");
            // console.log(payload.data);
            await Ajax.post('/api/services/app/Customer/CreateOrUpdate',payload.data);
        },
        async update(context:ActionContext<CustomerState,any>,payload:any){
            await Ajax.post('/api/services/app/Customer/CreateOrUpdate',payload.data);
        },
        async delete(context:ActionContext<CustomerState,any>,payload:any){
            console.log(payload.data);
            await Ajax.get('/api/services/app/Customer/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<Customer,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/Customer/GetById?Id='+payload.data.id);
            return reponse.data.result as Customer;
        },
        async getAll(context:ActionContext<Customer,any>,payload:any){
             
            let reponse=await Ajax.get('/api/services/app/Customer/getAll');
            return reponse.data.result as Customer;
        },
        async GetPaged(context:ActionContext<CustomerState,any>,payload:any){
            let reponse= await Ajax.post('/api/services/app/Customer/GetPaged',payload.data);
            context.state.loading=false;
            let page=reponse.data.result as PageResult<Customer>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items; 
        }
    };
    mutations={
        setCurrentPage(state:CustomerState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:CustomerState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:CustomerState, customerState:Customer){
            state.editCustomer=customerState;
        },
        query(state:CustomerState, customerState:Customer){
            state.queryCustomer=customerState;
        }
    }
}
const customerModule=new CustomerModule();
export default customerModule;