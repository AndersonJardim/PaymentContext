using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenActiveSubscription()
        {
            var name = new Name("Bruce", "Wayne");
            var document = new Document("25319042043", EDocumentType.CPF);
            var email = new Email("batman@dc.com");
            var address = new Address("Rua 1", "1234", "Bairro Legal", "Gothan", "SP", "BR", "134000000");
            //
            var student = new Student(name, document, email);
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", document, address, email);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            student.AddSubscription(subscription); //De proposito 2x para dar erro

            Assert.IsTrue(student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            var name = new Name("Bruce", "Wayne");
            var document = new Document("25319042043", EDocumentType.CPF);
            var email = new Email("batman@dc.com");
            var student = new Student(name, document, email);
            Assert.Fail();
        }

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