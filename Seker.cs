﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Hastane
{
    public class Seker : HastalikCesidiAbstraction
    {
        OleDbConnection baglanti;
        OleDbCommand komut;
        public override void Hastalik()
        {
            komut = new OleDbCommand();
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=D:/Hastane_Projesi/Hastane.accdb");
            komut.Connection = baglanti;

            int deger = base.KullaniciKontrol();
            if (deger == 0)
            {

                komut.CommandText = "insert into Hasta(HastaAdi,HastaSoyadi,HastaTCKNO,Hastalik,DiyetYontemi,Kahvalti,OgleYemegi,AksamYemegi) values('" + base.KisiAd + "','" + base.KisiSoyad + "','" + base.KisiTCKNO + "','Seker','" + diyet.Diyet() + "','" + diyet.Kahvalti() + "','" + diyet.OgleYemegi() + "','" + diyet.AksamYemegi() + "')";

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                System.Windows.Forms.MessageBox.Show("Kişi Kaydedildi.");
            }
            else if (deger == 1)
            {
                komut.CommandText = "update Hasta set Hastalik='Seker',DiyetYontemi='" + diyet.Diyet() + "',Kahvalti='" + diyet.Kahvalti() + "',OgleYemegi='" + diyet.OgleYemegi() + "',AksamYemegi='" + diyet.AksamYemegi() + "' where HastaTCKNO=" + base.KisiTCKNO + "";

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                System.Windows.Forms.MessageBox.Show("Kişi Bilgileri Güncellendi.");
            }
        }
    }
}
