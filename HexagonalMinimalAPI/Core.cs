namespace HexagonalMinimalAPI
{
    public interface IUserDB
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class Core
    {
        private readonly UserDb _userDb;

        public Core()
        {
            _userDb = new UserDb();
        }

        public User GetUserById(int id)
        {
            return _userDb.GetUserById(id);
        }

        public List<User> GetAllUsers()
        {
            return _userDb.GetAllUsers();
        }
        public void AddUser(User user)
        {
            _userDb.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            _userDb.UpdateUser(user);
        }
        public void DeleteUser(int id)
        {
            _userDb.DeleteUser(id);
        }
    }
}
