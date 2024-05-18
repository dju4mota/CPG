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

    public void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            Marcar();
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
