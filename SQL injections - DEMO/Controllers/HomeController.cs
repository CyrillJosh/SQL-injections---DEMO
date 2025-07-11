using System.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Configuration;
using SQL_injections___DEMO.Models;
using Microsoft.AspNetCore.Mvc;

namespace SQL_injections___DEMO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string connectionString = "Data Source=LAB4-PC25\\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True;Trust Server Certificate=True";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //Login
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
                SqlCommand command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    ViewBag.Message = "Login successful!";
                }
                else
                {
                    ViewBag.Message = "Login failed.";
                }
            }

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
