﻿using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace PontoAPI.Core.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

    }
}
