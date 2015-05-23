﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proton_CMS.Models
{
    public class TemplateModel
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Author { get; set; }
        public String Version { get; set; }
        public String FolderName { get; set; }
        public String Description { get; set; }
    }
}