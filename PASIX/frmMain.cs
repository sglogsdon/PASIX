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
    public partial class frmMain : Form
    {
        string cwid; //instance variable
        List<Book> myBooks; //instance method, list of myBooks

        public frmMain(string tempCwid) //constructor
        {
            this.cwid = tempCwid;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage; //fits the image to the size
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadList(); //calls method that loads the list
        }

        private void LoadList() //Method that loads the list for the form
        {
            myBooks = BookFile.GetAllBooks(cwid);
            lstBooks.DataSource = myBooks;
        }

        private void btnClose_Click(object sender, EventArgs e) //method for when close button is selected
        {
            this.Close();
        }

        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e) //method for when a different book is clicked on
        {
            Book myBook = (Book)lstBooks.SelectedItem; //cast what is selected from the list box

            //set
            txtTitleData.Text = myBook.title;
            txtAuthorData.Text = myBook.author;
            txtGenreData.Text = myBook.genre;
            txtIsbnData.Text = myBook.isbn;
            txtCopiesData.Text = myBook.copies.ToString();
            txtLengthData.Text = myBook.length.ToString();

            try
            {
                pbCover.Load(myBook.cover); //loads the picture
            }
            catch
            {

            }
        }

        private void btnRent_Click(object sender, EventArgs e) //method for when the rent button is selected
        {
            Book myBook = (Book)lstBooks.SelectedItem; //cast selected object from the list of books

            myBook.copies--; //decreases count of copies
            BookFile.SaveBook(myBook, cwid, "edit"); //saves
            LoadList(); //reloads the list
        }

        private void btnReturn_Click(object sender, EventArgs e) //method for when the return button is selected
        {
            Book myBook = (Book)lstBooks.SelectedItem; //cast selected object from the list of books

            myBook.copies++; //increases count of copies
            BookFile.SaveBook(myBook, cwid, "edit"); //saves
            LoadList(); //reloads the list
        }

        private void btnDelete_Click(object sender, EventArgs e) //method for when the delete button is selected
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo); //are you sure message

            if(dialogResult == DialogResult.Yes) //if they select yes
            {
                BookFile.DeleteBook(myBook, cwid); //deletes the book
                LoadList(); //reloads the list
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) // method for when the edit button is clicked
        {
            Book myBook = (Book)lstBooks.SelectedItem;
            frmEdit myForm = new frmEdit(myBook, "edit", cwid);
            if(myForm.ShowDialog()== DialogResult.OK)
            {

            }
            else
            {
                LoadList(); //reloads the list
            }
        }

        private void btnNew_Click(object sender, EventArgs e) //method for when the user wants to create new
        {
            Book myBook = new Book(); //cast selected object to a book
            frmEdit myForm = new frmEdit(myBook, "new", cwid); //creates form
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                //in form
            }
            else
            {
                LoadList();
            }
        }
    }
}
