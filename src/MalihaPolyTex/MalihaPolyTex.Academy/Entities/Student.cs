﻿using DevSkill.Data;
using System;

namespace MalihaPolyTex.Academy.Entities
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeptId { get; set; } 
        public Department Dept { get; set; }
        public DateTime DateOfBirth { get; set; } 
    }
}