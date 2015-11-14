using System.Collections.Generic;
using System.Web.Mvc;
using Nop.Web.Framework.Controllers;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Misc.LLT.Controllers
{
    public class LLTCatalogController : BaseController
    {
        public ActionResult TopMenu()
        {
            var topicModel = new TopMenuModel
            {
                Topics = new List<TopMenuModel.TopMenuTopicModel>
                {
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 2,
                        Name = "Главная"
                    },
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 2,
                        Name = "Новости",
                        //SeName = "News"
                    },
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 3,
                        Name = "Регламент",
                        SeName = "Regulations"
                    },
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 4,
                        Name = "Рейтинг",
                        SeName = "Rating"
                    },
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 5,
                        Name = "Игроки",
                        SeName = "Players",
                    },
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 6,
                        Name = "Head 2 Head",
                        SeName = "Head2Head"
                    },
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 7,
                        Name = "Турниры",
                        SeName = "Tournaments"
                    },
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 8,
                        Name = "Теннисные клубы",
                        SeName = "Clubs"
                    },
                    //new TopMenuModel.TopMenuTopicModel
                    //{
                    //    Id = 9,
                    //    Name = "Shop",
                    //    SeName = "Shop"
                    //}
                }
            };

            return View("~/Plugins/Misc.LLT/Views/TopMenu.cshtml", topicModel);
        }
    }
}
