using ff14bot.Helpers;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace LogJanitor
{
    /// <summary>
    /// Helpers for interacting with RebornBuddy's GUI.
    /// </summary>
    internal static class RebornBuddyUiHelpers
    {
        /// <summary>
        /// Appends a new button to RebornBuddy's main UI.
        /// </summary>
        /// <param name="label">Text displayed on new button.</param>
        /// <param name="onClick">Function called when new button is clicked.</param>
        public static void AddMainMenuButton(string label, RoutedEventHandler onClick)
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
