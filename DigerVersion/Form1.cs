/************************************************************************************
**                               SAKARYA ÜNİVERSİTESİ
**                    BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**                           BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**              NESNEYE DAYALI PROGRAMLAMA DERSİ 2021-2022 BAHAR DÖNEMİ
** 
**
**              ÖDEV NUMARASI..........: 2
**              ÖĞRENCİ ADI............: Eren Kara
**              ÖĞRENCİ NUMARASI.......: B211210031
**              DERSİN ALINDIĞI GRUP...: 1-B
**
**
*************************************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormOdev2
{
    public partial class Form1 : Form
    {
        static class Hesaplamalar
        {
            private static string sayiStrTamkisim;   // string olarak
            private static string sayiStrOndaliklikisim; //string
            private static int sayininTamKismi;      // sayi
            private static int sayininOndalikKismi;  // sayi olarak
            private static int index;                // hesaplanacak olan basamaktaki sayı
            private static string okunusu;           // en son yazdıralacak okunuş   
            private static int sabitTamKisim;        // sayinin tam kısmının değişmemesi için
            private static int sabitOndalikKisim;    // sayinin tam kısmının değişmemesi için


            private static string[] birlerBasamagi = { "", "Bir ", "İki ", "Üç ", "Dört ", "Beş ", "Altı ", "Yedi ", "Sekiz ", "Dokuz " };
            private static string[] OnlarBasamagi = { "", "On ", "Yirmi ", "Otuz ", "Kırk ", "Elli ", "Altmış ", "Yetmiş ", "Seksen ", "Doksan " };
            private static string[] ekstralar = { "Yüz ", "Bin ", "Milyon ", "Milyar " };

            public static void Hesaplama(string sayiStr)  // sayinin tam ve ondalik kısımlarını buluyor.
            {
                if (sayiStr.IndexOf(".") != -1)
                {
                    sayininOndalikKismi = sayiStr.Count() - (sayiStr.IndexOf(".") + 1);
                    sayininTamKismi = sayiStr.Count() - (sayininOndalikKismi + 1);
                    sayiStrTamkisim = sayiStr.Substring(0, sayininTamKismi);
                    sayiStrOndaliklikisim = sayiStr.Substring(sayininTamKismi + 1, sayininOndalikKismi);
                }
                else
                {
                    sayininTamKismi = sayiStr.Count();
                    sayiStrTamkisim = sayiStr.Substring(0, sayininTamKismi);
                }
                sabitTamKisim = sayininTamKismi;
                sabitOndalikKisim = sayininOndalikKismi;
            }
            public static int get_TamKisim()
            {
                return sabitTamKisim;
            }
            public static int get_OndalikKisim()
            {
                return sabitOndalikKisim;
            }

            public static void OkunusHesaplama(string sayiStr) // okunuşunu hesaplamak üzere fonk çağırıyor.
            {
                okunusu = "";
                if (sayiStr.IndexOf(".") != -1)
                {
                    TamOkunusu();
                    OndalikOkunusu();
                }
                else
                {
                    TamOkunusu();
                }
            }
            public static void TamOkunusu()     // sayının tam kısmının okunuşunu hesaplıyor
            {
                for (; sayininTamKismi > 0; sayininTamKismi--)
                {
                    string ara_gecis = Convert.ToString(sayiStrTamkisim[0]);
                    index = Convert.ToInt32(ara_gecis);
                    if (sabitTamKisim == 1 && index == 0) // sadece 0 girildiğinde 0 basıyor
                    {
                        okunusu += "Sıfır ";
                    }
                    if (sayininTamKismi % 3 == 0 && index != 0)   //  yüzü bastırmak için yaptım
                    {
                        if (index != 1)
                        {
                            okunusu += birlerBasamagi[index];
                        }
                        okunusu += ekstralar[0];
                    }
                    else if (sayininTamKismi % 3 == 2)  // yirmi otuz'ları bastırıyor.
                    {
                        okunusu += OnlarBasamagi[index];
                    }
                    else   // bir iki üç'ü bastırıyor
                    {
                        if (sayininTamKismi % 3 == 1)  // birler basamağını yapıyor
                        {
                            okunusu += birlerBasamagi[index];
                        }
                        if (index == 1 && sayininTamKismi == 4 && sabitTamKisim == 4)   // bindeki biri siliyor.
                        {
                            okunusu = okunusu.Remove(0, 4);
                        }
                        if (sayininTamKismi % 3 == 1 && sayininTamKismi != 1)   //  bin milyon ekliyor.
                        {
                            okunusu += ekstralar[sayininTamKismi / 3];
                        }
                    }
                    sayiStrTamkisim = sayiStrTamkisim.Remove(0, 1);
                }
                okunusu += "TL ";
            }
            public static void OndalikOkunusu()     // sayının ondalık kısmının okunuşunu hesaplıyor
            {
                for (; sayininOndalikKismi > 0; sayininOndalikKismi--)
                {
                    string ara_gecis = Convert.ToString(sayiStrOndaliklikisim[0]);
                    index = Convert.ToInt32(ara_gecis);
                    if (sayininOndalikKismi % 3 == 0 && index != 0)
                    {
                        if (index != 1)
                        {
                            okunusu += birlerBasamagi[index];
                        }
                        okunusu += ekstralar[0];
                    }
                    else if (sayininOndalikKismi % 3 == 2)
                    {
                        okunusu += OnlarBasamagi[index];
                    }
                    else
                    {
                        if (sayininOndalikKismi % 3 == 1)
                        {
                            okunusu += birlerBasamagi[index];
                        }
                        if (sayininOndalikKismi % 3 == 1 && sayininOndalikKismi != 1)
                        {
                            okunusu += ekstralar[sayininOndalikKismi / 3];
                        }
                    }

                    sayiStrOndaliklikisim = sayiStrOndaliklikisim.Remove(0, 1);
                }
                okunusu += "Kuruş";
            }
            public static string get_Okunusu()
            {
                return okunusu;
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        TextBox txt1 = new TextBox();
        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        Button btn1 = new Button();

        private void Form1_Load(object a, EventArgs b)
        {
            this.Size = new Size(670, 356);    // formun boyutu  ( X , Y )
            this.BackColor = Color.FromArgb(153, 180, 209);

            Font eski = lbl1.Font;              // eski bir fontfamily almak zorundayım ki yenisini tanımlayayım
            Font yeni = new Font(eski.FontFamily, 11, FontStyle.Bold);  // yazının boyutu ve bold olması
            lbl1.Font = yeni;    // kontrollerin font ayarı
            lbl2.Font = yeni;
            lbl3.Font = yeni;
            btn1.Font = yeni;
            txt1.Font = yeni;

            lbl1.Text = "_______________";
            lbl1.ForeColor = Color.FromArgb(128, 0, 0);    // RGB renkleriyle renk verme
            btn1.BackColor = Color.White;
            btn1.Text = "Hesapla ";
            lbl2.Text = "Faturadaki Tutar ";
            lbl3.Text = "Tutarın Okunuşu ";
            txt1.Text = "";
            txt1.Name = "txt1";
            lbl1.AutoSize = true;   // yazıya göre label'ın boyutunun ayarlanması
            lbl2.AutoSize = true;
            lbl3.AutoSize = true;

            Point txt1_Yer = new Point(190, 47);   // konumlarını ayarladım
            Point lbl1_Yer = new Point(190, 123);
            Point lbl2_Yer = new Point(35, 47);
            Point lbl3_Yer = new Point(35, 123);
            Point btn1_Yer = new Point(104, 204);
            btn1.Size = new Size(192, 33);
            btn1.Location = btn1_Yer;
            txt1.Location = txt1_Yer;
            lbl1.Location = lbl1_Yer;
            lbl2.Location = lbl2_Yer;
            lbl3.Location = lbl3_Yer;

            this.Controls.Add(txt1);
            this.Controls.Add(btn1);
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);
            this.Controls.Add(lbl3);

            btn1.Click += btn1_Click;   //   Eventi method ile eşleştirdik
            this.AcceptButton = btn1;   //   Enter'a basınca btn1 nesnesi çalışacak
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Hesaplamalar.Hesaplama(txt1.Text);
            if (Hesaplamalar.get_TamKisim() > 5)
            {
                MessageBox.Show("Lütfen 5 basamaktan fazla sayı girmeyin.");
            }
            else if (Hesaplamalar.get_OndalikKisim() > 2)
            {
                MessageBox.Show("99 kuruştan büyük bir miktar giremezsiniz.");
            }
            else
            {
                Hesaplamalar.OkunusHesaplama(txt1.Text);
                lbl1.Text = Hesaplamalar.get_Okunusu();
            }
        }
    }
}
