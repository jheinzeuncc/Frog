using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_Manager : MonoBehaviour
{

        

        [SerializeField] GameObject gameManager;
        /*
        [Header ("Frog prefabs")]
        [SerializeField] public GameObject royalCape;
        [SerializeField] public GameObject woodenSword;
        [SerializeField] public GameObject leafHat;
        [SerializeField] public GameObject cape;
        [SerializeField] public GameObject partyHat;
        */
       
        [SerializeField] private GameObject player;
        public static Scene_Manager Instance;
        private Dictionary<string, FrogObject> frogList = new Dictionary<string, FrogObject>();
        public int gold;
        public int combatNum;
        private Scene combatScene;
    
        
        private void Awake(){
        combatNum =0;
        gold = 20;

      if (Instance == null) 
    { 
        
        Instance = this; 
    } 
    else 
    { 
       
        Destroy(gameObject); 
    } 
       
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
     combatScene =  SceneManager.GetSceneByName("Combat_Scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToTown(Dictionary<string, FrogObject> frgLst){
       
        frogList = frgLst;
      //  frogList = gameManager.GetComponent<Game_Controller>().getFrogList();
        SceneManager.LoadScene (sceneName:"Town");
    }

    public Dictionary<string, FrogObject> getFrogList(){
        return frogList;
    }

    public void moveToForest(){
        SceneManager.LoadScene (sceneName:"Combat_Scene");

       Player_UI_Canvas.Instance.disableUI();
        Invoke("updateFrogList", .2f);
        
        Invoke("updateHealth",.2f);
        

    }


    private void updateHealth(){
             player=GameObject.Find("Player");
             player.GetComponent<Player_Controller>().setPlayerHealth(Player_UI_Canvas.Instance.getPlayerHealth());
             Player_UI_Canvas.Instance.enableUI();
        
        
    }

    private void updateFrogList(){
        gameManager = GameObject.Find("Game_Manager"); 
        gameManager.GetComponent<Game_Controller>().setFrogList(frogList);
    }

    public void updateGold(){
        Player_UI_Canvas.Instance.updateGoldUI(gold);
    }


}
