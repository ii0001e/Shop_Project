namespace Shop.Core.Dto
{
    public class FileToApiDto
    {        //to get img path 
        public Guid Id { get; set; }
        public string ExistingFilePath { get; set; }
        public Guid? SpaceshipId { get; set; }

        public Guid? RealsetateId { get; set; }
    }
}
