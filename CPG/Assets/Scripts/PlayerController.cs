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
    [SerializeField] MeterController meter;
    private AnimationController anim;
    public GameObject follow;
    public GameObject fartArea;
    private bool isWalking = true;
    public AudioSource audioP;
    public AudioClip peido;
    public AudioClip muu;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<AnimationController>();
        audioP = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        if(isWalking){
            Walk();
        }

        if(Input.GetKeyDown(KeyCode.Q) && isWalking && meter.fillImage.fillAmount == 1){
            meter.pum();
            StartCoroutine(Pum());
            audioP.clip = peido;
            audioP.Play();
            anim.ChangeAnimationState("Fart");
        }
    }

    public void Renzo(Collision2D col)
    {
        var kb = new Vector2(transform.position.x - col.transform.position.x, transform.position.y - col.transform.position.y);
        StartCoroutine(Knockback(transform.position, kb * KBForce));
    }

   
    void Walk(){
      Vector3 direction = follow.transform.position - transform.position;  
      transform.position = transform.position + (moveSpeed * Time.deltaTime * direction);
      Animation(direction);
    }

    void Animation(Vector3 dir){
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
        audioP.clip = muu;
        audioP.Play();

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
