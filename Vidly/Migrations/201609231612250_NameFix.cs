namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SingUpFee", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "SignupFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "SignupFee", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "SingUpFee");
        }
    }
}
