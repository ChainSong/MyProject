import Entity from './entity'
import TableColumnsDetails from './tableColumnsDetails'
// import AbpBase from "../../lib/abpbase";
export default class tableColumns extends Entity<number>{
projectId: number;
roleName: string;
customerId: number;
tableName: string;
tableNameCH: string;
displayName: string;
dbColumnName: string;
isKey: number;
isSearchCondition: number;
isHide: number;
isReadOnly: number;
isShowInList: number;
isImportColumn: number;
isDropDownList: number;
isCreate: number;
isUpdate: boolean;
searchConditionOrder: number;
validation:string;
group: string;
type: string;
order: string;
forView: string;
creationTime: string;
tableFormat: string;
tableColumnsDetails: Array<TableColumnsDetails>;
}