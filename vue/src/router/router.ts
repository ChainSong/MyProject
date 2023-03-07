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
    path: '/systemInto',
    name: 'systemInto',
    permission: '',
    meta: { title: '主信息' },
    icon: '&#xe68a;',
    component: main,
    children: [
        { path: 'user', permission: 'Pages.Users', meta: { title: 'Users' }, name: 'user', component: () => import('../views/setting/user/user.vue') },
        { path: 'role', permission: 'Pages.Roles', meta: { title: 'Roles' }, name: 'role', component: () => import('../views/setting/role/role.vue') },
        { path: 'tenant', permission: 'Pages.Tenants', meta: { title: 'Tenants' }, name: 'tenant', component: () => import('../views/setting/tenant/tenant.vue') },
        // { path: 'TableColumns', permission: 'Pages.Table.Columns', meta: { title: 'TableColumns' }, name: 'TableColumns', component: () => import('../views/TableColumns/tablecolumns-edit.vue') }
        { path: 'TableColumns', permission: 'Pages.TableColumns', meta: { title: 'TableColumns' }, name: 'TableColumns', component: () => import('../views/TableColumnsManagement/tablecolumns-list.vue') }
    ]
},
{
    path: '/BasicInfo',
    name: 'BasicInfo',
    permission: '1',
    meta: { title: '基础信息' },
    icon: '&#xe736;',
    component: main,
    children: [
        { path: 'Customers', permission: 'Pages.Customer', meta: { title: 'Customers' }, name: 'Customers', component: () => import('../views/CustomerManagement/customer-list.vue') },
        { path: 'Product', permission: 'Pages.WMS_Product', meta: { title: 'Product' }, name: 'Product', component: () => import('../views/ProductManagement/product-list.vue') },
        { path: 'Warehouse', permission: 'Pages.Warehouse', meta: { title: 'Warehouse' }, name: 'Warehouse', component: () => import('../views/WarehouseManagement/warehouse-list.vue') },
        { path: 'Area', permission: 'Pages.Area', meta: { title: 'Area' }, name: 'Area', component: () => import('../views/WarehouseManagement/area-list.vue') },
        { path: 'Location', permission: 'Pages.Location', meta: { title: 'Location' }, name: 'Location', component: () => import('../views/WarehouseManagement/location-list.vue') }
    ]
},
// {
//     path: '/CustomerBasic',
//     name: 'CustomerBasic',
//     permission: '1',
//     meta: { title: '客户信息' },
//     icon: '&#xe736;',
//     component: main,
//     children: [
//         { path: 'Customers', permission: 'Pages.Customer', meta: { title: 'Customers' }, name: 'Customers', component: () => import('../views/CustomerManagement/customer-list.vue') },
        

//     ]
// }
{
    path: '/ASNManagement',
    name: 'ASNManagement',
    permission: '2',
    meta: { title: '入库管理' },
    icon: '&#xe699;',
    component: main,
    children: [
        { path: 'ASN', permission: 'Pages.ASN', meta: { title: 'ASN' }, name: 'ASN', component: () => import('../views/ASNManagement/asn-list.vue') },
        { path: 'Receipt', permission: 'Pages.Receipt', meta: { title: 'Receipt' }, name: 'Receipt', component: () => import('../views/ReceiptManagement/receipt-list.vue') },
        { path: 'ReceiptReceiving', permission: 'Pages.ReceiptReceiving', meta: { title: 'ReceiptReceiving' }, name: 'ReceiptReceiving', component: () => import('../views/ReceiptReceivingManagement/receiptreceiving-list.vue') }
    ]
},
{
    path: '/InventoryManagement',
    name: 'InventoryManagement',
    permission: '2',
    meta: { title: '库存管理' },
    icon: '&#xe699;',
    component: main,
    children: [
        { path: 'InventoryUsable', permission: 'Pages.InventoryUsable', meta: { title: 'Inventory_Usable' }, name: 'InventoryUsable', component: () => import('../views/InventoryManagement/inventoryUsable-list.vue') },
    ]
},
{
    path: '/PreOrderManagement',
    name: 'PreOrderManagement',
    permission: '3',
    meta: { title: '出库管理' },
    icon: '&#xe699;',
    component: main,
    children: [
        { path: 'PreOrder', permission: 'Pages.PreOrder', meta: { title: 'PreOrder' }, name: 'PreOrder', component: () => import('../views/PreOrderManagement/preorder-list.vue') },
        { path: 'Order', permission: 'Pages.Order', meta: { title: 'Order' }, name: 'Order', component: () => import('../views/OrderManagement/order-list.vue') },
    ]
}
// ,{
//     path: '/ReceiptManagement',
//     name: 'ReceiptManagement',
//     permission: '3',
//     meta: { title: '入库管理' },
//     icon: '&#xe74a;',
//     component: main,
//     children: [
//         { path: 'Receipt', permission: 'Pages.Receipt', meta: { title: 'Receipt' }, name: 'Receipt', component: () => import('../views/ReceiptManagement/receipt-list.vue') }
//     ]
// },
//{
//     path: '/ProductManagement',
//     name: 'ProductManagement',
//     permission: '4',
//     meta: { title: '产品管理' },
//     icon: '&#xe610;',
//     component: main,
//     children: [
//         { path: 'Product', permission: 'Pages.WMS_Product', meta: { title: 'Product' }, name: 'Product', component: () => import('../views/ProductManagement/product-list.vue') }
//     ]
// },{
//     path: '/WarehouseManagement',
//     name: 'WarehouseManagement',
//     permission: '6',
//     meta: { title: '仓库管理' },
//     icon: '&#xe6b8;',
//     component: main,
//     children: [
//         { path: 'Warehouse', permission: 'Pages.Warehouse', meta: { title: 'Warehouse' }, name: 'Warehouse', component: () => import('../views/WarehouseManagement/warehouse-list.vue') },
//         { path: 'Area', permission: 'Pages.Area', meta: { title: 'Area' }, name: 'Area', component: () => import('../views/WarehouseManagement/area-list.vue') },
//         { path: 'Location', permission: 'Pages.Location', meta: { title: 'Location' }, name: 'Location', component: () => import('../views/WarehouseManagement/location-list.vue') }
//     ]
// },{
//     path: '/TableColumnsManagement',
//     name: 'TableColumnsManagement',
//     permission: '99',
//     meta: { title: '表字段' },
//     icon: '&#xe601;',
//     component: main,
//     children: [
//         { path: 'TableColumns', permission: 'Pages.TableColumns', meta: { title: 'TableColumns' }, name: 'TableColumns', component: () => import('../views/TableColumnsManagement/tablecolumns-list.vue') }
//     ]
// }
]
export const routers = [
    loginRouter,
    locking,
    ...appRouters,
    otherRouters
];
