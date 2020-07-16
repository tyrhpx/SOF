using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SOF.Log;

namespace SOF.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LogM.GetLogger().Info("StartUP");
            LogM.GetLogger().Error(new Exception(), "abc={0}", 1);
        }
    }
}
