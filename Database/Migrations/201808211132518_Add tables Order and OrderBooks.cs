namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddtablesOrderandOrderBooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Orders",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderName = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        PaymentType = c.String(),
                        Status = c.String(),
                        CustomerName = c.String(),
                        CustomerSurname = c.String(),
                        CustomerPhone = c.String(),
                        CustomerEmail = c.String(),
                        CustomerAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.OrderBooks",
                    c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false)
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Book_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Book_Id);


        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.OrderBooks", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderBooks", new[] { "Book_Id" });
            DropIndex("dbo.OrderBooks", new[] { "Order_Id" });
            DropTable("dbo.OrderBooks");
            DropTable("dbo.Orders");
        }
    }
}
