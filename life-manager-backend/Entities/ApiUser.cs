namespace life_manager_backend.Entities
{
    public class ApiUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }
        public bool IsBanned { get; set; }
        public string PartitionKey { get; set; } = "1";

        public ApiUser(
            string username,
            string password,
            string email,
            DateTime registeredAt,
            bool isBanned)
        {
            Username = username;
            Password = password;
            Email = email;
            RegisteredAt = registeredAt;
            IsBanned = isBanned;
            Id = Guid.NewGuid().ToString();
        }
    }
}