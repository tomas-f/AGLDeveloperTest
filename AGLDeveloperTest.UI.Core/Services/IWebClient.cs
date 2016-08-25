using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLDeveloperTest.UI.Core.Services
{
    //Wrapper Interface to enable Unit testing over WebClient
    public interface IWebClient : IDisposable
    {
        string DownloadString(string uri);
    }
}
