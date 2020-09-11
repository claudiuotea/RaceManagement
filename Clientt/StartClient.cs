using Client;
using Networking;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clientt
{
    static class StartClient
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IServices server = new AppServerObjectProxy("127.0.0.1", 55555);
            AppController controller = new AppController(server);
            LoginWindow win = new LoginWindow(controller);
            Application.Run(win);
        }
    }
}
