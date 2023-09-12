using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Chapter_9__File_Management_And_Hndeling {
    class Program {
        static void Main(string[] args) {


            /// ///////////////////////////////////////////
            ///     reading and writing files 
            /// /////////////////////////////////////////
            ///  Writing data :
            /// File.AppendAllText    // appends to existing shit in file
            /// writeallbytes
            /// writeAllLines       // wites array of strings to the file
            /// writealltext   // replaces existing contents of file
            /// 
            /// Read Data :
            /// File.ReadAllBytes
            /// readlies
            /// readalllines
            /// readalltext
            /// ////////////////////

            // create a path to the My Documents folder and the file name
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                Path.DirectorySeparatorChar + "My Custom Folder"+ Path.DirectorySeparatorChar + "file1.txt";  // this figures out what the fuck is the seperaor accoirding to your environment


            // if the file doesn't exist, create it by using WriteAllText
            if (!File.Exists(filePath)) {
                string content = "This is a text file." + Environment.NewLine;
                Console.WriteLine("Creating the file...");
                File.WriteAllText(filePath, content);
            }
            //// Use the AppendAllText method to add text to the content

            Console.Write("enter your shitty message : ");
            //string userEnteredshit = Console.ReadLine();
            //string addedText = userEnteredshit + Environment.NewLine;
            ////string addedText = "Text added to the file" + Environment.NewLine;
            //Console.WriteLine("Adding content to the file...");
            //File.AppendAllText(filePath, addedText);
            //Console.WriteLine();

            // Read the contents of the file
            Console.WriteLine("The current contents of the file are:");
            Console.WriteLine("-------------------------------------");

            // Read the contents of the file using ReadAllText
            //string currentContent = File.ReadAllText(filePath);
            //Console.Write(currentContent);
            //Console.WriteLine();

            // Read the contents of the file using ReadAllLines
            string[] contents = File.ReadAllLines(filePath); // all lines returns with array of strings
            foreach (string s in contents)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
           


            /// /////////////////////////////////////////////////////////////

            /// ///////////////////////////////////////////////////
            ///      Path Helper > helper class by Microsoft
            /// ////////////////////////////////////////////////
            ///  c:\    user\leeha\desktop\   someFuckingFile  .txt
            /// drive         path            filename         extension

            // get the path to the documents folder from the Environment class
            //string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // directoryPath += @"\My Custom Folder\file1.txt";


            // Exercise the Path class methods
            //Console.WriteLine("\n\nThe directory(fully qualified path) name is {0}", Path.GetDirectoryName(directoryPath));
            //Console.WriteLine("\nThe file name is > {0}", Path.GetFileName(directoryPath));
            //Console.WriteLine("\nThe file extension is > {0}", Path.GetExtension(directoryPath));
            //Console.WriteLine("\nFile name without extension is {0}", Path.GetFileNameWithoutExtension(directoryPath));
            //Console.WriteLine("\nRandom file name for path is {0}", Path.GetRandomFileName());

            // some crazy stuff i learned
            //string[] splitShit = directoryPath.Split('\\');

            //foreach(string val  in splitShit) {

            //    Console.WriteLine(val);
            //}

            /// ////////////////////////////////////////////////////////////////////////////////////

            /// /////////////////////////////////////
            ///     Directories
            /// /////////////////////////////////
            /// directory.exists
            /// createdirectory
            /// delete it
            /// getcurrentdirectory
            /// getfiels
            /// getdirectories

            //string DirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string theFolder = DirectoryPath + @"\My Custom Folder";

            //bool dirExists = false; 
            //// Check to see if a directory exists
            //dirExists = Directory.Exists(theFolder);
            //if (dirExists) {
            //    Console.WriteLine("The directory exists.");
            //}
            //else {
            //    Console.WriteLine("The directory does not exist.");
            //    Console.WriteLine("creating Directory");
            //    loadinDotsProgress(500, 8, "_");
            //    Directory.CreateDirectory(DirectoryPath + @"\My Custom Folder");
            //}

            //// Write out the names of the files in the directory
            //string[] files = Directory.GetFiles(theFolder);
            //foreach (string s in files) {
            //    Console.WriteLine("Found file: " + s);
            //}
            //Console.WriteLine();

            //// Get information about each fixed disk drive
            //Console.WriteLine("Drive Information:");
            //foreach (DriveInfo d in DriveInfo.GetDrives()) {
            //    if (d.DriveType == DriveType.Fixed) {
            //        Console.WriteLine("Drive Name: {0}", d.Name);
            //        Console.WriteLine("Free Space: {0} GB", d.TotalFreeSpace / (1024 * 1024 * 1000));
            //        Console.WriteLine("Free Space: {0} MBytes", d.TotalFreeSpace / (1024 * 1024));
            //        Console.WriteLine("Free Space: {0} KBytes", d.TotalFreeSpace / 1024);
            //        Console.WriteLine("Free Space: {0} Bytes", d.TotalFreeSpace);
            //        Console.WriteLine("Drive Type: {0}", d.DriveType);
            //        Console.WriteLine();
            //    }
            //}
            //Console.WriteLine();

            /// /////////////////////////////////////////////////////////////////


            /// ////////////////////////////////////
            ///        Esisting file
            /// ////////////////////////////////
            ///  file. esxists
            /// create
            /// copy
            ///  move
            /// 

            //bool fileExists = false;
            //string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string theFile = filePath + @"\file1.txt";

            //fileExists = File.Exists(theFile);

            //if (fileExists) {

            //    Console.Write("Checking file ");
            //    loadinDotsProgress(1000, 5, ".");

            //    Console.WriteLine("\nFile exists in > " + theFile);
            //    Console.WriteLine("It was created on > {0}", File.GetCreationTime(theFile));
            //    Console.WriteLine("It was last accessed on > {0}", File.GetLastAccessTime(theFile));

            //    //Console.Write("do you want to move the file ? ");  
            //    // not using this because in the following command its just renaming the file
            //    // to move the file provide the FilePath and directory

            //    Console.Write("do you want to rename the file ? ");
            //    string op = Console.ReadLine();
            //    if (op.ToLower().Equals("yes")) {

            //        Console.Write("enter the file name : ");
            //        string newFileName = Console.ReadLine();

            //        Console.Write("Renaming the file ");
            //        loadinDotsProgress(1000, 5, ".");
            //        Console.WriteLine("\n Rename successfull");
            //        File.Move(theFile, filePath + @"\" + newFileName + ".txt");
            //    }

            //    /// //////////////////////////////////////////////

            //}
            //else {

            //    Task.Delay(1000);
            //    Console.Write("file doesn't exist ");
            //    loadinDotsProgress(1000, 8, ".");
            //    Console.Write("\ncreating file ");
            //    loadinDotsProgress(1000, 8, ".");

            //    File.Create(theFile);
            //    Console.WriteLine("\nFile Create Successfull \nPress Enter To Exit");

            //}

            /// ///////////////////////////////////////////////////////////////////////////////////////////


            Console.ReadLine(); 

        }

        public static void loadinDotsProgress(int timeDuration, int NumberOfDots ,string loadingCharacter) {

            Console.Write(" ");
            for(int i = 0; i <= NumberOfDots; i++) {
                Console.Write(loadingCharacter);
                Thread.Sleep(timeDuration);
            }
        }

    }
}
 