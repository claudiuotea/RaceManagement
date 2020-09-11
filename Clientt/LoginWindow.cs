using Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clientt
{
    public partial class LoginWindow : Form
    {
        private AppController appController;
        public LoginWindow(AppController app)
        {
            InitializeComponent();
            this.appController = app;
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = userTextbox.Text;
            String pass = passTextbox.Text;

            try
            {
                appController.login(username, pass);
                MainWindow m = new MainWindow(appController);
                m.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "Error", "login failed!", MessageBoxButtons.OK);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                appController.logout();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't logout!");
            }
        }
    }
}
