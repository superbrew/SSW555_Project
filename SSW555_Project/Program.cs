using System;
using System.Collections.Generic;
using System.Linq;
/************************************************************************************
 * 
 * 
 * *********************************************************************************/

using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SSW555_Project
{
    class Program
    {
        static string[] validTags = {
                                 "INDI",
                                 "NAME",
                                 "SEX",
                                 "BIRT",
                                 "DEAT",
                                 "FAMC",
                                 "FAMS",
                                 "FAM",
                                 "MARR",
                                 "HUSB",
                                 "WIFE",
                                 "CHIL",
                                 "DIV",
                                 "DATE",
                                 "HEAD",
                                 "TRLR",
                                 "NOTE"
                             };

        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("outputFile.txt");
            Console.Write("SSW-555 Project P02\n");
            Console.Write("GEDCOM data extraction tool\n\n");
            Console.Write("**********************************************\n" +
                          "Enter a file name:");
            string fileName = Console.ReadLine();
            string[] gedcomLines;
            while (true)
            {
                try
                {
                    gedcomLines = File.ReadAllLines(fileName);
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid file name. Enter a file name:");
                    fileName = Console.ReadLine();
                }
            }
            foreach (string line in gedcomLines)
            {
                Console.WriteLine(line);
                writer.WriteLine(line);
                string[] splitLine = line.Split(' ');
                Console.WriteLine(splitLine[0]); 
                writer.WriteLine(splitLine[0]);
                bool isValid = false;
                foreach(string tag in validTags)
                {
                    if (splitLine[1] == tag)
                    {
                        isValid = true;
                        Console.WriteLine(splitLine[1]);
                        writer.WriteLine(splitLine[1]);
                    }
                }
                if (!isValid)
                {
                    Console.WriteLine("Found tag error");
                    writer.WriteLine("<<<TAG ERROR>>>");
                    writer.WriteLine(splitLine[1]);
                }
            }
            writer.Close();
            Console.WriteLine("Output saved in 'output.txt'. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
