using AbstractHotelBusinessLogic.BindingModels;
using AbstractHotelBusinessLogic.BuisnessLogic;
using AbstractHotelBusinessLogic.Interfaces;
using AbstractHotelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;


namespace AbstractHotel
{
    public partial class FormFillRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly MainLogic logic;
        private readonly IRequestLogic requestLogic;
        private readonly ILunchLogic lunchLogic;
        public FormFillRequest(ILunchLogic lunchLogic, IRequestLogic requestLogic, MainLogic logic)
        {
            InitializeComponent(); 
            this.logic = logic;
            this.requestLogic = requestLogic;
            this.lunchLogic = lunchLogic;
        }
        private void FormCreateRequest_Load(object sender, EventArgs e)
        {
            try
            {
                List<LunchViewModel> list = lunchLogic.Read(null);
                if (list != null)
                {
                    comboBoxTypeLunch.DisplayMember = "TypeLunch";
                    comboBoxTypeLunch.ValueMember = "Id";
                    comboBoxTypeLunch.DataSource = list;
                    comboBoxTypeLunch.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                List<RequestViewModel> list = requestLogic.Read(null);
                if (list != null)
                {
                    comboBoxRequest.DisplayMember = "RequestName";
                    comboBoxRequest.ValueMember = "Id";
                    comboBoxRequest.DataSource = list;
                    comboBoxRequest.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxTypeLunch.SelectedValue == null)
            {
                MessageBox.Show("Выберите тип места", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxRequest.SelectedValue == null)
            {
                MessageBox.Show("Выберите заявку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                logic.CreateRequest(new RequestLunchBindingModel
                {
                    Id = 0,
                    LunchId = Convert.ToInt32(comboBoxTypeLunch.SelectedValue),
                    RequestId = Convert.ToInt32(comboBoxRequest.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
                lunchLogic.LunchRefill(new RequestLunchBindingModel
                {
                    LunchId = Convert.ToInt32(comboBoxTypeLunch.SelectedValue),
                    RequestId = Convert.ToInt32(comboBoxRequest.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
