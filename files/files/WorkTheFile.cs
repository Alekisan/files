/* 
 * Name: Alexander D. Martinez
 * Date: 12/08/09
 * Purpose: work with reading and writing files. 
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace files
{
    class WorkTheFile
    {
        // class variable
        private string pathName;

        //the reader and writers
        StreamReader readFile;
        StreamWriter writeFile;
        
        //property method
        public string ThePathName
        {
            get { return pathName; }
            set { pathName = value; }
        }

        //constructors
        public WorkTheFile()
            : this(string.Empty)
        {
        }

        public WorkTheFile(string path)
        {
            ThePathName = path;
        }

        //method to set the new reader
        public void setReadPath()
        {
            readFile = new StreamReader(pathName);             
        }

        //method to set the writer
        public void setWritePath()
        {
            writeFile = new StreamWriter(pathName, true);
        }

        //returnd the next string in the stream
        public string GetIt()
        {
            string record = "";


            if (readFile.EndOfStream == false)
            {
                record = readFile.ReadLine();
            }
            else 
            {
                MessageBox.Show("End of document reached!", "END", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            return record;
        }

        //writes the inputted array one line per array item
        public void SetIt(string[] input)
        { 

            for (int i = 0; i < input.Length; i++)
            {
                writeFile.WriteLine(input[i]);
            }

        }

        //closes the streams
        public void CloseFile()
        {
            if (readFile != null)
            {
                readFile.Close();
            }


            if (writeFile != null)
            {
                writeFile.Close();
            }
        }

    }
}
