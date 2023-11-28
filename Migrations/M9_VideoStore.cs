using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(9)]
    public class M9_VideoStore : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("VideoToStore")
                .OnTable("Video")
                .InSchema("videostore");

            Delete.Column("Store_Id")
                .FromTable("Video")
                .InSchema("videostore");
        }

        public override void Up()
        {
            Create.Column("Store_Id")
                .OnTable("Video")
                .InSchema("videostore")
                .AsString(255)
                .Nullable();

            Create.ForeignKey("VideoToStore")
                .FromTable("Video")
                .InSchema("videostore")
                .ForeignColumn("Store_Id")
                .ToTable("Store")
                .InSchema("videostore")
                .PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.SetNull)
                .OnUpdate(System.Data.Rule.Cascade);
        }
    }
}
