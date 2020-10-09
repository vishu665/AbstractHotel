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
    public partial class FormRoom : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IRoomLogic logic;
        private int? id;
    


        public FormRoom(IRoomLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private Dictionary<int, (string, int)> lunchRooms;
        private void FormDiscipline_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    RoomViewModel view = logic.Read(new RoomBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.RoomsType;
                        textBoxPriceLunch.Text = view.Price.ToString();
                        lunchRooms = view.LunchRoom;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                textBoxPriceLunch.Text = "0";
                lunchRooms = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (lunchRooms != null)
                {
                    dataGridViewLunch.Rows.Clear();
                    foreach (var pc in lunchRooms)
                    {
                        dataGridViewLunch.Rows.Add(new object[] 
                        { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewLunch.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        lunchRooms.Remove(Convert.ToInt32(dataGridViewLunch.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewLunch.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormLunchRoom>();
                int id = Convert.ToInt32(dataGridViewLunch.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = lunchRooms[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    lunchRooms[form.Id] = (form.TypeLunch, form.Count);
                    LoadData();
                }
            }
        }
        public static int c = FormLunchRoom.c;
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormLunchRoom>();
           
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (lunchRooms.ContainsKey(form.Id))
                {
                    c = FormLunchRoom.c;
                    lunchRooms[form.Id] = (form.TypeLunch, form.Count);
                    textBoxPriceLunch.Text = form.priceLunch;
                }
                else
                {
                    c = FormLunchRoom.c;
                    lunchRooms.Add(form.Id, (form.TypeLunch, form.Count));
                    textBoxPriceLunch.Text = form.priceLunch;
                }
                LoadData();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPriceRoom.Text))
            {
                MessageBox.Show("Заполните цену за номер", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (lunchRooms == null || lunchRooms.Count == 0)
            {
                MessageBox.Show("Заполните места", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new RoomBindingModel
                {
                    Id = id,
                    RoomsType = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    LunchRooms = lunchRooms
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBoxPriceRoom_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPriceRoom.Text) && !string.IsNullOrEmpty(textBoxPriceLunch.Text)) 
                textBoxPrice.Text = (Convert.ToInt32(textBoxPriceLunch.Text) + Convert.ToInt32(textBoxPriceRoom.Text)).ToString();
        }
    }
}
