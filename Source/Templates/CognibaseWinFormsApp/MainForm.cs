using Missionware.Cognibase.UI.WinForms.Client;
using System.Windows.Forms;

namespace CognibaseWinFormsApp
{
    public partial class MainForm : Form
    {
        public static WinFormsApplication App { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            App.Client.Close();
            base.OnFormClosed(e);
        }
    }
}
