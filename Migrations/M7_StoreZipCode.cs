using FluentMigrator;

namespace Migrations
{
    [Migration(7)]
    public class M7_StoreZipCode : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("StoreToZipCode")
                .OnTable("Store")
                .InSchema("videostore");

            Delete.Column("ZipCode_Id")
                .FromTable("Store")
                .InSchema("videostore");
        }

        public override void Up()
        {
            Create.Column("ZipCode_Id")
                .OnTable("Store")
                .InSchema("videostore")
                .AsString(255)
                .Nullable();

            Create.ForeignKey("StoreToZipCode")
                .FromTable("Store")
                .InSchema("videostore")
                .ForeignColumn("ZipCode_Id")
                .ToTable("ZipCode")
                .InSchema("videostore")
                .PrimaryColumn("Code")
                .OnDelete(System.Data.Rule.SetNull)
                .OnUpdate(System.Data.Rule.Cascade);             
        }
    }
}
