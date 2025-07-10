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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // ? VULNERABLE TO SQL INJECTION
                string sql = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
                SqlCommand cmd = new SqlCommand(sql, conn);

                var reader = cmd.ExecuteReader();
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
