namespace WebApi.Dtos
{
    public class UserDto
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
    }
}