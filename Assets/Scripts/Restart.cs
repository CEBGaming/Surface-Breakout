using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour
{
    public AudioSource audioSourceWater;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSourceWater.Play();
            Invoke("msLoad", 3);
            //SceneManager.LoadScene("MainScene");
            //gameObject.SetActive(false);
        }
    }

    void msLoad()
    {
        SceneManager.LoadScene("MainScene");
    }
}
