using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Sessions.AbpSessionExtension
{
    public interface IAbpSessionExtension : IAbpSession
    {
        string RoleName { get; }
        string UserName { get; }
    }
}
