namespace Shop.Models.Realestate
{
    public class RealEstateDetailsViewModel
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public float SizeSqrM { get; set; }
        public int RoomCount { get; set; }

        public int Floor { get; set; }
        public string BuildingType { get; set; }

        public DateTime BuiltinYear { get; set; }


        public List<ImageToDatabaseViewModel> Image { get; set; }
            = new List<ImageToDatabaseViewModel>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
