using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FTPTester.Models;
using FluentFTP;
using FTPTester.Services;
using Microsoft.AspNetCore.Http;

namespace FTPTester.Controllers
{
    public class HomeController : Controller
    {
        Service _service;

        public HomeController()
        {
            _service = new Service();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload(IFormFile file)
        {
            _service.Upload(file.FileName);
            //_service.Upload(file.FileName);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Download(string nome)
        {
            _service.Download(nome);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Move(IFormFile file)
        {
            _service.Move(file.FileName);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
