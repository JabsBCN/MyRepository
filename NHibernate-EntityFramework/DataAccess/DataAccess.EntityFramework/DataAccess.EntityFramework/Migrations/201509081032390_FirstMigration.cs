namespace DataAccess.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Guid(nullable: false, identity: true),
                        ChartOfAccountsId = c.Guid(nullable: false),
                        AccountNumber = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.ChartOfAccounts", t => t.ChartOfAccountsId, cascadeDelete: true)
                .Index(t => t.ChartOfAccountsId);
            
            CreateTable(
                "dbo.ChartOfAccounts",
                c => new
                    {
                        ChartOfAccountsId = c.Guid(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ChartOfAccountsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "ChartOfAccountsId", "dbo.ChartOfAccounts");
            DropIndex("dbo.Accounts", new[] { "ChartOfAccountsId" });
            DropTable("dbo.ChartOfAccounts");
            DropTable("dbo.Accounts");
        }
    }
}
