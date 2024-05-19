using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEndingController : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] bool auto = false;
    [SerializeField] string SceneToLoad;
    [SerializeField] GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        if(!auto)
            StartCoroutine(OpenMenu());
        else{
            StartCoroutine(Run());
        }
    }

    public void Load(){
        SceneManager.LoadScene(SceneToLoad);
    }

    public void Quit(){
        Application.Quit();
    }

    public IEnumerator OpenMenu(){
        yield return new WaitForSeconds(time);
        Menu.SetActive(true);
    }

    public IEnumerator Run(){
        yield return new WaitForSeconds(time);
        Load();
    }
}
