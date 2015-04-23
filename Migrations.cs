using System;
using System.Collections.Generic;
using System.Data;
using Futurify.Training.Employees.Models;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Futurify.Training.Employees
{
    public class Migrations: DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("EmployeesPartRecord",table => table
                .ContentPartRecord()
                .Column("Name",DbType.String)
                .Column("Address", DbType.String)
                .Column("Age", DbType.Int32)

              );
            ContentDefinitionManager.AlterPartDefinition(
               typeof(EmployeesPart).Name, cfg => cfg.Attachable());
            return 1;
        }
        public int UpdateFrom1()
        {

            ContentDefinitionManager.AlterTypeDefinition("Employees", type => type
                .Creatable()
                .WithPart("EmployeesPart")
                .WithPart("BodyPart")
                .WithPart("TitlePart") );

            return 2;
        }

        public int UpdateFrom2()
        {

            ContentDefinitionManager.AlterTypeDefinition("Employees", type => type
                .WithPart("CommonPart"));

            return 3;
        }

        public int UpdateFrom3()
        {
            ContentDefinitionManager.AlterTypeDefinition("Employees", type => type.RemovePart("BodyPart"));
            return 4;
        }
        public int UpdateFrom4()
        {
            ContentDefinitionManager.AlterPartDefinition(
               "EmployeesPartRecord"
               , b => b
                   .Attachable()
                   .WithField("Birthday", cfg => cfg.OfType("DateTimeField")
                   .WithDisplayName("Ngày sinh"))
           );
            return 5;
        }
        public int UpdateFrom5()
        {
            ContentDefinitionManager.AlterPartDefinition(
               "EmployeesPartRecord"
               , b => b
                   .Attachable()
                   .WithField("Birthday", cfg => cfg.OfType("DateTimeField")
                   .WithDisplayName("Ngày sinh"))
           );
            return 6;
        }

        public int UpdateFrom6() {
            ContentDefinitionManager.AlterPartDefinition(
               "BirthdayPart"
               , b => b
                   .Attachable()
                   .WithField("BirthdayField", cfg => cfg.OfType("DateTimeField")
                   .WithDisplayName("Ngày sinh"))
           );
            ContentDefinitionManager.AlterTypeDefinition("Employees", type => type
                .WithPart("BirthdayPart"));
            return 7;
        }
    }
}