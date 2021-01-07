using File_Sort;
using System;
using System.IO;

namespace FileSort
{
    class FileSorter
    {
        public static void Sort(string path, int choice)
        {
            if (choice == 1)
            {
                SortFolderByName(path);
            }
            else if (choice == 2)
            {
                SortFolderByType(path);
            }

        }

        private static void SortFolderByName(string path)
        {
            string parentPath, destination, fileName, fileType;

            foreach (var a in Directory.GetFiles(path))
            {
                parentPath = Path.GetDirectoryName(a);

                destination = Path.GetFileName(a);
                destination = destination.Substring(0, destination.LastIndexOf("."));
                destination = destination.Substring(0, destination.LastIndexOf(".")).Replace(".", @"\");

                fileName = Path.GetFileNameWithoutExtension(a);
                fileName = fileName.Substring(fileName.LastIndexOf(".") + 1);

                fileType = a.Substring(a.LastIndexOf(".") + 1);

                MoveFile(parentPath, destination, fileName, fileType, a);
            }
        }
        private static void SortFolderByType(string path)
        {
            string parentPath, fileName, fileType;

            foreach (var a in Directory.GetFiles(path))
            {
                parentPath = Path.GetDirectoryName(a);

                fileName = Path.GetFileNameWithoutExtension(a);
                fileName = fileName.Substring(fileName.LastIndexOf(".") + 1);

                fileType = a.Substring(a.LastIndexOf(".") + 1);

                MoveFile(parentPath, fileType, fileName, fileType, a);
            }
        }


        private static void MoveFile(string parentPath, string destination, string fileName, string fileType, string pathOfCurrentFile)
        {

            try
            {
                Directory.Move(pathOfCurrentFile, $@"{parentPath}\{destination}\{fileName}.{fileType}");
            }
            catch (DirectoryNotFoundException)
            {
                if (MainWindow.DirectoryNotFoundChoice(fileName) == "Yes")
                {
                    Directory.CreateDirectory($@"{parentPath}\{destination}");
                    Directory.Move(pathOfCurrentFile, $@"{parentPath}\{destination}\{fileName}.{fileType}");
                }
                else
                {
                    //do nothing
                }
            }
        }
    }
}