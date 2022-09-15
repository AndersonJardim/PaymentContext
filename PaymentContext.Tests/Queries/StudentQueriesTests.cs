using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;


namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentQueriesTests
    {
        //Red, Green, Refactor
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            for(var i = 0; i <= 10; i++)
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString() ),
                    new Document("11111111111" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString() + "@balta.io")
                    ));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("123456789123");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studn);
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studn);
        }
    }
}