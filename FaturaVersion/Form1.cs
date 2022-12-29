/*************************************************************************************************
**				        	            SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				     NESNEYE DAYALI PROGRAMLAMA DERSİ 2021-2022 BAHAR DÖNEMİ
**					
**	
**				ÖDEV NUMARASI..........: 1
**				ÖĞRENCİ ADI............: Eren Kara
**				ÖĞRENCİ NUMARASI.......: B211210031
**              DERSİN ALINDIĞI GRUP...: 1-B
**
**************************************************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev2Forms2
{

    public partial class Form1 : Form
    {
        static class Hesaplamalar
        {
            private static string sayiStrTamkisim;  // string olarak
            private static string sayiStrOndaliklikisim;
            private static int sayininTamKismi;
            private static int sayininOndalikKismi;  // sayi olarak
            private static int index;                // hesaplanacak olan sayı
            public static string okunusu;

            private static string[] birlerBasamagi = { "","Bir", "İki", "Üç", "Dört", "Beş", "Altı", "Yedi", "Sekiz", "Dokuz" };
            private static string[] OnlarBasamagi = { "","On", "Yirmi", "Otuz", "Kırk", "Elli", "Altmış", "Yetmiş", "Seksen", "Doksan" };
            private static string[] ekstralar = { "Yüz", "Bin", "Milyon","Milyar" };
            private static string[] ekstralarOndalikli = { "Onda", "Yüzde", "Binde", "Onbinde", "Yüzbinde","Milyonda" };

            public static void TamKisim(string sayiStr)
            {
                okunusu = "";
                if (sayiStr.IndexOf(".") != -1)
                {
                    sayininOndalikKismi = sayiStr.Count() - (sayiStr.IndexOf(".") + 1);
                    sayininTamKismi = sayiStr.Count() - (sayininOndalikKismi + 1);
                    sayiStrTamkisim = sayiStr.Substring(0, sayininTamKismi);
                    sayiStrOndaliklikisim = sayiStr.Substring(sayininTamKismi + 1, sayininOndalikKismi);
                    TamOkunusu();
                    OndalikOkunusu();
                }
                else
                {
                    sayininTamKismi = sayiStr.Count();
                    sayiStrTamkisim = sayiStr.Substring(0, sayininTamKismi);
                    TamOkunusu();
                }
            }
            public static void TamOkunusu()
            {
                for (; sayininTamKismi > 0; sayininTamKismi--)
                {
                    string ara_gecis = Convert.ToString(sayiStrTamkisim[0]);
                    index = Convert.ToInt32(ara_gecis);
                    if (sayininTamKismi == 1 && index == 0)
                    {
                        okunusu += "Sıfır";
                    }
                    if (sayininTamKismi % 3 == 0 && index !=0)
                    {
                        if(index!=1)
                        {
                            okunusu += birlerBasamagi[index];
                        }
                        okunusu += ekstralar[0];
                    }
                    else if (sayininTamKismi % 3 == 2)
                    {
                        okunusu += OnlarBasamagi[index];
                    }
                    else
                    {
                        if (sayininTamKismi % 3 == 1 && index != 1)
                        {
                            okunusu += birlerBasamagi[index];
                        }
                        if (sayininTamKismi % 3 == 1 && sayininTamKismi != 1 && index!=0)
                        {
                            okunusu += ekstralar[sayininTamKismi / 3];
                        }
                    }
                    sayiStrTamkisim = sayiStrTamkisim.Remove(0, 1);
                }
            }
            public static void OndalikOkunusu()
            {
                
                okunusu += "Tam" + ekstralarOndalikli[sayininOndalikKismi - 1];

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
                        if (sayininOndalikKismi % 3 == 1 && index != 1)
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
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Hesaplamalar.TamKisim(textBox1.Text);
            label3.Text = Hesaplamalar.okunusu;
        }
    }
}
