using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Destroy(Scene_Manager.Instance);
         Destroy(Player_UI_Canvas.Instance);
         GameObject temp;
         temp = GameObject.Find("Scene_Manager");
         Destroy(temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mainMenu(){
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
        /*
         Application.LoadLevel(0);
         SceneManager.LoadScene (sceneName:"Title");
         */
        
        
    }
}
