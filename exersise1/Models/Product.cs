﻿using System.Reflection;

namespace exersise1.Models
{
    public class Product 
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public string prand {  get; set; }
        public string Category { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }
        public string Imgurl { get; set; } = "";

        public DateTime TimeCr {  get; set; }


    }
}
