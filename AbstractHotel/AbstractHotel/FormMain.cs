using AbstractHotelBusinessLogic.BuisnessLogic;
using AbstractHotelBusinessLogic.HelperModels;
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
        private readonly IBackUp backUpLogic;

        public FormMain(IRoomLogic roomLogic, IBackUp backUpLogic)
        {
            InitializeComponent();
            this.roomLogic = roomLogic;
            this.backUpLogic = backUpLogic;

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

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReport>();
            form.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (backUpLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        backUpLogic.SaveJsonRequest(fbd.SelectedPath);
                        backUpLogic.SaveJsonLunch(fbd.SelectedPath);
                        backUpLogic.SaveJsonLunchRoom(fbd.SelectedPath);
                        backUpLogic.SaveJsonRequestLunch(fbd.SelectedPath);
                        backUpLogic.SaveJsonRoom(fbd.SelectedPath);
                        MailLogic.MailSendBackUp(new MailSendInfo
                        {
                            MailAddress = "vitalik73ris@mail.ru",
                            Subject = $"JSON бекап",
                            Text = $"Бекап",
                            Type = "json",
                            FileName = fbd.SelectedPath
                    
                        });
                        MessageBox.Show("Бекап создан и отправлен на почту", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (backUpLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        backUpLogic.SaveXmlRequest(fbd.SelectedPath);
                        backUpLogic.SaveXmlLunch(fbd.SelectedPath);
                        backUpLogic.SaveXmlRoom(fbd.SelectedPath);
                        backUpLogic.SaveXmlRequestLunch(fbd.SelectedPath);
                        backUpLogic.SaveXmlLunchRooms(fbd.SelectedPath);
                       MailLogic.MailSendBackUp(new MailSendInfo
                        {
                            MailAddress = "vitalik73ris@mail.ru",
                            Subject = $"XML бекап",
                            Text = $"Бекап",
                            Type = "xml",
                            FileName = fbd.SelectedPath

                        });
                        MessageBox.Show("Бекап создан и отправлен на почту", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
