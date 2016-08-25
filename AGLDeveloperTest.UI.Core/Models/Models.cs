
//using System;
//using System.ComponentModel.DataAnnotations;
//using System.Collections.Generic;
//using System.Net;
//using Newtonsoft.Json;
//using System.Linq;

//namespace AGLDeveloperTest
//{
//#region Entities
	
//    public enum Gender
//    {
//        Male,
//        Female
//    }

//    public class Person
//    {
//        public string name
//        {
//            get;
//            set;
//        }

//        public string gender
//        {
//            get;
//            set;
//        }

//        public int age
//        {
//            get;
//            set;
//        }

//        public IEnumerable<Pet> pets
//        {
//            get;
//            set;
//        }
//    }

//    public enum PetType
//    {
//        Cat,
//        Dog,
//        Fish
//    }

//    public class Pet
//    {
//        public string name
//        {
//            get;
//            set;
//        }

//        public string type
//        {
//            get;
//            set;
//        }
//    }

//#endregion
	
	
//    public class CatViewModel
//    {
//        public CatViewModel(string gender, string name)
//        {
//            Gender = gender;
//            CatName = name;
//        }

//        public string Gender
//        {
//            get;
//            set;
//        }

//        public string CatName
//        {
//            get;
//            set;
//        }
//    }

//    public class PersonService
//    {
//        public IEnumerable<Person> GetPeople()
//        {
//            List<Person> people;
//            using (var client = new WebClient())
//            {
//                string json = client.DownloadString("http://agl-developer-test.azurewebsites.net/people.json");
//                people = JsonConvert.DeserializeObject<List<Person>>(json);
//            }

//            return people;
//        }

//        public IEnumerable<CatViewModel> GetCats()
//        {
//            List<CatViewModel> cats = new List<CatViewModel>();
//            IEnumerable<Person> people = GetPeople();
			
//            //var ret = people.SelectMany(p => p.pets, (pers, pet) => new CatViewModel(pers.gender,pet.name));
				
			
//            foreach (Person p in people)
//            {
//                if (p.pets != null && p.pets.Any()){
//                    foreach (Pet pe in p.pets)
//                    {
//                        if(pe.type == "Cat")
//                        {
//                            cats.Add(new CatViewModel(p.gender,pe.name));
//                        }
//                    }
//                }
//            }
			
//            /*var tt = (from person in people 
//                from pet in person.pets
//                    where person.pets != null && person.pets.Any() && pet.type == "Cat"
//                     select new CatViewModel(person.gender,pet.name)).OrderBy(c => c.Gender).ThenBy(c => c.CatName).ToList();*/
			
//             /*cats = 
//         from helper in people.Where(s=>s.pets.Any()).SelectMany
//               ( p => p.pets
//                 , ( pers, pet ) => new { pers, pet } )
//                      where helper.pet.type == "Cat"
//                           select new CatViewModel(helper.pers.gender,helper.pet.name);
		
//            */
//            return (from c in cats select c).OrderBy(c => c.Gender).ThenBy(c => c.CatName).ToList();
//        }
//    }
//}
