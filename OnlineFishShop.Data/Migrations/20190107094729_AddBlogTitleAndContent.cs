using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineFishShop.Data.Migrations
{
    public partial class AddBlogTitleAndContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryOptionId",
                table: "Purchase",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentOptionId",
                table: "Purchase",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "Products",
                maxLength: 25,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldDefaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "BlogPosts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "BlogPosts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_DeliveryOptionId",
                table: "Purchase",
                column: "DeliveryOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PaymentOptionId",
                table: "Purchase",
                column: "PaymentOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_DeliveryOptions_DeliveryOptionId",
                table: "Purchase",
                column: "DeliveryOptionId",
                principalTable: "DeliveryOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_PaymentOptions_PaymentOptionId",
                table: "Purchase",
                column: "PaymentOptionId",
                principalTable: "PaymentOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_DeliveryOptions_DeliveryOptionId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_PaymentOptions_PaymentOptionId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_DeliveryOptionId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_PaymentOptionId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "DeliveryOptionId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "PaymentOptionId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "Products",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
