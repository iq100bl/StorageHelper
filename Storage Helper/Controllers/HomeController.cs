using Microsoft.AspNetCore.Mvc;
using Storage_Helper.Models;
using System.Diagnostics;
using Core;

namespace Storage_Helper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransferService _transferService;

        public HomeController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        public IActionResult Index()
        {
            var storages = _transferService.GetStorages();

            var storagesView = new List<StorageViewModel>();
            foreach(var storage in storages)
            {
                var itemList = new List<ItemViewModel>();
                foreach(var item in storage.ItemOnStorages)
                {
                    itemList.Add(new ItemViewModel { Id = item.Id, NomenclatureDescribtion = item.Nomenclature.Description, Count = item.Count, });
                }
                storagesView.Add(new StorageViewModel { Id = storage.Id, Name = storage.Name, Items = itemList.ToArray()});
            }

            return View(storagesView.ToArray());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}