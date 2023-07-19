﻿using CarParts.Data.Models;
using CarParts.ViewModels.Part;

namespace CarParts.Services
{
    public interface IPartService
    {
        Task<ICollection<PartViewModel>> GetAllPartsAsync();

        Task<AddPartViewModel> GetAddPartViewModelAsync();

        Task AddPartAsync(AddPartViewModel addPartViewModel, string userId);

        Task<DetailsPartViewModel?> GetPartDetailsAsync(int id);

        Task<Part?> GetPartByIdAsync(int id);

        Task<EditPartViewModel?> GetEditPartViewModelAsync(int id, string userId);

        Task EditPartAsync(int id, EditPartViewModel editPartViewModel);

    }
}
