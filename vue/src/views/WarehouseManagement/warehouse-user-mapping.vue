<template>
  <div>
    <Modal title="管理仓库" :value="value" @on-ok="save" @on-visible-change="visibleChange">
      <el-checkbox-group v-model="warehouseUserCheck">
        <el-checkbox v-for="warehouse in warehouses" :label="warehouse.warehouseName" :key="warehouse.id"
          @change="handleCheckedCitiesChange($event, warehouse)">
          {{ warehouse.warehouseName }}</el-checkbox>
      </el-checkbox-group>
      <div slot="footer">
        <Button @click="cancel">{{ L('Cancel') }}</Button>
        <Button @click="save" type="primary">{{ L('OK') }}</Button>
      </div>
    </Modal>
  </div>
</template>
 <script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from 'vue-property-decorator';
import Util from '../../lib/util'
import AbpBase from '../../lib/abpbase'
import User from '../../store/entities/user'
import Warehouse from '@/store/entities/warehouse';
import WarehouseUser from '@/store/entities/warehouseUserMapping';
@Component
export default class WarehouseUserMapping extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  defaultcheckedkeys: string[] = [];
  warehouses: Array<Warehouse> = new Array<Warehouse>();
  warehouseUserCheck: string[] = [];
  warehouseUsers: Array<WarehouseUser> = new Array<WarehouseUser>();
  warehouseUser: WarehouseUser = new WarehouseUser();
  user: User = new User();
  created() {
  }
  getAll() {
    this.$store
      .dispatch({
        type: "warehouse/getAll",
        data: "",
      })
      .then((res) => {
        this.warehouseUsers = [];
        this.warehouses = res;
        this.warehouses.forEach(a => {
          this.warehouseUsers.push({
            warehouseId: a.id,
            warehouseName: a.warehouseName,
            status: -1,
            userId: this.user.id,
            userName: this.user.userName
          })
        })
        this.getMapping();
      })
      .catch((err) => {
        console.log(err);
      });
  }
  //点击多选框 处理数据
  handleCheckedCitiesChange(value, row) {

    this.warehouseUsers.forEach(a => {
      if (a.warehouseName == row.warehouseName) {
        a.status = value ? 1 : -1
      }
    })
    console.log(this.warehouseUsers)
  }
  //获取Mapping数据
  getMapping() {
    this.warehouseUserCheck = [];
    this.warehouseUser.userId = this.user.id;
    this.warehouseUser.userName = this.user.userName;
    // this.warehouseMapping.userName=this.user.userName;
    console.log(this.warehouseUser);
    this.$store
      .dispatch({
        type: "warehouseUserMapping/getMapping",
        data: this.warehouseUser,
      })
      .then((res) => {
        console.log(res);
        res.items.forEach(a => {
          if (a.status == 1) {
            this.warehouseUserCheck.push(a.warehouseName);
          }
          this.warehouseUsers.forEach(b => {
           
             if(b.warehouseName==a.warehouseName ){
              b.status=1;
             }
          })
        })
        console.log("this.warehouseUserCheck")
        console.log(this.warehouseUserCheck)
      })
      .catch((err) => {
        console.log(err);
      });
  }
  save() {
    this.$store
      .dispatch({
        type: "warehouseUserMapping/create",
        data: { WarehouseUserMappings: this.warehouseUsers },
      })
    this.$emit('save-success');
    this.$emit('input', false);
  }
  cancel() {
    this.$emit('input', false);
  }
  visibleChange(value: boolean) {
    if (!value) {
      this.$emit('input', value);
    } else {
      this.user = Util.extend(true, {}, this.$store.state.user.editUser);
      console.log("this.user");
      console.log(this.user);
      this.getAll();
      
    }
  }
}
</script>
<style scoped>
.Checkbox {
  width: 100%;
  border-bottom: 1px solid rgba(202, 202, 202, 0.616);
  /* 鼠标移动添加阴影 */
}

/* .Checkbox:hover {
    -webkit-box-shadow: #ccc 0px 10px 10px;
    -moz-box-shadow: #ccc 0px 10px 10px;
    box-shadow: #ccc 0px 10px 10px;
} */
</style>
