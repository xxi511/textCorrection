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
                #region 最前面替換或插入兩個全形空白
                char[] b = new char[willChange[i].Length];
                using (StringReader sr = new StringReader(willChange[i]))
                {
                    sr.Read(b, 0, willChange[i].Length);
                    for (int index = 0; index < b.Length; index++)
                    {
                        if (!String.Equals(b[index], ' ') && !String.Equals(b[index], '　'))
                        {
                            //不是半形空白或全形空白
                            var tempStr = new StringBuilder(willChange[i]);
                            int deleteLength = (index == 0) ? 0 : index;
                            tempStr.Remove(0, deleteLength);
                            tempStr.Insert(0, "　　");
                            willChange[i] = tempStr.ToString();
                            break;
                        }
                    }

                }
                #endregion

                string cor = "";
                for (int j = 0; j < oldWord.Count; j++)
                {
                    cor = willChange[i].Replace(oldWord[j], newWord[j]);
                    willChange[i] = cor;
                }
            }
       

            for (int i = 0; i < willChange.Length; i++)
            {
                novelText.Text += willChange[i];
                novelText.Text += "\n";

                String upLine = "";
                String lineNow = "";
                if (i > 0)
                { //把空白行的空白字元消掉，不然判斷太麻煩了
                    upLine = willChange[i - 1].Trim();
                    lineNow = willChange[i].Trim();
                }

                if (i > 0 &&  (!String.Equals(upLine,"") && !String.Equals(lineNow,"")))
                {
                    //willChange是一行一行的字
                    //如果上面那行不是空白，就是沒分段的意思
                    //加一行空白
                    //如果自己就是空白了，那就不用加了
                    novelText.Text += "\n";
                }
                else if (i == 0 && !String.Equals(willChange[1], ""))
                    novelText.Text += "\n"; //第一行的特別處理
            }
        }
    }
}
