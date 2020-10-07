using AbstractHotelBusinessLogic.BindingModels;
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
    public partial class FormLunchRoom : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxLunch.SelectedValue); }
            set { comboBoxLunch.SelectedValue = value; }
        }
        private readonly ILunchLogic logic;
        private readonly IRoomLogic logicR;

        public  string priceLunch;
        public static int c = 0; 
        public string TypeLunch { get { return comboBoxLunch.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        public FormLunchRoom(ILunchLogic logic, IRoomLogic logicR)
        {
            InitializeComponent();
            List<LunchViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxLunch.DisplayMember = "TypeLunch";
                comboBoxLunch.ValueMember = "Id";
                comboBoxLunch.DataSource = list;
                comboBoxLunch.SelectedItem = null;
            }
            this.logic = logic;
            this.logicR = logicR;

        }
        private void CalcSum()
        {
            if (comboBoxLunch.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxLunch.SelectedValue);
                       LunchViewModel product = logic.Read(new LunchBindingModel
                       {
                           Id =
                       id
                       })?[0];
                       int count = Convert.ToInt32(textBoxCount.Text);
                       c = c +  (int)(count * product?.Price ?? 0);
                       priceLunch = c.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
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
                MessageBox.Show("Заполните поле количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxLunch.SelectedValue == null)
            {
                MessageBox.Show("Выберите тип места", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }              
            DialogResult = DialogResult.OK;
            Close();
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
    }
}
