using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Image img;
    public Sprite[] sprites;
    public int index;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("changeAnim", time);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void changeAnim()
    {
        if(index == 10)
        {
            index = 0;
        }
        img.sprite = sprites[index];
        index++;
        Invoke("changeAnim", time);
    }


    public void ButtonStart()
    {
        
        SceneManager.LoadScene("InitialScene");      
    }

}
