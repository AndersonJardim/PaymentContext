using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            //if(string.IsNullOrEmpty(FirstName))
            //    AddNotifications("Name.FirstName","Nome inválido");

            // if(string.IsNullOrEmpty(LastName))
            //    AddNotifications("Name.LastName","Sobre nome inválido");

            //Code Contracts // Microsoft tentou

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres.")
                .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Nom deve conter pelo menos 3 caracteres.")
            );

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}