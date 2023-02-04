using AutoMapper;
using BugTracker_Web.Models;
using BugTracker_Web.Models.Dto;
using BugTracker_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace BugTracker_Web.Controllers
{
    public class BugController : Controller
    {
        private readonly IBugService _bugService;
        private readonly IMapper _mapper;

        public BugController(IBugService bugService, IMapper mapper)
        {
            _bugService = bugService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexBug()
        {
            List<BugDTO> list = new();

            var response = await _bugService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BugDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> CreateBug()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBug(BugCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bugService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexBug));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateBug(int bugId)
        {
            var response = await _bugService.GetAsync<APIResponse>(bugId);
            if (response != null && response.IsSuccess)
            {
                BugDTO model = JsonConvert.DeserializeObject<BugDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<BugUpdateDTO>(model));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBug(BugUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bugService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexBug));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteBug(int bugId)
        {
            var response = await _bugService.GetAsync<APIResponse>(bugId);
            if (response != null && response.IsSuccess)
            {
                BugDTO model = JsonConvert.DeserializeObject<BugDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBug(BugDTO model)
        {
            var response = await _bugService.DeleteAsync<APIResponse>(model.Id);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexBug));
            }

            return View(model);
        }
    }
}
