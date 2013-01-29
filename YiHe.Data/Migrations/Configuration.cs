using System;
using System.Data.Entity.Migrations;
using YiHe.Model.Navigation;
using YiHe.Model.Security;


namespace YiHe.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<YiHeDataContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(YiHeDataContex context)
        {
            //  This method will be called after migrating to the latest version.

            // user
            context.Users.AddOrUpdate(
                p => p.FirstName,
                new User
                {
                    UserId = 1,
                    Email = "admin",
                    FirstName = "admin",
                    LastName = "admin",
                    Password = "123456",
                    DateCreated = DateTime.Now,
                    LastLoginTime = DateTime.Now,
                    Activated = true,
                    RoleId = 15,
                }
                );

            // menu
            var home = new Menu
                       {
                           MenuId = 1,
                           MenuText = "首页",
                           Position = 1,
                           UrlController = "Home",
                           UrlAction = "Index",
                           BackgroundImage = "/Images/about/photo/consultingroom1.jpg",
                           Role = 0,
                       };
            var about = new Menu
                        {
                            MenuId = 2,
                            MenuText = "关于我们",
                            Position = 2,
                            UrlController = "About",
                            UrlAction = "Index",
                            BackgroundImage = "/Images/about/photo/office.jpg",
                            Role = 0,
                        };
            var article = new Menu
                          {
                              MenuId = 3,
                              MenuText = "文章",
                              Position = 3,
                              UrlController = "Article",
                              UrlAction = "Index",
                              BackgroundImage = "/Images/about/photo/bookshelf.jpg",
                              Role = 0,
                          };
            var support = new Menu
                          {
                              MenuId = 4,
                              MenuText = "咨询",
                              Position = 4,
                              UrlController = "Support",
                              UrlAction = "Index",
                              BackgroundImage = "/Images/about/photo/clock.jpg",
                              Role = 0,
                          };
            var contact = new Menu
                          {
                              MenuId = 5,
                              MenuText = "联系我们",
                              Position = 5,
                              UrlController = "Contact",
                              UrlAction = "Index",
                              BackgroundImage = "/Images/about/photo/consultingroom3.jpg",
                              Role = 0,
                          };
            var manager = new Menu
                          {
                              MenuId = 6,
                              MenuText = "后台管理",
                              Position = 6,
                              UrlController = "Admin",
                              UrlAction = "Index",
                              BackgroundImage = "/Images/about/photo/rabbit.jpg",
                              Role = 10,
                          };

            context.Menus.AddOrUpdate(
                p => p.MenuText,
                home,
                about,
                article,
                support,
                contact,
                manager,
                new Menu
                {
                    MenuId = 7,
                    MenuText = "成长故事",
                    Position = 1,
                    UrlController = "About",
                    UrlAction = "Index",
                    Parent = about
                },
                new Menu
                {
                    MenuId = 8,
                    MenuText = "咨询师介绍",
                    Position = 2,
                    UrlController = "About",
                    UrlAction = "Staff",
                    Parent = about
                },
                new Menu
                {
                    MenuId = 9,
                    MenuText = "实景图片",
                    Position = 3,
                    UrlController = "About",
                    UrlAction = "Photo",
                    Parent = about
                },
                new Menu
                {
                    MenuId = 10,
                    MenuText = "易禾动态",
                    Position = 4,
                    UrlController = "About",
                    UrlAction = "News",
                    Parent = about
                },
                new Menu
                {
                    MenuId = 11,
                    MenuText = "全部文章",
                    Position = 1,
                    UrlController = "Article",
                    UrlAction = "Index",
                    Parent = article
                },
                new Menu
                {
                    MenuId = 12,
                    MenuText = "服务范围",
                    Position = 1,
                    UrlController = "Support",
                    UrlAction = "Index",
                    Parent = support
                },
                new Menu
                {
                    MenuId = 13,
                    MenuText = "咨询说明",
                    Position = 2,
                    UrlController = "Support",
                    UrlAction = "FQA",
                    Parent = support
                },
                new Menu
                {
                    MenuId = 14,
                    MenuText = "中心开放时间",
                    Position = 3,
                    UrlController = "Support",
                    UrlAction = "OfficeHours",
                    Parent = support
                },
                new Menu
                {
                    MenuId = 15,
                    MenuText = "咨询费用",
                    Position = 4,
                    UrlController = "Support",
                    UrlAction = "Fees",
                    Parent = support
                },
                new Menu
                {
                    MenuId = 16,
                    MenuText = "咨询视频",
                    Position = 5,
                    UrlController = "Support",
                    UrlAction = "Video",
                    Parent = support
                }
                );
        }
    }
}