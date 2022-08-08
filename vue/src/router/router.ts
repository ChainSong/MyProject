declare global {
    interface RouterMeta {
        title: string;
    }
    interface Router {
        path: string;
        name: string;
        icon?: string;
        permission?: string;
        meta?: RouterMeta;
        component: any;
        children?: Array<Router>;
    }
    interface System {
        import(request: string): Promise<any>
    }
    var System: System
}
import login from '../views/login.vue'
import home from '../views/home/home.vue'
import main from '../views/main.vue'

export const locking = {
    path: '/locking',
    name: 'locking',
    component: () => import('../components/lockscreen/components/locking-page.vue')
};
export const loginRouter: Router = {
    path: '/',
    name: 'login',
    meta: {
        title: 'LogIn'
    },
    component: () => import('../views/login.vue')
};
export const otherRouters: Router = {
    path: '/main',
    name: 'main',
    permission: '',
    meta: { title: 'ManageMenu' },
    component: main,
    children: [
        { path: 'home', meta: { title: 'HomePage' }, name: 'home', component: () => import('../views/home/home.vue') }
    ]
}
export const appRouters: Array<Router> = [{
    path: '/setting',
    name: 'setting',
    permission: '',
    meta: { title: 'ManageMenu' },
    icon: '&#xe68a;',
    component: main,
    children: [
        { path: 'user', permission: 'Pages.Users', meta: { title: 'Users' }, name: 'user', component: () => import('../views/setting/user/user.vue') },
        { path: 'role', permission: 'Pages.Roles', meta: { title: 'Roles' }, name: 'role', component: () => import('../views/setting/role/role.vue') },
        { path: 'tenant', permission: 'Pages.Tenants', meta: { title: 'Tenants' }, name: 'tenant', component: () => import('../views/setting/tenant/tenant.vue') },
        // { path: 'TableColumns', permission: 'Pages.Table.Columns', meta: { title: 'TableColumns' }, name: 'TableColumns', component: () => import('../views/TableColumns/tablecolumns-edit.vue') }
    
    ]
},{
    path: '/CustomerBasic',
    name: 'CustomerBasic',
    permission: '1',
    meta: { title: '客户信息' },
    icon: '&#xe68a;',
    component: main,
    children: [
        { path: 'Customers', permission: 'Pages.Customer', meta: { title: 'Customers' }, name: 'Customers', component: () => import('../views/CustomerManagement/customer-list.vue') }
    ]
},{
    path: '/ASNManagement',
    name: 'ASNManagement',
    permission: '2',
    meta: { title: '预入库管理' },
    icon: '&#xe68a;',
    component: main,
    children: [
        { path: 'ASN', permission: 'Pages.ASN', meta: { title: 'ASN' }, name: 'ASN', component: () => import('../views/ASNManagement/asn-list.vue') }
    ]
},{
    path: '/ReceiptManagement',
    name: 'ReceiptManagement',
    permission: '2',
    meta: { title: '入库管理' },
    icon: '&#xe68a;',
    component: main,
    children: [
        { path: 'Receipt', permission: 'Pages.Receipt', meta: { title: 'Receipt' }, name: 'Receipt', component: () => import('../views/ReceiptManagement/receipt-list.vue') }
    ]
},{
    path: '/ProductManagement',
    name: 'ProductManagement',
    permission: '4',
    meta: { title: '产品管理' },
    icon: '&#xe68a;',
    component: main,
    children: [
        { path: 'Product', permission: 'Pages.WMS_Product', meta: { title: 'Product' }, name: 'Product', component: () => import('../views/ProductManagement/product-list.vue') }
    ]
},{
    path: '/WarehouseManagement',
    name: 'WarehouseManagement',
    permission: '6',
    meta: { title: '仓库管理' },
    icon: '&#xe68a;',
    component: main,
    children: [
        { path: 'Warehouse', permission: 'Pages.Warehouse', meta: { title: 'Warehouse' }, name: 'Warehouse', component: () => import('../views/WarehouseManagement/warehouse-list.vue') }
    ]
},{
    path: '/TableColumnsManagement',
    name: 'TableColumnsManagement',
    permission: '99',
    meta: { title: '表字段' },
    icon: '&#xe68a;',
    component: main,
    children: [
        { path: 'TableColumns', permission: 'Pages.TableColumns', meta: { title: 'TableColumns' }, name: 'TableColumns', component: () => import('../views/TableColumnsManagement/tablecolumns-list.vue') }
    ]
}]
export const routers = [
    loginRouter,
    locking,
    ...appRouters,
    otherRouters
];
