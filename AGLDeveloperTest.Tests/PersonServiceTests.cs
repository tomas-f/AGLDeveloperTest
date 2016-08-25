using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Linq;
using AGLDeveloperTest.UI.Core.Services;
using System.Collections.Generic;
using AGLDeveloperTest.UI.Core.Models.Entities;

namespace AGLDeveloperTest.Tests
{
    [TestClass]
    public class PersonServiceTests
    {
        [TestMethod]
        public void GetPeople_Success()
        {            
            string jsonReturnValue = @"[{""name"":""Bob"",""gender"":""Male"",""age"":23,""pets"":[{""name"":""Garfield"",""type"":""Cat""},{""name"":""Fido"",""type"":""Dog""}]},{""name"":""Jennifer"",""gender"":""Female"",""age"":18,""pets"":[{""name"":""Garfield"",""type"":""Cat""}]},{""name"":""Steve"",""gender"":""Male"",""age"":45,""pets"":null},{""name"":""Fred"",""gender"":""Male"",""age"":40,""pets"":[{""name"":""Tom"",""type"":""Cat""},{""name"":""Max"",""type"":""Cat""},{""name"":""Sam"",""type"":""Dog""},{""name"":""Jim"",""type"":""Cat""}]},{""name"":""Samantha"",""gender"":""Female"",""age"":40,""pets"":[{""name"":""Tabby"",""type"":""Cat""}]},{""name"":""Alice"",""gender"":""Female"",""age"":64,""pets"":[{""name"":""Simba"",""type"":""Cat""},{""name"":""Nemo"",""type"":""Fish""}]}]";
            var client = new Mock<IWebClient>() { CallBase = false };
            client.Setup(c => c.DownloadString("http://agl-developer-test.azurewebsites.net/people.json")).Returns(jsonReturnValue);

            var service = new PersonService(client.Object);
            IEnumerable<Person> result = service.GetPeople();

            Assert.AreEqual(result.Count(), 6);
            Assert.AreEqual(result.FirstOrDefault().Name, "Bob");
            Assert.AreEqual(result.LastOrDefault().Gender, "Female");
            Assert.AreEqual(result.ElementAt(3).Pets.Count(), 4);
        }

        [ExpectedException(typeof(WebException))]
        [TestMethod]
        public void GetPeople_ThrowsWebExeption()
        {
            var client = new Mock<IWebClient>() { CallBase = false};
            client.Setup(c => c.DownloadString("http://agl-developer-test.azurewebsites.net/people.json")).Throws(new WebException("Test Error"));

            var service = new PersonService(client.Object);
            IEnumerable<Person> result = service.GetPeople();

            Assert.Fail("Test Error");            
        }
    }
}
