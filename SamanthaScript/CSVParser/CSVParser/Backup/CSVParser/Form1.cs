using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO; //System.IO is not used by default

namespace CSVParser
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      List<string[]> testParse =
          parseCSV("C:\\Documents and Settings\\Rich\\My Documents\\TestParse.csv");
      DataTable newTable = new DataTable();
      foreach(string column in testParse[0])
      {
        newTable.Columns.Add();
      }

      foreach (string[] row in testParse)
      {
        newTable.Rows.Add(row);
      }
      dataGridView1.DataSource = newTable;
    }

public List<string[]> parseCSV(string path)
{
  List<string[]> parsedData = new List<string[]>();

  using (StreamReader readFile = new StreamReader(path))
  {
    string line;
    string[] row;

    while ((line = readFile.ReadLine()) != null)
    {
      row = line.Split(',');
      parsedData.Add(row);
    }
  }

  return parsedData;
}
  }
}