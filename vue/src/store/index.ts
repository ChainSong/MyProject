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
// import Table_ColumnsDetails from './modules/Table_ColumnsDetails'
import customer from './modules/customer'
import asn from './modules/asn'
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
        // Table_ColumnsDetails,
        customer,
        asn,
        // CustomerDetail
    }
});

export default store;