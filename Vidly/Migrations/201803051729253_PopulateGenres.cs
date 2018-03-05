namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class PopulateGenres : DbMigration
	{
		public override void Up()
		{
			Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Comedy')");
			Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Action')");
			Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Horror')");
			Sql("INSERT INTO Genres (Id, Name) VALUES (4,'Science Fiction')");
			Sql("INSERT INTO Genres (Id, Name) VALUES (5,'Romance')");
			Sql("INSERT INTO Genres (Id, Name) VALUES (6,'Drama')");
		}
		
		public override void Down()
		{
		}
	}
}
