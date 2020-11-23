using Medicine.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Repository
{
    public class MedicineRepository:IMedicineRepository
    {
        private readonly MedicineDbContext _context;
        public MedicineRepository(MedicineDbContext context)
        {
            this._context = context;
        }

        public async Task<MedicineListModel> GetName(string Name)
        {
            MedicineListModel medicinedetails = await _context.MedicineList.Where(m => m.Name == Name).FirstOrDefaultAsync();
            return medicinedetails;
        }
    }
}
