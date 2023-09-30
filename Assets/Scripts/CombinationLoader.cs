using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CombinationLoader
{
    private static string combinationFolder = "Assets/Texts";
    private static string combinationFile = "combination.txt"; 
    private static string combinationPath
    {
        get
        {
            return Path.Combine(combinationFolder, combinationFile);
        }
    }
    public static List<int> Load(List<int> defaultCombination)
    {
        EnsureFileExist(defaultCombination);
        return ReadCombinationFromFile();
    }
    private static void EnsureFileExist(List<int> defaultCombination)
    {
        if (!File.Exists(combinationPath)) //if not file exist
        {
            CreateFile(defaultCombination);
        }
    }

    private static void CreateFile(List<int> defaultCombination)
    {
        EnsureDirectoryExists();
        StreamWriter writer = new StreamWriter(combinationPath);
        foreach (int combinationEntry in defaultCombination)
        {
            writer.WriteLine(combinationEntry); //adds a line after each number
        }
        writer.Close();
    }

    private static void EnsureDirectoryExists()
    {
        if (!Directory.Exists(combinationFolder))
        {
            Directory.CreateDirectory(combinationFolder);
        }
    }

    private static List<int> ReadCombinationFromFile()
    {
        List<int> combination = new List<int>();

        StreamReader reader = new StreamReader(combinationPath);
        string combinationNumber = string.Empty;
        while ((combinationNumber = reader.ReadLine()) != null)
        {
            int combinationInteger;
            bool wasSuccess = int.TryParse(combinationNumber, out combinationInteger); //makes the string an int
            if (wasSuccess)
                combination.Add(combinationInteger);
        }
        reader.Close();
        return combination;
    }
}
