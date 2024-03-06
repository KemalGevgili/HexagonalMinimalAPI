using HexagonalMinimalAPI;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void GetAllUsers_ShouldReturnEmptyList_WhenNoUsersAdded()
        {
            // Arrange
            IUserDB userDb = new FakeUserDb();

            // Act
            var users = userDb.GetAllUsers();

            // Assert
            Assert.Empty(users);
        }

        [Fact]
        public void AddUser_ShouldAddUserToList()
        {
            // Arrange
            IUserDB userDb = new FakeUserDb();
            var user = new User { Id = 1, Name = "John", Surname = "Doe" };

            // Act
            userDb.AddUser(user);
            var users = userDb.GetAllUsers();

            // Assert
            Assert.Single(users);
            Assert.Contains(user, users);
        }

        [Fact]
        public void UpdateUser_ShouldUpdateUserInList()
        {
            // Arrange
            IUserDB userDb = new FakeUserDb();
            var user = new User { Id = 1, Name = "John", Surname = "Doe" };
            userDb.AddUser(user);

            // Act
            var updatedUser = new User { Id = 1, Name = "Updated", Surname = "Surname" };
            userDb.UpdateUser(updatedUser);

            // Assert
            var users = userDb.GetAllUsers();
            var foundUser = users.FirstOrDefault(u => u.Id == updatedUser.Id);

            Assert.NotNull(foundUser);
            Assert.Equal(updatedUser.Name, foundUser.Name);
            Assert.Equal(updatedUser.Surname, foundUser.Surname);
        }


        [Fact]
        public void DeleteUser_ShouldRemoveUserFromList()
        {
            // Arrange
            IUserDB userDb = new FakeUserDb();
            var user = new User { Id = 1, Name = "John", Surname = "Doe" };
            userDb.AddUser(user);

            // Act
            userDb.DeleteUser(1);

            // Assert
            var users = userDb.GetAllUsers();
            Assert.Empty(users);
        }
    }
}