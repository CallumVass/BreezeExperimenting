namespace BreezeExperimenting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMaxLengthToLocation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Location", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Location", c => c.String(nullable: false));
        }
    }
}
