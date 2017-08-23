namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes Set Name = 'Pay as you go' WHERE Id = 1");
            Sql("update MembershipTypes Set Name = 'Monthly' WHERE Id = 2");
            Sql("update MembershipTypes Set Name = 'Quarterly' WHERE Id = 3");
            Sql("update MembershipTypes Set Name = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
