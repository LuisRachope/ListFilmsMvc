using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListFilmsMvc.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void CheckLogin()
        {
            Response.Redirect("/Home/Index");
        }
    }
}





//Continuar aqui: https://www.youtube.com/watch?v=NdIdjQeIpfA