using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraviAnt;

namespace TraviAnt
{
    public partial class LoginForm : Form
    {
        CookieCollection cookies = null;
        private const string netlifyUrl = "https://traviant.netlify.com/.netlify/identity/token";

        public LoginForm()
        {
            InitializeComponent();
            AddVersionNumber();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            GetUserSettings();
        }

        private void GetUserSettings()
        {
            textBoxUsername.Text = TraviAnt.Properties.Settings.Default.NEmail;
            textBoxPassword.Text = Properties.Settings.Default.NPassword;
            checkBoxRemember.Checked = Properties.Settings.Default.Remember;
        }

        private void AddVersionNumber()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            this.Text += $" v.{ versionInfo.FileVersion }";
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            var postParams = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", textBoxUsername.Text },
                { "password", textBoxPassword.Text },
            };

            if (HTTP.PostRequest(netlifyUrl, null, new Dictionary<string, string> { }, postParams, ref cookies))
            {
                DialogResult = DialogResult.OK;

                if (checkBoxRemember.Checked)
                    SaveUserSettings();
                else
                    ResetUserSettings();
            }
            else
            {
                MessageBox.Show("Unable to log in, please check your credentials.");
            }
        }

        private void ResetUserSettings()
        {
            Properties.Settings.Default.Reset();
        }

        private void SaveUserSettings()
        {
            Properties.Settings.Default.NEmail = textBoxUsername.Text;
            Properties.Settings.Default.NPassword = textBoxPassword.Text;
            Properties.Settings.Default.Remember = checkBoxRemember.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
