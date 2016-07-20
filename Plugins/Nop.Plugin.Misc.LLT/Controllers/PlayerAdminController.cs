using System.Linq;
using System.Web.Mvc;
using Nop.Admin.Controllers;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Extensions;
using Nop.Plugin.Misc.LLT.Models.Player;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Kendoui;

namespace Nop.Plugin.Misc.LLT.Controllers
{
    [AdminAuthorize]
    public class PlayerAdminController: BaseAdminController
    {
        private readonly IPlayerService _playerService;

        public PlayerAdminController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        //list
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult List(PlayerListModel model, DataSourceRequest command)
        {
            var players = _playerService.GetAll(model.SearchLevel, model.SearchFullName, model.SearchCity);

            var gridModel = new DataSourceResult
            {
                Data = players.PagedForCommand(command).Select(x => x),
                Total = players.Count
            };

            return Json(gridModel);
        }

        //create
        public ActionResult Create()
        {
            var model = new PlayerModel();
            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(PlayerModel model, bool continueEditing)
        {
            var player = model.ToEntity();
            _playerService.Add(player);
            return continueEditing ? RedirectToAction("Edit", new { id = player.Id }) : RedirectToAction("List");
        }
            
        //edit
        public ActionResult Edit(int id)
        {
            var player = _playerService.GetById(id);
            if(player == null)
                return RedirectToAction("List");

            var playerModel = player.ToModel();
            return View(playerModel);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Edit(PlayerModel model,bool continueEditing)
        {
            var player = _playerService.GetById(model.Id);
            if (player == null)
                return RedirectToAction("List");

            player = model.ToEntity();
            _playerService.Update(player);

            if (continueEditing)
            {
                return RedirectToAction("Edit", new {id = model.Id });
            }
            return RedirectToAction("List");
        }

        //delete
        [HttpPost]
        public ActionResult Delete(int playerId)
        {
            var player = _playerService.GetById(playerId);
            if (player == null)
                return Json(null);
            else
            {
                player.Deleted = true;
                _playerService.Update(player);
                return Json(player);
            }
        }
    }
}
