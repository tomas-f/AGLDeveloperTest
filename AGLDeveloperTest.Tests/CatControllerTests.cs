using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using AGLDeveloperTest.UI.Core.Models.Entities;
using Newtonsoft.Json;
using Moq;
using AGLDeveloperTest.UI.Core.Services;
using AGLDeveloperTest.UI.Core.Controllers;
using System.Web.Mvc;
using AGLDeveloperTest.UI.Core.ViewModels;

namespace AGLDeveloperTest.Tests
{
    [TestClass]
    public class CatControllerTests
    {
        [TestMethod]
        public void Index_Success()
        {
            string json = @"[{""name"":""Bob"",""gender"":""Male"",""age"":23,""pets"":[{""name"":""Garfield"",""type"":""Cat""},{""name"":""Fido"",""type"":""Dog""}]},{""name"":""Jennifer"",""gender"":""Female"",""age"":18,""pets"":[{""name"":""Garfield"",""type"":""Cat""}]},{""name"":""Steve"",""gender"":""Male"",""age"":45,""pets"":null},{""name"":""Fred"",""gender"":""Male"",""age"":40,""pets"":[{""name"":""Tom"",""type"":""Cat""},{""name"":""Max"",""type"":""Cat""},{""name"":""Sam"",""type"":""Dog""},{""name"":""Jim"",""type"":""Cat""}]},{""name"":""Samantha"",""gender"":""Female"",""age"":40,""pets"":[{""name"":""Tabby"",""type"":""Cat""}]},{""name"":""Alice"",""gender"":""Female"",""age"":64,""pets"":[{""name"":""Simba"",""type"":""Cat""},{""name"":""Nemo"",""type"":""Fish""}]}]";
            List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json);

            var service = new Mock<IPersonService>() { CallBase = false };
            service.Setup(s => s.GetPeople()).Returns(people);

            var controller = new CatsController(service.Object);
            ActionResult result = controller.Index();
            ViewResult vResult = result as ViewResult;
            IEnumerable<CatViewModel> model = vResult.Model as IEnumerable<CatViewModel>;


            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(vResult.Model, typeof(IEnumerable<CatViewModel>));
            Assert.AreEqual(model.Count(), 2);
            Assert.AreEqual(model.ElementAt(0).CatNames.Count(), 4);
            Assert.AreEqual(model.ElementAt(1).CatNames.ElementAt(1), "Simba");
            Assert.AreEqual(model.ElementAt(1).Gender, "Female");
        }
    }
}
