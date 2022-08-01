using Abp.Domain.Services;

namespace MyProject
{
	public abstract class DomainServiceBase : DomainService
	{
		/*在领域服务中添加你的自定义公共方法*/


		protected DomainServiceBase()
		{
			LocalizationSourceName = MyProjectConsts.LocalizationSourceName;
		}
	}
}
