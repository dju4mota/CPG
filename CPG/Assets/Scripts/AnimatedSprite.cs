using UnityEngine;
using UnityEngine.UI;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public float framerate = 1f / 6f;

    private Image img;
    private int frame;
    private bool ended = false;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(Animate), framerate, framerate);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Animate()
    {
        if(!ended){
            frame++;

            if (frame >= sprites.Length) {
                ended = true;
            }

            if (frame >= 0 && frame < sprites.Length) {
                img.sprite = sprites[frame];
            }
        }
        
    }

}