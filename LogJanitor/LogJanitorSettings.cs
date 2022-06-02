using ff14bot.Helpers;
using System.ComponentModel;
using System.IO;

namespace LogJanitor
{
    /// <summary>
    /// Strongly-typed configuration for LogJanitor.
    /// </summary>
    internal class LogJanitorSettings : JsonSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogJanitorSettings"/> class.
        /// </summary>
        /// <param name="path">Location of settings file.</param>
        public LogJanitorSettings(string path)
            : base(path)
        {
        }

        /// <summary>
        /// Gets global instance of <see cref="LogJanitorSettings"/>.
        /// </summary>
        public static LogJanitorSettings Instance { get; } = new LogJanitorSettings(Path.Combine(CharacterSettingsDirectory, "LogJanitor.json"));

        /// <summary>
        /// Gets or sets max age of log files before they are deleted, in days.
        /// </summary>
        [Category("Log Cleanup")]
        [DisplayName("Max Age")]
        [Description("Max age of log files before they are deleted, in days.")]
        [DefaultValue(30)]
        public int MaxAgeDays { get; set; } = 30;
    }
}
