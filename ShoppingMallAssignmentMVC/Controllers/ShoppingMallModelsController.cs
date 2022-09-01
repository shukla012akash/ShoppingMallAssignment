using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingMallAssignmentDB.Models;
using ShoppingMallAssignmentMVC.Models;
using System.Text;

namespace ShoppingMallAssignmentMVC.Controllers
{
    [Authorize(Policy = "readonly")]
    public class ShoppingMallModelsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7244/api");
        HttpClient client;
        private readonly IMapper _mapper;

        public ShoppingMallModelsController(IMapper mapper)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _mapper = mapper;
        }
       
        public IActionResult PartialIndex()
        {

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ShoppingMallModels").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<ShoppingMallAssignmentDB.Models.ShoppingMallModel>>(data)!;
                var mallList = _mapper.Map<List<Models.ShoppingMallModelMVC>>(list);
                mallList = mallList.OrderByDescending(m => m.YearBuilt).ToList();
                mallList = mallList.OrderBy(n => n.ShoppingMallName).ToList();         
                return View(mallList);
            }
            else
                return View();

        }
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult CreateOrUpdate(ShoppingMallAssignmentDB.Models.ShoppingMallModel shoppingMall)
        {
            string data = JsonConvert.SerializeObject(shoppingMall);
            StringContent stringContent = new(data, Encoding.UTF8, "application/json");

            if (shoppingMall.ID == 0)
            {
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/ShoppingMallModels", stringContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("PartialIndex");
                }
                return View("Create", shoppingMall);
            }
            else
            {
                HttpResponseMessage response = client.PutAsync(client.BaseAddress + $"/ShoppingMallModels?id={shoppingMall.ID}", stringContent).Result;
                return RedirectToAction("PartialIndex");
            }
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"/ShoppingMallModels/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("PartialIndex");
            }
            return BadRequest("Something went Wrong");
        }

        public ActionResult Edit(ShoppingMallAssignmentDB.Models.ShoppingMallModel shoppingMall)
        {
            return View("Create", shoppingMall);
        }

    }
}
