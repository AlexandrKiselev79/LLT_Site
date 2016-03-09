using System.Web.Mvc;
using Nop.Admin.Controllers;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;
using Nop.Plugin.Misc.LLT.Extensions;
using Nop.Plugin.Misc.LLT.Models.Player;
using Nop.Services.Security;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Misc.LLT.Controllers
{
    [AdminAuthorize]
    public class PlayerAdminController: BaseAdminController
    {
        private readonly IPermissionService _permissionService;
        private readonly IPlayerService _playerService;

        public PlayerAdminController(IPermissionService permissionService,
            IPlayerService playerService)
        {
            _permissionService = permissionService;
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

        //create
        public ActionResult Create()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDiscounts))
                return AccessDeniedView();

            var model = new PlayerModel();
            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(PlayerModel model, bool continueEditing)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDiscounts))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var player = model.ToEntity();
                _playerService.Add(player);
                return continueEditing ? RedirectToAction("Edit", new { id = player.Id }) : RedirectToAction("List");
            }

            return View(model);
        }

        //edit
        public ActionResult Edit(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDiscounts))
                return AccessDeniedView();

            return View();
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Edit(bool continueEditing)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDiscounts))
                return AccessDeniedView();

            if (continueEditing)
            {
                //selected tab
                SaveSelectedTabIndex();

                return RedirectToAction("Edit", new {id = 1}); //discount.Id });
            }
            return RedirectToAction("List");
        }

        //delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDiscounts))
                return AccessDeniedView();
            
            return RedirectToAction("List");
        }
    }
}
