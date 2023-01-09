using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json;
using RestSharp;
using System.Drawing;
using System.Net;
using TesteCastGroup.MVC.Models;

namespace TesteCastGroup.MVC.Controllers
{
    public class ContaController : Controller
    {
        // GET: ContaController1
        public async Task<ActionResult> Index()
        {
            IEnumerable<ContaViewModel> contas = null;
            var client = new RestClient("https://localhost:44378/api/");

            var request = new RestRequest("conta", RestSharp.Method.Get);
            var response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
                contas = JsonConvert.DeserializeObject<List<ContaViewModel>>(response.Content);

            else
            {
                contas = Enumerable.Empty<ContaViewModel>();
                ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
            }
            return View(contas);
        }

        // GET: ContaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContaController/Create
        [HttpPost]
        public ActionResult Create(ContaViewModel conta)
        {
            var client = new RestClient("https://localhost:44378/api/");

            var request = new RestRequest("conta", RestSharp.Method.Post);
            request.AddParameter("application/json", JsonConvert.SerializeObject(conta), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = client.ExecuteAsync(request);

            if (response.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(conta);
        }

        // GET: ContaController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            IEnumerable<ContaViewModel> contas = null;
            var client = new RestClient("https://localhost:44378/api/");

            var request = new RestRequest("conta", RestSharp.Method.Get);
            var response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
                contas = JsonConvert.DeserializeObject<List<ContaViewModel>>(response.Content);

            else
            {
                contas = Enumerable.Empty<ContaViewModel>();
                ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
            }
            ContaViewModel conta = contas.Where(c => c.ContaId == id).FirstOrDefault();
            return View(conta);
        }

        // POST: ContaController/Edit/5
        [HttpPost]
        public ActionResult Edit(ContaViewModel conta)
        {
            var client = new RestClient("https://localhost:44378/api/");
            var request = new RestRequest("conta", RestSharp.Method.Put);
            request.AddParameter("application/json", JsonConvert.SerializeObject(conta), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = client.ExecuteAsync(request);

            if (response.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(conta);
        }

        // GET: ContaController1/Delete/5
        public ActionResult Delete(int id)
        {
            var client = new RestClient("https://localhost:44378/api/");
            var request = new RestRequest("conta?id=" + id, RestSharp.Method.Delete);
            var response = client.ExecuteAsync(request);

            if (response.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return RedirectToAction("Index");
        }

        // POST: ContaController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
