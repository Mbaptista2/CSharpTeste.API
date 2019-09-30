using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;
using CSharp.Infra.Migration.Base;

namespace CSharp.Infra.Migration
{
    [MigrationBase(1, "Tools")]
    public class BaseLine : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Hotel")
                  .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                  .WithColumn("Nome").AsAnsiString(100).NotNullable()
                  .WithColumn("Classificacao").AsInt32().NotNullable();


            Create.Table("Hotel_Taxas")
               .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
               .WithColumn("Id_Hotel").AsInt32().NotNullable()
               .WithColumn("Tipo_Cliente").AsAnsiString(20).NotNullable()
               .WithColumn("Dia_Semana").AsAnsiString(20).NotNullable()
               .WithColumn("Valor").AsDecimal(5, 2);


            Create.ForeignKey("FK_Hotel_Taxas_Hotel")
               .FromTable("Hotel_Taxas")
               .ForeignColumns("Id_Hotel")
               .ToTable("Hotel")
               .PrimaryColumns("Id");
        }


        public override void Down()
        {
            Delete.Table("Hotel");
            Delete.Table("Hotel_Taxas");


        }

        
    }
}
