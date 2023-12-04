using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_Manager : MonoBehaviour
{

        [SerializeField] GameObject gameManager;
       

        public static Scene_Manager Instance;
        private Dictionary<string, FrogObject> frogList = new Dictionary<string, FrogObject>();
    
        
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

    public void moveToTown(Dictionary<string, FrogObject> frgLst){
        print("it worked");
        frogList = frgLst;
      //  frogList = gameManager.GetComponent<Game_Controller>().getFrogList();
        SceneManager.LoadScene (sceneName:"Town");
    }

    public Dictionary<string, FrogObject> getFrogList(){
        return frogList;
    }

    public void moveToForest(){
        SceneManager.LoadScene (sceneName:"Combat_Scene");
        Invoke("updateFrogList", .5f);
        

    }

    private void updateFrogList(){
        gameManager = GameObject.Find("Game_Manager"); 
        gameManager.GetComponent<Game_Controller>().setFrogList(frogList);
    }


}
