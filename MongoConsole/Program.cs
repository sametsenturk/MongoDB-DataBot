using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoConsole.Library;

namespace MongoConsole
{
    class Program
    {
        // MongoDB Data Bot - Created by Abdulsamet Şentürk
        static void Main(string[] args)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("deneme");
            var col = db.GetCollection<UserModel>("users");
            string[] harfList = { "a", "b", "c", "d", "e", "f", "g", "i" };
            Random rndm = new Random();

            for (int a = 0; a < 10000; a++)
            {
                string kadi = "";
                string sifre = "";
                string ad = "";
                string soyad = "";
                for (int i = 0; i < 10; i++)
                {
                    kadi = kadi + harfList[rndm.Next(0, harfList.Length - 1)];
                    sifre = sifre + harfList[rndm.Next(0, harfList.Length - 1)];
                    ad = ad + harfList[rndm.Next(0, harfList.Length - 1)];
                    soyad = soyad + harfList[rndm.Next(0, harfList.Length - 1)];
                }
                UserModel um = new UserModel()
                {
                    Id=new ObjectId(),
                    Ad = ad,
                    Soyad = soyad,
                    Kadi = kadi,
                    Sifre = sifre
                };
                col.InsertOne(um);
                Console.WriteLine(um.Id + " => Success !");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.Write("Job is ended.");
            Console.ReadKey();
        }
    }
}
