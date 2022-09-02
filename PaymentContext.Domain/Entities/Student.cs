using System.Collections.Generic;
//using System.Linq;
using Flunt.Validations;
//using System.Linq;
//using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get{return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            //if(subscription.Payments.Payment.Count == 0)

            // if(true)
            //     throw new Exception("");

            // //Se o nome não tiver 30 caracteres...

            // // Se já tiver uma assinatura ativa, cancela
            // // Camceça todas as outras assinaturas e coloca esta como princial
            // foreach(var sub in Subscriptions)
            // {
            //     sub.Inactivate();
            // }

            // _subscriptions.Add(subscription);

            var hasSubscriptionActive = false;
            foreach(var sub in _subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            //alternativa 1:
            // //using Flunt.Validations;
            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já tem uma assinatura ativa.")
                //.IsLowerThan(0, subscription.Payments.Count, "Student.Subscription", "Esta assinatura não possui pagamentos.")
                .AreEquals(0, subscription.Payments.Count, "Student.Subscription", "Esta assinatura não possui pagamentos.")
            );    
            
            //alternativa 2:
            if(hasSubscriptionActive)            
                AddNotification("Student.Subscription", "Você já tem uma assinatura ativa.");           

            
            //if (Valid)
            //    _subscriptions.Add(subscription);
            // Alternativa
            // if (hasSubscriptionActive)
            //     AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa");
        }
    }
}