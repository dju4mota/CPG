using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bloco : MonoBehaviour
{
    // Start is called before the first frame update
    public int x;
    public int y;
    public bool marcado = false;
    SpriteRenderer SpriteRenderer;
    [ SerializeField] Sprite sprite;
    [ SerializeField] Sprite spriteTarget;
    [SerializeField]LevelController levelController;

    public void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        levelController = FindObjectOfType<LevelController>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            if (!marcado)
            {
                if(levelController.listaGabarito[x, y] ==1)
                {
                    Debug.Log("bateu");
                    levelController.pontos++;
                }

                    Marcar();
                levelController.listaMarcados[x, y] = 1;
            }
            
         }
    }

    public void Marcar()
    {
        marcado = true;
        SpriteRenderer.sprite = sprite;
    }

    public void Target(){
        SpriteRenderer.sprite = spriteTarget;
    }

    
}
