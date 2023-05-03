using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using SoftwareTest.Models;
using Microsoft.Extensions.Configuration;
namespace SoftwareTest.DatabaseCURD
{ 
    /**
     * Class for Database Driver CRUD operations 
     */
    public class DriverCRUD
    {
    private IConfiguration _configuration;
        public DriverCRUD(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
        /**
         * SelectAllDrivers - select all drivers in database
         * 
         * Return : List of drivers
         *
         */
        public List<Driver> SelectAllDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            string conStr = _configuration.GetConnectionString("DefaultConnection");
            string query = "SELECT * FROM Drivers";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            drivers.Add(new Driver
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                FirstName = Convert.ToString(sdr["FirstName"]),
                                LastName = Convert.ToString(sdr["LastName"]),
                                Email = Convert.ToString(sdr["Email"]),
                                PhoneNumber = Convert.ToString(sdr["PhoneNumber"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            if (drivers.Count == 0)
            {
                drivers.Add(new Driver());
            }
            return drivers;

        }

        /**
         * InsertDriver - insert driver in database
         * 
         * @driver : driver want to insert
         * 
         * Return : id of driver
         *
         */
        public Driver InsertDriver(Driver driver)
        {
            string query = "INSERT INTO Drivers (FirstName,LastName,Email,PhoneNumber) VALUES (@FirstName,@LastName,@Email,@PhoneNumber)";
            query += "SELECT SCOPE_IDENTITY()";
            string conStr = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@FirstName", driver.FirstName.Trim());
                    cmd.Parameters.AddWithValue("@LastName", driver.LastName.Trim());
                    cmd.Parameters.AddWithValue("@Email", driver.Email.Trim());
                    cmd.Parameters.AddWithValue("@PhoneNumber", driver.PhoneNumber.Trim());
                    con.Open();
                    driver.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }

            return driver;
        }

        /**
          * UpdateDriver - update driver in database
          * 
          * @driver : driver want to update
          * 
          * Return : boolean true
          *
          */
        public Boolean UpdateDriver(Driver driver)
        {
            string query = "UPDATE Drivers SET FirstName=@FirstName,LastName=@LastName,Email=@Email,PhoneNumber= @PhoneNumber WHERE Id=@Id";
            string conStr = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Id", driver.Id);
                    if (driver.FirstName != null)
                        cmd.Parameters.AddWithValue("@FirstName", driver.FirstName.Trim());
                    else
                        cmd.Parameters.AddWithValue("@FirstName", "");
                    if (driver.LastName != null)
                        cmd.Parameters.AddWithValue("@LastName", driver.LastName.Trim());
                    else
                        cmd.Parameters.AddWithValue("@LastName", "");
                    if (driver.Email != null)
                        cmd.Parameters.AddWithValue("@Email", driver.Email.Trim());
                    else
                        cmd.Parameters.AddWithValue("@Email", "");
                    if (driver.PhoneNumber != null)
                        cmd.Parameters.AddWithValue("@PhoneNumber", driver.PhoneNumber.Trim());
                    else
                        cmd.Parameters.AddWithValue("@PhoneNumber", "");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            return true;
        }
        /**
          * DeleteDriver - delete driver from database
          * 
          * @Id : driver id want to delete
          * 
          * Return : boolean true
          *
          */
        public Boolean DeleteDriver(int Id)
        {
            string query = "DELETE FROM Drivers WHERE Id=@Id";
            string conStr = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            return true;
        }
        /**
          * SelectDriver - select driver from database
          * 
          * @Id : driver id want to select
          * 
          * Return : list of drivers (just one driver return according to id)
          *
          */
        public List<Driver> SelectDriver(int Id)
        {
            List<Driver> drivers = new List<Driver>();
            string query = "Select * FROM Drivers WHERE Id=@Id";
            string conStr = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            drivers.Add(new Driver
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                FirstName = Convert.ToString(sdr["FirstName"]).Trim(),
                                LastName = Convert.ToString(sdr["LastName"]).Trim(),
                                Email = Convert.ToString(sdr["Email"]).Trim(),
                                PhoneNumber = Convert.ToString(sdr["PhoneNumber"]).Trim()
                            });
                        }
                    }
                    con.Close();
                }

            }

            if (drivers.Count == 0)
            {
                drivers.Add(new Driver());
            }
            return drivers;
        }

    }
}



