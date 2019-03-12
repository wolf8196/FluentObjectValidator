using BooleanResultValidationApp.Services;
using DemoApps.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DemoAppNet4_5.Web.Controllers
{
    [Route("api/[controller]")]
    public class DemoController : Controller
    {
        private readonly DemoService demoService;

        public DemoController(DemoService demoService)
        {
            this.demoService = demoService;
        }

        [Route("product")]
        [HttpPost]
        public IActionResult AddProduct(ProductDTO product)
        {
            demoService.AddProduct(product);
            return Ok();
        }

        [Route("user")]
        [HttpPost]
        public IActionResult AddUser(UserDTO user)
        {
            demoService.AddUser(user);
            return Ok();
        }
    }
}