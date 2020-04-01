using Cwiczenia3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia3.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> students;

        static MockDbService()
        {
            students = new List<Student>
            {
                new Student{IdStudent=1,FirstName="Jan",LastName="Kowalski"},
                new Student{IdStudent=2,FirstName="Anna",LastName="Malewski"},
                new Student{IdStudent=3,FirstName="Andrzej",LastName="Andrzejewski"}
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            throw new NotImplementedException();
        }
    }
}
