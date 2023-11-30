using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] private GameObject Player;
     [SerializeField] private GameObject Game_Controller;
    
    private int Player_Max_Health = 20;
    private int Player_Health = 20;
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       
    }
    public int getPlayerHealth(){
        return Player_Health;
    }
        public int getPlayerMaxHealth(){
        return Player_Max_Health;
    }

    public void reducePlayerHealth(int reduceAmount){
        int tempShield = Game_Controller.GetComponent<Game_Controller>().shieldAmount;
        if(tempShield>reduceAmount){
            tempShield -= reduceAmount;
        }else{
            tempShield = 0;
             Player_Health = Player_Health - reduceAmount + tempShield;
        }
        Game_Controller.GetComponent<Game_Controller>().shieldAmount = tempShield;
       
        Game_Controller.GetComponent<Game_Controller>().updateHealth();
    }
}



        /* Move The player
         if(Input.GetKey(KeyCode.D)){
            player.transform.Translate(.1f,0,1);
        }
        if(Input.GetKey(KeyCode.A)){
            player.transform.Translate(-.1f,0,1);
        }*/