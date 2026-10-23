using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Domain.Entities
{
    public class  User:BaseEntity
    {
        public string Name { get; private set; } = "";
        public string Email { get; private set; } = "";
        private User() { }
        public static User Create(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be empty.", nameof(email));
            return new User
            {
                Name = name,
                Email = email
            };
        }

    }
}
