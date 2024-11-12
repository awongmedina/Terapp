using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Terapp.UI
{
    public partial class TerapiModel : DbContext
    {
        public TerapiModel()
            : base("name=TerapiModel")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
