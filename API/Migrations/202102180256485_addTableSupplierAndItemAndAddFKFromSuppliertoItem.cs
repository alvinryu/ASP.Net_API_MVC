namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableSupplierAndItemAndAddFKFromSuppliertoItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tb_M_Supplier", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Tb_M_Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_Item", "SupplierId", "dbo.Tb_M_Supplier");
            DropIndex("dbo.Tb_Item", new[] { "SupplierId" });
            DropTable("dbo.Tb_M_Supplier");
            DropTable("dbo.Tb_Item");
        }
    }
}
