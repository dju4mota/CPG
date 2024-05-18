using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;


public class LevelController : MonoBehaviour
{

    [SerializeField] public  Bloco[] listaBloco;
    [SerializeField] public int sizeX = 128;
    [SerializeField] public int sizeY = 128;
    [SerializeField] public int[,] listaGabarito = new int[128,128];
    [SerializeField] public int[,] listaMarcados = new int[128,128];
    [SerializeField] public float tempoLimite;
    [SerializeField] public float tempoAtual;
    [SerializeField] public float pontos;
    [SerializeField] TMP_Text time;
    public Bloco Bloco;
    string[] lines;
    int faseAtual = 5;

    // Start is called before the first frame update
    void Start()
    {
        Read();
        Generate();
        tempoAtual = tempoLimite;
    }

    // Update is called once per frame
    void Update()
    {
        time.text = ((int)tempoAtual).ToString();
        if(tempoAtual > 0)
        {
            tempoAtual -= Time.deltaTime;
        }
    }

    public void CarregarFase()
    {
        faseAtual++;
        Read();
        Generate();
    }

    public void CalculaPontos()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                if (listaGabarito[i,j] == listaMarcados[i,j])
                {
                    pontos++;
                }
                else
                {
                    pontos--;
                }
            }
        }
        Debug.Log("pontos: " + pontos);
        pontos += tempoAtual - tempoLimite;
        Debug.Log("ponto com tempo" + pontos);
    }


    private void Read()
    {
        string filePath;
        switch (faseAtual)
        {
            case 1:
                filePath = Application.dataPath + "/StreamingAssets/fase_1.txt";
                break;
            case 2:
                filePath = Application.dataPath + "/StreamingAssets/fase_2.txt";
                break;
            case 3:
                filePath = Application.dataPath + "/StreamingAssets/fase_3.txt";
                break;
            case 4:
                filePath = Application.dataPath + "/StreamingAssets/fase_4.txt";
                break;
            case 5:
                filePath = Application.dataPath + "/StreamingAssets/fase_5.txt";
                break;
            default:
                filePath = Application.dataPath + "/StreamingAssets/fase_1.txt";
                break;

        }
        


        if (File.Exists(filePath))
        {
            lines = File.ReadAllLines(filePath);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

    public void Generate()
    {
        int x = 0;
        int y = 0;
        float xpos = transform.position.x;
        float ypos = transform.position.y;
        // for
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                Bloco b = Instantiate(Bloco, transform);
                b.x = x;
                b.y = y;
                b.transform.position = new Vector3(xpos, ypos, 0);
                x++;
                xpos += 0.075f;
                if (lines[i][j] == '1')
                {
                    listaGabarito[i, j] = 1;
                }
            }
            y++;
            ypos += 0.075f;
            x = 0;
            xpos = transform.position.x;
        }


        // so printa o gabarito pra testar
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < listaGabarito.GetLength(0); i++)
        {
            for (int j = 0; j < listaGabarito.GetLength(1); j++)
            {
                sb.Append(listaGabarito[i, j]);
                sb.Append(' ');
            }
            sb.AppendLine();
        }
        Debug.Log(sb.ToString());

    }
}
