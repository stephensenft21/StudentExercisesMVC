using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentExercises;

namespace StudentExercisesMVC.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly IConfiguration _config;

        public InstructorsController(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        // GET: Instructors
        public async Task<ActionResult> Index()
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                                            SELECT i.Id,
                                            i.FirstName,    
                                            i.LastName,
                                            i.Slack,
                                            i.CohortId,
                                            i.Specialty
                                            FROM Instructor i";
                        SqlDataReader reader = cmd.ExecuteReader();

                        List<Instructor> instructors = new List<Instructor>();
                        while (reader.Read())
                        {
                            Instructor instructor = new Instructors
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Slack = reader.GetString(reader.GetOrdinal("Slack")),
                                CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                            };

                            instructors.Add(instructor);
                        }

                        reader.Close();

                        return View(instructors);
                    }
                }
            }
            catch (Exception e)
            {

                return View();
            }
            return View();
        }

        // GET: Instructors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Instructors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instructors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Instructors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Instructors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Instructors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Instructors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    internal class Instructors : Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Slack { get; set; }
        public int CohortId { get; set; }
    }
}