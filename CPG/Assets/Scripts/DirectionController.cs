using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour
{
    private Transform player;
    public float dist = 2;
    public float speed = 5;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>().gameObject.transform;
        offset = transform.position - player.position;
        offset = offset.normalized * dist;
    }

    // Update is called once per fram
    void Update()
    {
         Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 
        Vector3 direction = mousePosition - player.position;
        direction = Vector3.ClampMagnitude(direction, dist); 
        direction = direction.normalized * dist;      
        Vector3 clampedMousePosition = player.position + direction;

        transform.position = clampedMousePosition;
    }
}
