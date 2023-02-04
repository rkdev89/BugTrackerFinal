using AutoMapper;
using BugTracker_Web.Models;
using BugTracker_Web.Models.Dto;
using BugTracker_Web.Services;
using BugTracker_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace BugTracker_Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexUser()
        {
            List<UserDTO> list = new();

            var response = await _userService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<UserDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexUser));
                }
            }
            return View(model);
        }
        public async Task<IActionResult> UpdateUser(int userId)
        {
            var response = await _userService.GetAsync<APIResponse>(userId);
            if (response != null && response.IsSuccess)
            {
                UserDTO model = JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<UserUpdateDTO>(model));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexUser));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteUser(int userId)
        {
            var response = await _userService.GetAsync<APIResponse>(userId);
            if (response != null && response.IsSuccess)
            {
                UserDTO model = JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(UserDTO model)
        {

            var response = await _userService.DeleteAsync<APIResponse>(model.Id);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexUser));
            }

            return View(model);
        }
    }
}
