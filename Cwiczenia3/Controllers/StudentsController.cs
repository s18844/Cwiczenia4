using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia3.DAL;
using Cwiczenia3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 2000)}";
            return Ok(student);
        }

        [HttpPut]
        public IActionResult PutCos(int id)
        {
            String message = "Aktualizacja dokonczona " + id;
            return Ok(message);
        }

        [HttpDelete]
        public IActionResult DeleteCos(int id)
        {
            String message = "Usunie zakonczone " + id;
            return Ok(message);
        }

        [HttpGet]
        public string GetStudent(string idStudenta)
        {
            if (idStudenta == null) idStudenta = "1";
            Console.WriteLine(idStudenta);
            var zwrotna="";
            using(var client = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18844;Integrated Security=True"))
            using (var com = new SqlCommand()) {
                com.Connection=client;
                com.CommandText = "select * from Student where Student.IndexNumber=@idStudenta";
                com.Parameters.AddWithValue("idStudenta", idStudenta);
                client.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    zwrotna = st.FirstName+" "+st.LastName;
                }
            }
            return zwrotna;
        }
    }
}