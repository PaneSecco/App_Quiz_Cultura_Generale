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

namespace App_quiz_cultura_generale
{
    public partial class Progetto : Form
    {
        int counter = 0;
        int risposte_giuste = 0;
        int [] memoria_punteggio = { 0, 0, 0 };
        string[] memoria_materia = { "", "", ""};
        int partita = 0;
        string materia;

        public Progetto()
        {
            InitializeComponent();
        }
        public struct domanda
        {
            public string question;
            public string answer1;
            public string answer2;
            public string answer3;
            public string answer4;
            public string giusto;
            public string suggerimento;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            button4.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Controlla se si ha selezionato un campo materia

            if (comboBox1.Text == "")
            {
                MessageBox.Show("Non hai selezionato un campo rispetto alla materia, selezionane uno per iniziare il quiz", "Attenzione");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Si vuole iniziare una nuova partita?", "Attenzione", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    button4.Hide();
                    button3.Show();
                    partita++;
                    counter++;
                    //richiama il Quiz
                    domande();
                }
                //Non fa nulla
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //verifica se si ha risposto alla domanda
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true || radioButton4.Checked == true)
            {
                giusto_sbagliato();
            }
            else
            {
                MessageBox.Show("Non hai risposto alla domanda", "Attenzione");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public domanda domande()
        {
            domanda [] a= new domanda [200];

            if (comboBox1.Text == "Storia")
            {
                //mettilo nella cartella debug che si trova nella cartella bin dentro la cartella app quiz cultura generale
                using (StreamReader sr = new StreamReader("Storia.txt"))
                {
                    materia = "Storia";
                    for(int y=1; y<6; y++)
                    {
                        a[y].question = sr.ReadLine();
                        a[y].answer1 = sr.ReadLine();
                        a[y].answer2 = sr.ReadLine();
                        a[y].answer3 = sr.ReadLine();
                        a[y].answer4 = sr.ReadLine();
                        a[y].giusto = sr.ReadLine();
                        a[y].suggerimento = sr.ReadLine();
                    }
                }
            }

            if (comboBox1.Text == "Sistemi e Reti")
            {
                using (StreamReader sr = new StreamReader("Sistemi e Reti.txt"))
                {
                    materia = "Sistemi e Reti";
                    for (int y = 1; y < 6; y++)
                    {
                        a[y].question = sr.ReadLine();
                        a[y].answer1 = sr.ReadLine();
                        a[y].answer2 = sr.ReadLine();
                        a[y].answer3 = sr.ReadLine();
                        a[y].answer4 = sr.ReadLine();
                        a[y].giusto = sr.ReadLine();
                        a[y].suggerimento = sr.ReadLine();
                    }
                }
            }

            if (comboBox1.Text == "Italiano")
            {
                using (StreamReader sr = new StreamReader("Italiano.txt"))
                {
                    materia = "Italiano";
                    for (int y = 1; y < 6; y++)
                    {
                        a[y].question = sr.ReadLine();
                        a[y].answer1 = sr.ReadLine();
                        a[y].answer2 = sr.ReadLine();
                        a[y].answer3 = sr.ReadLine();
                        a[y].answer4 = sr.ReadLine();
                        a[y].giusto = sr.ReadLine();
                        a[y].suggerimento = sr.ReadLine();
                    }
                }
            }

            textBox4.Text = "Domanda n° " + counter + " su 5";
            panel1.Show();

            textBox1.Text = a[counter].question;
            radioButton1.Text = a[counter].answer1;
            radioButton2.Text = a[counter].answer2;
            radioButton3.Text = a[counter].answer3;
            radioButton4.Text = a[counter].answer4;

            domanda b;
            b.question = a[counter].question;
            b.answer1 = a[counter].answer1;
            b.answer2 = a[counter].answer2;
            b.answer3 = a[counter].answer3;
            b.answer4 = a[counter].answer4;
            b.giusto = a[counter].giusto;
            b.suggerimento = a[counter].suggerimento;

            return b;
        }
        
        public void giusto_sbagliato()
        {
            domanda a = domande();
            //salva la scelta fatta
            string scelta = "";
            if (radioButton1.Checked == true)
            {
                scelta = a.answer1;
            }
            if (radioButton2.Checked == true)
            {
                scelta = a.answer2;
            }
            if (radioButton3.Checked == true)
            {
                scelta = a.answer3;
            }
            if (radioButton4.Checked == true)
            {
                scelta = a.answer4;
            }

            counter++;
            //controlla se la risposta data è giusta o sbagliata
            if (scelta == a.giusto)
            {
                panel2.Show();
                textBox2.Text = "Risposta esatta!";
                textBox3.Show();
                textBox3.Text = "Complimenti!";
                risposte_giuste++;
            }
            else
            {
                panel2.Show();
                textBox2.Text = "Risposta errata!";
                textBox3.Show();
                textBox3.Text = "La risposta giusta era: " + a.giusto;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (counter == 6)
            {
                risultati();
            }
            else {
                panel2.Hide();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                domande();
            }
        }
        public void risultati()
        {
            button3.Hide();
            button4.Show();

            if (risposte_giuste >= 4)
            {
                textBox3.Text = "Complimenti per il punteggio!";
            }
            else
            {
                textBox3.Text = "Sarà per la prossima volta";
            }
            textBox2.Text = "Il tuo punteggio è " + risposte_giuste + "/5";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (partita == 1)
            {
                memoria_punteggio[partita-1] = risposte_giuste;
                memoria_materia[partita-1] = materia;
            }
            if (partita == 2)
            {
                int b = 0;
                b = memoria_punteggio[0];
                memoria_punteggio[partita - 1] = b;
                memoria_punteggio[0] = risposte_giuste;
                string a = "";
                a = memoria_materia[0];
                memoria_materia[partita - 1] = a;
                memoria_materia[0] = materia;
            }
            if (partita == 1)
            {
                int b = 0;
                b = memoria_punteggio[1];
                memoria_punteggio[2] = b;
                b = memoria_punteggio[0];
                memoria_punteggio[1] = b;
                memoria_punteggio[0] = risposte_giuste;

                string a = "";
                a = memoria_materia[1];
                memoria_materia[2] = a;
                a = memoria_materia[0];
                memoria_materia[1] = a;
                memoria_materia[0] = materia;
            }

            panel1.Hide();
            panel2.Hide();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            counter = 0;
            risposte_giuste = 0;
        }

        private void tornaAllaHomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Se si procede a tornare alla schermata home i progressi verranno persi, continuare?", "Attenzione", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                panel1.Hide();
                panel2.Hide();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                counter = 0;
                risposte_giuste = 0;
                partita--;
            }
            //Non fa nulla
        }

        private void suggerimentiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int b;
            string a="";
            if (comboBox1.Text == "Storia")
            {
                using (StreamReader sr = new StreamReader("Storia.txt"))
                {
                    //dato che la stringa per il suggerimento è ogni 7 posti basta moltiplicare il numero della domanda per 7 in modo che arrivi alla righa che serve
                    b = counter * 7;
                    for (int y = 0; y < b; y++)
                    {
                        a = sr.ReadLine();
                    }
                }
            }
            if (comboBox1.Text == "Sistemi e Reti")
            {
                using (StreamReader sr = new StreamReader("Sistemi e Reti.txt"))
                {
                    //dato che la stringa per il suggerimento è ogni 7 posti basta moltiplicare il numero della domanda per 7 in modo che arrivi alla righa che serve
                    b = counter * 7;
                    for (int y = 0; y < b; y++)
                    {
                        a = sr.ReadLine();
                    }
                }
            }
            if (comboBox1.Text == "Italiano")
            {
                using (StreamReader sr = new StreamReader("Italiano.txt"))
                {
                    //dato che la stringa per il suggerimento è ogni 7 posti basta moltiplicare il numero della domanda per 7 in modo che arrivi alla righa che serve
                    b = counter * 7;
                    for (int y = 0; y < b; y++)
                    {
                        a = sr.ReadLine();
                    }
                }
            }
            MessageBox.Show(a, "Suggerimeto");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ultimeDomandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (partita == 0) 
            {
                MessageBox.Show("Non sono state giocate partite da quando il programma è stato avviato, i punteggi delle prossime partite verranno salvati qui (fino ad un massimo di 3)", "Attenzione");
            }
            if (partita == 1)
            {
                string a =
                "Ultima partita:" + Environment.NewLine +
                "Materia: " + memoria_materia[0]
                 + Environment.NewLine + "Risposte giuste: " + memoria_punteggio[0];
                MessageBox.Show(a, "Ultima partita giocata");
            }

            if (partita == 2)
            {
                string b =
                "Ultima partita:" + Environment.NewLine +
                "Materia: " + memoria_materia[0]
                + Environment.NewLine + "Risposte giuste: " + memoria_punteggio[0] + Environment.NewLine +
                "" + Environment.NewLine +
                "----------------------------------------" + Environment.NewLine +
                "" + Environment.NewLine +
                "Penultima partita:" + Environment.NewLine +
                "Materia: " + memoria_materia[1]
                + Environment.NewLine + "Risposte giuste: " + memoria_punteggio[1];
                MessageBox.Show(b, "Ultime partite giocate");
            }
            if (partita >= 3)
            {
                string c =
                "Ultima partita:" + Environment.NewLine +
                "Materia: " + memoria_materia[0]
                + Environment.NewLine + "Risposte giuste: " + memoria_punteggio[0] + Environment.NewLine +
                "" + Environment.NewLine +
                "----------------------------------------" + Environment.NewLine +
                "" + Environment.NewLine +
                "Penultima partita:" + Environment.NewLine +
                "Materia: " + memoria_materia[1]
                + Environment.NewLine + "Risposte giuste: " + memoria_punteggio[1] + Environment.NewLine +
                "" + Environment.NewLine +
                "----------------------------------------" + Environment.NewLine +
                "" + Environment.NewLine +
                "Terzultima partita:" + Environment.NewLine +
                "Materia: " + memoria_materia[2]
                + Environment.NewLine + "Risposte giuste: " + memoria_punteggio[2];
                MessageBox.Show(c, "Ultime partite giocate");
            }
        }

        private void informazioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a=
            "Questa è un app a quiz, è strutturata da più domande (5 per ogni campo) suddivise in campi diversi, uno per ogni materia, il suo obbiettivo è quello di poter ripassare alcuni argomenti fatti a scuola senza che la cosa sia troppo pesante." + Environment.NewLine +
            "" + Environment.NewLine +
            "--------------------------------------------------------------------------------------------" + Environment.NewLine +
            "" + Environment.NewLine +
            "Nella sezione 'ultime partite' verranno mostrate le ultime partite giocate, ne verranno mostrate a schermo 3, ordinate dalla più recente alla meno recente, verranno indicate la materia e il punteggio acquisito." + Environment.NewLine +
            "" + Environment.NewLine +
            "--------------------------------------------------------------------------------------------" + Environment.NewLine +
            "" + Environment.NewLine +
            "Per iniziare una partita basterà scegliere una materia tra quelle proposte e pigiare sul tasto 'nuova partita', quando il quiz si presenterà potrete vedere la domada e le quattro possibili risposte, il numero della domanda a cui sui è arrivati e il pulsante per passare alla domanda successiva (quando si ha risposto ad una domanda non si può tornare indietro), inoltre si possono notare la fuzione 'Termina partita' e 'Suggerimenti', il primo permette di terminare prima il quiz ma i progressi non verranno salvati, il secondo dà un consiglio al giocatore sulla risposta giusta." + Environment.NewLine +
            "" + Environment.NewLine +
            "--------------------------------------------------------------------------------------------" + Environment.NewLine +
            "" + Environment.NewLine +
            "Infine una volta risposto a tutte le domande si potrà vedere il proprio risultato a schermo.";
            MessageBox.Show(a, "Info");
        }
    }
}
