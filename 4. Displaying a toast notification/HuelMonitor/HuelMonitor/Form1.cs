using Microsoft.Toolkit.Uwp.Notifications;

namespace HuelMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            bool available = AvailabilityChecker.IsChocolateHuelAvailable();

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
        }
    }
}