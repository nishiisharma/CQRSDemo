using CQRSPlayerDemo.Features.Players.Commands;
using CQRSPlayerDemo.Features.Players.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSPlayerDemo.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(string? searchTerm, int page = 1)
        {
            TempData["ToastrType"] = TempData["ToastrType"];
            TempData["ToastrMessage"] = TempData["ToastrMessage"];

            var query = new GetPlayersWithPaginationQuery
            {
                SearchTerm = searchTerm,
                PageNumber = page,
                PageSize = 5
            };

            var result = await _mediator.Send(query);

            ViewBag.TotalPages = (int)Math.Ceiling((double)result.TotalCount / query.PageSize);
            ViewBag.CurrentPage = page;
            ViewBag.SearchTerm = searchTerm;

            return View(result.Players); // View still uses IEnumerable<Player>
        }


        public async Task<IActionResult> Details(int id)
        {
            return View(await _mediator.Send(new GetPlayerByIdQuery() { Id = id }));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePlayerCommand command)
        {
            int toasterType = 0;
            string toastrmessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    toasterType = 2; //success
                    toastrmessage = "Player's information added successfully!!";
                }
            }
            catch (Exception ex)
            {
                toasterType = 3; //failure
                toastrmessage = "Something went wrong while saving the players information!!!";
                ModelState.AddModelError("", "Something went wrong while saving the players information!!!");
            }

            TempData["ToastrType"] = toasterType;
            TempData["ToastrMessage"] = toastrmessage;

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id)
        {
            return View("~/Views/Player/Create.cshtml", await _mediator.Send(new GetPlayerByIdQuery() { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdatePlayerCommand command)
        {
            int toasterType = 0;
            string toastrmessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    toasterType = 2; //success
                    toastrmessage = "Player's information updated successfully!!";
                }
            }
            catch (Exception ex)
            {
                toasterType = 3; //failure
                toastrmessage = "Something went wrong while updating the players information!!!";
                ModelState.AddModelError("", "Something went wrong while updating the players information!!!");
            }

            TempData["ToastrType"] = toasterType;
            TempData["ToastrMessage"] = toastrmessage;

            return RedirectToAction(nameof(Index));
        }


        public async Task<ActionResult> Delete(int id)
        {
            int toasterType = 0;
            string toastrmessage = string.Empty;
            try
            {
                await _mediator.Send(new DeletePlayerCommand() { Id = id });
                toasterType = 2; //success
                toastrmessage = "Deleted successfully!!";
            }
            catch (Exception ex)
            {
                toasterType = 3; //failure
                toastrmessage = "Something went wrong while deleting the players information!!!";
                ModelState.AddModelError("", "Something went wrong while deleting the players information!!!");
            }

            TempData["ToastrType"] = toasterType;
            TempData["ToastrMessage"] = toastrmessage;

            return RedirectToAction(nameof(Index));
        }

    }
}

