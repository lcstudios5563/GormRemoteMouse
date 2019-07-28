﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GormLib.LoggerNS;

namespace GormLib.WifiHotspotNS
{
    public class Hotspot
    {

        private ProcessStartInfo ps = null;
        private dynamic netSharingManager = null;
        private dynamic everyConnections = null;
        private bool hasNetSharingManager = false;

        public string Message { get; set; } = "";

        public Hotspot()
        {
            Init();
        }
        private void Init()
        {
            ps = new ProcessStartInfo("cmd.exe");
            ps.UseShellExecute = false;
            ps.RedirectStandardOutput = true;
            ps.CreateNoWindow = true;
            ps.FileName = "netsh";

            netSharingManager = Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.HNetShare.1"));

            if (netSharingManager == null)
            {
                this.Message = "HNetCfg.HNetShare.1 was not found! \n";
                hasNetSharingManager = true;
            }
            else
            {
                hasNetSharingManager = false;
            }

            if (netSharingManager.SharingInstalled == false)
            {
                this.Message = "Sharing on this platform is not available \n";
                hasNetSharingManager = false;
            }
            else
            {
                hasNetSharingManager = true;
            }

            if (hasNetSharingManager)
            {
                everyConnections = netSharingManager.EnumEveryConnection;

            }

        }


        public List<String> GetConnections()
        {
            dynamic everyConnection = null;
            dynamic connectionProp = null;
            everyConnections = netSharingManager.EnumEveryConnection;
            List<String> connections = new List<string>();
            foreach (dynamic connection in everyConnections)
            {
                everyConnection = netSharingManager.INetSharingConfigurationForINetConnection(connection);
                connectionProp = netSharingManager.NetConnectionProps(connection);
                connections.Add(connectionProp.Name);
            }

            return connections;
        }

        public void ShareInternet(string pubConnectionName, string priConnectionName, bool isEnabled)
        {
            bool hasCon = false;
            dynamic everyConnection = null;
            dynamic connectionProp = null;
            everyConnections = netSharingManager.EnumEveryConnection;
            foreach (dynamic connection in everyConnections)
            {
                everyConnection = netSharingManager.INetSharingConfigurationForINetConnection(connection);
                connectionProp = netSharingManager.NetConnectionProps(connection);

                if (connectionProp.Name == pubConnectionName) // Public Connection Name
                {
                    hasCon = true;
                    this.Message += String.Format("Setting ICS Public {0} on connection: {1} \n", isEnabled, pubConnectionName);
                    if (isEnabled)
                    {
                        everyConnection.EnableSharing(0);
                    }
                    else
                    {
                        everyConnection.DisableSharing();
                    }
                }

                if (connectionProp.Name == priConnectionName) // Private Connection Name
                {
                    hasCon = true;
                    this.Message += String.Format("Setting ICS Private {0} on connection: {1} \n", isEnabled, priConnectionName);
                    if (isEnabled)
                    {
                        everyConnection.EnableSharing(1);
                    }
                    else
                    {
                        everyConnection.DisableSharing();
                    }
                }
            }

            if (!hasCon)
            {
                this.Message += "No connection found!";
            }
        }


        public void Start()
        {
            ps.Arguments = "wlan start hosted network";
            Execute(ps);
        }
        public void Create(string ssid, string key)
        {
            ps.Arguments = String.Format("wlan set hostednetwork mode=allow ssid={0} key={1}", ssid, key);
            Execute(ps);
        }
        public void Stop()
        {
            ps.Arguments = "wlan stop hosted network";
            Execute(ps);
        }
        private bool Execute(ProcessStartInfo ps)
        {
            bool isExecuted = false;
            try
            {
                using (Process p = Process.Start(ps))
                {
                    Message += p.StandardOutput.ReadToEnd() + "\n";
                    p.WaitForExit();
                    isExecuted = true;
                }
            }
            catch (Exception e)
            {
                Message = "";
                Message += e.Message;
                isExecuted = false;
            }
            return isExecuted;
        }

    }

}

