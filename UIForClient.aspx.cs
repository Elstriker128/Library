using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace Library
{
    public partial class UIForClient : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            string dataPath = TextBox1.Text;
            string searchPattern = "*.txt";

            try
            {
                if(Directory.GetFiles(dataPath, searchPattern).Length==0 && Directory.GetFiles(dataPath, searchPattern).Count()==0)
                {
                    throw new DirectoryNotFoundException();
                }
            }
            catch(DirectoryNotFoundException)
            {
                CustomValidator6.ErrorMessage = "Nebuvo rasti tinkami duomenys"; 
            }

            string[] files = Directory.GetFiles(dataPath, searchPattern);

            TaskUtils FirstData = InOut.ReadData(files[0], CustomValidator1);
            TaskUtils SecondData = InOut.ReadData(files[1], CustomValidator2);
            TaskUtils ThirdData = InOut.ReadData(files[2],CustomValidator3);
            TaskUtils FourthData = InOut.ReadData(files[3], CustomValidator4);
            TaskUtils FifthData = InOut.ReadData(files[4],CustomValidator5);

            if (File.Exists(Server.MapPath("~/Result_Data/Nenauji.csv")))
            {
                File.Delete(Server.MapPath("~/Result_Data/Nenauji.csv"));
            }
            if (File.Exists(Server.MapPath("~/Result_Data/PopuliarūsLeidiniai.csv")))
            {
                File.Delete(Server.MapPath("~/Result_Data/PopuliarūsLeidiniai.csv"));
            }
            if (File.Exists(Server.MapPath("~/Result_Data/Rezultatai.txt")))
            {
                File.Delete(Server.MapPath("~/Result_Data/Rezultatai.txt"));
            }

            InOut.PrintData(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"{FirstData.LibraryName} duomenų failo duomenys", FirstData);
            InOut.PrintData(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"{SecondData.LibraryName} duomenų failo duomenys", SecondData);
            InOut.PrintData(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"{ThirdData.LibraryName} duomenų failo duomenys", ThirdData);
            InOut.PrintData(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"{FourthData.LibraryName} duomenų failo duomenys", FourthData);
            InOut.PrintData(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"{FifthData.LibraryName} duomenų failo duomenys", FifthData);

            InsertPublicationData($"{FirstData.LibraryName} duomenų failo duomenys", PlaceHolder1, FirstData);
            InsertPublicationData($"{SecondData.LibraryName} duomenų failo duomenys", PlaceHolder2, SecondData);
            InsertPublicationData($"{ThirdData.LibraryName} duomenų failo duomenys", PlaceHolder3, ThirdData);
            InsertPublicationData($"{FourthData.LibraryName} duomenų failo duomenys", PlaceHolder4, FourthData);
            InsertPublicationData($"{FifthData.LibraryName} duomenų failo duomenys", PlaceHolder5, FifthData);


            TaskUtils FilteredWhoAreScientific = new TaskUtils();
            FirstData.AddWhichAreScientific( ref FilteredWhoAreScientific );
            SecondData.AddWhichAreScientific(ref FilteredWhoAreScientific );
            ThirdData.AddWhichAreScientific(ref FilteredWhoAreScientific);
            FourthData.AddWhichAreScientific(ref FilteredWhoAreScientific);
            FifthData.AddWhichAreScientific(ref FilteredWhoAreScientific);

            InOut.PrintData(Server.MapPath("~/Result_Data/Rezultatai.txt"), "Leidiniai kurių stilius yra mokslinis", FilteredWhoAreScientific);

            InsertPublicationData("Mokslinio tipo leidinių duomenys", PlaceHolder6, FilteredWhoAreScientific);

            TaskUtils FilteredOld = new TaskUtils();
            FirstData.AddOldPublishes(ref FilteredOld);
            SecondData.AddOldPublishes(ref FilteredOld);
            ThirdData.AddOldPublishes(ref FilteredOld);
            FourthData.AddOldPublishes(ref FilteredOld);
            FifthData.AddOldPublishes(ref FilteredOld);
            InOut.PrintData(Server.MapPath("~/Result_Data/Rezultatai.txt"), "Pasenę leidiniai pries rūšiavimą", FilteredOld);
            InOut.PrintData(Server.MapPath("~/Result_Data/Nenauji.csv"), "Pasenę leidiniai pries rūšiavimą", FilteredOld);
            InsertPublicationData("Pasenę leidiniai pries rūšiavimą", PlaceHolder7, FilteredOld);

            FilteredOld.Sort();
            InOut.PrintData(Server.MapPath("~/Result_Data/Rezultatai.txt"), "Pasenę leidiniai po rūšiavimo", FilteredOld);
            InOut.PrintData(Server.MapPath("~/Result_Data/Nenauji.csv"), "Pasenę leidiniai po rūšiavimo", FilteredOld);
            InsertPublicationData("Pasenę leidiniai po rūšiavimo", PlaceHolder8, FilteredOld);

            TaskUtils FilteredWithMoreThan10000 = new TaskUtils();
            FirstData.AddWhichAreOver10000(ref FilteredWithMoreThan10000);
            SecondData.AddWhichAreOver10000(ref FilteredWithMoreThan10000);
            ThirdData.AddWhichAreOver10000(ref FilteredWithMoreThan10000);
            FourthData.AddWhichAreOver10000(ref FilteredWithMoreThan10000);
            FifthData.AddWhichAreOver10000(ref FilteredWithMoreThan10000);

            InOut.PrintPopular(Server.MapPath("~/Result_Data/Rezultatai.txt"), "Leidiniai su virš 10000 tiražu", FilteredWithMoreThan10000);
            InOut.PrintPopular(Server.MapPath("~/Result_Data/PopuliarūsLeidiniai.csv"), "Leidiniai su virš 10000 tiražu", FilteredWithMoreThan10000);
            Insert2FormatDataNaming("Leidiniai su virš 10000 tiražu", PlaceHolder9);
            Insert2FormatData("Leidiniai su virš 10000 tiražu", PlaceHolder9, FilteredWithMoreThan10000);

            File.AppendAllText(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"Leidinių kuriems yra daugiau nei 2 metai {FirstData.LibraryName} filiale yra: {FirstData.CountHowMany2YearOldCreations()}");
            File.AppendAllText(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"\r\n");
            File.AppendAllText(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"Leidinių kuriems yra daugiau nei 2 metai {SecondData.LibraryName} filiale yra: {SecondData.CountHowMany2YearOldCreations()}");
            File.AppendAllText(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"\r\n");
            File.AppendAllText(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"Leidinių kuriems yra daugiau nei 2 metai {ThirdData.LibraryName} filiale yra: {ThirdData.CountHowMany2YearOldCreations()}");
            File.AppendAllText(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"\r\n");
            File.AppendAllText(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"Leidinių kuriems yra daugiau nei 2 metai {FourthData.LibraryName} filiale yra: {FourthData.CountHowMany2YearOldCreations()}");
            File.AppendAllText(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"\r\n");
            File.AppendAllText(Server.MapPath("~/Result_Data/Rezultatai.txt"), $"Leidinių kuriems yra daugiau nei 2 metai {FifthData.LibraryName} filiale yra: {FifthData.CountHowMany2YearOldCreations()}");

            Insert2FormatDataNaming("Visų filialų leidiniai, kuriems daugiau nei 2 metai", PlaceHolder10);
            Insert2FormatData(FirstData.LibraryName, PlaceHolder10, FirstData, FirstData.CountHowMany2YearOldCreations());
            Insert2FormatData(SecondData.LibraryName, PlaceHolder10, SecondData, SecondData.CountHowMany2YearOldCreations());
            Insert2FormatData(ThirdData.LibraryName, PlaceHolder10, ThirdData, ThirdData.CountHowMany2YearOldCreations());
            Insert2FormatData(FourthData.LibraryName, PlaceHolder10, FourthData, FourthData.CountHowMany2YearOldCreations());
            Insert2FormatData(FifthData.LibraryName, PlaceHolder10, FifthData, FifthData.CountHowMany2YearOldCreations());
        }
        
    }
}