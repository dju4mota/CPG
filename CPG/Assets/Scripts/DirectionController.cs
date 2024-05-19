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
        float dir = Input.GetAxis("Horizontal");
        float angle = speed * -dir;
        offset = Quaternion.Euler(0, 0, angle) * offset;

        transform.position = player.position + offset;
    }
}
