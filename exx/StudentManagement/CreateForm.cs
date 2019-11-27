using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exx.StudentManagement
{
    public partial class CreateForm : Form
    {
        private LogicLayer Business;
        public CreateForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += CreateForm_Load;
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var code = this.txtCode.Text;
            var name = this.txtName.Text;
            var birthday = this.dtpBirthday.Value;
            var class_id = (int)this.cboClass.SelectedValue;

            this.Business.CreateStudent(code, name, birthday, class_id);
            MessageBox.Show("Create student successfully.");
            this.Close();
        }

        void CreateForm_Load(object sender, EventArgs e)
        {
            this.cboClass.DataSource = this.Business.GetClasses();
            this.cboClass.DisplayMember = "Name";
            this.cboClass.ValueMember = "id";
        }
    }
}
