using Microsoft.Toolkit.Uwp.Notifications;

namespace HuelMonitor
{
    public partial class Form1 : Form
    {
        private const string LastAvailableEnvVar = "HUEL_MONITOR_LAST_AVAILABLE";
        private const string LastNotificationAtEnvVar = "HUEL_MONITOR_LAST_NOTIFICATION_AT";

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            base.OnLoad(e);

            bool available = AvailabilityChecker.IsChocolateHuelAvailable();
            DateTime now = DateTime.Now;

            bool? lastAvailable = EnvironmentVariable.GetBoolean(LastAvailableEnvVar);
            DateTime? lastNotificationAt = EnvironmentVariable.GetDateTime(LastNotificationAtEnvVar);

            if (ShouldShowNotification(available, now, lastAvailable, lastNotificationAt))
            {
                if (available)
                {
                    new ToastContentBuilder()
                        .AddText("Chocolate Huel available")
                        .AddText("Chocolate Huel is available! Hooray!!!")
                        .Show();
                }
                else
                {
                    new ToastContentBuilder()
                        .AddText("Chocolate Huel not available")
                        .AddText("Sorry, chocolate Huel isn't available today.")
                        .Show();
                }

                EnvironmentVariable.SetBoolean(LastAvailableEnvVar, available);
                EnvironmentVariable.SetDateTime(LastNotificationAtEnvVar, now);
            }

            Close();
        }

        private static bool ShouldShowNotification(bool available, DateTime now, bool? lastAvailable, DateTime? lastNotificationAt)
        {
            if (lastAvailable == null || lastNotificationAt == null)
                return true;

            if (available != lastAvailable)
                return true;

            TimeSpan timeSinceLastChecked = now - lastNotificationAt.Value;
            if (timeSinceLastChecked.TotalDays >= 7)
                return true;

            return false;
        }
    }
}