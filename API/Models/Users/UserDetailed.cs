﻿using API.Models.Contacts;
using API.Models.Lunch;
using System;
using System.Collections.Generic;

namespace API.Models.Users
{
    public class UserDetailed
    {
        public int Id { get; set; }
        public string NationalNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthdate { get; set; }
        public string AdCity { get; set; }
        public int AdPostalCode { get; set; }
        public string AdStreet { get; set; }
        public int AdNumber { get; set; }
        public string AdBox { get; set; }
        public string MobilePhone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public string PersonalNote { get; set; }
        public string Token { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FirstLogin { get; set; }
        public string Email { get; set; }
        public int? ClassId { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Lunch.Lunch> Lunches { get; set; }
        public int StatusCode { get; set; }

    }
}
