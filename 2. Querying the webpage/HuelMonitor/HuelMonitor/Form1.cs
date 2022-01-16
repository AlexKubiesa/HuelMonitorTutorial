using HtmlAgilityPack;

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

            Console.WriteLine("Checking availability of chocolate Huel...");

            var web = new HtmlWeb();
            var doc = web.Load("https://uk.huel.com/products/huel-ready-to-drink");
            var flavoursContainer = doc.DocumentNode.SelectSingleNode("//div[@id='product-form-app']");
        }
    }
}