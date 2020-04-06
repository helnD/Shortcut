using System.Linq;
using System.Text.Json;
using Domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers.ViewEntities;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Shortcuts()
        {

            var start = int.Parse(Request.Query["s"]);
            var maxNodeNumber = 0;

            foreach (var key in Request.Query.Keys)
            {
                if (key.Length >= 2 && int.Parse(key[1].ToString()) > maxNodeNumber)
                {
                    maxNodeNumber = int.Parse(key[1].ToString());
                }
            }

            var matrix = new int[maxNodeNumber + 1][];

            for (var row = 0; row <= maxNodeNumber; row++)
            {
                matrix[row] = new int[maxNodeNumber + 1];
                for (var column = 0; column <= maxNodeNumber; column++)
                {
                    var value = Request.Query[$"e{row}{column}"];
                    matrix[row][column] = value == "infinity" ? int.MaxValue : int.Parse(value);
                }
            }

            var interactor = new ShortcutInteractor();
            var shortcuts = interactor.GetShortcuts(matrix, start);
            var viewShortcuts = new { Shortcuts = shortcuts.Select(it => new Shortcut(it)) };
            
            return Json(viewShortcuts);
        }
        
    }
}