
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import {
CreateOrUpdateTable_ColumnsInput,
Table_ColumnsEditDto,
Table_ColumnsServiceProxy,
KeyValuePairOfStringString
} from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'create-or-edit-table_-columns',
  templateUrl: './create-or-edit-table_-columns.component.html',
  styleUrls:[
	'create-or-edit-table_-columns.component.less'
    ],
    })

    export class CreateOrEditTable_ColumnsComponent
    extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

    entity: Table_ColumnsEditDto=new Table_ColumnsEditDto();

    /**
    * 构造函数，在此处配置依赖注入
    */
    constructor(
    injector: Injector,
    private _table_ColumnsService: Table_ColumnsServiceProxy

    ) {
    super(injector);
    }

    ngOnInit() :void{
    this.init();
    }


    /**
    * 初始化方法
    */
    init(): void {
    this._table_ColumnsService.getForEdit(this.id).subscribe(result => {
    this.entity = result.table_Columns;
    

                           
                           
                           });
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
    const input = new CreateOrUpdateTable_ColumnsInput();
    input.table_Columns = this.entity;

    this.saving = true;

    this._table_ColumnsService.createOrUpdate(input)
     .pipe(finalize(() => (this.saving = false)))
    .subscribe(() => {
    this.notify.success(this.l('SavedSuccessfully'));
    this.success(true);
    });
    }
    }
