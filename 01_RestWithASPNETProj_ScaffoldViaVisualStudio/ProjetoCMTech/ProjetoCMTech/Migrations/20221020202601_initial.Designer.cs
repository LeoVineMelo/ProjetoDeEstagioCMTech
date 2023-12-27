using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjetoCMTech.Model.Context;

namespace ProjetoCMTech.Migrations
{
    [DbContext(typeof(PostgreSQLContext))]
    [Migration("20221020202601_initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
        }
    }
}
