using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OlasılıkProblemi
{
    public static class Oyun
    {

        static int _oyunSayisi;
        static int _kovaSayisi;
        static int _ilkCekilenBeyazSayisi;
        static bool _ilkCekilenTopBeyazMi;
        static int _sonCekilenSiyahSayisi;
        static int puan;
        public static Kova[] _kovalar = new Kova[_kovaSayisi];
        


        public static void run(int oyunSayisi, int kovaSayisi1)
        {
            Console.SetCursorPosition((Console.WindowWidth - "".Length) / 2, Console.CursorTop);
            Console.Write("bekle");

            _oyunSayisi = oyunSayisi;
            _kovaSayisi = kovaSayisi1;
            _ilkCekilenTopBeyazMi = false;
            _kovalar = new Kova[_kovaSayisi];
            kovalariDoldur();
            topCekYanKutuyaAt(0, kovaSayisi1);
            Top SonBirTopCek = _kovalar[0].rastgeleTopCek();
           
            if(SonBirTopCek.Renk == "Siyah"&& _ilkCekilenTopBeyazMi)
            {
                puan++;
            }
            if (SonBirTopCek.Renk == "Siyah")
            {
                _sonCekilenSiyahSayisi++;
            }


            //oyuna devam edilecekmi
            if (oyunSayisi>1)
            run(oyunSayisi-1,kovaSayisi1);
            //oyuna devam edilmeyecekse istatistikleri? yaz
            else
            {
                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth - "Özet".Length) / 2, Console.CursorTop);
                Console.WriteLine();

                Console.WriteLine("İlk Beyaz Çekme Sayısı = " + _ilkCekilenBeyazSayisi);
                Console.WriteLine();

                Console.WriteLine("Son Cekilen Siyah Sayısı = " + _sonCekilenSiyahSayisi);
                Console.WriteLine();

                Console.WriteLine("İlk Beyaz Çekip Son Siyah Çekme Sayısı = " + puan);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();


            }
        }


        static void kovalariDoldur()
        {
            for (int i = 0; i < _kovaSayisi; i++)
            {
                _kovalar[i] = new Kova();
                _kovalar[i].kovaDoldur(i + 1, i + 2);
            }
        }

        static void topCekYanKutuyaAt(int baslangic, int bitis)
        {
            //cekilen top büyük numaralı kovaya atılıyor
            for (int i = baslangic; i < bitis - 1; i++)
            {
                
                Top cekilentop = _kovalar[i].rastgeleTopCek();
                _kovalar[i + 1].topEkle(cekilentop);
                if (i == 0 && cekilentop.Renk=="Beyaz")
                {
                    _ilkCekilenTopBeyazMi = true;
                    _ilkCekilenBeyazSayisi++;
                }
                
            }
            //Console.WriteLine(_ilkCekilenBeyazSayisi);
            //çekilen top küçük numaralı kovaya atılıyor
            for (int i = bitis - 1; i > baslangic; i--)
            {
                Top cekilentop = _kovalar[i].rastgeleTopCek();
                _kovalar[i - 1].topEkle(cekilentop);
            }
        }



    }
}
