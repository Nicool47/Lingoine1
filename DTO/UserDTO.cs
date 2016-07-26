using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lingoine1.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string SkypeId { get; set; }
        public bool IsPremium { get; set; }
        public bool Gender { get; set; }
        public bool IsOnline { get; set; }
        public bool IsBusy { get; set; }
    }
}