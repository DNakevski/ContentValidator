
namespace ContentValidator.Content
{
    /// <summary>
    /// Class that contains user data
    /// </summary>
    public class User
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public User(string name, string surname, string email, int age)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Age = age;
        }

        /// <summary> Name of the user </summary>
        public string Name { get; set; }

        /// <summary> Surname of the user </summary>
        public string Surname { get; set; }

        /// <summary> Email of the user </summary>
        public string Email { get; set; }

        /// <summary> Name of the user </summary>
        public int Age { get; set; }
    }
}
