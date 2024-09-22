using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject panel;

    private bool estaPausado = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(estaPausado==false){
                panel.SetActive(true);
                estaPausado=true;
                Time.timeScale=0;
            }
            else{
                panel.SetActive(false);
                estaPausado=false;
                Time.timeScale=1;
            }
        }
    }

    public void resume(){
        panel.SetActive(false);
        estaPausado=false;
        Time.timeScale=1;
    }

    public void quit(){
        Application.Quit();
    }

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        panel.SetActive(false);
        estaPausado=false;
        Time.timeScale=1;
    }

}
