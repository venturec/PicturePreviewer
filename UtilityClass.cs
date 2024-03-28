using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturePreviewer
{
    internal class UtilityClass
    {
        public static String folderBrowserSelectPath(String descr, Boolean showNewFolderBtn, FolderEnum fe, String lastSelectedPath)
        {
            String selectedFolderPath = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (descr != "") fbd.Description = descr;

            if (fe == FolderEnum.ReadFrom && lastSelectedPath != "")
            {
                fbd.SelectedPath = lastSelectedPath;
            }
            else if (fe == FolderEnum.SaveTo && lastSelectedPath != "")
            {
                fbd.SelectedPath = lastSelectedPath;
            }

            fbd.ShowNewFolderButton = showNewFolderBtn;

            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                if (fbd.SelectedPath != null && fbd.SelectedPath != "")
                {
                    selectedFolderPath = fbd.SelectedPath;
                }
            }

            return selectedFolderPath;
        }

        public static String[] getDirectoryFiles(String folderPath, Boolean getFromSubfolders)
        {
            List<String> fileList = new List<string>();

            List<String> subdirectoryComplete = new List<String>();
            // Escape any characters in the search String first
            // Get each folder and subfolder
            List<String> subDirectoryList = new List<String>();

            subDirectoryList.Add(folderPath);
            if (getFromSubfolders == true)
            {
                subDirectoryList.AddRange(getSubdirectories(folderPath));
            }

            //Boolean resultsFound = false;
            Boolean subdirectoriesExist = false;

            if (subDirectoryList.Count > 0)
            {
                subdirectoriesExist = true;
            }

            while (subdirectoriesExist == true)
            {
                if (subDirectoryList.Count == 0) subdirectoriesExist = false;

                for (Int32 i = 0; i < subDirectoryList.Count; i++)
                {
                    try
                    {
                        // Get all files in the current directory
                        fileList.AddRange(Directory.GetFiles(subDirectoryList[i]));
                    }
                    catch (Exception exc)
                    {

                    }

                    subdirectoryComplete.Add(subDirectoryList[i]);
                }

                // Check if there are any additional sub directories in the current directory and add them to the list
                if (getFromSubfolders == true)
                {
                    List<String> subDirectories = new List<String>();
                    for (Int32 i = 0; i < subDirectoryList.Count; i++)
                    {
                        List<String> sds = getSubdirectories(subDirectoryList[i]);
                        if (sds.Count > 0)
                        {
                            foreach (String s in sds)
                            {
                                if (!subdirectoryComplete.Contains(s))
                                {
                                    subDirectories.Add(s);
                                }
                            }
                        }
                    }

                    // Remove the current directories in subDirectoriesList before adding the additional subdirectories
                    subDirectoryList.Clear();

                    if (subDirectories.Count > 0)
                    {
                        foreach (String s in subDirectories)
                        {
                            if (!subDirectoryList.Contains(s))
                            {
                                subDirectoryList.Add(s);
                            }
                        }

                        subDirectories.Clear();
                    }
                }
                else
                {
                    subdirectoriesExist = false;
                }
            }

            return fileList.ToArray();
        }

        private static List<String> getSubdirectories(String folderLocation)
        {
            // Check for additional subdirectories in the current subdirectory list and add them to the list
            List<String> subDirectoryList = new List<String>();
            String[] subDirectories = new String[0];
            try
            {
                subDirectories = Directory.GetDirectories(folderLocation);
                foreach (String sub in subDirectories)
                {
                    subDirectoryList.Add(sub);
                }
            }
            catch (Exception e)
            {

            }

            return subDirectoryList;
        }

    }
}
