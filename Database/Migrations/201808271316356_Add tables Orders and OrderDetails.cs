namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtablesOrdersandOrderDetails : DbMigration
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
                    "dbo.OrderDetails",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .PrimaryKey(t => new { t.OrderId, t.BookId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.BookId);
        }
        
        public override void Down()
        {
            
        }
    }
}
