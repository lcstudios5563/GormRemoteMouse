using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.LoggerNS
{
    public class LoggerConfig
    {
        /// <summary>
        /// Call Setup during App Start
        /// https://stackoverflow.com/questions/16336917/can-you-configure-log4net-in-code-instead-of-using-a-config-file
        /// </summary>
        public static void Setup()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] %-5level- %message%newline";
            patternLayout.ActivateOptions();

            string filePath = string.Format("{0}\\{1}\\", 
                Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), StringHelper.AppName);

            RollingFileAppender InfoRfa = CreateRollingFileAppender(
                string.Format("{0}Info.{1}.log", filePath, StringHelper.AppName), patternLayout,
                5, "5mb", Level.Info);
            hierarchy.Root.AddAppender(InfoRfa);
            RollingFileAppender WarnRfa = CreateRollingFileAppender(
                string.Format("{0}Warn.{1}.log", filePath, StringHelper.AppName), patternLayout,
                5, "5mb", Level.Warn);
            hierarchy.Root.AddAppender(WarnRfa);
            RollingFileAppender ErrorRfa = CreateRollingFileAppender(
                string.Format("{0}Error.{1}.log", filePath, StringHelper.AppName), patternLayout,
                5, "5mb", Level.Error);
            hierarchy.Root.AddAppender(ErrorRfa);

            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;
        }

        private static RollingFileAppender CreateRollingFileAppender(string filename, PatternLayout patternLayout,
            int maxSizeRollBackups, string maximumFileSize, Level level) {
            RollingFileAppender rfa = new RollingFileAppender();
            rfa.AppendToFile = true;
            rfa.File = filename;
            rfa.Layout = patternLayout;
            rfa.MaxSizeRollBackups = maxSizeRollBackups;
            rfa.MaximumFileSize = maximumFileSize;
            rfa.RollingStyle = RollingFileAppender.RollingMode.Size;
            rfa.StaticLogFileName = true;

            LevelRangeFilter levelRangeFilter = new log4net.Filter.LevelRangeFilter();
            levelRangeFilter.LevelMin = level;

            rfa.AddFilter(levelRangeFilter);
            rfa.ActivateOptions();

            return rfa;
        }
    }
}
