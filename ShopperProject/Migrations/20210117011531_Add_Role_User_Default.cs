using Microsoft.EntityFrameworkCore.Migrations;
using ShopperProject.Helpers;

namespace ShopperProject.Migrations
{
    public partial class Add_Role_User_Default : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlInsertRole = @$"
USE [ShopperDb]
GO
SET IDENTITY_INSERT [dbo].[VaiTro] ON 
GO
INSERT [dbo].[VaiTro] ([RoleId], [RoleName], [IsSystem]) VALUES ({RoleContants.Customer}, N'Khách hàng', 1)
GO
INSERT [dbo].[VaiTro] ([RoleId], [RoleName], [IsSystem]) VALUES ({RoleContants.Administrator}, N'Quản trị', 1)
GO
SET IDENTITY_INSERT [dbo].[VaiTro] OFF
GO
";
            migrationBuilder.Sql(sqlInsertRole);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
