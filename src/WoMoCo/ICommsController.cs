using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;

namespace WoMoCo.Controllers
{
    public interface ICommsController
    {
        IActionResult Get();
        IActionResult Get(int id);
        IActionResult Post([FromBody] Comm comm);
    }
}