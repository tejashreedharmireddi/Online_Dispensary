using Medicine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Repository
{
    public interface IMedicineRepository
    {
        public Task<MedicineListModel> GetName(string Name);
    }
}
