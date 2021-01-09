using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopperProject.Migrations
{
    public partial class Add_Default_Loai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlInsertLoai = @"
    SET IDENTITY_INSERT [dbo].[Loai] ON 

    INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (1, N'Điện thoại', NULL)
    INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (2, N'Điện phổ thông', 1)
    INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (3, N'Điện thoại thông minh', 1)
    INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (4, N'Điện tử - Điện lạnh', NULL)
    INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (5, N'Tivi', 4)
    INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (6, N'Điều hòa', 4)
    INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (7, N'Tivi thường', 5)
    INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (8, N'Smart Tivi', 5)
    SET IDENTITY_INSERT [dbo].[Loai] OFF
";
            migrationBuilder.Sql(sqlInsertLoai);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
