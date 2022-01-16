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
        }
    }
}