using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Infra.Migration.Base
{
    public class MigrationBaseAttribute : MigrationAttribute
    {
        public new long Version { get; }
       
        public MigrationBaseAttribute(int versionNumber, string author)
            : base(versionNumber)
        {
            Author = author;
            Version = versionNumber;
        }

        public string Author { get; set; }
       
    }
}
