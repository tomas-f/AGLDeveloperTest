using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AGLDeveloperTest.UI.Core.Services
{
    public class CustomWebClient : IWebClient, IDisposable
    {
        bool _disposed;
        private WebClient _cutomWebClient = new WebClient();
  
        public string DownloadString(string uri) 
        {
            return _cutomWebClient.DownloadString(uri);
        }

    

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~CustomWebClient()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _cutomWebClient.Dispose();                
            }

            _cutomWebClient = null;            
            _disposed = true;
        }

    }
}
