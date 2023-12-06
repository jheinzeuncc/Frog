using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] private GameObject Player;
     [SerializeField] private GameObject Game_Controller;
    
    private int Player_Max_Health = 20;
    private int Player_Health = 20;
   
    void Start()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
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
        if(tempShield>=reduceAmount){
            tempShield -= reduceAmount;
        }else{
            tempShield = 0;
             Player_Health = Player_Health - reduceAmount + tempShield;
        }
        Game_Controller.GetComponent<Game_Controller>().shieldAmount = tempShield;
       
        Game_Controller.GetComponent<Game_Controller>().updateHealth();
        if(Player_Health <=0){
            SceneManager.LoadScene (sceneName:"Game Over");
        }
    }
    public void healPlayer(int heal){
        if((Player_Health+heal)>Player_Max_Health){
            Player_Health = Player_Max_Health;
        }else{
            Player_Health += heal;
        }
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