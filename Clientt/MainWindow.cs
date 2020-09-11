using Client;
using Model.model;
using Services;
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
    public partial class MainWindow : Form
    {
        AppController appController;
        IList<Cursa> curseData;
        IList<Participant> participantiData;
        public MainWindow(AppController appController)
        {
            InitializeComponent();
            this.appController = appController;


            //iau de la controller cursele si le pun ca datasource la listbox
            curseData = appController.getCurse();
            cursaListbox.DataSource = curseData;

            appController.updateEvent += participantUpdate;

            populateTeamCombobox();
        }

        private void populateTeamCombobox()
        {
            foreach (Echipa p in appController.getEchipe())
                echipaCombobox.Items.Add(p.NumeEchipa);
        }

        private void participantUpdate(object sender, AppEventArgs e)
        {
            if(e.EventType == AppEvent.ParticipantAdded)
            {
                int idc = Int32.Parse(e.Data.ToString());
                cursaListbox.BeginInvoke(new UpdateCursaListboxCallback(this.updateCursaListbox), new Object[] { cursaListbox, idc});
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void AppWindow_FormClosing(object sender,FormClosingEventArgs e)
        {
            Console.Write("App closing" + e.CloseReason);
            if(e.CloseReason == CloseReason.UserClosing)
            {
                appController.logout();
                appController.updateEvent -= participantUpdate;
                Application.Exit();
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            appController.logout();
            appController.updateEvent -= participantUpdate;
            Application.Exit();
        }

        private void cautaButton_Click(object sender, EventArgs e)
        {
            String teamName = echipaCombobox.Text;
            

            try
            {
                participantiData = appController.getParticipantsByTeam(teamName);
                participantListbox.BeginInvoke(new UpdateParticipantListboxCallback(
                    this.updateParticipantListbox), new Object[] { participantListbox, participantiData });
            }
            catch(AppException ex)
            {
                MessageBox.Show(this, "Eroare", ex.Message, MessageBoxButtons.OK);
            }
        }

        private void updateParticipantListbox(ListBox listBox, IList<Participant> data)
        {
            listBox.DataSource = null;
            listBox.DataSource = data;
        }
        private void updateCursaListbox(ListBox listBox, int idCursa)
        {
            listBox.DataSource = null;

            foreach (Cursa c in curseData)
                if (c.Id == idCursa)
                    c.NumarParticipanti += 1;
            
            listBox.DataSource = curseData;
        }

        public delegate void UpdateParticipantListboxCallback(ListBox list, IList<Participant> data);
        public delegate void UpdateCursaListboxCallback(ListBox list, int idCursa);

        private void addButton_Click(object sender, EventArgs e)
        {
            Save saveWindow = new Save(appController);
            saveWindow.populateComboboxes();
            this.Hide();
            saveWindow.ShowDialog();
            this.Show();
        }
    }
}
