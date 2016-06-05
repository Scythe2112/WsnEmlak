using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Emlak.BLL.Account;
using Emlak.ENTITY.IdentyModels;
using Microsoft.AspNet.Identity;

namespace Emlak.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Site için role tanımlamaları yapılıyor:
            var roleManager = MemberShipTools.NewRoleManager();
            if (!roleManager.RoleExists("Admin"))
            {
                ApplicationRole rol = new ApplicationRole()
                {
                    Name = "Admin",
                    Description = "Site Yöneticisi"
                };

                roleManager.Create(rol);
            }

            if (!roleManager.RoleExists("User"))
            {
                ApplicationRole rol = new ApplicationRole()
                {
                    Name = "User",
                    Description = "Üye"
                };

                roleManager.Create(rol);
            }

            if (!roleManager.RoleExists("Banned"))
            {
                ApplicationRole rol = new ApplicationRole()
                {
                    Name = "Banned",
                    Description = "Yasaklı Üye"
                };

                roleManager.Create(rol);
            }
        }
    }
}
