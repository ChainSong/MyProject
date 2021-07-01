
using MyProject.TableColumns;
using MyProject.TableColumns.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.Tests.Table_Columnss
{
    public class Table_ColumnsAppService_Tests : MyProjectTestBase
    {
        private readonly ITable_ColumnsAppService _table_ColumnsAppService;

        public Table_ColumnsAppService_Tests()
        {
            _table_ColumnsAppService = Resolve<ITable_ColumnsAppService>();
        }

        [Fact]
        public async Task CreateTable_Columns_Test()
        {
            await _table_ColumnsAppService.CreateOrUpdate(new CreateOrUpdateTable_ColumnsInput
            {
                Table_Columns = new Table_ColumnsEditDto
                {


                    RoleName = "test",
                    TableName = "test",
                    TableNameCH = "test",
                    DisplayName = "test",
                    DbColumnName = "test",
                    Group = "test",
                    Type = "test",
                    CreationTime = DateTime.Now,


                }
            });

            await UsingDbContextAsync(async context =>
            {
                var dystopiaTable_Columns = await context.Table_Columns.FirstOrDefaultAsync();
                dystopiaTable_Columns.ShouldNotBeNull();
            }
            );
        }

        [Fact]
        public async Task GetTable_Columnss_Test()
        {
            // Act
            var output = await _table_ColumnsAppService.GetPaged(new GetTable_ColumnssInput
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