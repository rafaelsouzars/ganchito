using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ganchito.Prompito.AbstractClasses;

namespace ganchito.Prompito.Classes
{
    class AppData
    {
        private string _appName;
        private string _versionNumber;
        private string _description;
        private string _profileURL;
        private string _repositorieURL;
        public string GetAppName { get => _appName; }
        public string GetVersionNumber { get => _versionNumber; }
        public string GetDescription { get => _description; }
        public string GetProfileURL { get => _profileURL; }
        public string GetRepositorieURL { get => _repositorieURL; }

        public AppData(string appName, string versionNumber, string description, string profileURL, string repositorieURL)  
        {
            try 
            {
                
                var program = new Program();
                
                if (string.IsNullOrWhiteSpace(appName))
                {
                    _appName = program.ToString().Replace(".Program", "");
                }                

                _versionNumber = versionNumber ?? throw new ArgumentNullException("O AppData não pode valores nulos", nameof(versionNumber));
                _description = description ?? throw new ArgumentNullException("O AppData não pode valores nulos", nameof(description));
                _profileURL = profileURL ?? throw new ArgumentNullException("O AppData não pode valores nulos", nameof(profileURL));
                _repositorieURL = repositorieURL ?? throw new ArgumentNullException("O AppData não pode valores nulos", nameof(repositorieURL));
                
            }
            catch (Exception exception) 
            {
                Console.WriteLine("ERROR: {0}", exception);
            }
            
        }
    }
}
