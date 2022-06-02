using ff14bot.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LogJanitor
{
    /// <summary>
    /// Methods for managing RebornBuddy log files.
    /// </summary>
    internal class LogManager
    {
        /// <summary>
        /// Deletes all RebornBuddy logs older than the specified number of days.
        /// </summary>
        /// <param name="maxAgeDays">Max age of logs to keep, in days.</param>
        public static void DeleteOldLogs(int maxAgeDays)
        {
            DirectoryInfo logsDir = new DirectoryInfo(Path.GetDirectoryName(Logging.LogFilePath));
            List<FileInfo> oldLogs = logsDir.GetFiles("*.txt", SearchOption.TopDirectoryOnly)
                .Where(file => file.LastWriteTime < DateTime.Now.AddDays(-maxAgeDays))
                .ToList();

            if (oldLogs.Count > 0)
            {
                Logging.Write($"[Log Janitor] Deleting {oldLogs.Count} logs older than {maxAgeDays} days.");

                foreach (FileInfo logFile in oldLogs)
                {
                    logFile.Delete();
                }
            }
        }
    }
}
