using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlasılıkProblemi
{

    public class Kova
    {
        List<Top> _toplar = new List<Top>();


        public Top rastgeleTopCek()
        {

            Guid guid = Guid.NewGuid();                     //Random yaramadı bunu kullandım
            byte[] bytes = guid.ToByteArray();              //
            int rastgele = BitConverter.ToInt32(bytes, 0);  //random sayı üretme

            rastgele = Math.Abs(rastgele % _toplar.Count);
            //Console.WriteLine(rastgele +"--"+_toplar.Count);
            Top cekilenTop = _toplar[rastgele];
            _toplar.RemoveAt(rastgele);
            return cekilenTop;
        }


        public void topEkle(Top t)
        {
            _toplar.Add(t);
        }


        public void kovaDoldur(int beyazTopSayisi, int SiyahTopSayisi)
        {
            
            for (int i = 0; i < beyazTopSayisi; i++)
            {
                topEkle(new BeyazTop());
            }
            for (int i = 0; i < SiyahTopSayisi; i++)
            {
                topEkle(new SiyahTop());
            }

        }

        public void toplariYaz()
        {
            foreach (Top top in _toplar)
            {
                Console.WriteLine(top.Renk);
            }
        }

    }
}
