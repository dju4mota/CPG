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

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void Update()
    {
        if (marcado)
        {
            SpriteRenderer.sprite = sprite;
        }
    }


    public void Marcar()
    {
        
        marcado = true;
    }
}
