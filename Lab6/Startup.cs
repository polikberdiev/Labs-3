using System.Linq;
using Lab6.BL.Helpers;
using Lab6.BL.Services;
using Lab6.DAL;
using Lab6.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab6
{
    public class Startup
    {
        private readonly IConfiguration _configuration;


        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<Lab6DbContext>(o => o.UseSqlServer(_configuration.GetConnectionString("Lab6DbConnectionString")));
            services.AddUnitOfWork<Lab6DbContext>();

            services.AddSingleton<IBonusCalculator, BonusCalculator>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountTypeService, AccountTypeService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            UpdateDatabase(app);

            app.UseStaticFiles();
            app.UseMvc(routes => { routes.MapRoute("default", "{controller=Home}/{action=Accounts}/{id?}"); });
        }


        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            using (var context = serviceScope.ServiceProvider.GetRequiredService<Lab6DbContext>())
            {
                context.Database.Migrate();
                context.Database.EnsureCreated();

                if (!context.Set<UserModel>().Any())
                {
                    var user = new UserModel { Name = "Stalin" };
                    context.Add(user);

                    var baseAccountType = new AccountTypeModel { Name = "Base", BonusPercent = 3 };
                    var goldAccountType = new AccountTypeModel { Name = "Gold", BonusPercent = 23 };
                    var platinumAccountType = new AccountTypeModel { Name = "Platinum ", BonusPercent = 43 };
                    context.AddRange(baseAccountType, goldAccountType, platinumAccountType);

                    context.Add(new AccountModel { OwnerUser = user, AccountType = baseAccountType, Balance = 444, Bonus = 23, Number = "DX234(base)" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = goldAccountType, Balance = 64, Bonus = 22, Number = "DX235(gold)" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX236(plat)" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2362" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2364" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2365" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2366" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2367" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2368" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2368" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2369" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2376" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2356" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2336" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2316" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2326" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2364" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2365" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2366" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2367" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2368" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2368" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2369" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2376" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2356" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2336" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2316" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2326" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2364" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2365" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2366" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2367" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2368" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2368" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2369" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2376" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2356" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2336" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2316" });
                    context.Add(new AccountModel { OwnerUser = user, AccountType = platinumAccountType, Balance = 42, Bonus = 266, Number = "DX2326" });

                    context.SaveChanges();
                }
            }
        }
    }
}