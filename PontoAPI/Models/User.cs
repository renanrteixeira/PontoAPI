﻿using System.ComponentModel.DataAnnotations;

namespace PontoAPI.Models
{
    public class User
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Email { get; set; }

        [Required, StringLength(255)]
        public string Password { get; set; }

        [Required, StringLength(1)]
        public char Admin { get; set; }

        [Required, StringLength(1)]
        public char Status { get; set; }
    }
}
