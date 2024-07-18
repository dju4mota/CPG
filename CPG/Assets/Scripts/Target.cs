using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour
{
    [SerializeField] private float tempoPassadoDentro = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        tempoPassadoDentro = Time.time;
    }


}
