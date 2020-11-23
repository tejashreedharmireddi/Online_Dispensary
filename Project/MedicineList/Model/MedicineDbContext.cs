using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Medicine.Model
{
    public class MedicineDbContext:DbContext
    {
        public MedicineDbContext(DbContextOptions<MedicineDbContext> options) : base(options)
        {

        }

        public virtual DbSet<MedicineListModel> MedicineList { get; set; }
    }
}
