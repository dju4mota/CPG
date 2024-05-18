using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float powerTime;
    [SerializeField] float KBForce;
    [SerializeField] float bounds;
    private SpriteRenderer spriteRenderer;
    private AnimationController anim;
    private Rigidbody2D rb2d;
    public GameObject follow;
    public GameObject fartArea;
    private bool isWalking = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<AnimationController>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        if(isWalking){
            Walk();
        }

        if(Input.GetKeyDown(KeyCode.Q) && isWalking){
            StartCoroutine(Pum());
            anim.ChangeAnimationState("Fart");
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Cow"))
        {
            var kb = new Vector2(transform.position.x - col.transform.position.x, transform.position.y - col.transform.position.y);
            StartCoroutine(Knockback(transform.position, kb*KBForce));
        }
    }

   
    void Walk(){
      Vector3 direction = follow.transform.position - transform.position;  
      transform.position = transform.position + (moveSpeed * Time.deltaTime * direction);
      Animation(direction);
    }

    void Animation(Vector3 dir){
        Debug.Log(dir);
        if(Mathf.Abs(dir.x) > Mathf.Abs(dir.y)){
            if(dir.x > 0)
                anim.ChangeAnimationState("Walk_Right");
            else{
                anim.ChangeAnimationState("Walk_Left");
            }
        }else{
             if(dir.y > 0)
                anim.ChangeAnimationState("Walk_Top");
            else{
                anim.ChangeAnimationState("Walk_Bottom");
            }
        }
    }

    IEnumerator Pum(){
        isWalking = false;
        fartArea.SetActive(true);
        yield return new WaitForSeconds(powerTime);
        fartArea.SetActive(false);
        isWalking = true;
    }

    private IEnumerator Knockback(Vector3 from, Vector3 to)
    {
        isWalking = false;
        float elapsed = 0f;
        float duration = 0.125f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.position = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = to;
        isWalking = true;
    }

}
