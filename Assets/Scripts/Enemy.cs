using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
     [Header("Stats")]
     [SerializeField] private float Max_Health;
     [SerializeField] private int Damage;
     [SerializeField] private Slider Health_Bar;

     private GameObject Game_Manager;
     private float Current_Health;
     private float scale;
     

    void Start()
    {
        Game_Manager = GameObject.Find("Game_Manager");
         scale = 1;

       Current_Health = Max_Health;
       updateHealthBar();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void updateHealthBar(){
        print("current health: " + Current_Health);
        print("max health: " + Max_Health);
        float percent = Current_Health/Max_Health;
        print("percent: " + percent);
        Health_Bar.value = percent;

    }
    public void setEnemy(string enemyType){
        switch(enemyType){
        case "Slime":
        Max_Health = 10;
        updateHealthBar();
        
        
        break;

        default:
        print("no such enemy found");
        break;
        }
    }

         private void OnMouseOver(){
            if(Game_Manager.GetComponent<Game_Controller>().checkAttack() == true){
        
        this.transform.localScale = new Vector3(1.2f * scale,1.2f* scale,1.2f* scale);
            }
    } 

        private void OnMouseExit(){
        this.transform.localScale = new Vector3(1f* scale,1f* scale,1f* scale);
    }


        private void OnMouseDown(){
        
        bool temp = Game_Manager.GetComponent<Game_Controller>().checkAttack();
        
        
        if(temp == true){
            
           Game_Manager.GetComponent<Game_Controller>().doDamage(this);
        }
    }


    public void healthDown(int damage){
        print("health down ran");
        Current_Health -= damage;
        updateHealthBar();
        Game_Manager.GetComponent<Game_Controller>().endAttack();

    }
}   
