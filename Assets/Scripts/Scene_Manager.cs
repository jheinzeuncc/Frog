using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_Manager : MonoBehaviour
{

        [SerializeField] GameObject gameManager;
       

        public static Scene_Manager Instance;
        //private Dictionary<string, FrogObject> frogList = new Dictionary<string, FrogObject>();
    
        
        private void Awake(){

      if (Instance != null && Instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        Instance = this; 
    } 
       
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToTown(){
        print("it worked");
      //  frogList = gameManager.GetComponent<Game_Controller>().getFrogList();
        SceneManager.LoadScene (sceneName:"Town");
    }

    public void getFrogList(){
        
    }


}
