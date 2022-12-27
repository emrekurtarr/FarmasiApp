﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Catalog.DAL.Settings
{
    public interface IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
