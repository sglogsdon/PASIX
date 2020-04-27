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
    public partial class frmEdit : Form
    {
        private Book myBook; //instance variable
        private string cwid;
        private string mode; //new book or editing exsiting book
        public frmEdit(Object tempBook, string tempMode, string tempCwid) //constructor
        {
            myBook = (Book)tempBook; //cast book
            cwid = tempCwid;
            mode = tempMode;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage; //sets image to fitting size
        }

        private void frmEdit_Load(object sender, EventArgs e) //load method
        {
            if(mode == "edit") //set text fields
            {
                txtTitleData.Text = myBook.title;
                txtAuthorData.Text = myBook.genre;
                txtGenreData.Text = myBook.genre;
                txtCopiesData.Text = myBook.copies.ToString();
                txtIsbnData.Text = myBook.isbn;
                txtCoverData.Text = myBook.cover;
                txtLengthData.Text = myBook.length.ToString();

                pbCover.Load(myBook.cover);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) 
        {
            this.Close(); //closes form
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //sets whats in the object equal to what is in the textbox
            myBook.title = txtTitleData.Text;
            myBook.genre = txtAuthorData.Text;
            myBook.genre = txtGenreData.Text;
            myBook.copies = int.Parse(txtCopiesData.Text);
            myBook.isbn = txtIsbnData.Text;
            myBook.cover = txtCoverData.Text;
            myBook.length = int.Parse(txtLengthData.Text);
            myBook.cwid = cwid;

            BookFile.SaveBook(myBook, cwid, mode); //save

            MessageBox.Show("Content was saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information); //message that shows the user it was saved
            this.Close(); //close

        }
    }
}
