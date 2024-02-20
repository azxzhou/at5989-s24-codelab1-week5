using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;



public class ASCIILevelLoader : MonoBehaviour
{

    int currentLevel = 0;

    GameObject level;

    public int CurrentLevel
    {

        get
        {

            return currentLevel;

        }

        set
        {

            currentLevel = value;
            
            LoadLevel();

        }
        
    }

    string FILE_PATH;

    public static ASCIILevelLoader instance;
    
    // Start is called before the first frame update
    
    void Start()
    {

        FILE_PATH = Application.dataPath + "/Levels/LevelNum.txt";
        
        LoadLevel();

    }
    void LoadLevel()
    {
        
        Destroy(level);
        
        level = new GameObject("Level Objects");

        string[] lines = File.ReadAllLines(FILE_PATH.Replace("Num", currentLevel + "")); 
        //read all lines

        for (int yLevelPos = 0; yLevelPos < lines.Length; yLevelPos++)
        {

            string line = lines[yLevelPos].ToUpper(); //make line variable a single string

            char[] characters = line.ToCharArray();
            
            for (int xLevelPos = 0; xLevelPos < characters.Length; xLevelPos++)
            {
            
                char c = characters[xLevelPos];

                GameObject newObject = null;

                switch (c) //check if thing is any of the listed and do x if so
                {

                    case 'W': //wall
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Wall"));
                        break;

                    case 'P': //player
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
                        Camera.main.transform.parent = newObject.transform;
                        Camera.main.transform.position = new Vector3(0, 0, -10);
                        break;

                    case 'S': //spike
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Spike"));
                        break;
                    
                    case 'G': //goal
                        newObject = Instantiate((Resources.Load<GameObject>("Prefabs/Goal")));
                        break;

                    default:
                        break;

                }
                

                if (newObject != null) //give position based on where it was in ascii file
                {
                    
                    newObject.transform.parent = level.transform; 
                    //makes all the new objects nest under this - doesnt work when newObject is null
                    
                    newObject.transform.position = new Vector3(xLevelPos, -yLevelPos, 0);
                    
                }
            
            }
            
        }
        
    }
    
}
