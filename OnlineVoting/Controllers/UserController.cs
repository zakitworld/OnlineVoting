using Microsoft.AspNetCore.Mvc;
using System.Linq;
using OnlineVoting.Models;

public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        var users = _userRepository.GetAllUsers();
        return View(users);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            _userRepository.AddUser(user);
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }

    public IActionResult Edit(int id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    [HttpPost]
    public IActionResult Edit(User user)
    {
        if (ModelState.IsValid)
        {
            _userRepository.UpdateUser(user);
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }
}
