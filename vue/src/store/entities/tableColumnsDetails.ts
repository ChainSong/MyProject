import Entity from './entity'

export default class tableColumnsDetails extends Entity<number>{
  
    codeInt: number;
    codeStr: string;
    name: string;
    type: string;
    associated: string;
    status: number;
    creator: string;
    creationTime: string;
    
}