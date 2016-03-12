using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace change
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            #region Get Data Detail
            string dataFile = @"data.txt";
            StreamReader data = new StreamReader(dataFile, System.Text.Encoding.Default); //讀取data

            int line = 0;

            List<string> oldWord = new List<string>();
            List<string> newWord = new List<string>();

            while (data.Peek() != -1)
            {
                string currentRow = data.ReadLine();
                string[] tempword = currentRow.Trim().Split(' '); // 將字串以空白字元分解，第一個是舊的第二個是新的

                foreach (string w in tempword)
                {
                    if (!(w.Trim() == "" || w.Trim() == null))
                    {
                        if (line % 2 == 0)
                            oldWord.Add(w); // 將字串存入 List
                        else
                            newWord.Add(w);

                        line += 1;
                    }
                }
            }
            data.Close();
            #endregion
            
            // 拆成一行一行丟進去，willChange[0]表示第一行，[1]表示第二行...
            string[] willChange = (!String.IsNullOrEmpty(novelText.Text.Trim())) ? novelText.Lines : null;
            novelText.Text = ""; //處理完過的文字會全部塞在裡面
            for (int i = 0; i < willChange.Length; i++)
            {
               //變成兩個全形空白
                willChange[i] = willChange[i].Trim();
                willChange[i] =  willChange[i].Insert(0, "　　");
                
                string cor = "";
                for (int j = 0; j < oldWord.Count; j++)
                {
                    cor = willChange[i].Replace(oldWord[j], newWord[j]);
                    willChange[i] = cor;
                }
            }

            for (int i = 0; i < willChange.Length; i++)
            {
                String upLine = willChange[i].Trim(); //我
                String downLine =(i == willChange.Length-1)? "": willChange[i + 1].Trim();

                if (i < willChange.Length-1)
                {
                    if (!String.Equals(upLine, "") && String.Equals(downLine, ""))
                    {
                        //我是文字，而且下一行是空白
                        novelText.Text += (i == 0)? upLine: willChange[i];
                        novelText.Text += "\n";
                    }
                    else if (String.Equals(upLine, "") && String.Equals(downLine, ""))
                    {
                        //我是空白，下一行也是空白
                        continue;
                    }
                    else if (!String.Equals(upLine, "") && !String.Equals(downLine, ""))
                    {
                        //我是文字，下一行也是文字
                        novelText.Text += (i == 0) ? upLine : willChange[i];
                        novelText.Text += "\n\n";
                    }
                    else if (String.Equals(upLine, "") && !String.Equals(downLine, ""))
                    { 
                        //我是空白，下一行是文字
                        novelText.Text += upLine;
                        novelText.Text += "\n";
                    }
                }
                else
                {
                    novelText.Text += willChange[i];
                }
            }

        }

        private void pasteBtn_Click(object sender, EventArgs e)
        {
            //貼上
            novelText.Text = Clipboard.GetData(DataFormats.Text).ToString();
        }

        private void cutBtn_Click(object sender, EventArgs e)
        {
            //剪下
            Clipboard.SetData(DataFormats.Text, novelText.Text);
            novelText.Text = "";
        }


    }
}
