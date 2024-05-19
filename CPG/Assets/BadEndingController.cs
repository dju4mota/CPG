using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEndingController : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Run());
    }

    public void Reset(){
        SceneManager.LoadScene("Felipe");
    }

    public void Quit(){
        Application.Quit();
    }

    public IEnumerator Run(){
        yield return new WaitForSeconds(time);
        Menu.SetActive(true);
    }
}
