using imageuploading.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace imageuploading.Controllers
{
    public class HomeController : Controller
    {

        Context c = new Context();

        public IActionResult Index() {


            return View();

        }

        [HttpGet]

        public IActionResult formitem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult formitem(ItemImage item)
        {

            c.itemImages.Add(item);
            c.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Privacy()
        {


            return View();


        }
        [HttpPost]
        public async Task<IActionResult> Privacy(IFormFile file) {
            ItemImage ıtemImage = new ItemImage();


            if (file != null)//post edilen form boş değilse
            {
                

                var uzantı = Path.GetExtension(file.FileName);//uzantı aldık

              string  randomname = string.Format($"{Guid.NewGuid()}{uzantı}");//ratgele isim belirlendi


                ıtemImage.Name = randomname;//file urlsi itemin urlye aktarılır

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomname);// path kaydediliyor

                ıtemImage.Url = path;

                c.Add(ıtemImage);
                c.SaveChanges(); 

                using (var stream=new FileStream(path,FileMode.Create))//dosya dizine kaydediliyor
                {
                   await file.CopyToAsync(stream);
                }
            }




            return View();


        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
