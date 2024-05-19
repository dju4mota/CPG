using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class LevelController : MonoBehaviour
{

    [SerializeField] public  Bloco[] listaBloco;
    [SerializeField] public int sizeX = 128;
    [SerializeField] public int sizeY = 128;
    [SerializeField] public int[,] listaGabarito = new int[128,128];
    [SerializeField] public int[,] listaMarcados = new int[128,128];
    [SerializeField] public float tempoLimite;
    [SerializeField] public float tempoAtual;
    public int pontosMax;
    [SerializeField] public int pontos;
    [SerializeField] TMP_Text time;
    [SerializeField] GameObject countdownWindow;
    [SerializeField] GameObject completedMenu;
    [SerializeField] TMP_Text point_count;
    [SerializeField] TMP_Text countdown;
    public Bloco Bloco;
    string[] lines;
    public int faseAtual;

    private bool freeRoam = false;
    [SerializeField] PlayerController playerController;
    [SerializeField] CowController[] cow;

    // Start is called before the first frame update
    void Start()
    {
        pontos = 0;
        CarregarFase();
    }

    // Update is called once per frame
    void Update()
    {
        time.text = ((int)tempoAtual).ToString();
        point_count.text = "Pontos: " + pontos.ToString();
        if(tempoAtual > 0 && freeRoam)
        {
            tempoAtual -= Time.deltaTime;
        }

        if ((tempoAtual <= 0 || Input.GetKeyDown(KeyCode.Return)) && freeRoam)
        {
            End();
        }

        if(freeRoam){
            playerController.HandleUpdate();
            for(int i = 0; i < cow.Length; i++){
                cow[i].HandleUpdate();
            }
        }
    }

    public void End()
    {
       CalculaPontos();
       freeRoam = false;
       completedMenu.SetActive(true);
        
    }


    public void CarregarFase()
    {
        tempoAtual = tempoLimite;
        
        StartCoroutine(Countdown());
        Read();
        Generate();
    }

    public void CalculaPontos()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                if (listaGabarito[i,j] == listaMarcados[i,j] && listaGabarito[i,j] == 1 )
                {
                    pontos++;
                }
            }
        }
        Score();
    }

    private void Score(){
        if(pontos >= 3*pontosMax/4){
            Debug.Log("Você é foda");
        }else if(pontos > pontosMax/2 && pontos < 3*pontosMax/4){
            Debug.Log("Você é meio foda");
        }else if(pontos > pontosMax/4 && pontos < pontosMax/2){
            Debug.Log("Você é um 1/4 foda");
        }else{
            Debug.Log("Você é um lixo");
        }
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
            case 6:
                filePath = Application.dataPath + "/StreamingAssets/fase_6.txt";
                break;
            case 7:
                filePath = Application.dataPath + "/StreamingAssets/fase_7.txt";
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
                b.transform.position = new Vector3(xpos,ypos, 0);
                x++;
                xpos += 0.075f;
                if (lines[i][j] == '1')
                {
                    pontosMax++;
                    listaGabarito[i, j] = 1;
                    b.Target();
                }
            }
            y++;
            ypos += 0.075f;
            x = 0;
            xpos = transform.position.x;
        }
    Debug.Log(pontosMax);

    }

    IEnumerator Countdown(){
        countdownWindow.SetActive(true);
        countdown.text = "3";
        yield return new WaitForSeconds(1);
        countdown.text = "2";
        yield return new WaitForSeconds(1);
        countdown.text = "1";
        yield return new WaitForSeconds(1);
        countdown.text = "GO!";
        yield return new WaitForSeconds(1);
        freeRoam = true;
        countdownWindow.SetActive(false);
    }
}
