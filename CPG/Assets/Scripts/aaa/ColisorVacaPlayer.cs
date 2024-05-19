using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorVacaPlayer : MonoBehaviour
{
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Cow"))
        {
            playerController.Renzo(col);
        }
    }
}
