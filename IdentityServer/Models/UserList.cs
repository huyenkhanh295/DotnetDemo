namespace IdentityServer.Models
{
    public class UserList
    {
        public static List<User> Users = new List<User>() {
                new User(){ Username = "huyenkhanh1", Password="123456"},
                new User(){ Username = "huyenkhanh2", Password="123456"},
                new User(){ Username = "huyenkhanh3", Password="123456"},
                new User(){ Username = "huyenkhanh4", Password="123456"}
            };
    }
}
