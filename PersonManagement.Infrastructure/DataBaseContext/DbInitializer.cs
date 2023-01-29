using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Domain.Entities;
using PersonManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Infrastructure.DataBaseContext
{
    public static class DbInitializer
    {
        public static void Initialize(PersonsDbContext context)
        {

            context.Database.EnsureCreated();
            if (context.Persons.Any())
            {
                return;
            }

            var city1 = new City() { Name = "Tbilis" };
            var city2 = new City() { Name = "Telavi" };
            var city3 = new City() { Name = "kutaisi" };
            var city4 = new City() { Name = "Batumi" };

            context.Cities.AddRange(new[] { city1, city2, city3, city4});

            var person1 = new Person()
            {
                FirstName = "გიორგი",
                LastName = "გიორგაძე",
                Gender = Gender.Male,
                PersonalNumber = "01234567891",
                DateOfBirth = DateTime.Now.AddYears(-23),
                CityID = 1,
                Phones = new List<Phone>() { new Phone() { PhoneNumber = "599304050", PhoneNumberType = PhoneNumberType.Home } }
            };

            var person2 = new Person() {
                FirstName = "გელა",
                LastName = "გელაშვილი",
                Gender = Gender.Male,
                PersonalNumber = "01020304051",
                DateOfBirth = DateTime.Now.AddYears(-18),
                CityID = 2,
                Phones = new List<Phone>() { new Phone() { PhoneNumber = "599608090", PhoneNumberType = PhoneNumberType.Office } }
            };

            var person3 = new Person()
            {
                FirstName = "John",
                LastName = "Smith",
                Gender = Gender.Male,
                PersonalNumber = "01020405067",
                DateOfBirth = DateTime.Now.AddYears(-28),
                CityID = 3,
                Phones = new List<Phone>() { new Phone() { PhoneNumber = "59910111213", PhoneNumberType = PhoneNumberType.Mobile } }
            };
            context.Persons.AddRange(new[] { person1, person2, person3 });

            var personrelation1 = new PersonRelation() { Person = person1, RelatedPerson = person2, PersonRelationType = PersonRelationType.Colleague };
            var personRelation2 = new PersonRelation() { Person = person1, RelatedPerson = person3, PersonRelationType = PersonRelationType.Relative };
            var personRelation3 = new PersonRelation() { Person = person2, RelatedPerson = person3, PersonRelationType = PersonRelationType.Familiar };

            context.PersonRelations.AddRange(new[] { personrelation1, personRelation2, personRelation3 });


            var phone1 = new Phone() { PhoneNumber = "599608090", PhoneNumberType = PhoneNumberType.Office, PersonId = 1 };
            var phone2 = new Phone() { PhoneNumber = "599123456", PhoneNumberType = PhoneNumberType.Mobile, PersonId = 2 };

            context.Phones.AddRange(new[] { phone1, phone2 });

            context.SaveChanges();
        }
    }
}
