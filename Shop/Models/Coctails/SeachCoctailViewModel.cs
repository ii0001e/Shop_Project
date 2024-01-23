namespace Shop.Models.Coctails
{
    public class SeachCoctailViewModel
    {
        ////[Required(ErrorMessage = "You must enter a coctail")]
        //[RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text")]
        //[StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a coctail name greater than 2 and less than 20 characters")]
        //[Display(Name = "Coctail Name")]
        public string CoctailName { get; set; }
    }
}
