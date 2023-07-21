﻿using System.ComponentModel.DataAnnotations;

namespace CarParts.Web.ViewModels.Part.PartProperties
{
    public class PartCategoryViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}