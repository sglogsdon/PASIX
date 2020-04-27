using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASIX
{
    public partial class frmCWID : Form
    {
        public frmCWID()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) //closes form
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e) //method for if ok button is clicked
        {
            this.Hide(); //hides and doesn't close
            frmMain myForm = new frmMain(txtCWID.Text); //instantiates object
            if(myForm.ShowDialog() == DialogResult.OK) 
            {
                //equal to ok run the form
            }
            else
            {
                this.Close(); //closes
            }
        }
    }
}
