using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Yr25Mango.Web.Models.DTO;
using Yr25Mango.Web.Service.IService;
using Yr25Mango.Web.Utility;

namespace Yr25Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO loginRequestDTO = new();

            return View(loginRequestDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO obj)
        {
            ResponseDTO result = await _authService.LoginAsync(obj);
            if(result !=null && result.IsSuccess)
            {
                LoginResponseDTO loginResponseDTO = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(result.Result));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", result.Message);
                return View(obj);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RoleAdmin, Value=SD.RoleAdmin},
                  new SelectListItem{Text=SD.RoleCustomer, Value=SD.RoleCustomer},
            };

            ViewBag.RoleList = roleList;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDTO obj)
        {

            ResponseDTO result = await _authService.RegisterAsync(obj);
            ResponseDTO assignRole;

            if(result!=null && result.IsSuccess)
            {
                if(string.IsNullOrEmpty(obj.Role))
                {
                    obj.Role = SD.RoleCustomer;
                }
                assignRole = await _authService.AssignRoleAsync(obj);
                if(assignRole!=null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Registration done";
                    RedirectToAction(nameof(Login));
                }
            }
                 var roleList = new List<SelectListItem>()
                {
                    new SelectListItem{Text=SD.RoleAdmin, Value=SD.RoleAdmin},
                    new SelectListItem{Text=SD.RoleCustomer, Value=SD.RoleCustomer},
                };

                ViewBag.RoleList = roleList;
             
            return View(obj);
        }


        [HttpGet]
        public IActionResult Logout()
        {
            // RegisterRequestDTO regRequestDTO = new();

            return View();
        }
    }
}
