﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFishShop.Web.Models.Automapper
{
    public interface IHaveCustomMapping
    {
        void Configure(AutoMapperProfile config);
    }
}
