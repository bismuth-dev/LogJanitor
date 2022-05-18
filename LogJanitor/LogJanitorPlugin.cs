using ff14bot.AClasses;
using ff14bot.Helpers;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace LogJanitor
{
    /// <summary>
    /// Entry-point for Log Janitor plugin.
    /// </summary>
    public class LogJanitorPlugin : BotPlugin
    {
        /// <inheritdoc/>
        public override string Author => "Manta";

        /// <inheritdoc/>
        public override string Name => "Log Janitor";

        /// <inheritdoc/>
        public override string Description => "Deletes old logs and adds shortcut to logs folder.";

        /// <inheritdoc/>
        public override Version Version => new Version(0, 1);

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
            base.OnButtonPress();
        }

        /// <summary>
        /// Called once during bot startup, after plugin compilation.
        /// </summary>
        public override void OnInitialize()
        {
            AddMainMenuButton("View Logs", (sender, e) => Process.Start("explorer.exe", $@"/select,""{Logging.LogFilePath}"""));
        }

        /// <summary>
        /// Called once during bot shutdown, as the process closes.
        /// </summary>
        public override void OnShutdown()
        {
            base.OnShutdown();
        }

        /// <summary>
        /// Called each time the plugin is enabled in the Plugins tab.
        /// </summary>
        public override void OnEnabled()
        {
            base.OnEnabled();
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

        /// <summary>
        /// Appends a new button to RebornBuddy's main UI.
        /// </summary>
        /// <param name="label">Text displayed on new button.</param>
        /// <param name="onClick">Function called when new button is clicked.</param>
        private static void AddMainMenuButton(string label, RoutedEventHandler onClick)
        {
            if (!Application.Current.MainWindow.CheckAccess())
            {
                Logging.WriteDiagnostic($"Failed to add button \"{label}\": Current thread {Thread.CurrentThread.ManagedThreadId} \"{Thread.CurrentThread.Name}\" cannot access MainWindow dispatcher.");

                return;
            }

            Application.Current.MainWindow.Dispatcher.Invoke(() =>
            {
                Window mainWindow = Application.Current.MainWindow;
                ComboBox mainMenu = mainWindow.FindName("BotBox") as ComboBox;
                Grid buttonGrid = mainMenu.Parent as Grid;

                Button newButton = new Button
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 129,
                    Height = 18,
                    Margin = new Thickness(0, 169, 10, 0),

                    IsEnabled = true,
                    Visibility = Visibility.Visible,

                    Name = $"button{buttonGrid.Children.Count + 1}",
                    Content = label,
                };

                newButton.Click += onClick;

                buttonGrid.Children.Add(newButton);
            });
        }
    }
}
