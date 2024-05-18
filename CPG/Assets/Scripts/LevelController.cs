using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] public  Bloco[] listaBloco;
    [SerializeField] public int sizeX = 4;
    [SerializeField] public int sizeY = 6;
    [SerializeField] public int[,] listaGabarito = new int[4,6];
    [SerializeField] public int[,] listaMarcados = new int[4, 6];
    [SerializeField] public float tempoLimite;
    [SerializeField] public float tempoAtual;
    [SerializeField] public float pontos;

    // Start is called before the first frame update
    void Start()
    {
       /* for(int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                Debug.Log(listaGabarito[i,j]);
            }
        }*/
        tempoAtual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(tempoAtual >= tempoLimite)
        {
            Debug.Log("Acabou");
        }
        else
        {
            tempoAtual += Time.deltaTime;
            Debug.Log(tempoAtual);
        }*/
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
}
