using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Form1 : Form
    {
        List<Pessoa> pessoas;
        public Form1()
        {
            InitializeComponent();

            pessoas = new List<Pessoa>();

            ComboboxEC.Items.Add("Casado");
            ComboboxEC.Items.Add("Solteiro");
            ComboboxEC.Items.Add("Viuvo");
            ComboboxEC.Items.Add("Separado");

            ComboboxEC.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach(Pessoa pessoa in pessoas)
            {
                if(pessoa.Nome == txtNome.Text)
                {
                    index = pessoas.IndexOf(pessoa);
                }
            }

            if(txtNome.Text == " ")
            {
                MessageBox.Show("Preencha o campo Nome!");
                txtNome.Focus();
                return;
            }

            if (txtTelefone.Text == "(  )      -")
            {
                MessageBox.Show("Preencha o campo Telefone!");
                txtTelefone.Focus();
                return;
            }

            char sexo;

            if(radioM.Checked)
            {
                sexo = 'M';

            }
            else if(radioF.Checked)
            {
                sexo = 'F';
            }
            else
            {
                sexo = 'O';
            }

            Pessoa p = new Pessoa();

            p.Nome =txtNome.Text;
            p.DataNascimento = txtData.Text;
            p.EstadoCivil = ComboboxEC.SelectedItem.ToString();
            p.Telefone = txtTelefone.Text;
            p.CasaPropria = checkCasa.Checked;
            p.Veiculo = checkVeiculo.Checked;
            p.Sexo = sexo;
           
            if(index<0)
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas[index] = p;
            }
            btnLimpar_Click(btnLimpar, EventArgs.Empty);

            Listar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = Lista.SelectedIndex;
            pessoas.RemoveAt(indice);
            Listar();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
 
            txtNome.Text = "";
            txtData.Text = "";
            ComboboxEC.SelectedIndex = 0;
            txtTelefone.Text = "";
            checkCasa.Checked = false;
            checkVeiculo.Checked = false;
            radioM.Checked = true;
            radioF.Checked = false; 
            radioO.Checked = false;
            txtNome.Focus();
        }

        private void Listar ()
        {
            Lista.Items.Clear();

            foreach (Pessoa p in pessoas)
            {
                Lista.Items.Add(p.Nome);
            }

        }

        private void Lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = Lista.SelectedIndex;
            Pessoa p = pessoas[indice];

            txtNome.Text = p.Nome;
            txtTelefone.Text = p.Telefone;
            txtData.Text = p.DataNascimento;
            ComboboxEC.SelectedItem = p.EstadoCivil;
            checkCasa.Checked = p.CasaPropria;
            checkVeiculo.Checked = p.Veiculo;

            switch (p.Sexo)
            {
                case 'M'
                    : radioM.Checked = true;
                    break;
                case 'F'
                    :
                    radioF.Checked = true;
                    break;
                default: radioO.Checked = true;
                    break;
            }
            
        }
    }
}
