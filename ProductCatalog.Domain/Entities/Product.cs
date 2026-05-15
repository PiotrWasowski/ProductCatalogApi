using ProductCatalog.Domain.Validation;

namespace ProductCatalog.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Kod { get; private set; }

        public string Nazwa { get; private set; }

        public decimal Cena { get; private set; }

        public Product(string kod, string nazwa, decimal cena)
        {
            ValidateDomain(kod, nazwa, cena);
        }

        public Product(int id, string kod, string nazwa, decimal cena) 
        {
            DomainExceptionValidation.When(id <= 0, "Id must be greater than zero.");
            ValidateDomain(kod, nazwa, cena);
            Id = id;
        }

        public void Update(string kod, string nazwa, decimal cena)
        {
            ValidateDomain(kod, nazwa, cena);
        }

        public void ValidateDomain(string kod, string nazwa, decimal cena)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(kod), "Kod is required.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(nazwa), "Nazwa is required.");
            DomainExceptionValidation.When(cena <= 0, "Cena must be greater than zero.");

            Kod = kod;
            Nazwa = nazwa;
            Cena = cena;
        }
    }
}
