import Vue from 'vue';
import Vuex from 'vuex';
Vue.use(Vuex);
import app from './modules/app'
import session from './modules/session'
import account from './modules/account'
import user from './modules/user'
import role from './modules/role'
import tenant from './modules/tenant'
import tableColumns from './modules/tableColumns'
import tableColumnsDetails from './modules/tableColumnsDetails'
// import Table_ColumnsDetails from './modules/Table_ColumnsDetails'
import customer from './modules/customer'
import asn from './modules/asn'
import receipt from './modules/receipt'
import product from './modules/product'
import warehouse from './modules/warehouse'
import area from './modules/area'
import location from './modules/location'
import warehouseUserMapping from './modules/warehouseUserMapping'
import customerUserMapping from './modules/customerUserMapping'
import receiptReceiving from './modules/receiptReceiving'
import inventoryUsable from './modules/inventoryUsable'
import preorder from './modules/preorder'
import order from './modules/order'
// import CustomerDetail from './modules/CustomerDetail'
const store = new Vuex.Store({
    state: {
        //
    },
    mutations: {
        //
    },
    actions: {

    },
    modules: {
        app,
        session,
        account,
        user,
        role,
        tenant,
        tableColumns,
        tableColumnsDetails,
        // Table_ColumnsDetails,
        customer,
        asn,
        receipt,
        product,
        warehouse,
        area,
        location,
        warehouseUserMapping,
        customerUserMapping,
        receiptReceiving,
        inventoryUsable,
        preorder,
        order
        // CustomerDetail
    }
});

export default store;