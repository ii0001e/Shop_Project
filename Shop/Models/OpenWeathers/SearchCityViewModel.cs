﻿using System.ComponentModel.DataAnnotations;

namespace Shop.Models.OpenWeathers
{
    public class SearchCityViewModel
    {
        [Required(ErrorMessage = "You must enter a city name")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a city name greater than 2 and less than 20 characters")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }


    }
}
