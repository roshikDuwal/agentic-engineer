using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; } = "";
        public string Email { get; private set; } = "";
        private User() { }

        protected User(Guid id, string name, string email, DateTime createdAt, DateTime? updatedAt)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
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

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
            SetUpdatedAt();
        }

    }
}
