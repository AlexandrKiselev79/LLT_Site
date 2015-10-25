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
                        Id = 1,
                        Name = "News",
                        SeName = "News"
                    },
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 2,
                        Name = "Regulations",
                        SeName = "Regulations"
                    },
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 2,
                        Name = "Tournaments",
                        SeName = "Tournaments"
                    },
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 2,
                        Name = "Players",
                        SeName = "Players"
                    },
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 2,
                        Name = "Ratings",
                        SeName = "Ratings"
                    },
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 2,
                        Name = "Courts",
                        SeName = "Courts"
                    },
                    new TopMenuModel.TopMenuTopicModel
                    {
                        Id = 2,
                        Name = "Shop",
                        SeName = "Shop"
                    }
                }
            };

            return View(topicModel);
        }
    }
}
