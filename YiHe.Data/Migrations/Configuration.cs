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
                           MenuText = "��ҳ",
                           Position = 1,
                           UrlController = "Home",
                           UrlAction = "Index",
                           BackgroundImage = "/Images/about/photo/consultingroom1.jpg",
                           Role = 0,
                       };
            var about = new Menu
                        {
                            MenuId = 2,
                            MenuText = "��������",
                            Position = 2,
                            UrlController = "About",
                            UrlAction = "Index",
                            BackgroundImage = "/Images/about/photo/office.jpg",
                            Role = 0,
                        };
            var article = new Menu
                          {
                              MenuId = 3,
                              MenuText = "����",
                              Position = 3,
                              UrlController = "Article",
                              UrlAction = "Index",
                              BackgroundImage = "/Images/about/photo/bookshelf.jpg",
                              Role = 0,
                          };
            var support = new Menu
                          {
                              MenuId = 4,
                              MenuText = "��ѯ",
                              Position = 4,
                              UrlController = "Support",
                              UrlAction = "Index",
                              BackgroundImage = "/Images/about/photo/clock.jpg",
                              Role = 0,
                          };
            var contact = new Menu
                          {
                              MenuId = 5,
                              MenuText = "��ϵ����",
                              Position = 5,
                              UrlController = "Contact",
                              UrlAction = "Index",
                              BackgroundImage = "/Images/about/photo/consultingroom3.jpg",
                              Role = 0,
                          };
            var manager = new Menu
                          {
                              MenuId = 6,
                              MenuText = "��̨����",
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
                    MenuText = "�ɳ�����",
                    Position = 1,
                    UrlController = "About",
                    UrlAction = "Index",
                    Parent = about
                },
                new Menu
                {
                    MenuId = 8,
                    MenuText = "��ѯʦ����",
                    Position = 2,
                    UrlController = "About",
                    UrlAction = "Staff",
                    Parent = about
                },
                new Menu
                {
                    MenuId = 9,
                    MenuText = "ʵ��ͼƬ",
                    Position = 3,
                    UrlController = "About",
                    UrlAction = "Photo",
                    Parent = about
                },
                new Menu
                {
                    MenuId = 10,
                    MenuText = "�׺̶�̬",
                    Position = 4,
                    UrlController = "About",
                    UrlAction = "News",
                    Parent = about
                },
                new Menu
                {
                    MenuId = 11,
                    MenuText = "ȫ������",
                    Position = 1,
                    UrlController = "Article",
                    UrlAction = "Index",
                    Parent = article
                },
                new Menu
                {
                    MenuId = 12,
                    MenuText = "����Χ",
                    Position = 1,
                    UrlController = "Support",
                    UrlAction = "Index",
                    Parent = support
                },
                new Menu
                {
                    MenuId = 13,
                    MenuText = "��ѯ˵��",
                    Position = 2,
                    UrlController = "Support",
                    UrlAction = "FQA",
                    Parent = support
                },
                new Menu
                {
                    MenuId = 14,
                    MenuText = "���Ŀ���ʱ��",
                    Position = 3,
                    UrlController = "Support",
                    UrlAction = "OfficeHours",
                    Parent = support
                },
                new Menu
                {
                    MenuId = 15,
                    MenuText = "��ѯ����",
                    Position = 4,
                    UrlController = "Support",
                    UrlAction = "Fees",
                    Parent = support
                },
                new Menu
                {
                    MenuId = 16,
                    MenuText = "��ѯ��Ƶ",
                    Position = 5,
                    UrlController = "Support",
                    UrlAction = "Video",
                    Parent = support
                }
                );
        }
    }
}