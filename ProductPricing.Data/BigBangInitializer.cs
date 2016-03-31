using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProductPricing.Core.Entities;
using System;
using System.Data.Entity;

namespace ProductPricing.Data
{
    public class BigBangInitializer : DropCreateDatabaseIfModelChanges<ProductPricingDbContext>
    {
        protected override void Seed(ProductPricingDbContext context)
        {
            Initialize(context);
            base.Seed(context);
        }

        public void Initialize(ProductPricingDbContext context)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!roleManager.RoleExists("Admin"))
                {
                    roleManager.Create(new IdentityRole("Admin"));
                }

                if (!roleManager.RoleExists("Member"))
                {
                    roleManager.Create(new IdentityRole("Member"));
                }

                var user = new ApplicationUser()
                {
                    Email = "test@test.com",
                    UserName = "test@test.com",
                    Name = "Test Test"
                };

                var userResult = userManager.Create(user, "Admin@123");

                if (userResult.Succeeded)
                {
                    userManager.AddToRole<ApplicationUser, string>(user.Id, "Admin");
                }

                context.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}