using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ProjetoCMTech.Model.Context;

namespace ProjetoCMTech.Migrations
{
    [DbContext(typeof(PostgreSQLContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
        }
    }
}
