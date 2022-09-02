using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("35111507795", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
            subscription.AddPayment(payment);
            _student.AddSubscription(subscription);
            _student.AddSubscription(subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            //var subscription = new Subscription(null);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            //var subscription = new Subscription(null);
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }



        //Esse funcionava:

        // [TestMethod]
        // public void ShouldReturnErrorWhenSubscriptionHasNoPayment22()
        // {
        //     var name = new Name("Bruce", "Wayne");
        //     var document = new Document("25319042043", EDocumentType.CPF);
        //     var email = new Email("batman@dc.com");
        //     var student = new Student(name, document, email);
        //     Assert.Fail();
        // }


        // [TestMethod]
        // public void ShouldReturnSucessWhenActiveSubscription()
        // {
        //     Assert.Fail();
        // }



        // [TestMethod]
        // public void AdicionarAssinatura()
        // {
        //  //   var subscription = new Subscription(null);
        //  //   var student = new Student("Anderson", "Jardim", "123456789012", "andersonjardim@gmail.com");
        //  //   //student.Subscriptions.Add(subscription);
        //  //   student.AddSubscription(subscription);

        //     //var Payment = new PayPalPaymet();

        //     //var name = new Name("Teste", "Teste");
        //     //foreach(var not in name.Notifications){
        //     //   not.Message;
        //     //}
        // }
    }
}