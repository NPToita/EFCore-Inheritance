using EfCore.Domain;
using System;
using System.Collections;
using System.Collections.Generic;

namespace EfCore.Data
{
    public class MyUser : User
    {
        public string PhoneNumber { get; set; }
    }
}
