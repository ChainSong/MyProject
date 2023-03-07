<template font-family="Helvetica Neue">
  <div>
    <el-alert v-for="i in alertData" v-bind="i" :key="i" :title="i.msg" :type="i.status">
    </el-alert>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../lib/util";
import AbpBase from "../../lib/abpbase";
// import TableColumns from "../../store/entities/tableColumns";
import orderStatus from "../../store/entities/orderStatus";
@Component
export default class resultpopup extends AbpBase {
  //字段的值
  @Prop({ type: Array, default:  new Array<orderStatus>() }) objData:Array<orderStatus>;
  alertData:Array<orderStatus>=new Array<orderStatus>();
  // @Watch("orderStatus", { immediate: true, deep: true })
  // getDropDownListRemote() {
  // }
  created() {
       console.log("进来值");
       console.log(this.objData);
       this.alertData=this.objData;
       console.log(this.alertData);
  }
}
</script>
 