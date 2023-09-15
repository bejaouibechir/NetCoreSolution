using System.Diagnostics;
using System;
using System.Web;

namespace WebMVC
{
    public class TraceModule : IHttpModule
    {
        HttpApplication _context;

        public void Dispose()
        {
            //Là il faut disposer les ressources externes
            //utilisées par l'objet IHttpModule exemple 
            //connexion à une base de données ou un flux
        }

        public void Init(HttpApplication context)
        {
           _context = context;
            _context.BeginRequest += _context_BeginRequest;
        }

        private void _context_BeginRequest(object sender, System.EventArgs e)
        {
            string message = $"{_context.Request.Url}" + 
                $"Dernière visite à {DateTime.Now.Hour}:{DateTime.Now.Minute}";
            Debug.WriteLine(message);   
        }
    }
}