using ff14bot.AClasses;
using ff14bot.Helpers;
using ff14bot.Managers;
using System;
using System.Diagnostics;
using System.Linq;

namespace LogJanitor
{
    /// <summary>
    /// Entry-point for Log Janitor plugin.
    /// </summary>
    public class LogJanitorPlugin : BotPlugin
    {
        private SettingsForm settingsForm;

        /// <inheritdoc/>
        public override string Author => "Manta";

        /// <inheritdoc/>
        public override string Name => "Log Janitor";

        /// <inheritdoc/>
        public override string Description => "Deletes old logs and adds shortcut to logs folder.";

        /// <inheritdoc/>
        public override Version Version => new Version(0, 1, 0);

        /// <summary>
        /// Gets a value indicating whether to enable the plugin's settings button.
        /// </summary>
        public override bool WantButton => true;

        /// <summary>
        /// Gets text to be displayed on the plugin's settings button.
        /// </summary>
        public override string ButtonText => base.ButtonText;

        /// <summary>
        /// Called when the plugin's settings button is pressed.
        /// </summary>
        public override void OnButtonPress()
        {
            if (settingsForm == null)
            {
                settingsForm = new SettingsForm();
            }

            settingsForm.ShowDialog();
        }

        /// <summary>
        /// Called once during bot startup, after plugin compilation.
        /// </summary>
        public override void OnInitialize()
        {
            RebornBuddyUiHelpers.AddMainMenuButton("View Full Logs", (sender, e) => Process.Start("explorer.exe", $@"/select,""{Logging.LogFilePath}"""));
        }

        /// <summary>
        /// Called once during bot shutdown, as the process closes.
        /// </summary>
        public override void OnShutdown()
        {
            base.OnShutdown();

            PluginContainer ljPlugin = PluginManager.Plugins.FirstOrDefault(p => (BotPlugin)p.Plugin == this);

            if (ljPlugin != null && ljPlugin.Enabled)
            {
                LogManager.DeleteOldLogs(LogJanitorSettings.Instance.MaxAgeDays);
            }
        }

        /// <summary>
        /// Called each time the plugin is enabled in the Plugins tab.
        /// </summary>
        public override void OnEnabled()
        {
            LogManager.DeleteOldLogs(LogJanitorSettings.Instance.MaxAgeDays);
        }

        /// <summary>
        /// Called each time the plugin is disabled in the Plugins tab.
        /// </summary>
        public override void OnDisabled()
        {
            base.OnDisabled();
        }

        /// <summary>
        /// Called repeatedly while the bot is running, during TreeSharp ticks.
        /// </summary>
        public override void OnPulse()
        {
            base.OnPulse();
        }
    }
}
