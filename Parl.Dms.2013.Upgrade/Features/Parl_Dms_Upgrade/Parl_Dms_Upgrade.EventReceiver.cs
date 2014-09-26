using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace Parl.Dms.Upgrade
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("9e137cc9-9863-4ebf-9d85-aecfe4e3b9ae")]
    public class UpgradeEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWeb web = (SPWeb)properties.Feature.Parent;
            LogUpgradeInfo("Upgrade feature activated...", web, null);
        }


        private void LogUpgradeInfo(string message, SPWeb web, SPList list)
        {
            string info = message;
            if (web != null) info += " [" + web.Url + "]";
            if (list != null) info += " [" + list.Title + "]";

            SPDiagnosticsService.Local.WriteTrace(
                0,
                new SPDiagnosticsCategory("Parl.Dms.Upgrade", TraceSeverity.Verbose, EventSeverity.Information), 
                TraceSeverity.Verbose, 
                info, 
                null
            );
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
