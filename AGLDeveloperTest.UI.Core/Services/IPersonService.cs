using AGLDeveloperTest.UI.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLDeveloperTest.UI.Core.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetPeople();
    }
}
