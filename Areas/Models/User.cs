namespace Areas.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Remember { get; set; }
    }

    public class UserInit
    {
        public static List<User> Init()
        {
            return new List<User>()
            {
                new User(){ Username = "Ali", Password = "123456", Remember = "on"},
                new User(){ Username = "Can", Password = "123456", Remember = "off"},
                new User(){ Username = "Mehmet", Password = "123456", Remember = "off"},
                new User(){ Username = "Mustafa", Password = "123456", Remember = "on"}
            };
        }
    }
}
