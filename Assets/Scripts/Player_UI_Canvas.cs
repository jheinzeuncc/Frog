using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player_UI_Canvas : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image shieldImage;
     [SerializeField] private TMP_Text shield_UI_Number;
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private GameObject healthBarPosition;
    [SerializeField] private GameObject UICanvas;

     public static Player_UI_Canvas Instance;
     public int Player_Health = 20;
     private int Player_Max_Health = 20;

   
    void Awake()
    {
        
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


    public Image getHealthBar(){
        return healthBar;
    }
    public TMP_Text getHealth(){
        return healthText;
    }
    public Image getShieldImage(){
        return shieldImage;
    }
    public TMP_Text getShieldUINumber(){
        return shield_UI_Number;
    }
        
    public void updateGoldUI(int goldNum){
        goldText.text = goldNum.ToString();
    }
    public void disableUI(){
        UICanvas.SetActive(false);
    }
    public void enableUI(){
        UICanvas.SetActive(true);
    }


    public int getPlayerHealth(){
        return Player_Health;   
    }

    public void setPlayerHealth(int hlth){
        Player_Health = hlth;
    }

    public void healPlayer(int heal){
         if((Player_Health+heal)>Player_Max_Health){
            Player_Health = Player_Max_Health;
        }else{
            Player_Health += heal;
        }
        updateHealth();
    }

    public void updateHealth(){
        print("UI update");
        print("player health: " + Player_Health);
        print("player maxhealth: " + Player_Max_Health);
        healthText.text = Player_Health.ToString();
        float current;
        float max;
        current = Player_Health;
        max = Player_Max_Health;
        healthBar.fillAmount = current/max;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
