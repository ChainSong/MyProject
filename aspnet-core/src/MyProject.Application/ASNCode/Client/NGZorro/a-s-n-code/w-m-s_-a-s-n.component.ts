
import { Component, Injector, OnInit } from '@angular/core';
import * as _ from 'lodash';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/component-base/paged-listing-component-base';
import {WMS_ASNServiceProxy, PagedResultDtoOfWMS_ASNListDto, WMS_ASNListDto } from '@shared/service-proxies/service-proxies';
import { CreateOrEditWMS_ASNComponent } from './create-or-edit-w-m-s_-a-s-n/create-or-edit-w-m-s_-a-s-n.component';
import { AppConsts } from 'abpPro/AppConsts';
  import { FileDownloadService } from '@shared/utils/file-download.service';
  import { finalize } from 'rxjs/operators';


@Component({
    templateUrl: './w-m-s_-a-s-n.component.html',
    styleUrls: ['./w-m-s_-a-s-n.component.less'],
    animations: [appModuleAnimation()],
    })


    export class  WMS_ASNComponent extends PagedListingComponentBase<WMS_ASNListDto>
    implements OnInit {

    constructor(
    injector: Injector,
    private _wMS_ASNService: WMS_ASNServiceProxy,
	private _fileDownloadService: FileDownloadService,

    ) {
    super(injector);
    }

    /**
    * 获取后端数据列表信息
    * @param request 请求的数据的dto 请求必需参数 skipCount: number; maxResultCount: number;
    * @param pageNumber 当前页码
    * @param finishedCallback 完成后回调函数
    */
    protected fetchDataList(request: PagedRequestDto,pageNumber: number,finishedCallback: Function): void {
    this._wMS_ASNService.getPaged(
    this.filterText,
    request.sorting,
    request.maxResultCount,
    request.skipCount,
    )
   .pipe(finalize(() => finishedCallback()))
    .subscribe(result => {
    this.dataList = result.items;
    this.showPaging(result);
    });
    }

    ngOnInit(): void {
    // 初始化加载表格数据
    this.refresh();
    }

    /**
    * 新增或编辑DTO信息
    * @param id 当前DTO的Id
    */
    createOrEdit(id?: number): void {
    this.modalHelper.static(CreateOrEditWMS_ASNComponent, { id: id })
    .subscribe(result => {
    if (result) {
    this.refresh();
    }
    });
    }


    /**
    * 删除功能
    * @param entity 角色的实体信息
    */
    delete(entity: WMS_ASNListDto): void {
    this._wMS_ASNService.delete(entity.id)
    .subscribe(() => {
    /**
    * 刷新表格数据并跳转到第一页（`pageNumber = 1`）
    */
    this.refreshGoFirstPage();
    this.notify.success(this.l('SuccessfullyDeleted'));
    });
    }

    /**
    * 批量删除
    */
    batchDelete(): void {
    const selectCount = this.selectedDataItems.length;
    if (selectCount <= 0) {
    abp.message.warn(this.l('PleaseSelectAtLeastOneItem'));
    return;
    }

    abp.message.confirm(
    this.l('ConfirmDeleteXItemsWarningMessage', selectCount),undefined,
    res => {
    if (res) {
    const ids = _.map(this.selectedDataItems, 'id');
    this._wMS_ASNService.batchDelete(ids).subscribe(() => {
    this.refreshGoFirstPage();
    this.notify.success(this.l('SuccessfullyDeleted'));
    });
    }
    },
    );
    }


    /**
    * 导出为Excel表
    */
    exportToExcel(): void {
   // abp.message.error('已经开发完成测试通过！！！！');
    this._wMS_ASNService.getToExcelFile().subscribe(result => {
  this._fileDownloadService.downloadTempFile(result);
});
    }

    }

