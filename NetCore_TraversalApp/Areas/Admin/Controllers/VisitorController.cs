using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore_TraversalApp.Areas.Admin.Views;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace NetCore_TraversalApp.Areas.Admin.Controllers
{

    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Visitor")]
    public class VisitorController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public VisitorController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var model = new List<VisitorViewModel>();
            var http = _httpClient.CreateClient();

            var response = await http.GetAsync("https://localhost:7168/api/Visitor/GetVisitor");
            if (response.IsSuccessStatusCode)
            {
                var datas =await  response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<VisitorViewModel>>(datas);    
            }
            return View(model);
        }

        [HttpGet]
        [Route("AddNewVisitor")]
        public async Task<IActionResult> AddNewVisitor()
        {

            return View();
        }

        [HttpPost]
        [Route("AddNewVisitor")]
        public async Task<IActionResult> AddNewVisitor(VisitorViewModel model)
        {
            if(ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                var http = _httpClient.CreateClient();
                var response = await http.PostAsync("https://localhost:7168/api/Visitor/AddVisitor", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateVisitor/{id}")]
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var http = _httpClient.CreateClient();
            var request = await http.GetAsync($"https://localhost:7168/api/Visitor/GetVisitor/{id.ToString()}");
            var data =  await request.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<VisitorViewModel>(data);
            return View(model);
        }

        [HttpPost]
        [Route("UpdateVisitor/{id}")]
        public async Task<IActionResult> UpdateVisitor(VisitorViewModel model)
        {
            var http = _httpClient.CreateClient();
            var data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            var response = await http.PostAsync("https://localhost:7168/api/Visitor/UpdateVisitor", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Route("DeleteVisitor/{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var http = _httpClient.CreateClient();
            var response = await http.DeleteAsync($"https://localhost:7168/api/Visitor/DeleteVisitor/{id.ToString()}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
