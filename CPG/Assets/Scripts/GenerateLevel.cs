using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public Bloco Bloco;
    public LevelController levelController;
    string[] lines;

    // Start is called before the first frame update
    void Start()
    {
        // Construct the full path to the file
        string filePath = Application.dataPath + "/StreamingAssets/teste.txt";


        if (File.Exists(filePath))
        {
            // Read all lines from the file and store them in an array
            lines = File.ReadAllLines(filePath);

           /* // Debug log to show the array contents
            foreach (string line in lines)
            {
                Debug.Log(line);
            }*/
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate()
    {
        int x = 0;
        int y = 0;
        // for
        for(int i = 0;  i < lines.Length; i++)
        {
            for(int j = 0; j < lines[i].Length; j++)
            {
                Bloco b = Instantiate(Bloco, transform);
                b.x = x;
                b.y = y;
                b.transform.position = new Vector3(x,y,0);
                x++;
                if (lines[i][j] == '1'){
                    b.marcado = true;
                    levelController.listaGabarito[i, j] = 1;

                }
                else
                {
                    levelController.listaGabarito[i, j] = 0;
                }                            
            }
            y++;
            x = 0;
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < levelController.listaGabarito.GetLength(0); i++)
        {
            for (int j = 0; j < levelController.listaGabarito.GetLength(1); j++)
            {
                sb.Append(levelController.listaGabarito[i, j]);
                sb.Append(' ');
            }
            sb.AppendLine();
        }
        Debug.Log(sb.ToString());

    }

}
