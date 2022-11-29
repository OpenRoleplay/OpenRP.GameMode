﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpenRP.GameMode.Data.Models
{
    public class Character
    {
        public ulong Id { get; set; }
        [Column(TypeName = "varchar(35)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string MiddleName { get; set; }
        [Column(TypeName = "varchar(35)")]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Accent { get; set; }
        public Inventory Inventory { get; set; }
    }
}