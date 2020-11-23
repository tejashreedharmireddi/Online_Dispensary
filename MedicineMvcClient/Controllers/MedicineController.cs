using MedicineMvcClient.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MedicineMvcClient.Controllers
{
    public class MedicineController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SearchMedicineByName model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44307");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));
            var response = await client.GetAsync("/api/Medicine/GetDetails/"+model.Name);

            MedicineListModel medicine = new MedicineListModel();


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                medicine = JsonConvert.DeserializeObject<MedicineListModel>(jsonContent);
                return RedirectToAction("GetMedicine", medicine); 
                
                


            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public  IActionResult GetMedicine()
        {
            MedicineListModel m = new MedicineListModel();
            return View(m);
           
        }
    }
}
