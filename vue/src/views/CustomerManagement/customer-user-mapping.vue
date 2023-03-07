<template>
  <div>
    <Modal title="管理客户" :value="value" @on-ok="save" @on-visible-change="visibleChange">
      <el-checkbox-group v-model="customerUserCheck">
        <el-checkbox v-for="customer in customers" :label="customer.customerName" :key="customer.id"
          @change="handleCheckedCitiesChange($event, customer)">
          {{ customer.customerName }}</el-checkbox>
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
import Customer from '@/store/entities/customer';
import CustomerUser from '@/store/entities/customerUserMapping';
@Component
export default class CustomerUserMapping extends AbpBase {
  @Prop({ type: Boolean, default: false }) value: boolean;
  defaultcheckedkeys: string[] = [];
  customers: Array<Customer> = new Array<Customer>();
  customerUserCheck: string[] = [];
  customerUsers: Array<CustomerUser> = new Array<CustomerUser>();
  customerUser: CustomerUser = new CustomerUser();
  user: User = new User();
  created() {
  }
  getAll() {
    this.$store
      .dispatch({
        type: "customer/getAll",
        data: "",
      })
      .then((res) => {
        this.customerUsers = [];
        this.customers = res;
        this.customers.forEach(a => {
          this.customerUsers.push({
            customerId: a.id,
            customerName: a.customerName,
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

    this.customerUsers.forEach(a => {
      if (a.customerName == row.customerName) {
        a.status = value ? 1 : -1
      }
    })
    console.log(this.customerUsers)
  }
  //获取Mapping数据
  getMapping() {
    this.customerUserCheck = [];
    this.customerUser.userId = this.user.id;
    this.customerUser.userName = this.user.userName;
    console.log(this.customerUser);
    this.$store
      .dispatch({
        type: "customerUserMapping/getMapping",
        data: this.customerUser,
      })
      .then((res) => {
        console.log(res);
        res.items.forEach(a => {
          if (a.status == 1) {
            this.customerUserCheck.push(a.customerName);
          }
          this.customerUsers.forEach(b => {
           
             if(b.customerName==a.customerName ){
              b.status=1;
             }
          })
        })
      })
      .catch((err) => {
        console.log(err);
      });
  }
  save() {
    this.$store
      .dispatch({
        type: "customerUserMapping/create",
        data: { CustomerUserMappings: this.customerUsers },
      })
    this.$emit('save-success');
    this.$emit('input', false);
  }
  cancel() {
    this.$emit('input', false);
  }
  visibleChange(value: boolean) {
    console.log("进来了")
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
