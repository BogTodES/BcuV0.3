﻿using System;
using BcuV0._3.Models.Scaffold2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BcuV0._3.Areas.Identity.IdentityHostingStartup))]
namespace BcuV0._3.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<Var_2Context>();
            });
        }
    }
}