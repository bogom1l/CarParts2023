using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CarParts.Data.Models
{
    public class UserFavoritePart
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;


        [ForeignKey(nameof(Part))]
        public int PartId { get; set; }
        public Part Part { get; set; } = null!;

    }
}
