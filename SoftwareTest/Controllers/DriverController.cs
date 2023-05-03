using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareTest.Models;
using SoftwareTest.DatabaseCURD;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using SoftwareTest.DatabaseCURD;
using System.Diagnostics;

namespace SoftwareTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private IConfiguration Configuration;
        /**
         * Rest API control to acess all database operations 
         */
        public DriverController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        /**
         * InsertDriver - insert Driver in db
         * 
         * @driver : driver want to be insert
         * 
         * Return : json result of driver id
         */
        [HttpPost]
        public JsonResult InsertDriver(Driver driver)
        {
            DriverCRUD driverCRUD = new DriverCRUD(Configuration);
            return new JsonResult(Ok(driverCRUD.InsertDriver(driver)));
        }
        /**
         * UpdateDriver - update driver in database
         * 
         * @driver : driver want to be update
         * 
         * Return : json
         */
        [HttpPost]
        public JsonResult UpdateDriver(Driver driver)
        {
            DriverCRUD driverCRUD = new DriverCRUD(Configuration);
            return new JsonResult(Ok(driverCRUD.UpdateDriver(driver)));
        }
        /**
         * DeleteDriver - delete driver from database
         * 
         * @id : id of driver want to be deleted
         * 
         * Return : json
         * 
         */
        [HttpDelete]
        public JsonResult DeleteDriver(int id)
        {
            DriverCRUD driverCRUD = new DriverCRUD(Configuration);
            return new JsonResult(Ok(driverCRUD.DeleteDriver(id)));
        }
        /**
         * SelectAllDrivers - select all drivers from database
         * 
         * Return :json of drivers 
         */
        [HttpGet("/SelectAllDrivers")]
        public JsonResult SelectAllDrivers()
        {
            DriverCRUD driverCRUD = new DriverCRUD(Configuration);
            return new JsonResult(Ok(driverCRUD.SelectAllDrivers()));
        }
        /**
         * SelectDriver - select driver with id
         *
         *@id : id of driver 
         *
         *Return :json of selected driver
         *
         */
        [HttpGet]
        public JsonResult SelectDriver(int id)
        {
            DriverCRUD driverCRUD = new DriverCRUD(Configuration);
            return new JsonResult(Ok(driverCRUD.SelectDriver(id)));
        }
        /**
         * InsertDriverRandom100 - insert random 100 Driver name in db
         * 
         * @driver : driver want to be insert
         * 
         * Return : json result of driver id
         */
        [HttpPost]
        public JsonResult InsertDriverRandom100()
        {
            string charsUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string charLower =   "abcdefjhklmnopqrstwvxyz";
            string numbers = "0123456789";

            for (int i = 0; i < 100; i++)
            {


                var random = new Random();
                string randomStringUpperF = new string(Enumerable.Repeat(charsUpper, 1)
                                                        .Select(s => s[random.Next(s.Length)]).ToArray());
                string randomStringLowerF = new string(Enumerable.Repeat(charLower, 4)
                                                        .Select(s => s[random.Next(s.Length)]).ToArray());
                string firstName = randomStringUpperF + randomStringLowerF;
                string randomStringUpperS = new string(Enumerable.Repeat(charsUpper, 1)
                                                        .Select(s => s[random.Next(s.Length)]).ToArray());
                string randomStringLowerS = new string(Enumerable.Repeat(charLower, 4)
                                                        .Select(s => s[random.Next(s.Length)]).ToArray());
                string secondName = randomStringUpperS + randomStringLowerS;

                string phoneNumber = new string(Enumerable.Repeat(numbers, 9)
                                                        .Select(s => s[random.Next(s.Length)]).ToArray());

                Driver driver = new Driver();
                driver.FirstName = firstName;
                driver.LastName = secondName;
                driver.Email = firstName+secondName+"@email.com";
                driver.PhoneNumber = "+2"+ phoneNumber;


                DriverCRUD driverCRUD = new DriverCRUD(Configuration);
                driverCRUD.InsertDriver(driver);
            }
            
                return new JsonResult(Ok());
        }

        /**
        * SelectAllDrivers - select all Alphabetized drivers Full Name from database
        * 
        * Return :json of Alphabetized drivers Names
        */
        [HttpGet("/SelectAllDriversAlphabetized")]
        public JsonResult SelectAllDriversAlphabetized()
        {
            DriverCRUD driverCRUD = new DriverCRUD(Configuration);
            List<Driver> drivers = new List<Driver>();
            List<string> newDrivers = new List<string>();
                for (int i = 0; i < driverCRUD.SelectAllDrivers().Count; i++)
                {
                    Driver driver = driverCRUD.SelectAllDrivers()[i];
                    newDrivers.Add(String.Concat(driver.FirstName.OrderBy(ch => ch)).Trim() +" " +  String.Concat(driver.LastName.OrderBy(ch => ch)).Trim());
                }

            return new JsonResult(Ok(newDrivers));
        }

        /**
        * SelectAllDriversOrderes - select all drivers ordered from database
        * 
        * Return :json of ordered drivers 
        */
        [HttpGet("/SelectAllDriversOrdered")]
        public JsonResult SelectAllDriversOrdered()
        {
            DriverCRUD driverCRUD = new DriverCRUD(Configuration);    
            return new JsonResult(Ok(driverCRUD.SelectAllDrivers().OrderBy(p => p.FirstName).ThenBy(p => p.LastName).ToList()));
        }
 
    }
}
