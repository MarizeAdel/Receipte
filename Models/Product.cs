﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
       public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Balance { get; set; }

    }
}
