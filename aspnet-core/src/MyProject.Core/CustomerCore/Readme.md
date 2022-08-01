

# SOEI.Faker ABP 开发辅助工具操作手册
# 感谢 (ABP Code Power Tools ) 开发作者和52ABP的大力推广（保留52ABP 和 ABP Code Power Tools 介绍推广）
# 代码生成器(ABP Code Power Tools )使用说明文档
# 目前陕西西安地区ABP的使用业内渐渐多起来，希望大家一同努力进行宣传和团队建设

**松毅软件官方网站：[http://www.soei.com.cn](http://www.soei.com.cn)**
**52ABP官方网站：[http://www.52abp.com](http://www.52abp.com)**


- 团队采用ABP样板工程进行项目开发工作，之前使用ABP Code Power Tools和自己一些开发习惯问题，着手开发一套自己的插件配合前端，
本次开发由 松毅软件（http://www.soei.com.cn/），质量架构部提供支持，如有任何问题请联系Email:  huayhy@126.com

编码 SOEI软件,质量架构部，华威

FakerSolution  ABP 样板项目 [Github地址](https://github.com/huayhy/FakerSolution)



-前端我们采用 VUE 开发，之后会生成关于VUE的代码片段



如果你选择了**生成权限功能**，请打开MyProject.Application类库中的MyProjectApplicationModule.cs类文件。
然后复制以下代码到 的PreInitialize 方法中:

```csharp
Configuration.Authorization.Providers.Add<CustomerAuthorizationProvider>();

```


 

请打开MyProject.Application类库中MyProjectApplicationModule.cs中的 PreInitialize 方法中:

```csharp
// 自定义AutoMapper类型映射
// 如果没有这一段就把本所有代码复制上去
Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
{
    // ....其他代码

    // 只需要复制这一段
        CustomerDtoAutoMapper.CreateMappings(configuration);

    // ....其他代码
});

```

打开EntityFrameworkCore类库在 **MyProjectContext**类文件中添加以下代码段：

```csharp
public virtual DbSet<Customer>  Customers { get; set; }

 ```
以实现将实体配置到数据库上下文中。
 
【此步骤选填】如果要使用 EntityFrameworkCore 中的 Fluent API 进行具有最高优先级的配置实体，可添加以下代码到方法```OnModelCreating```中

新的ABP项目如下操作

```csharp 

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
   modelBuilder.ApplyConfiguration(new  CustomerMapper());
}

```
若使用 Faker.Solution 项目或者 SOEI.Solution 

```csharp 

        /// <summary>
        ///  配置用户表
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected void SetUserTablePrefix(ModelBuilder modelBuilder)
        {
            // 代码生成器生成的表实体配置全部添加到这里
             modelBuilder.ApplyConfiguration(new  CustomerMapper());  // 请将代码配置到这里 
        }

```



如果该实体的属性值未发生改变可以跳过当前小节

打开**程序包管理器控制台**工具，指定默认项目类库以**EntityFrameworkCore**结尾，然后执行以下命令:

添加一条迁移记录

```
Add-Migration Add_CustomerEntity_Migration
```

同步实体文件到数据库中
```
Update-Database
```

由于我们暂时项目用不到没有处理









52ABP官方网站：[http://www.52abp.com](http://www.52abp.com)

代码生成器帮助文档：[http://www.cnblogs.com/wer-ltm/p/8445682.html](http://www.cnblogs.com/wer-ltm/p/8445682.html)


【ASP.NetCore Mvc EF入门学习】:850720634(免费)
[![52ABP .NET CORE 实战群](http://pub.idqqimg.com/wpa/images/group.png)](https://jq.qq.com/?_wv=1027&k=5GbjOD9) 

【52ABP .NET CORE 实战群】：633751348 (免费)
[![52ABP .NET CORE 实战群](http://pub.idqqimg.com/wpa/images/group.png)](https://jq.qq.com/?_wv=1027&k=5pWtBvu)

【ABP代码生成器交流群】：104390185（收费）
[![52ABP .NET CORE 实战群](http://pub.idqqimg.com/wpa/images/group.png)](http://shang.qq.com/wpa/qunwpa?idkey=3f301fa3101d3201c391aba77803b523fcc53e59d0c68e6eeb9a79336c366d92)

