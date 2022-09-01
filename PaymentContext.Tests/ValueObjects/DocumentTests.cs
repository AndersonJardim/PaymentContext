using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentTests
    {
        //Red, Green, Refactor

        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnSucessWhenCNPJIsValid()
        {
            Assert.Fail();
        }


        

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnSucessWhenCPFIsValid()
        {
            Assert.Fail();
        }
    }
}