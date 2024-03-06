using System.Data.SQLite;

namespace HexagonalMinimalAPI
{
    public class FakeUserDb : IUserDB
    {
        private readonly List<User> _fakeUsers;

        public FakeUserDb()
        {
            _fakeUsers = new List<User>();
        }

        public List<User> GetAllUsers()
        {
            return _fakeUsers;
        }

        public User GetUserById(int id)
        {
            return _fakeUsers.Find(user => user.Id == id);
        }

        public void AddUser(User user)
        {
            _fakeUsers.Add(user);
        }

        public void UpdateUser(User user)
        {
            var existingUser = _fakeUsers.Find(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;
            }
        }

        public void DeleteUser(int id)
        {
            _fakeUsers.RemoveAll(user => user.Id == id);
        }
    }
}
