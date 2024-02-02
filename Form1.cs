using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NompumeleloHlongwaneC_SummativeAssessment
{
    public partial class Form1 : Form
    {

        private ArrayList addedWords = new ArrayList();
        private ArrayList concatenatedWords = new ArrayList();
        public Form1()
        {
            InitializeComponent();

            addbutton.Click += addbutton_Click;
            radioButtonRemove.CheckedChanged += radioButton_CheckedChanged;
            radioButtonConcatenate.CheckedChanged += radioButton_CheckedChanged;

           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            if (radioButtonRemove.Checked)
            {
                RemoveWord();
            }
            else 
            {
                AddOrConcatenateWord();
            }

        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            addbutton.Text = radioButton.Checked ? "Remove Item" : "Concatenate" ;
        }
        private void AddOrConcatenateWord()
        {
            string word = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show("Please enter a word into the TextBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (addedWords.Contains(word))
            {
                MessageBox.Show("This word has already been added.");
                return;
            }

            if (concatenatedWords.Contains(word))
            {
                MessageBox.Show("This word has already been concatenated.");
                return;
            }

            if (radioButtonConcatenate.Checked)
            {
                string selectedWord1 = comboBox1.SelectedItem?.ToString();
                string selectedWord2 = comboBox2.SelectedItem?.ToString();

                

                if (string.IsNullOrEmpty(selectedWord1) || string.IsNullOrEmpty(selectedWord2))
                {
                    MessageBox.Show("Please select words from both ComboBox controls.");
                    return;
                }
                if (selectedWord1.Equals(selectedWord2))
                {
                    MessageBox.Show("Please select different words from the ComboBox controls.");
                    return;
                }

                string concatenatedWord = $"{selectedWord1} {selectedWord2} {word}";
                concatenatedWords.Add(concatenatedWord);
                MessageBox.Show($"The word '{word}' has been concatenated and added to the collection.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                label1.Text = $"Concatenated Word: {concatenatedWord}";

            }

            else
            {
                addedWords.Add(word);
                MessageBox.Show($"The word '{word}' has been added to the collection.", "Success");
            }

        }

        private void RemoveWord()
        {
            string selectedWord = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedWord))
            {
                MessageBox.Show("Please select a word from the ComboBox control to remove.");
                return;
            }

            comboBox1.Items.Remove(selectedWord);
            comboBox2.Items.Remove(selectedWord);
            concatenatedWords.Remove(selectedWord);
            MessageBox.Show($"The word '{selectedWord}' has been removed.", "Success");
            label1.Text = $"Concatenated Word:{string.Join(" ", concatenatedWords.ToArray())}";
        }

        private void radioButtonConcatenate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
