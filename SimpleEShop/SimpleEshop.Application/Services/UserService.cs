using SimpleEshop.Domain;

namespace SimpleEshop.Application.Services
{
    public class UserService : IUserService
    {
        private List<User> users = new List<User>
        {
            new User{Id=1, UserName="turkay", Password="123", Email="a@b.com", FullName="Türkay Ürkmez" , Role="admin"},
            new User{Id=2, UserName="kemal", Password="123", Email="a@b.com", FullName="Türkay Ürkmez" , Role="editor"},
            new User{Id=3, UserName="sinem", Password="123", Email="a@b.com", FullName="Türkay Ürkmez" , Role="client"}
        };

        public User ValidateUser(string userName, string password)
        {
            return users.SingleOrDefault(u => u.UserName == userName && u.Password == password);

        }
    }
}
