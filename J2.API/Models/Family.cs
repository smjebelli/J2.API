﻿namespace J2.API.Models
{
    public class Family:BaseEntity
    {
        public string FamilyName { get; set; }
        public List<User> Users { get; set; }
    }
}