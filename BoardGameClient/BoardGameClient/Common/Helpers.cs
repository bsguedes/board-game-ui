using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BoardGameClient.Common
{
    public interface IBoardGameOptionsView
    {
        UserControl AsUserControl();
        OptionsBase GetOptions();
        OptionsViewModelBase ViewModel { get; }
    }

    public delegate void GameStartEventHandler();
    public delegate void GameAbortedEventHandler();

    public static class Helpers
    {
        internal static string GetVersion()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }

            return "Debug";
        }
    }
}
