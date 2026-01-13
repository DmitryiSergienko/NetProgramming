namespace HTTP.Models
{
    public record Person
    {
        public Guid Id { get; init; } = Guid.CreateVersion7();
        public required string LastName { get; init; }
        public required string FirstName { get; init; }
    }
}