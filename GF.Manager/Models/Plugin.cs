﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GF.Manager.Models
{
    public class Plugin
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ServerUrl { get; set; }

        public IReadOnlyList<PluginItem> Items { get; set; }
    }
}