﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registratura
{
    public partial class poisk_p_pas : Form
    {
        public poisk_p_pas()
        {
            InitializeComponent();
        }
        public static string n = null;
        public static int i = 0;
        private void FieldsForm_Fill()
        {
            textBox1.Text = Form1.ds.Tables["Пациенты"].Rows[n]["id_pac"].ToString();
            textBox2.Text = Form1.ds.Tables["Пациенты"].Rows[n]["fam"].ToString();
            textBox3.Text = Form1.ds.Tables["Пациенты"].Rows[n]["pol"].ToString();
            if (Form1.ds.Tables["Пациенты"].Rows[n]["dat_r"] != DBNull.Value)
                dateTimePicker1.Value = Convert.ToDateTime(Form1.ds.Tables["Пациенты"].Rows[n]["dat_r"]);
            textBox4.Text = Form1.ds.Tables["Пациенты"].Rows[n]["polic"].ToString();
            textBox5.Text = Form1.ds.Tables["Пациенты"].Rows[n]["obl"].ToString();
            textBox6.Text = Form1.ds.Tables["Пациенты"].Rows[n]["nam"].ToString();
            textBox7.Text = Form1.ds.Tables["Пациенты"].Rows[n]["snils"].ToString();
            textBox8.Text = Form1.ds.Tables["Пациенты"].Rows[n]["ser_nom"].ToString();
            textBox9.Text = Form1.ds.Tables["Пациенты"].Rows[n]["otch"].ToString();
            textBox10.Text = Form1.ds.Tables["Пациенты"].Rows[n]["reg"].ToString();
            textBox11.Text = Form1.ds.Tables["Пациенты"].Rows[n]["gorod"].ToString();
            textBox12.Text = Form1.ds.Tables["Пациенты"].Rows[n]["yl"].ToString();
            textBox13.Text = Form1.ds.Tables["Пациенты"].Rows[n]["dom"].ToString();
            textBox14.Text = Form1.ds.Tables["Пациенты"].Rows[n]["kvar"].ToString();
            textBox1.Enabled = false;
        }
        private void FieldsForm_Clear()
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.ResetText();
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox1.Focus();
            textBox1.Enabled = true;

        }


        private void tabPage1_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql;
            if (n < Form1.ds.Tables["Пациенты"].Rows.Count)
            {
                sql = "update pac set fam='" + textBox2.Text +
                    "', nam='" + textBox6.Text +
                    "', otch='" + textBox9.Text +
                    "', pol='" + textBox3.Text +
                    "', dat_r='" + dateTimePicker1.Value +
                    "', polic='" + textBox4.Text +
                    "', snils='" + textBox7.Text +
                    "', ser_nom='" + textBox8.Text +
                    "', obl='" + textBox5.Text +
                    "', reg='" + textBox10.Text +
                    "', gorod='" + textBox11.Text +
                    "', yl='" + textBox12.Text +
                    "', dom='" + textBox13.Text +
                    "', kvar='" + textBox14.Text +
                    "' where id_pac=" + textBox1.Text + "";
                Form1.ModificationExecute(sql);

            }
        }

            private void button6_Click(object sender, EventArgs e)
        {

            string message = "Вы точно хотите удалить из справочника пациента с кодом " + textBox1.Text + "?";
            string caption = "Удаление пациента";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }
            Form1.TableFill("Мед. карта", "select * from med");

            for (int i = 0; i < Form1.ds.Tables["Мед. карта"].DefaultView.Count; i++)
                if (Form1.ds.Tables["Мед. карта"].DefaultView[i]["id_med"].ToString() == textBox1.Text)
                {
                    MessageBox.Show("Пациент\"" + textBox2.Text + "\" входит в состав информации о карте с кодом " +
                        Form1.ds.Tables["Мед. карта"].DefaultView[i]["id_med"].ToString(), "Ошибка удаления");
                    return;
                }

            string sql = "delete from pac where id_pac=" + textBox1.Text;
            Form1.ModificationExecute(sql);

            Form1.ds.Tables["Пациенты"].Rows.RemoveAt(n);

            if (Form1.ds.Tables["Пациенты"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
            else
            {
                FieldsForm_Clear();
            }

            Form1.tabControl1.Controls.Remove(Form1.tabControl1.SelectedTab);
        }
    }
}
