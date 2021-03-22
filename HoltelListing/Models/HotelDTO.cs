using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoltelListing.Models
{
    public class CreateHotelDTO
    {
        [Required]
        [StringLength(maximumLength: 200, ErrorMessage = "Hotel Name cannot exceed 200 Characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 200, ErrorMessage = "Hotel Address cannot exceed 200 Characters")]
        public string Address { get; set; }

        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
    public class HotelDTO : CreateHotelDTO
    {
        public int ID { get; set; }
        public CountryDTO Country { get; set; }

    }

}
