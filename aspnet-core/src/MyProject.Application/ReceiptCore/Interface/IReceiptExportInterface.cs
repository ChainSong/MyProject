﻿using Microsoft.AspNetCore.Mvc;
using MyProject.ASNCore;
using MyProject.ASNCore.Dtos;
using MyProject.Dtos;
using MyProject.ReceiptCore.Dtos;
using MyProject.Sessions.AbpSessionExtension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ReceiptCore.Interface
{
   public  interface IReceiptExportInterface
    {
        Response<DataTable> Strategy(List<long> request, IAbpSessionExtension abpSession);
    }
}
