using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour
{
    [SerializeField] public int tempoPassadoDentro = 0 ;    
            

    private void OnTriggerStay2D(Collider2D collision)
    {
        tempoPassadoDentro += 1;
    }

}
