using UserManagement.Business.Models;

namespace UserManagement.Business.Http
{
    public class EndpointConfiguration
    {
        public EndpointConfiguration() { }
     
        public EndpointConfiguration(string host, string path) 
        {
            Host = host;
            Path = path;
        }

        public string Host { get; set; }

        public string Path { get; set; } = "/";

        public Credential Credential { get; set; }
    }
}
