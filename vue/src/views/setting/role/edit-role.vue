<template>
    <div>
        <Modal :title="L('EditRole')" :value="value" @on-ok="save" @on-visible-change="visibleChange">
            <Form ref="roleForm" label-position="top" :rules="roleRule" :model="role">
                <Tabs value="detail">
                    <TabPane :label="L('RoleDetails')" name="detail">
                        <FormItem :label="L('RoleName')" prop="name">
                            <Input v-model="role.name" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('DisplayName')" prop="displayName">
                            <Input v-model="role.displayName" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('Description')" prop="description">
                            <Input v-model="role.description" :maxlength="1024"></Input>
                        </FormItem>
                    </TabPane>
                    <TabPane :label="L('RolePermission')" name="permission">
                        <Form>
                            <CheckboxGroup v-model="role.grantedPermissions">
                                <FormItem>

                                    <Checkbox class="Checkbox" :label="permission.name"
                                        v-for="permission in permissions" :key="permission.name">
                                        <span>{{ permission.displayName }}</span>

                                        <template v-if="permission.children.length > 0">
                                            <div>
                                                <Checkbox :label="children.name" v-for="children in permission.children"
                                                    :key="children.name">
                                                    <span>{{ children.displayName }}</span>
                                                </Checkbox>
                                            </div>
                                        </template>

                                    </Checkbox>

                                </FormItem>
                            </CheckboxGroup>
                        </Form>
                    </TabPane>
                </Tabs>
            </Form>
            <div slot="footer">
                <Button @click="cancel">{{ L('Cancel') }}</Button>
                <Button @click="save" type="primary">{{ L('OK') }}</Button>
            </div>
        </Modal>
    </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from 'vue-property-decorator';
import Util from '../../../lib/util'
import AbpBase from '../../../lib/abpbase'
import Role from '@/store/entities/role';
@Component
export default class EditRole extends AbpBase {
    @Prop({ type: Boolean, default: false }) value: boolean;
    role: Role = new Role();
    defaultcheckedkeys: string[];
    get permissions() {
        return this.arrayToTreeRecursive(this.$store.state.role.permissions)
    }


    /**
     * 递归查找，获取children
     */
    getChildren(data, result, pid) {
        data.forEach(item => {
            //如果元素的pid 和要查找的pid一致, 生成children格式数据存入结果数据
            if (item.name.indexOf(pid) >= 0 && item.name != pid) {
                const newItem = {
                    ...item,
                    label: item.displayName,
                    children: []
                };

                if (pid == "Pages" && item.name.split('.').length > 2) {

                } else {
                    result.push(newItem);
                }
                //查每一个数据的子集
                this.getChildren(data, newItem.children, item.name);
            }
        })
    }

    /**
     * 转换方法
     */
    arrayToTreeRecursive(data) {
        this.defaultcheckedkeys = [];
        const result = [];
        this.getChildren(data, result, "Pages")
        console.log(result)
        return result;
    }

    save() {
        // console.log(this.role);
        (this.$refs.roleForm as any).validate(async (valid: boolean) => {
            if (valid) {
                await this.$store.dispatch({
                    type: 'role/update',
                    data: this.role
                });
                (this.$refs.roleForm as any).resetFields();
                this.$emit('save-success');
                this.$emit('input', false);
            }
        })
    }
    cancel() {
        (this.$refs.roleForm as any).resetFields();
        this.$emit('input', false);
    }
    visibleChange(value: boolean) {
        if (!value) {
            this.$emit('input', value);
        } else {
            this.role = Util.extend(true, {}, this.$store.state.role.editRole);
        }
    }
    roleRule = {
        name: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('RoleName')), trigger: 'blur' }],
        displayName: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('DisplayName')), trigger: 'blur' }]
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
