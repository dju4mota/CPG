using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        if (marcado)
        {
            SpriteRenderer.sprite = sprite;
        }
    }
}
