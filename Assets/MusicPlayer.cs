using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    void Awake ()
    {
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        Invoke("LoadLevel", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadLevel() 
    {
        SceneManager.LoadScene(1);
    
    }

}
