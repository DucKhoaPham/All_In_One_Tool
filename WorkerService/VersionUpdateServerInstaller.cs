using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using WorkerService.Model;

namespace WorkerService
{
    [RunInstaller(true)]
    public partial class VersionUpdateWinSeviceInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller ServiceProcessInstaller;

        private ServiceInstaller serviceInstaller;

        public VersionUpdateWinSeviceInstaller()
        {
            InitializeComponent();

            InstallSetup();
        }

        public void InstallSetup()
        {
            //IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //var dirname = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //var allConfig = Directory.GetFiles(string.Format("{0}{1}", dirname, @"\Config"), "*.json", SearchOption.AllDirectories);
            //foreach (var jsonFilename in allConfig)
            //    if (Path.GetFileName(jsonFilename) == "appsettings.json")
            //    {
            //        configurationBuilder.AddJsonFile(jsonFilename);
            //        break;
            //    }
            //IConfiguration configuration = configurationBuilder.Build();
            //var serviceInfo = configuration.GetSection("ServiceInfo").Get<ServiceInfo>();
            this.ServiceProcessInstaller = new ServiceProcessInstaller();
            this.serviceInstaller = new ServiceInstaller();
            // 
            // orderEntryServiceProcessInstaller
            // 
            this.ServiceProcessInstaller.Account = ServiceAccount.LocalSystem;
            this.ServiceProcessInstaller.Password = null;
            this.ServiceProcessInstaller.Username = null;
            // 
            // orderEntryServiceInstaller
            // 
            this.serviceInstaller.Description = ServiceInstallConfig.GetConfig().Description;
            this.serviceInstaller.DisplayName = ServiceInstallConfig.GetConfig().DisplayName;
            this.serviceInstaller.ServiceName = ServiceInstallConfig.GetConfig().ServiceName;
            this.serviceInstaller.StartType = ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            Installers.Add(this.ServiceProcessInstaller);
            Installers.Add(this.serviceInstaller);
        }
    }
}
