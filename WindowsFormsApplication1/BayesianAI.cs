using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class BayesianAI : Form
    {
        public List<Rect> rects = new List<Rect>();
        public List<Link> lines = new List<Link>();
        public Rect selectedRect = null;

        private List<int> _excludedIndexes = new List<int>();
        private List<string> _attributeNames = new List<string>();
        private Dictionary<string, int> _classes = new Dictionary<string, int>();
        private List<List<string>> _dataSetLine = new List<List<string>>();
        private Dictionary<string, List<string>> _dataSetColumn = new Dictionary<string, List<string>>();
        private Dictionary<string, string> _selectedOptions = new Dictionary<string, string>();
        private Dictionary<string, Dictionary<string, int>> _occuranciesByClass = new Dictionary<string, Dictionary<string, int>>();
        private Dictionary<string, Dictionary<string, double>> _probabilitiesByClass = new Dictionary<string, Dictionary<string, double>>();
        private string _classKeyStr = "";
        private int _classIndex = 0;
        private int _nrLines = 0;
        private int _nrAttributes = 0;
        

        public BayesianAI()
        {
            InitializeComponent();
        }

        private void loadData_Click(object sender, EventArgs e)
        {
            buttonCalc.Enabled = false;
            datasetTextBox.Text = "";
            textBoxInfo.Text = "";
            _classKeyStr = "";
            _excludedIndexes = new List<int>();
            _attributeNames = new List<string>();
            _classes = new Dictionary<string, int>();
            _dataSetLine = new List<List<string>>();
            _dataSetColumn = new Dictionary<string, List<string>>();
            _selectedOptions = new Dictionary<string, string>();
            _occuranciesByClass = new Dictionary<string, Dictionary<string, int>>();
            _probabilitiesByClass = new Dictionary<string, Dictionary<string, double>>();
            _classIndex = (int)classIndex.Value;
            pictureBox1.CreateGraphics().Dispose();
            rects = new List<Rect>();
            lines = new List<Link>();

            _nrLines = 0;
            _nrAttributes = 0;


            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            var userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == DialogResult.OK)
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(openFileDialog1.FileName))
                {
                    do
                    {
                        string line = reader.ReadLine();
                        
                        if (_nrLines == 0)
                        {
                            var attributes = line.Split(',');
                            foreach (var item in attributes)
                            {
                                _attributeNames.Add(item);
                            }
                            _nrAttributes = _attributeNames.Count;
                            _classKeyStr = _attributeNames[_classIndex];
                            var excl = excludedIndexes.Text.Split(',');
                            foreach (var item in excl)
                            {
                                try
                                {
                                    _excludedIndexes.Add(Int32.Parse(item));
                                }
                                catch (Exception)
                                {

                                }
                            }
                            _excludedIndexes.Add((int)classIndex.Value);
                            _excludedIndexes.Sort();
                        }
                        else
                        {
                            //datasetTextBox.Text += (line + ((reader.Peek() != -1 && !line.Equals("\n")) ? "\n" : ""));
                            _dataSetLine.Add(new List<string>(line.Split(',')));
                            
                        }
                        _nrLines++;

                    }
                    while (reader.Peek() != -1);
                    _nrLines = _dataSetLine.Count;
                    reader.Close();
                    
                    for(int i=0;i< _dataSetLine[0].Count; i++)
                    {
                        List<String> tempCol = new List<string>();
                        for(int j = 0; j < _dataSetLine.Count; j++)
                        {
                            tempCol.Add(_dataSetLine[j][i]);
                        }
                        try
                        {
                            _dataSetColumn.Add(_attributeNames[i], tempCol);
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show(ee.Message);
                        }
                    }
                }
                List<string> tempClasses =new List<string>( (from d in _dataSetColumn[_attributeNames[(int)classIndex.Value]] select d).Distinct());

                foreach(String item in tempClasses)
                {
                    _classes.Add(item,(_dataSetColumn[_attributeNames[(int)classIndex.Value]].Count(s => item.Equals(s) )));
                }

                foreach (var item in _dataSetLine)
                {
                    foreach (var child in item)
                    {
                        datasetTextBox.AppendText(child + "\t");
                    }
                    datasetTextBox.AppendText("\n");
                }

                loadData();
            }            
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            calculateData();
        }

        private void loadData()
        {
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Refresh();
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.ColumnCount = _nrAttributes - _excludedIndexes.Count;

            List<int> copyExcluded = new List<int>(_excludedIndexes);
            List<string> copyAttrib = new List<string>(_attributeNames);
            Dictionary<String,List<string>> copyDataSetColumn = new Dictionary<String, List<string>>(_dataSetColumn);
            copyExcluded.Reverse();
            
            foreach (var item in copyExcluded)
            {
                copyAttrib.RemoveAt(item);
                copyDataSetColumn.Remove(_attributeNames[item]);
            }

            textBoxInfo.AppendText("Total number of entries loaded : " + _dataSetLine.Count + "\n");
            textBoxInfo.AppendText("Total number of attributes : " + copyAttrib.Count + "\n");
            textBoxInfo.AppendText("Number of classes Loaded : " + _classes.Count + "\n");
            textBoxInfo.AppendText("Class Distribution : \n");

            foreach (var item in _classes)
            {
                textBoxInfo.AppendText("\t" + item.Key + " - " + item.Value + "\n");
            }
            textBoxInfo.AppendText("\n");

            for (int i = 0; i<tableLayoutPanel1.ColumnCount; i++)
            {
                Label label = new Label();
                label.Text = copyAttrib[i];
                tableLayoutPanel1.Controls.Add(label, i, 0);

                string[] comboArray = new string[copyDataSetColumn[copyAttrib[i]].Count];
                copyDataSetColumn[copyAttrib[i]].CopyTo(comboArray);

                List<string> comboList = new List<string>(comboArray);
                comboList.Sort();

                ComboBox combo = new ComboBox();
                combo.Items.AddRange((from d in comboList select d).Distinct().ToArray());
                tableLayoutPanel1.Controls.Add(combo, i, 1);
            }
            
            //tableLayoutPanel1.Size = new Size(tableLayoutPanel1.PreferredSize.Width, tableLayoutPanel1.PreferredSize.Height);
            tableLayoutPanel1.Padding = new Padding(0, 0, 0, SystemInformation.HorizontalScrollBarHeight);
            buttonCalc.Enabled = true;
        }

        private int numberOfOccurances(string classKey, string attribKey, string attribValue)
        {
            int contor = 0;

            List<string> colClass = new List<string>(_dataSetColumn[_classKeyStr]);
            List<string> colAttrib = new List<string>(_dataSetColumn[attribKey]);

            for (int i = 0; i < colAttrib.Count; i++)
            {
                if (colClass[i] == classKey && colAttrib[i] == attribValue)
                {
                    contor++;
                }
            }

            return contor;
        }

        private void calculateData()
        {
            _selectedOptions = new Dictionary<string, string>();
            _occuranciesByClass = new Dictionary<string, Dictionary<string, int>>();
            _probabilitiesByClass = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i += 2)
            {
                _selectedOptions.Add(tableLayoutPanel1.Controls[i].Text, tableLayoutPanel1.Controls[i + 1].Text);
            }
            
            foreach (var item in _classes)
            {
                Dictionary<string, int> tempDict = new Dictionary<string, int>();
                foreach (var option in _selectedOptions)
                {
                    tempDict.Add(option.Key + "_" + option.Value, numberOfOccurances(item.Key, option.Key, option.Value));
                }
                _occuranciesByClass.Add(item.Key, tempDict);
            }

            foreach (var item in _classes)
            {
                Dictionary<string, double> tempDict = new Dictionary<string, double>();
                foreach (var option in _selectedOptions)
                {
                    double aparitii = _occuranciesByClass[item.Key][option.Key + "_" + option.Value];

                    if (radioLaplace.Checked)
                    {
                        tempDict.Add(option.Key + "_" + option.Value, (aparitii + 1) / (item.Value + _classes.Count));
                    }
                    else
                    {
                        tempDict.Add(option.Key + "_" + option.Value, Math.Log((aparitii + 1) / (item.Value + _classes.Count)));
                    }
                }
                _probabilitiesByClass.Add(item.Key, tempDict);
            }

            Dictionary<string, double> result = new Dictionary<string, double>();
            foreach (var item in _probabilitiesByClass)
            {
                double tempDouble = (radioLaplace.Checked)?((double)_classes[item.Key]/(double)_dataSetLine.Count):Math.Log((double)_classes[item.Key] / (double)_dataSetLine.Count);
                foreach (var prob in item.Value)
                {
                    if (radioLaplace.Checked)
                    {
                        tempDouble *= prob.Value;
                    }
                    else
                    {
                        tempDouble += prob.Value;
                    }
                }
                result.Add(item.Key, tempDouble);
            }

            textBoxInfo.AppendText("Full result set : \n");
            foreach (var item in result)
            {
                textBoxInfo.AppendText("\t" + item.Key + " = " + item.Value.ToString() + "\n");
            }
            textBoxInfo.AppendText("\n");

            resultTextBox.Text = result.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            DrawGraph();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var link in lines)
            {
                Pen p = new Pen(Color.Black);
                e.Graphics.DrawLine(p, link.R11.X + link.R11.Width / 2, link.R11.Y + link.R11.Height / 2, link.R21.X + link.R21.Width / 2, link.R21.Y + link.R21.Height / 2);
            }
            
            foreach (var r in rects)
            {
                RectangleF rectF2 = new RectangleF(r.X-2, r.Y-2, r.Width+4, r.Height+4);
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), rectF2);
                RectangleF rectF1 = new RectangleF(r.X, r.Y, r.Width, r.Height);
                e.Graphics.FillRectangle(new SolidBrush(Color.Azure), rectF1);
                e.Graphics.DrawString(r.Info, new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, rectF1);
            }

            e.Dispose();
        }

        private void mouse_D(object sender, MouseEventArgs e)
        {
            Pen p = new Pen(Color.Red);
            if (e.Button == MouseButtons.Left)
            {
                foreach (var r in rects)
                {
                    if (e.X >= r.X && e.X <= r.X + r.Width && e.Y >= r.Y && e.Y <= r.Y + r.Height)
                    {
                        selectedRect = r;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                Rect clickedRectangle = null;
                foreach (var r in rects)
                {
                    if (e.X >= r.X && e.X <= r.X + r.Width && e.Y >= r.Y && e.Y <= r.Y + r.Height)
                    {
                        clickedRectangle = r;
                    }
                }

                MessageBox.Show("Lots of information about " + clickedRectangle.Info, clickedRectangle.Info);
            }
        }

        private void mouse_M(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (selectedRect != null)
                {
                    Point location = e.Location;

                    if (pictureBox1.ClientRectangle.Contains(location))
                    {
                        selectedRect.X = e.X-selectedRect.Width/2;
                        selectedRect.Y = e.Y-selectedRect.Height/2;
                        rects.Add(selectedRect);
                    }
                    pictureBox1.Invalidate();
                }
            }
            else
            {
                selectedRect = null;
            }
        }

        private void DrawGraph()
        {
            Rect root = new Rect(20, 20, 50, 50, "");
            int offsetX = 10;
            int offsetY = 10;

            foreach (var item in _attributeNames)
            {
                Rect r = new Rect(20, 20, 100, 50, item);

                if (item == _attributeNames[_classIndex])
                {
                    root = r;
                }

                rects.Add(r);
            }

            foreach (var r in rects)
            {
                if (offsetX + r.Width < pictureBox1.Width)
                {
                    r.X += offsetX;
                    r.Y += offsetY;
                    offsetX += r.Width + 5;
                }
                else if (offsetY + r.Height < pictureBox1.Height)
                {
                    offsetX = 10;
                    offsetY += r.Height + 5;
                    r.X += offsetX;
                    r.Y += offsetY;
                }
                else
                {
                    offsetX = 10;
                    offsetY = 10;
                    r.X += offsetX;
                    r.Y += offsetY;
                }

                if (r != root)
                    lines.Add(new Link(root, r));
            }
            
            pictureBox1.Invalidate();
        }
    }

    public class Link
    {
        Rect r1;
        Rect r2;

        public Link(Rect r1, Rect r2)
        {
            this.r1 = r1;
            this.r2 = r2;
        }

        public Rect R11
        {
            get { return r1; }
            set { r1 = value; }
        }
        public Rect R21
        {
            get { return r2; }
            set { r2 = value; }
        }
    }

    public class Rect
    {
        public Rect(int X, int Y, int Width, int Height, string Info)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Info = Info;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Info { get; set; }
}
}
