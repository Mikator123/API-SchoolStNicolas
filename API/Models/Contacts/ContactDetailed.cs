﻿using API.Models.Users;
using System;
using System.Collections.Generic;

namespace API.Models.Contacts
{
    public class ContactDetailed : Contact
    {

        public IEnumerable<UserForEntities> Users { get; set; }
    }
}
