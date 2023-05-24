using Excel = Microsoft.Office.Interop.Excel;
using WebView2.DevTools.Dom;

namespace Parser
{
    public partial class ATS : Form
    {
        public ATS()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application excel = new();
                Excel.Workbook sheet = excel.Workbooks.Open(@"C:\Users\Luka\Desktop\Parser\ATS.xlsx");
                Excel.Worksheet? x = excel.ActiveSheet as Excel.Worksheet;
                Excel.Range usedRange = x.UsedRange;
                x.Cells.Clear();
                int brojRedova = 1;
                int brojKolona = usedRange.Columns.Count;
                var ctx = await webView21.CoreWebView2.CreateDevToolsContextAsync(); //potrebna promenljiva za rad DOM-a
                var item_data_Div = await ctx.QuerySelectorAllAsync(".item_data");
                string naziv = "", adresa = "", brojPr = "", imePrezime = "", email = "";
                //struktura divova
                /*
                 item_data
                    item_header
                    item_details
                        item_details_part
                        item_details_part
                        item_details_part
                 */
                foreach (var div in item_data_Div)
                {
                    string punString = ""; //sta se salje u excel
                    var naslovi = await div.QuerySelectorAllAsync<HtmlHeadingElement>("h2");
                    foreach (var naslov in naslovi) //ima samo jedan h2 po divu ali mora foreach jer QuerySelectorAll pravi niz
                    {
                        var tekstNaslova = await naslov.GetInnerHtmlAsync();
                        naziv = tekstNaslova;
                    }
                    punString += naziv + ", ";

                    var item_header_Div = await div.QuerySelectorAllAsync<HtmlDivElement>(".item_header");
                    foreach (var div2 in item_header_Div)
                    {
                        var podaci = await div2.QuerySelectorAllAsync<HtmlHeadingElement>("h3"); //vadi sve h3 naslove iz item_header diva
                        adresa = await podaci[0].GetInnerHtmlAsync(); //prvi h3 sadrzi adresu
                    }
                    punString += adresa + ", ";

                    var item_details_part_Div = await div.QuerySelectorAllAsync<HtmlDivElement>(".item_details_part");

                    var tabele = await item_details_part_Div[0].QuerySelectorAllAsync<HtmlTableElement>("table");
                    var aktivnaTabela = tabele[0];
                    var redovi = await aktivnaTabela.GetRowsAsync().ToArrayAsync();
                    var celije = await redovi[0].GetCellsAsync().ToArrayAsync();
                    brojPr = await celije[1].GetInnerHtmlAsync();
                    punString += brojPr + ", ";

                    tabele = await item_details_part_Div[2].QuerySelectorAllAsync<HtmlTableElement>("table");
                    aktivnaTabela = tabele[0];
                    redovi = await aktivnaTabela.GetRowsAsync().ToArrayAsync();
                    celije = await redovi[0].GetCellsAsync().ToArrayAsync();
                    imePrezime = await celije[1].GetInnerHtmlAsync();
                    punString += imePrezime + ", ";

                    celije = await redovi[4].GetCellsAsync().ToArrayAsync();
                    email = await celije[1].GetInnerHtmlAsync();
                    punString += email;
                    //MessageBox.Show(punString);
                    string[] podela = naziv.Split(' ');
                    string noviNaziv = "";
                    for (int i = 1; i < podela.Length; i++)
                    {
                        noviNaziv += podela[i] + " ";
                    }
                    if (noviNaziv.EndsWith(' '))
                    {
                        noviNaziv = noviNaziv.Remove(noviNaziv.Length - 1);
                    }
                    naziv = noviNaziv;
                    //dodavanje u excel
                    x.Cells[brojRedova, 1] = naziv;
                    x.Cells[brojRedova, 2] = adresa;
                    x.Cells[brojRedova, 3] = brojPr;
                    x.Cells[brojRedova, 4] = imePrezime;
                    x.Cells[brojRedova, 5] = email;
                    brojRedova++;
                }

                //zatvaranje i oslobadjanje svega
                MessageBox.Show("Podaci uspesno kopirani", "Gotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sheet.Close(true, Type.Missing, Type.Missing);
                excel.Quit();
                await ctx.DisposeAsync();
            }
            catch (Exception a)
            {
                MessageBox.Show("Greška:\n" + a.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Inicijalizacija()
        {
            await webView21.EnsureCoreWebView2Async(null);
        }
        public async void InitBrowser()
        {
            await Inicijalizacija();
            webView21.CoreWebView2.Navigate("http://registar.ats.rs/?q=&status=0&suspendovan=1&vrsta_akreditacije=0&datum_prve_akr_od=&datum_prve_akr_do=&datum_poslednje_akr_od=&datum_poslednje_akr_do=&datum_isticanja_akr_od=&datum_isticanja_akr_do=");
        }

        private void ATS_Load(object sender, EventArgs e)
        {
            InitBrowser();
        }
    }
}
