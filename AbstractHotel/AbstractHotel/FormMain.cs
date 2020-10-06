using AbstractHotelBusinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractHotel
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IRoomLogic roomLogic;
        public FormMain(IRoomLogic roomLogic)
        {
            InitializeComponent();
            this.roomLogic = roomLogic;
        }
    

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = roomLogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[3].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void обедыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormLunches>();
            form.ShowDialog();

        }

        private void номераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRooms>();
            form.ShowDialog();
        }

        private void заявкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRequests>();
            form.ShowDialog();
        }
    }
}
