using System.Collections.Generic;
using System.Text;
using BATester.Standard.Utilities;
using BATester.Standard.Models;
namespace BATester.Standard
{
    public partial class Configuration
    {

        public enum Environments
        {
            PRODUCTION,
            TESTING,
        }
        public enum Servers
        {
            DEFAULT,
            AUTH_SERVER,
        }

        //The current environment being used
        public static Environments Environment = Environments.PRODUCTION;

        //TODO: Replace the Port with an appropriate value
        public static string Port = "80";

        //TODO: Replace the Suites with an appropriate value
        public static Models.SuiteCodeEnum? Suites = Models.SuiteCodeEnum.HEARTS;

        //The username to use with basic authentication
        //TODO: Replace the BasicAuthUserName with an appropriate value
        public static string BasicAuthUserName = "TODO: Replace";

        //The password to use with basic authentication
        //TODO: Replace the BasicAuthPassword with an appropriate value
        public static string BasicAuthPassword = "TODO: Replace";

        //A map of environments and their corresponding servers/baseurls
        public static Dictionary<Environments, Dictionary<Servers, string>> EnvironmentsMap =
            new Dictionary<Environments, Dictionary<Servers, string>>
            {
                { 
                    Environments.PRODUCTION,new Dictionary<Servers, string>
                    {
                        { Servers.DEFAULT,"http://apimatic.hopto.org:{suites}" },
                        { Servers.AUTH_SERVER,"http://apimaticauth.hopto.org:3000" },
                    }
                },
                { 
                    Environments.TESTING,new Dictionary<Servers, string>
                    {
                        { Servers.DEFAULT,"http://localhost:3000" },
                        { Servers.AUTH_SERVER,"http://apimaticauth.xhopto.org:3000" },
                    }
                },
            };

        /// <summary>
        /// Makes a list of the BaseURL parameters 
        /// </summary>
        /// <return>Returns the parameters list</return>
        internal static List<KeyValuePair<string, object>> GetBaseURIParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("port", Port),
                new KeyValuePair<string, object>("suites", (int)Suites),
            };
            return kvpList; 
        }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters
        /// </summary>
        /// <param name="alias">Default value:DEFAULT</param>
        /// <return>Returns the baseurl</return>
        internal static string GetBaseURI(Servers alias = Servers.DEFAULT)
        {
            StringBuilder Url =  new StringBuilder(EnvironmentsMap[Environment][alias]);
            APIHelper.AppendUrlWithTemplateParameters(Url, GetBaseURIParameters());
            return Url.ToString();        
        }
    }
}