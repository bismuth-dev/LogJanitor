using System;
using System.Windows.Forms;

namespace LogJanitor
{
    /// <summary>
    /// Settings window for LogJanitor.
    /// </summary>
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsForm"/> class.
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            settingsPropGrid.SelectedObject = LogJanitorSettings.Instance;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogJanitorSettings.Instance.Save();
            LogManager.DeleteOldLogs(LogJanitorSettings.Instance.MaxAgeDays);
        }
    }
}
