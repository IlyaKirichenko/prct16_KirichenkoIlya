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

namespace WordCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string input = txtWord.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Введите слово");
            }

            string file = "text.txt";

            if (!File.Exists(file))
            {
                MessageBox.Show("Файл не найден");
            }
            //чтение текста из файла
            var text = File.ReadAllText(file).ToLower();
            var words = text.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            var count = words
                //филтруем слова, под то что мы ищем
                .Where(word => word == input)
                //подсчёт
                .Count();
            label1.Text = $"Были найдены {count} вхождений слова - '{input}'";
        }
    }
}
