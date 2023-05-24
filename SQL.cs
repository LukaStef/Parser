using System.Collections;
using System.Diagnostics;

namespace Parser
{
    public partial class SQL : Form
    {
        public SQL()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string veliki = File.ReadAllText(@"ulaz.txt");
                File.WriteAllText(@"izlaz.txt", "");
                veliki = veliki.Replace("\"", "`");
                veliki = veliki.Replace("\\N", "NULL");
                string izlaz = "";
                string[] prvaPodela = new string[veliki.Length];
                prvaPodela = veliki.Split("COPY "); //razdvaja sve komande i komentare
                List<string> spremneKomande = new();
                for (int i = 1; i < prvaPodela.Length; i++) //pocinje od 1 jer je 0 prazna
                {
                    string komanda = prvaPodela[i];
                    string[] drugaPodela = new string[komanda.Length];
                    drugaPodela = komanda.Split("\\."); //razdvaja komande od komentara
                    spremneKomande.Add(drugaPodela[0]);
                }
                foreach (string a in spremneKomande)
                {
                    string[] trecaPodela = new string[a.Length];
                    trecaPodela = a.Split(" FROM stdin;"); //razdvajaju se ime i polja tabele od podataka
                    string imeTabele = trecaPodela[0];
                    imeTabele = imeTabele.Replace(" key", " `key`");
                    string vrednosti = trecaPodela[1];
                    string[] cetvrtaPodela = new string[vrednosti.Length];
                    cetvrtaPodela = vrednosti.Split("\r\n"); //pravi kolone
                    foreach (string b in cetvrtaPodela) //za svaku kolonu
                    {
                        if (b != "")
                        {

                            izlaz = "";
                            string[] petaPodela = new string[b.Length];
                            petaPodela = b.Split('\t');
                            ArrayList kolone = new();
                            foreach (string c in petaPodela) //dodaje podatke u listu
                            {
                                string vred = c;
                                if (c == "t")
                                {
                                    vred = "1";
                                }
                                if (c == "f")
                                {
                                    vred = "0";
                                }
                                if (vred.EndsWith("+01") || vred.EndsWith("+02"))
                                {
                                    vred = vred.Replace("+01", "");
                                    vred = vred.Replace("+02", "");
                                }
                                kolone.Add(vred);
                            }
                            izlaz += "INSERT INTO " + imeTabele + " VALUES (";
                            int broj = 0;
                            foreach (string c in kolone) //pravi insert komandu
                            {
                                broj++;
                                string vr = c.Replace('\n', '\0');
                                izlaz += "\"" + vr + "\",";
                            }
                            izlaz = izlaz.Replace("\"NULL\"", "NULL");
                            izlaz += ");";
                            izlaz = izlaz.Remove(izlaz.Length - 3, 1);
                            izlaz = izlaz.Replace('\n', '\0');
                            izlaz += "\r\n\n";
                            File.AppendAllText(@"izlaz.txt", izlaz);
                        }
                    }
                }
                Process.Start(@"notepad.exe", @"izlaz.txt");
            }
            catch
            {
                MessageBox.Show("Greška", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(@"notepad.exe", @"ulaz.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(@"notepad.exe", @"izlaz.txt");
        }
    }
}
