using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using Microsoft.CSharp;

// Eng: Additional items 13,14,15,16 are implemented.
// Clarification of point 15. The author has interpreted the condition so that when you write the code 
// it is automatically formatted.
// Rus: Уточнение к пункту 15. Автор интерпретировал условие так, что при написании непосредственно самого кода
// он автоматически форматируется.
namespace PeerGradeNotepad
{
    public partial class Form1 : Form
    {
        // File path name.
        public string filename;
        // Page counter.
        int tabcount = 1;
        RichTextBox TextE;
        // A dictionary that stores the page name and its text.
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        // A dictionary that stores the page name and its path.
        Dictionary<string, string> path = new Dictionary<string, string>();
        // A dictionary that stores the page name and its RichTextBox.
        Dictionary<string, RichTextBox> rtfArr = new Dictionary<string, RichTextBox>();
        // A dictionary that stores the page name and its FastColoredTextBox.
        //Dictionary<string, FastColoredTextBox> fastArr = new Dictionary<string, FastColoredTextBox>();
        private string colour = "";
        private string time = "";
        // A variable in which all paths are stored.
        private string allPath;
        FastColoredTextBox fastColoredTextBox1 = new FastColoredTextBox();
        public Form1()
        {
            InitializeComponent();
            // Filter to open txt, rtf, cs files.
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|cs files (*.cs)|*cs";
            // Filter to save rtf files.
            saveFileDialog2.Filter = "RichText Files (*.rtf)|*.rtf";
            // Filter to save txt files.
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
            // Filter to save cs files.
            saveFileDialog3.Filter = "cs files (*.cs)|*cs";
            // Connecting event handlers to buttons.
            Open.Click += OpenFile;
            Save_as_txt.Click += SaveAsMethodTxt;
            Save_as_rtf.Click += SaveAsMethodRtf;
            Save.Click += SaveMethod;
            FormatButton.Click += Format;
            ColorChange1.Click += ColorChange11;
            ColorChange2.Click += ColorChange22;
            ColorChange3.Click += ColorChange33;
            timer1.Start();
            min1.Click += Min1;
            min5.Click += Min5;
            min15.Click += Min15;
            min30.Click += Min30;
            Stop.Click += Stop1;
            NewFile2.Click += NewFile22;
            NewFile3.Click += OpenNewPageAndSave;
            SavingCurrentDocument.Click += SaveAsMethodTxt;
            SavingAllDocuments1.Click += OnTimedEvent;
            ClosingApplication.Click += (object sender, EventArgs e) => this.Close();
            undoingPreviousActions.Click += buttonUp_Click;
            returningPreviousActions.Click += button2_Click;
            
        }

        /// <summary>
        /// Method for creating a document in a new window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NewFile22(object sender, EventArgs e)
        {
            Form1 Form2 = new Form1();
            Form2.Show();
            Form2.SaveAsMethodTxt(sender, e);
        }

        /// <summary>
        /// Method for creating a document in a new tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OpenNewPageAndSave(object sender, EventArgs e)
        {
            buttonAdd_Click(sender, e);
            SaveAsMethodTxt(sender, e);
        }

        /// <summary>
        /// Method for inserting text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pasteMenuItem_Click(object sender, EventArgs e)
        {
            // Determine if there is any text in the Clipboard to paste into the text box.
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
                {
                    return;
                }
                // Determine if any text is selected in the text box.
                if (rtfArr[tabControl1.SelectedTab.Text].SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example",
                            MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        rtfArr[tabControl1.SelectedTab.Text].SelectionStart =
                            rtfArr[tabControl1.SelectedTab.Text].SelectionStart +
                            rtfArr[tabControl1.SelectedTab.Text].SelectionLength;
                }
                rtfArr[tabControl1.SelectedTab.Text].Paste();
            }
        }

        /// <summary>
        /// Method for copying text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void copyMenuItem_Click(object sender, EventArgs e)
        {
            if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
            {
                return;
            }
            // Ensure that text is selected in the text box.   
            if (rtfArr[tabControl1.SelectedTab.Text].SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                rtfArr[tabControl1.SelectedTab.Text].Copy();
        }

        /// <summary>
        /// Method for cutting out text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cut(System.Object sender, System.EventArgs e)
        {
            if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
            {
                return;
            }
            // Ensure that text is currently selected in the text box.   
            if (rtfArr[tabControl1.SelectedTab.Text].SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                rtfArr[tabControl1.SelectedTab.Text].Cut();
        }

        /// <summary>
        /// Method for selecting all text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HightLight(object sender, EventArgs e)
        {
            if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
            {
                return;
            }
            rtfArr[tabControl1.SelectedTab.Text].SelectionStart = 0;
            rtfArr[tabControl1.SelectedTab.Text].SelectionLength = rtfArr[tabControl1.SelectedTab.Text].Text.Length;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /// <summary>
        /// Method for saving text in txt format.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsMethodTxt(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 0)
            {
                return;
            }
            if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
            {
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // Получаем выбранный файл.
            filename = saveFileDialog1.FileName;
            // Сохраняем текст в файл.
            System.IO.File.WriteAllText(filename, rtfArr[tabControl1.SelectedTab.Text].Text, Encoding.UTF8);
        }

        /// <summary>
        /// Method for saving text in rtf format.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsMethodRtf(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 0)
            {
                return;
            }
            if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
            {
                return;
            }
            if (saveFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            rtfArr[tabControl1.SelectedTab.Text].SaveFile(saveFileDialog2.FileName);
        }

        /// <summary>
        /// Method for saving text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveMethod(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 0)
            {
                return;
            }
            if (!path.ContainsKey(tabControl1.SelectedTab.Text))
                return;
            filename = path[tabControl1.SelectedTab.Text];
            if (!System.IO.File.Exists(filename))
            {
                return;
            }
            if (filename != null)
            {
                if (Path.GetExtension(filename).ToLower() == ".rtf")
                {
                    if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
                    {
                        return;
                    }
                    //string str = tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First().Text;
                    //rtfArr[tabControl1.SelectedTab.Text].Clear();
                    //rtfArr[tabControl1.SelectedTab.Text].AppendText(str);
                    rtfArr[tabControl1.SelectedTab.Text].SaveFile(filename);
                }
                else if (Path.GetExtension(filename).ToLower() == ".txt")
                {

                    System.IO.File.WriteAllText(filename, tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First().Text, Encoding.UTF8);
                }
                else if (Path.GetExtension(filename).ToLower() == ".cs")
                {
                    try
                    {
                        using (StreamWriter st = new StreamWriter(filename))
                        {
                            st.Write(tabControl1.SelectedTab.Controls.OfType<FastColoredTextBox>().First().Text);
                        }
                    }
                    catch (Exception exep)
                    {

                    }


                }

            }
            else
                MessageBox.Show("Вы не выбрали файл! Нажмите \"Открыть\" ");

            if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
            {
                dictionary.Remove(tabControl1.SelectedTab.Text);
                dictionary.Add(tabControl1.SelectedTab.Text,
                    tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First().Text);
            }

            else
            {
                dictionary.Remove(tabControl1.SelectedTab.Text);
                dictionary.Add(tabControl1.SelectedTab.Text,
                    tabControl1.SelectedTab.Controls.OfType<FastColoredTextBox>().First().Text);
            }

        }

        /// <summary>
        /// Method for opening text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            if (tabControl1.TabPages.Count == 0)
            {
                buttonAdd_Click(sender, e);
            }
            filename = openFileDialog1.FileName;
            int check = 0;
            foreach (var i in path)
            {
                if (tabControl1.SelectedTab.Text == i.Key)
                    check = 1;
            }
            if (check == 0)
            {
                path.Add(tabControl1.SelectedTab.Text, filename);
            }
            if (Path.GetExtension(filename).ToLower() == ".txt")
            {
                if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
                {
                    return;
                }
                // Read the file to the line.
                string fileText = System.IO.File.ReadAllText(filename);
                rtfArr[tabControl1.SelectedTab.Text].Text = System.IO.File.ReadAllText(openFileDialog1.FileName, Encoding.UTF8); //RichTextBoxStreamType.PlainText);
                dictionary.Remove(tabControl1.SelectedTab.Text);
                dictionary.Add(tabControl1.SelectedTab.Text, tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First().Text);
            }
            else if (Path.GetExtension(filename).ToLower() == ".rtf")
            {
                if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
                {
                    return;
                }
                rtfArr[tabControl1.SelectedTab.Text].LoadFile(openFileDialog1.FileName);
                dictionary.Remove(tabControl1.SelectedTab.Text);
                dictionary.Add(tabControl1.SelectedTab.Text, tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First().Text);
            }
            else
            {
                TabPage tp = new TabPage();
                FastColoredTextBox textBox = new FastColoredTextBox();
                textBox.Language = FastColoredTextBoxNS.Language.CSharp;
                textBox.Size = new Size(830, 455);
                string title = "Page" + tabcount;
                string fileTextProg = System.IO.File.ReadAllText(filename);
                textBox.Text = fileTextProg;
                tp.Text = title;
                // Add Textbox to the tab.
                tp.Controls.Add(textBox);
                // Add tabpage to tabcontrol.
                tabControl1.Controls.Add(tp);
                ++tabcount;
                tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                path.Add(tabControl1.SelectedTab.Text, filename);
                dictionary.Remove(tabControl1.SelectedTab.Text);
                dictionary.Add(tabControl1.SelectedTab.Text, tabControl1.SelectedTab.Controls.OfType<FastColoredTextBox>().First().Text);
               // fastArr.Add(tabControl1.SelectedTab.Text, textBox);
            }
        }

        /// <summary>
        /// Method for opening text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="filename1"></param>
        private void OpenFileClone(object sender, EventArgs e, string filename1)
        {
            FastColoredTextBox t = new FastColoredTextBox();

            if (tabControl1.TabPages.Count == 0)
            {
                buttonAdd_Click(sender, e);
            }
            if (!System.IO.File.Exists(filename1))
            {
                return;
            }
            path.Add(tabControl1.SelectedTab.Text, filename1);
            if (Path.GetExtension(filename1).ToLower() == ".txt")
            {

                if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
                {
                    return;
                }
                // Read the file to the line.
                rtfArr[tabControl1.SelectedTab.Text].Text = System.IO.File.ReadAllText(filename1, Encoding.UTF8); //RichTextBoxStreamType.PlainText);
            }
            else if (Path.GetExtension(filename1).ToLower() == ".rtf")
            {

                if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
                {
                    return;
                }
                rtfArr[tabControl1.SelectedTab.Text].LoadFile(filename1);
            }
            else
            {
                TabPage tp = new TabPage();
                t.Language = FastColoredTextBoxNS.Language.CSharp;
                t.Size = new Size(830, 455);
                string title = "Page" + tabcount;
                string fileTextProg = System.IO.File.ReadAllText(filename1);
                t.Text = fileTextProg;
                tp.Text = title;
                // Add Textbox to the tab.
                tp.Controls.Add(t);
                // Add tabpage to tabcontrol.
                tabControl1.Controls.Add(tp);
                ++tabcount;
                tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                path.Add(tabControl1.SelectedTab.Text, filename1);
            }
            if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
            {
                dictionary.Remove(tabControl1.SelectedTab.Text);
                dictionary.Add(tabControl1.SelectedTab.Text, tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First().Text);
            }
            else
            {
                dictionary.Remove(tabControl1.SelectedTab.Text);
                dictionary.Add(tabControl1.SelectedTab.Text, tabControl1.SelectedTab.Controls.OfType<FastColoredTextBox>().First().Text);
               // fastArr.Add(tabControl1.SelectedTab.Text, t);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Read the saved settings from the file.
            if (System.IO.File.Exists("SaveInfo"))
            {
                var ans = MessageBox.Show("Хотите применить настройки предыдущего сеанса", "Выберите действия",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    string[] data = System.IO.File.ReadAllLines("SaveInfo");
                    // Check which color is selected.
                    switch (data[0])
                    {
                        case ("1"):
                            ColorChange11(sender, e);
                            break;
                        case ("2"):
                            ColorChange22(sender, e);
                            break;
                        case ("3"):
                            ColorChange33(sender, e);
                            break;
                        default:
                            break;
                    }
                    // Check which interval is selected.
                    switch (data[1])
                    {
                        case ("1"):
                            Min1(sender, e);
                            break;
                        case ("5"):
                            Min5(sender, e);
                            break;
                        case ("15"):
                            Min15(sender, e);
                            break;
                        case ("30"):
                            Min30(sender, e);
                            break;
                        case ("stop"):
                            Stop1(sender, e);
                            break;
                        default:
                            break;
                    }
                    int check = 0;
                    for (int i = 2; i < data.Length; i++)
                    {
                        buttonAdd_Click(sender, e);
                        OpenFileClone(sender, e, data[i]);
                        check = 1;
                    }
                    if (check == 0)
                        buttonAdd_Click(sender, e);
                }
                else
                {
                    buttonAdd_Click(sender, e);
                }

            }
            // Create menu items.
            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Копировать");
            ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("Вставить");
            ToolStripMenuItem cutMenuItem = new ToolStripMenuItem("Вырезать");
            ToolStripMenuItem formatMenuItem = new ToolStripMenuItem("Изменить формат");
            ToolStripMenuItem hightLightMenuItem = new ToolStripMenuItem("Выделить все");
            // Add items to the menu.
            contextMenuStrip2.Items.AddRange(new[] { copyMenuItem, pasteMenuItem,cutMenuItem,  formatMenuItem,
                hightLightMenuItem});
            // Associate the context menu with the text field.
            ////rtfArr[tabControl1.SelectedIndex].ContextMenuStrip = contextMenuStrip2;
            // Set event handlers for the menu.
            copyMenuItem.Click += copyMenuItem_Click;
            pasteMenuItem.Click += pasteMenuItem_Click;
            cutMenuItem.Click += Cut;
            formatMenuItem.Click += Format;
            hightLightMenuItem.Click += HightLight;
            if (tabControl1.TabPages.Count == 0)
            {
                buttonAdd_Click(sender, e);
            }

        }
        /// <summary>
        /// // Method for adding a tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            TextE = new RichTextBox();
            TextE.Dock = DockStyle.Fill;
            TextE.Multiline = true;
            TabPage tp = new TabPage();
            string tital = "Page" + tabcount;
            tp.Text = tital;
            // Add Textbox to the tab.
            tp.Controls.Add(TextE);
            // Add tabpage to tabcontrol.
            tabControl1.Controls.Add(tp);
            ++tabcount;
            tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
            dictionary.Add(tabControl1.SelectedTab.Text, tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First().Text);
            rtfArr.Add(tabControl1.SelectedTab.Text, TextE);
            // Associate the context menu with the text field.
            rtfArr[tabControl1.SelectedTab.Text].ContextMenuStrip = contextMenuStrip2;
        }

        /// <summary>
        /// Method for removing a tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            string ourText;

            if (tabControl1.TabPages.Count == 0)
            {
                MessageBox.Show("Вам нечего удалять :) ");
                return;
            }

            if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
            {
                ourText = tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First().Text;
            }
            else
            {
                ourText = tabControl1.SelectedTab.Controls.OfType<FastColoredTextBox>().First().Text;
            }

            if (dictionary[tabControl1.SelectedTab.Text] != ourText)
            {
                var ans = MessageBox.Show("сохранить файл?", "Выберите действия",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    SaveMethod(sender, e);
                }
                else if (ans == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
            {
                rtfArr.Remove(tabControl1.SelectedTab.Text);
            }
            //if (fastArr.ContainsKey(tabControl1.SelectedTab.Text))
            //{
            //    fastArr.Remove(tabControl1.SelectedTab.Text);
            //}
            dictionary.Remove(tabControl1.SelectedTab.Text);
            path.Remove(tabControl1.SelectedTab.Text);
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);

        }

        private void Form1_Close(object sender, FormClosingEventArgs e)
        {
            int flag = 0;
            string ourText;
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                tabControl1.SelectedIndex = i;
                if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
                {
                    ourText = tabControl1.SelectedTab.Controls.OfType<RichTextBox>().First().Text;
                }
                else
                {
                    ourText = dictionary[tabControl1.SelectedTab.Text];
                }

                if (dictionary[tabControl1.SelectedTab.Text] != ourText)
                {
                    flag = 1;
                }

            }

            if (flag == 1)
            {
                // Ask if the user wants to save the opened files.
                var ans = MessageBox.Show("Сохранить файлы?", "Выберите действия",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                if (tabControl1.TabPages.Count == 0)
                {
                    MessageBox.Show("Вам нечего сохранять :) ");
                    return;
                }
                if (ans == DialogResult.Yes)
                {
                    for (int i = 0; i < tabControl1.TabPages.Count; i++)
                    {
                        tabControl1.SelectedIndex = i;
                        SaveMethod(sender, e);
                    }
                }
                else if (ans == DialogResult.No)
                {

                }
                else
                {
                    e.Cancel = true;
                }
            }
            // Saving the current settings to a file.
            foreach (var x in path)
            {
                allPath += x.Value + Environment.NewLine;
            }
            System.IO.File.WriteAllText("SaveInfo", colour + Environment.NewLine + time + Environment.NewLine + allPath);

        }

        /// <summary>
        /// Method for changing the color scheme.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorChange11(object sender, EventArgs e)
        {
            buttonAdd.BackColor = System.Drawing.Color.Coral;
            buttonRemove.BackColor = System.Drawing.Color.Chartreuse;
            this.BackColor = Color.Bisque;
            buttonAdd.ForeColor = Color.Black;
            buttonRemove.ForeColor = Color.Black;
            colour = "1";

        }

        /// <summary>
        /// Method for changing the color scheme.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorChange22(object sender, EventArgs e)
        {
            buttonAdd.BackColor = System.Drawing.Color.Cyan;
            buttonRemove.BackColor = System.Drawing.Color.DeepPink;
            this.BackColor = Color.Black;
            buttonAdd.ForeColor = Color.Black;
            buttonRemove.ForeColor = Color.Black;
            colour = "2";
        }

        /// <summary>
        /// Method for changing the color scheme.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorChange33(object sender, EventArgs e)
        {
            buttonAdd.BackColor = System.Drawing.Color.Black;
            buttonRemove.BackColor = System.Drawing.Color.Black;
            this.BackColor = Color.Gold;
            buttonAdd.ForeColor = Color.GhostWhite;
            buttonRemove.ForeColor = Color.GhostWhite;
            colour = "3";
        }

        /// <summary>
        /// Method for changing the text format.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Format(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 0)
            {
                return;
            }
            if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
            {
                return;
            }
            FontDialog fontOption = new FontDialog();
            fontOption.ShowDialog();
            rtfArr[tabControl1.SelectedTab.Text].SelectionFont = fontOption.Font;
            
        }

        /// <summary>
        /// Method for automatically saving open files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object sender, EventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                tabControl1.SelectedIndex = i;
                SaveMethod(sender, e);
            }


            MessageBox.Show("Было выполнено автоматическое сохранение открытых файлов :) ");
        }

        /// <summary>
        /// Method for automatically saving open files (1 minute interval).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Min1(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 1 * 60000;
            timer1.Start();
            time = "1";
        }

        /// <summary>
        /// Method for automatically saving open files (5 minute interval).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Min5(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 5 * 60000;
            timer1.Start();
            time = "5";
        }

        /// <summary>
        /// Method for automatically saving open files (15 minute interval).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Min15(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 15 * 60000;
            timer1.Start();
            time = "15";
        }

        /// <summary>
        /// Method for automatically saving open files (30 minute interval).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Min30(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 30 * 60000;
            timer1.Start();
            time = "30";
        }

        /// <summary>
        /// Method for stopping the automatic saving of open files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop1(object sender, EventArgs e)
        {
            timer1.Stop();
            time = "stop";
        }

        /// <summary>
        /// A method for going back forward.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            if (tabControl1.TabPages.Count == 0)
            {
                return;
            }
            if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
            {
                return;
            }
            rtfArr[tabControl1.SelectedTab.Text].Redo();
        }

        /// <summary>
        /// Method for going back.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 0)
            {
                return;
            }
            if (!rtfArr.ContainsKey(tabControl1.SelectedTab.Text))
            {
                return;
            }
            rtfArr[tabControl1.SelectedTab.Text].Undo();
        }
    }
}
