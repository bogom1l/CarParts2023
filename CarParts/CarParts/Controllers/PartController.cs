﻿using CarParts.Data.Models;
using CarParts.Services;
using CarParts.ViewModels.Part;

namespace CarParts.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PartController : BaseController
    {
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            this._partService = partService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var parts = await this._partService.GetAllPartsAsync();

            return View(parts);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddPartViewModel part = await this._partService.GetAddPartViewModelAsync();

            return View(part);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPartViewModel addPartViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addPartViewModel);
            }
            
            await this._partService.AddPartAsync(addPartViewModel, GetUserId());

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var detailsPartViewModel = await this._partService.GetPartDetailsAsync(id);

            if (detailsPartViewModel == null)
            {
                RedirectToPage("All");
            }

            return View(detailsPartViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Part? part = await this._partService.GetPartByIdAsync(id);

            if (part == null)
            {
                return RedirectToAction("All");
            }

            if (part.UserId != GetUserId())
            {
                return RedirectToAction("All");
            }

            var editPartViewModel = await this._partService.GetEditPartViewModelAsync(id, GetUserId());

            if (editPartViewModel == null)
            {
                RedirectToPage("All");
            }

            return View(editPartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPartViewModel part)
        {
            if (!ModelState.IsValid)
            {
                return View(part);
            }

            await this._partService.EditPartAsync(id, part);

            return RedirectToAction("All");
        }



    }
}
