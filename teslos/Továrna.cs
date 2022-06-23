using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;

namespace projekt_továren.Tridy
{
    internal class Továrna
    {
        Dictionary<string, string> TeslaIndustries = new Dictionary<string, string>()
        {
            {"Model 3", "https://backend.elektrickevozy.cz/wp-content/uploads/2021/08/tesla-model-3-modra-jizda.jpg" },
            {"Model S", "https://cdn.24net.cz/5/obrazek/tesla-model-s-27628" },
            {"Model X", "https://tesla-cdn.thron.com/delivery/public/image/tesla/ddc135ed-1638-40fb-8ab1-f8045059ecef/bvlatuR/std/4096x2560/Homepage-Model-X-Desktop-LHD" },
            {"Model Y", "https://tesla-cdn.thron.com/delivery/public/image/tesla/8e2df1b9-a4bf-4eb9-beec-2cf5cc77fca0/bvlatuR/std/2880x2400/Desktop-ModelY?quality=70" },
            {"Cybertruck", "https://i0.wp.com/auto-mania.cz/wp-content/uploads/2019/12/tesla-cybertruck-fake-video.jpg?fit=800%2C450&ssl=1" }
        };

        public string Menu()
        {
            Console.WriteLine("Vítejte v továrně Tesla");
            Console.WriteLine("V nabidce máme");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Model S");
            Console.WriteLine("Model 3");
            Console.WriteLine("Model X");
            Console.WriteLine("Model Y");
            Console.WriteLine("Cybertruck");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1.Chci zobrazit poslední vytvořené auto");
            Console.WriteLine("2.Chci vytvořit nové auto");

            string input = Console.ReadLine();
            return input;
        }

        public Auto VytvorAuto()
        {
            Console.Clear();

            Auto vyrabeneAuto = new Auto();
            #region model
            while (true)
            {
                Console.WriteLine("Zadej model : (zadejte přesný název)");
                vyrabeneAuto.model = Console.ReadLine();
                if (this.TeslaIndustries.ContainsKey(vyrabeneAuto.model))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("error, špatná hodnota");
                }
            }
            #endregion model
            #region pocetsedadel
            while (true)
            {
                Console.WriteLine("Zadej počet sedadel");
                vyrabeneAuto.pocetsedadel = Convert.ToInt32(Console.ReadLine());
                if (vyrabeneAuto.pocetsedadel > 3 && vyrabeneAuto.pocetsedadel < 9)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("error, špatná hodnota");
                }
            }
            #endregion pocetsedadel
            #region druhpohonu
            while (true)
            {

                Console.WriteLine("Zadej druh pohonu");
                Console.WriteLine("Elektrický/Hybridní");
                vyrabeneAuto.druhpohonu = Console.ReadLine();
                if (vyrabeneAuto.druhpohonu == "elektrický" || vyrabeneAuto.druhpohonu == "Hybridní")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("error, špatná hodnota");
                }

            }
            #endregion druhpohonu
            Console.WriteLine("Zadejte Cenu: ");
            vyrabeneAuto.Cena = Convert.ToInt32(Console.ReadLine());

            vyrabeneAuto.obrazek = TeslaIndustries[vyrabeneAuto.model];

            return vyrabeneAuto;
        }


        public void VytvorStranku(Auto vyrobeneAuto)
        {
            string html = $@"
            <html>
            <body>
            <h1>Továrna na auta</h1>
            <h2 style='color:blue;'>{vyrobeneAuto.Znacka}</h2>
            <h2>{vyrobeneAuto.model}</h2>
            <h2>Počet sedaček: {vyrobeneAuto.pocetsedadel}</h2>
            <h2>Druh pohonu: {vyrobeneAuto.druhpohonu}</h2>
            <img  src='{vyrobeneAuto.obrazek}'>
            <h3>Rok výroby: {vyrobeneAuto.rokvyroby}</h3>
            <hr>
            <div>
            Cena: <h4 style='color: orange;'>{vyrobeneAuto.Cena}</h4>
            </div>
            </body>
            </html>";
            File.WriteAllText("index.html", html);
        }
        public void ZobrazStranku(string adresaSouboru)
        {
            var process = new System.Diagnostics.ProcessStartInfo();
            process.UseShellExecute = true;
            process.FileName = adresaSouboru;
            System.Diagnostics.Process.Start(process);
        }
    }
}