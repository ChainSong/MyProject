
using MyProject.ASNCode;
using MyProject.ASNCode.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.Tests.WMS_ASNs
{
    public class WMS_ASNAppService_Tests : MyProjectTestBase
    {
        private readonly IWMS_ASNAppService _wMS_ASNAppService;

        public WMS_ASNAppService_Tests()
        {
            _wMS_ASNAppService = Resolve<IWMS_ASNAppService>();
        }

        [Fact]
        public async Task CreateWMS_ASN_Test()
        {
            await _wMS_ASNAppService.CreateOrUpdate(new CreateOrUpdateWMS_ASNInput
            {
                WMS_ASN = new WMS_ASNEditDto
                {


                    ASNNumber = "test",
                    ExternReceiptNumber = "test",
                    CustomerName = "test",
                    WarehouseName = "test",
                    ASNType = "test",
                    PO = "test",
                    Contact = "test",
                    ContactInfo = "test",
                    Remark = "test",
                    Creator = "test",
                    CreationTime = DateTime.Now,
                    Updator = "test",
                    Str1 = "test",
                    Str2 = "test",
                    Str3 = "test",
                    Str4 = "test",
                    Str5 = "test",
                    Str6 = "test",
                    Str7 = "test",
                    Str8 = "test",
                    Str9 = "test",
                    Str10 = "test",
                    Str11 = "test",
                    Str12 = "test",
                    Str13 = "test",
                    Str14 = "test",
                    Str15 = "test",
                    Str16 = "test",
                    Str17 = "test",
                    Str18 = "test",
                    Str19 = "test",
                    Str20 = "test",


                }
            });

            //await UsingDbContextAsync(async context =>
            //{
            //    var dystopiaWMS_ASN = await context.WMS_ASNs.FirstOrDefaultAsync();
            //    dystopiaWMS_ASN.ShouldNotBeNull();
            //}
            //);
        }

        [Fact]
        public async Task GetWMS_ASNs_Test()
        {
            // Act
            var output = await _wMS_ASNAppService.GetPaged(new GetWMS_ASNsInput
            {
                MaxResultCount = 20,
                SkipCount = 0
            });

            // Assert
            output.Items.Count.ShouldBeGreaterThanOrEqualTo(0);
        }


        //// custom codes



        //// custom codes end


    }
}