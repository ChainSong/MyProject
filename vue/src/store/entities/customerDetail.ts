import Entity from './entity'

export default class customerDetail extends Entity<number>{
    customerId: number;
    projectId: number;
    customerCode: string;
    customerName: string;
    contact: string;
    tel: string;
    creator: string;
    creationTime: string;

}