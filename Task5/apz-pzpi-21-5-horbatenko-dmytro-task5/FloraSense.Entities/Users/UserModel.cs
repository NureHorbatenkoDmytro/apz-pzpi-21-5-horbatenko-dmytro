namespace FloraSense.Entities.Users
{
    public class UserModel
    {
        public Guid? Id { get; set; } = null;
        public string? Email { get; set; } = null;

        public bool IsEmpty => Id is null && Email is null;
    }
}
