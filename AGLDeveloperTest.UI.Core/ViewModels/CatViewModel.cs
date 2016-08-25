using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLDeveloperTest.UI.Core.ViewModels
{
    public class CatViewModel
    {
        public string Gender { get; set; }
        public IEnumerable<string> CatNames { get; set; }
    }
}
