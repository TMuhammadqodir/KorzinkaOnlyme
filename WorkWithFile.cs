using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Korzinka
{
    internal static class WorkWithFile
    {

        public static void  AddToFile(string name, string amount, decimal price)
        {
            List<List<string>> FileData = GetInfoFromFile();

            bool check = false;
            int ind = 0;
            
            for(int i=0; i<FileData.Count; i++)
            {
                if (FileData[i][0].ToLower() == name.ToLower())
                {
                    ind = i;
                    check = true;

                    break;
                } 
            }


            if (check)
            {

                FileData[ind][1] = $"{float.Parse(FileData[ind][1].Split()[0]) + float.Parse(amount.Split()[0])} {amount.Split()[1]}";
                FileData[ind][2] = $"{price}";
                FileData[ind][3] = $"{Convert.ToDecimal(FileData[ind][1].Split()[0])*price}";

                File.WriteAllText("D:/Warehause.txt", $"{FileData[0][0]}|{FileData[0][1]}|{FileData[0][2]}|{FileData[0][3]}\n");

                for(int i=1; i<FileData.Count; i++)
                {
                    File.AppendAllText("D:/Warehause.txt", $"{FileData[i][0]}|{FileData[i][1]}|{FileData[i][2]}|{FileData[i][3]}\n");
                    
                }

            }
            else
            {

                File.AppendAllText("D:/Warehause.txt", $"{name}|{amount}|{price}|{price * Convert.ToDecimal(amount.Split()[0])}\n");

            }

            DateTime dateTime = DateTime.Now;

            File.AppendAllText("D:/IstoryOfWarehause.txt", $"{name}|+{amount}|{price}|{price * Convert.ToDecimal(amount.Split()[0])}|{dateTime}\n");


        }


        public static List<List<string>> GetInfoFromFile()
        {

            try
            {
                var   file = File.ReadAllText("D:/Warehause.txt").Split("\n");

                List<List<string>> result = new List<List<string>>();

                for(int i=0; i<file.Length-1; i++)
                {
                    var line = file[i].Split("|");

                    result.Add(new List<string>() { line[0], line[1], line[2], line[3] });

                }
                
                return result;
             
            }
            catch 
            {

                return new List<List<string>>();
            }
            
        }

        public static bool GetProductFromFile(string name, string amount)
        {
            List<List<string>> FileData = GetInfoFromFile();

            bool check = false;
            int ind = 0;

            for (int i = 0; i < FileData.Count; i++)
            {
                if (FileData[i][0].ToLower() == name.ToLower())
                {
                    ind = i;
                    check = true;

                    break;
                }
            }

            if(check)
            {
                if (float.Parse(FileData[ind][1].Split()[0]) > float.Parse(amount.Split()[0]))
                {
                    DateTime dateTime1 = DateTime.Now;

                    File.AppendAllText("D:/IstoryOfWarehause.txt", $"{name}|-{amount.Split()[0]} {FileData[ind][1].Split()[1]}|{FileData[ind][2]}|{Convert.ToDecimal(FileData[ind][2])* Convert.ToDecimal(amount.Split()[0])}|{dateTime1}\n");

                    FileData[ind][1] = $"{float.Parse(FileData[ind][1].Split()[0]) - float.Parse(amount.Split()[0])} {FileData[ind][1].Split()[1]}";
                    FileData[ind][3] = $"{Convert.ToDecimal(FileData[ind][1].Split()[0]) * Convert.ToDecimal(FileData[ind][2])}";
                    
                    File.WriteAllText("D:/Warehause.txt", $"{FileData[0][0]}|{FileData[0][1]}|{FileData[0][2]}|{FileData[0][3]}\n");

                    for (int i = 1; i < FileData.Count; i++)
                    {
                        File.AppendAllText("D:/Warehause.txt", $"{FileData[i][0]}|{FileData[i][1]}|{FileData[i][2]}|{FileData[i][3]}\n");

                    }

                    return true;
                }
                else if(float.Parse(FileData[ind][1].Split()[0]) == float.Parse(amount.Split()[0]))
                {
                    DateTime dateTime2 = DateTime.Now;

                    File.AppendAllText("D:/IstoryOfWarehause.txt", $"{name}|-{amount.Split()[0]} {FileData[ind][1].Split()[1]}|{FileData[ind][2]}|{Convert.ToDecimal(FileData[ind][2]) * Convert.ToDecimal(amount.Split()[0])}|{dateTime2}\n");
                   
                    FileData.RemoveAt(ind);

                    if(FileData.Count > 0)
                    {
                        File.WriteAllText("D:/Warehause.txt", $"{FileData[0][0]}|{FileData[0][1]}|{FileData[0][2]}|{FileData[0][3]}\n");

                        for (int i = 1; i < FileData.Count; i++)
                        {
                            File.AppendAllText("D:/Warehause.txt", $"{FileData[i][0]}|{FileData[i][1]}|{FileData[i][2]}|{FileData[i][3]}\n");

                        }

                    }
                    else
                    {
                        File.WriteAllText("D:/Warehause.txt","");
                    }

                    return true;
                }
               
            }
            

            return false;
        }

        public static List<List<string>> GetHistoryOfWarehause()
        {

            try
            {
                var file = File.ReadAllText("D:/IstoryOfWarehause.txt").Split("\n");

                List<List<string>> result = new List<List<string>>();

                for (int i = 0; i < file.Length - 1; i++)
                {
                    var line = file[i].Split("|");

                    result.Add(new List<string>() { line[0], line[1], line[2], line[3], line[4] });

                }

                return result;

            }
            catch
            {

                return new List<List<string>>();
            }
        }
    }
}

