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
    public partial class Save : Form
    {
        AppController appController;
        IList<String> curseData;
        IList<String> echipeData;
        public Save(AppController app)
        {
            InitializeComponent();
            curseData = new List<String>();
            echipeData = new List<String>();
            this.appController = app;
        }

        public void populateComboboxes()
        {
            foreach (Cursa c in appController.getCurse())
                curseData.Add(c.CapacitateCilindrica);
            foreach (Echipa e in appController.getEchipe())
                echipeData.Add(e.NumeEchipa);

            echipaCombobox.DataSource = echipeData;
            cursaCombobox.DataSource = curseData;
        }

        private void Save_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                appController.saveParticipant(cursaCombobox.SelectedItem.ToString(), echipaCombobox.SelectedItem.ToString(), textBox1.Text);

            }
            catch (AppException ex)
            {
                MessageBox.Show(this, "error", "eroare la adaugare", MessageBoxButtons.OK);
            }
            MessageBox.Show(this, "Succes", "Element adaugat!", MessageBoxButtons.OK);
            
        }
    }
}
