using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour
{
    [SerializeField] float runTime;
    [SerializeField] int bounds;
    [SerializeField] int moveSpeed;
    [SerializeField] Vector3 direction;
    GameObject player;
    bool isWalking = true;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
        if(transform.position.x > bounds || transform.position.y > bounds){
            direction = -direction;
        }
        if(isWalking){
            transform.position = transform.position + (moveSpeed * Time.deltaTime * direction);
        }
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Pum"))
        {
            var run = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
            StartCoroutine(RunAway(run));
        }
    }

    IEnumerator RunAway(Vector2 run){
        isWalking = false;
        yield return new WaitForSeconds(runTime);
        isWalking = true;
    }
}
