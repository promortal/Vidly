namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class PopulateMembershipTypeNames : DbMigration
	{
		public override void Up()
		{
			Sql("UPDATE MembershipTypes Set Name = 'Pay as You Go' WHERE DurationInMonths = 0");
			Sql("UPDATE MembershipTypes Set Name = 'Monthly' WHERE DurationInMonths = 1");
			Sql("UPDATE MembershipTypes Set Name = '90-Day' WHERE DurationInMonths = 3");
			Sql("UPDATE MembershipTypes Set Name = 'Annual' WHERE DurationInMonths = 12");
		}
		
		public override void Down()
		{
		}
	}
}
