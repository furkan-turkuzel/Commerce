﻿using CommerceSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSite.Model.Entities
{
    public class Blog : IEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string Image { get; set; }
    }
}
