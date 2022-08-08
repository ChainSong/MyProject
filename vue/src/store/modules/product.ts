import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import product from '../entities/product'
import Ajax from '../../lib/ajax' 
import PageResult from '@/store/entities/page-result';

interface ProductState extends ListState<product>{
    editProduct:product;
    queryProduct:product;
    permissions:Array<string>
}
class ProductModule extends ListModule<ProductState,any,product>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<product>(),
        map: new Array<product>(),
        loading:false,
        editProduct:new product(),
        queryProduct:new product(),
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
        async create(context:ActionContext<ProductState,any>,payload:any){
            console.log("dasdasd");
            console.log(payload.data);
            await Ajax.post('/api/services/app/WMS_Product/CreateOrUpdate',payload.data);
        },
        async update(context:ActionContext<ProductState,any>,payload:any){
            // console.log("dasdasd");
            // console.log(payload.data);
            await Ajax.post('/api/services/app/WMS_Product/CreateOrUpdate',payload.data);
        },
        async delete(context:ActionContext<ProductState,any>,payload:any){
            await Ajax.delete('/api/services/app/WMS_Product/Delete?Id='+payload.data.id);
        },
        // async update(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.put('/api/services/app/Role/Update',payload.data);
        // },
        // async delete(context:ActionContext<RoleState,any>,payload:any){
        //     await Ajax.delete('/api/services/app/Role/Delete?Id='+payload.data.id);
        // },
        async get(context:ActionContext<product,any>,payload:any){
            console.log(payload.data)
            //let reponse=await Ajax.get('/api/services/app/Product/GetById?Id='+payload.data.id);
            let reponse=await Ajax.get('/api/services/app/WMS_Product/GetById?Id='+payload.data.id);
            return reponse.data.result as product;
        },
        // async getAllPermissions(context:ActionContext<RoleState,any>){
        //     let reponse=await Ajax.get('/api/services/app/Role/getAllPermissions');
        //     context.state.permissions=reponse.data.result.items;
        // },

        async GetPaged(context:ActionContext<ProductState,any>,payload:any){
            console.log("开始请求");
            console.log(JSON.stringify(payload.data));
            let reponse= await Ajax.post('/api/services/app/WMS_Product/GetPaged',payload.data);
            context.state.loading=false;
            let page=reponse.data.result as PageResult<product>;
            console.log(page);
            context.state.totalCount=page.totalCount;
            context.state.list=page.items as Array<product>;
            // return reponse.data.result  as Array<TableColumns>;
        }
    };
    mutations={
        setCurrentPage(state:ProductState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:ProductState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:ProductState, ProductState:product){
            state.editProduct=ProductState;
        },
        query(state:ProductState, ProductState:product){
            state.queryProduct=ProductState;
        }
    }
}
const productModule=new ProductModule();
export default productModule;