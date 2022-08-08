import Entity from './entity'
import CustomerDetail from './customerDetail'

export default class customer extends Entity<number>{
     
customerid: number;
projectid: number;
customercode: number;
customername: string;
description: string;
customertype: string;
customerstatus: number;
creditline: string;
province: string;
city: string;
address: string;
remark: string;
email: string;
phone: string;
lawperson: string;
postcode: string;
bank: string;
account: string;
taxid: string;
invoicetitle: string;
fax: string;
website: string;
creator: string;
createtime: string;
endcreatetime: string;
creationtime: string;
endcreationtime: string;
    customerDetail:Array<CustomerDetail>;
}