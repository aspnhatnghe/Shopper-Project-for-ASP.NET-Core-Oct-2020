using Microsoft.EntityFrameworkCore.Migrations;
using ShopperProject.Helpers;

namespace ShopperProject.Migrations
{
    public partial class Add_UserAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var randomKey = MyTool.GetRandom();
            var matkhauHash = "admin".ToSHA512Hash(randomKey);
            var adminId = 1;
            var sqlInsertAdminuser = @$"
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([MaNd], [HoTen], [SoDienThoai], [Email], [MatKhau], [DiaChi], [DangHoatDong], [MaNgauNhien]) VALUES ({adminId}, N'Quản trị hệ thống', N'0909009900', N'admin@nhatnghe.com', N'{matkhauHash}', N'105 Bà Huyện Thanh Quan', 1, N'{randomKey}')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
INSERT INTO UserRole(RoleId, UserId) VALUES({RoleContants.Administrator}, {adminId})
GO
";
            migrationBuilder.Sql(sqlInsertAdminuser);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
