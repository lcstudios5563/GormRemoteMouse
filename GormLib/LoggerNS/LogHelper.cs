using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.LoggerNS
{

    public class LogHelper
    {
        public static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public delegate void eventRaiser(string a, string b);
        public static event eventRaiser OnlogTextReceived;

        public static void Info(String text)
        {
            try
            {
                if (Logger != null)
                {
                    Logger.Info(text);
                }
                OnlogTextReceived?.Invoke("Info", text);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }

        public static void Warn(String text)
        {
            try
            {
                if (Logger != null)
                {
                    Logger.Warn(text);
                }
                OnlogTextReceived?.Invoke("Warn", text);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }

        public static void Error(String text)
        {
            try
            {
                if (Logger != null)
                {
                    Logger.Error(text);
                }
                OnlogTextReceived?.Invoke("Error", text);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }
    }
}
