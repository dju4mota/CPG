using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour
{
    [SerializeField] float runTime;
    [SerializeField] Vector2 bounds;
    [SerializeField] int moveSpeed;
    [SerializeField] Vector3 direction;
    GameObject player;
    bool isWalking = true;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
        if(transform.position.x > bounds.x || transform.position.x < -bounds.x){
            direction.x = -direction.x;
        }
        if(transform.position.y > bounds.y || transform.position.y < -bounds.y){
            direction.y = -direction.y;
        }
        if(isWalking){
            transform.position = transform.position + (moveSpeed * Time.deltaTime * direction);
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Pum"))
        {
            var to = new Vector3(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
            StartCoroutine(RunAway(transform.position, transform.position + to*2));
        }
    }

    IEnumerator RunAway(Vector3 from, Vector3 to){
        isWalking = false;
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
        isWalking = true;
    }
}