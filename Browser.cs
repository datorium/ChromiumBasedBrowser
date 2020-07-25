using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace ChromiumBasedBrowser
{
    public partial class Browser : Form
    {
        private ChromiumWebBrowser browser;

        public Browser()
        {
            InitializeComponent();
            InitializeBrowser();
        }

        private void InitializeBrowser()
        {
            Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser("https://datorium.eu");
            browser.Dock = DockStyle.Fill;
            this.Controls.Add(browser);
            browser.AddressChanged += Browser_AddressChanged;
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            try
            {
                browser.Load(toolStripAddressBar.Text);
            }
            catch
            {

            }            
        }

        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            browser.Back();  
        }

        private void toolStripButtonForward_Click(object sender, EventArgs e)
        {
            browser.Forward();
        }

        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            var selectedBrowser = (ChromiumWebBrowser)sender;
            this.Invoke(new MethodInvoker(() =>
            {
                toolStripAddressBar.Text = e.Address;
            }));
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            browser.Reload();
        }
    }
}
