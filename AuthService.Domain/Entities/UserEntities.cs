namespace AuthService.Domain.Entities
{
    public class UserEntities
    {
        private UserEntities() { }

        public UserEntities(string email, string passwordHash, string role = "User")
        {
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Email { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;
        public string Role { get; private set; } = "User";
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public void UpdatePassword(string newHash) => PasswordHash = newHash;
        public void SetRole(string role) => Role = role;
    }
}
