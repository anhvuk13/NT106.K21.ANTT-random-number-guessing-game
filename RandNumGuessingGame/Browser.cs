using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Shapes;

namespace RNGG
{
    public partial class Browser : Form
    {
        private String text;

        public Browser(string text)
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            this.text = text;
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate("https://ctxt.io/");
            } catch
            {
                MessageBox.Show("Can't connect to https://ctxt.io/", "Error");
                this.Close();
            }
        }
            
        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (webBrowser1.Url.ToString() == "https://ctxt.io/")
                {
                    HtmlElement editable = FindEle("div", "className", "editable");
                    editable.InnerHtml = "";
                    String[] lines = text.Split('\n');
                    foreach (String line in lines) editable.InnerHtml += $"{line}<br>";
                    FindEle("select", "className", "select").SetAttribute("value", "1d");
                    FindEle("input", "className", "button").InvokeMember("click");
                }
                else
                {
                    var url = webBrowser1.Url.ToString();
                    this.Text = url;
                    (new Thread(() => (new CustomMessageBox($"Your log is stored at:\n{url}")).ShowDialog())).Start();
                }
            } catch
            {
                MessageBox.Show("Error occurred while sending your log to https://ctxt.io/", "Error");
                this.Close();
            }
        }

        private HtmlElement FindEle(String tag, String att, String attVal)
        {
            HtmlElementCollection elements = webBrowser1.Document.GetElementsByTagName(tag);
            foreach (HtmlElement element in elements)
            {
                if (element.GetAttribute(att).Equals(attVal)) return element;
            }
            return null;
        }
    }
}
