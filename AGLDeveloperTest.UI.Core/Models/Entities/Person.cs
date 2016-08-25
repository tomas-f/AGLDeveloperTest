﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLDeveloperTest.UI.Core.Models.Entities
{
    public class Person
    {
        public string Name { get; set; }
		public string Gender { get; set; }
		public int Age { get; set; }
		public IEnumerable<Pet> Pets { get; set; }
    }
}
