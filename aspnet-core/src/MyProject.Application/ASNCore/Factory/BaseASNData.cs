using MyProject.ASNCore.Dtos;
using MyProject.Dtos;
using MyProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ASNCore.Factory
{
    public class BaseASNData : IHub<CreateOrUpdateWMS_ASNInput>
    {
        //public CreateOrUpdateWMS_ASNInput _createOrUpdateWMS { get; set; }

        //public BaseASNData(CreateOrUpdateWMS_ASNInput createOrUpdateWMS)
        //{
        //    this._createOrUpdateWMS = createOrUpdateWMS;
        //}

        //public virtual void CustomerDefinedSettledTransData(ref string message)
        //{

        //}

        public Response<CreateOrUpdateWMS_ASNInput> Hub(CreateOrUpdateWMS_ASNInput t)
        {
            return new Response<CreateOrUpdateWMS_ASNInput>();
        }
    }
}
