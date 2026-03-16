namespace NZWalksAPIs.Model.DTO
{
    public class Walkdtos
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double LenghtInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        public Regiondto Region { get; set; }

        public Difficultydto Difficulty { get; set; }
    }
}
