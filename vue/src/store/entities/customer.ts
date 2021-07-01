import Entity from './entity'
import CustomerDetail from './customerDetail'

export default class customer extends Entity<number>{
    customerId    :number;
    projectId	  :number;
    customerCode  :number;
    customerName  :string;
    description	  :string;
    customerType  :string;
    customerStatus:number;
    creditLine	  :string;
    province	  :string;
    city		  :string;
    address		  :string;
    remark		  :string;
    email		  :string;
    phone		  :string;
    lawPerson	  :string;
    postCode	  :string;
    bank		  :string;
    account		  :string;
    taxId		  :string;
    invoiceTitle  :string;
    fax			  :string;
    webSite		  :string;
    creator		  :string;
    createTime	  :string;
    endCreateTime :string; 
    creationTime  :string;
    endCreationTime  :string;
    customerDetail:Array<CustomerDetail>;
}