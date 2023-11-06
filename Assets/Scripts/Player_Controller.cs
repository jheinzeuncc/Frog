using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] private GameObject Player;
    
    private int Player_Max_Health = 100;
    private int Player_Health = 100;
   
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
        Player_Health = Player_Health - reduceAmount;
    }
}



        /* Move The player
         if(Input.GetKey(KeyCode.D)){
            player.transform.Translate(.1f,0,1);
        }
        if(Input.GetKey(KeyCode.A)){
            player.transform.Translate(-.1f,0,1);
        }*/