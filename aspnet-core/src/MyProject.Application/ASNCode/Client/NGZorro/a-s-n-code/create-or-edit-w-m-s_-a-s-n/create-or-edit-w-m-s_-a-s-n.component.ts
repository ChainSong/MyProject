
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import {
CreateOrUpdateWMS_ASNInput,
WMS_ASNEditDto,
WMS_ASNServiceProxy,
KeyValuePairOfStringString
} from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'create-or-edit-w-m-s_-a-s-n',
  templateUrl: './create-or-edit-w-m-s_-a-s-n.component.html',
  styleUrls:[
	'create-or-edit-w-m-s_-a-s-n.component.less'
    ],
    })

    export class CreateOrEditWMS_ASNComponent
    extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

    entity: WMS_ASNEditDto=new WMS_ASNEditDto();

    /**
    * 构造函数，在此处配置依赖注入
    */
    constructor(
    injector: Injector,
    private _wMS_ASNService: WMS_ASNServiceProxy

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
    this._wMS_ASNService.getForEdit(this.id).subscribe(result => {
    this.entity = result.wMS_ASN;
    

                           
                           
                           });
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
    const input = new CreateOrUpdateWMS_ASNInput();
    input.wMS_ASN = this.entity;

    this.saving = true;

    this._wMS_ASNService.createOrUpdate(input)
     .pipe(finalize(() => (this.saving = false)))
    .subscribe(() => {
    this.notify.success(this.l('SavedSuccessfully'));
    this.success(true);
    });
    }
    }
