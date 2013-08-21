/* 
 * Name: Alexander D. Martinez
 * Date: 12/08/09
 * Purpose: work with reading and writing files. 
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace files
{
    public partial class frmTestScores : Form
    {
        public frmTestScores()
        {
            InitializeComponent();
        }

        //intantiate the WorkTheFile class
        WorkTheFile workIt = new WorkTheFile();
        //input string array
        string[] writeIn = new string[2];

        //opens the existing file
        private void btnOpenFile_Click(object sender, EventArgs e)
        {           

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                workIt.ThePathName = openFileDialog1.FileName;

                workIt.setReadPath();

                btnCloseFile.Enabled = true;
                btnNextRecord.Enabled = true; 
            }

        }

        //creates a new file or overwrites
        private void btnNewFile_Click(object sender, EventArgs e)
        {            

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                workIt.ThePathName = saveFileDialog1.FileName;

                workIt.setWritePath();

                btnCloseFile.Enabled = true;
                btnAddRecord.Enabled = true; 
            }
            

        }


        //closes the open file streams and disables appropriate button
        private void btnCloseFile_Click(object sender, EventArgs e)
        {
            workIt.CloseFile();
            btnCloseFile.Enabled = false;
            btnAddRecord.Enabled = false;
            btnNextRecord.Enabled = false;
            txtName.Text = "";
            txtScore.Text = "";
        }

        //adds a record to a new file
        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            writeIn[0] = txtName.Text;
            writeIn[1] = txtScore.Text;
            workIt.SetIt(writeIn);
            txtName.Text = "";
            txtScore.Text = "";
        }


        //displays the next record in an opened file
        private void btnNextRecord_Click(object sender, EventArgs e)
        {

            txtName.Text = workIt.GetIt();
            txtScore.Text = workIt.GetIt();            

        }


    }
}
