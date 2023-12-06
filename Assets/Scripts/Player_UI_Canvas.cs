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

     public static Player_UI_Canvas Instance;
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
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
