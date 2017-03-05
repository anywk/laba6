using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discrete4
{
    public partial class Form1 : Form
    {

        private bool[][] adjacencyMatrix = new bool[8][] {
            new bool[] {false, false, true, true, false, false, false, true},
            new bool[] {false, false, false, false, true, false, false, false},
            new bool[] {false, false, false, false, true, true, false, true},
            new bool[] {false, false, false, false, false, false, true, false},
            new bool[] {false, false, false, false, false, true, true, false},
            new bool[] {false, false, false, false, false, false, false, true},
            new bool[] {false, false, false, false, false, false, false, false},
            new bool[] {false, false, false, false, false, false, false, false}
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 8;
            fillTable(adjacencyMatrix);
        }

        private void button_execute_Click(object sender, EventArgs e)
        {
            IDictionary<int, int> grandiFunctions = new Grandi().execute(readDataFromTable());

            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Name = "grandi value";
            
            for (int i = 0, grandiFunction; i < grandiFunctions.Count; i++)
            {
                grandiFunctions.TryGetValue(i, out grandiFunction);
                dataGridView1.Rows[i].Cells[dataGridView1.Columns.Count - 1].Value = grandiFunction;
            }
        }

        private bool[][] readDataFromTable()
        {
            int verticesCount = dataGridView1.Columns.Count;
            bool[][] matrix = new bool[verticesCount][];
            for (int i = 0; i < verticesCount; i++)
            {
                matrix[i] = new bool[verticesCount];
                for (int j = 0; j < verticesCount; j++)
                {
                    matrix[i][j] = bool.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }
            return matrix;
        }

        private void fillTable(bool[][] adjacencyMatrix)
        {
            for (int i = 0; i < adjacencyMatrix.Count(); i++)
            {
                dataGridView1.Rows.Add();
                for (int j = 0; j < adjacencyMatrix.Count(); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = adjacencyMatrix[i][j].ToString();
                }
            }
        }

    }
}
