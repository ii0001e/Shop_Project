using Microsoft.AspNetCore.Http;

namespace Shop.Core.Dto
{
    public class KinderGartenDto
    {
        public Guid? Id { get; set; }
        public string GroupName { get; set; }

        public int ChildrenCount { get; set; }

        public string KindergartenName { get; set; }

        public string Teacher { get; set; }

        public List<IFormFile> Files { get; set; }



        //database

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
