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
        private readonly string connectionString = "Data Source=LAB4-PC16\\LAB2PC16;Initial Catalog=\\SQLIDEMO;Integrated Security=True;Trust Server Certificate=True";

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


                //string sql = "SELECT * FROM Users WHERE username = @Username AND password = @Password";
                //SqlCommand command = new SqlCommand(sql, connection);


                //command.Parameters.AddWithValue("@Username", username);
                //command.Parameters.AddWithValue("@Password", password);


                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    User user = new User()
                    {
                        Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),                   // handle null id
                        Username = reader.IsDBNull(1) ? string.Empty : reader.GetString(1), // handle null username
                        Password = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)  // handle null password
                    };
                    ViewBag.Message = $"Login successful!, Welcome {user.Username}";
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
