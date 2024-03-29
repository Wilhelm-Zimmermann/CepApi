﻿namespace CepApi.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public User(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdatePassword(string password) 
        {
            Password = password;    
        }

        public void UpdateRole(string role)
        {
            Role = role;
        }
    }
}
