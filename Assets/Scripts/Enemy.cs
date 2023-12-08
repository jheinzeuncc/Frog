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
     [SerializeField] private SpriteRenderer spriteRenderer;
        private float moveAmount;
     

     [Header("Sprites")]
     [SerializeField] private Sprite slime;
     [SerializeField] private Sprite wolf;

     private GameObject Game_Manager;
     private GameObject player;
     private GameObject Combat_Manager;
     private float Current_Health;
     private float scale;
     private string enemyType;
     public int listNum;
     
    private int goldValue;
    void Start()
    {
        moveAmount = 50f;
        
        Game_Manager = GameObject.Find("Game_Manager");
        player = GameObject.Find("Player");
        Combat_Manager = GameObject.Find("Combat_Manager");
         scale = 1;

       Current_Health = Max_Health;
       updateHealthBar();


        Vector3 flip = transform.localScale;
        flip.x *= -1;
        transform.localScale = flip;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void updateHealthBar(){
  
        float percent = Current_Health/Max_Health;
        
        Health_Bar.value = percent;

    }
    public void setEnemy(string en){
        enemyType = en;
        switch(enemyType){
        case "Slime":
        scale = .8f;
        spriteRenderer.sprite = slime;
        goldValue = 2;
        Max_Health = 10;
        updateHealthBar();
        break;

        case "Wolf":
        scale = 1f;
        spriteRenderer.sprite = wolf;
        goldValue = 8;
        Max_Health = 20;
        updateHealthBar();
        break;
        default:
        print("no such enemy found");
        break;
        }
    }

         private void OnMouseOver(){
            if(Game_Manager.GetComponent<Game_Controller>().checkAttack() == true){
        
        this.transform.localScale = new Vector3(1.2f * scale*-1,1.2f* scale,1.2f* scale);
            }
    } 

        private void OnMouseExit(){
        this.transform.localScale = new Vector3(1f* scale*-1,1f* scale,1f* scale);
    }


        private void OnMouseDown(){
        
        bool temp = Game_Manager.GetComponent<Game_Controller>().checkAttack();
        
        
        if(temp == true){
            this.transform.localScale = new Vector3(1f* scale*-1,1f* scale,1f* scale);
           Game_Manager.GetComponent<Game_Controller>().doDamage(this);
        }
    }


    public void healthDown(int damage){
        
        Current_Health -= damage;
        if(Current_Health<=0){
            destroyThis();
        }
        updateHealthBar();
        Game_Manager.GetComponent<Game_Controller>().endAttack();

    }

    public void AOEHealthDown(int damage){
         Current_Health -= damage;
        if(Current_Health<=0){
            destroyThis();
        }
        updateHealthBar();
    }

    public void startAttack(){

        switch(enemyType){
        case "Slime":
        //uncomment to wiggle attack
       transform.Translate(Vector3.left*Time.deltaTime*moveAmount);
       Invoke("moveBack", .2f);
        player.GetComponent<Player_Controller>().reducePlayerHealth(2);
        break;

        default:
        print("no such enemy found");
        break;
        }

    }

    private void moveBack(){
        transform.Translate(Vector3.right*Time.deltaTime*moveAmount);
    }
    private void destroyThis(){
        Scene_Manager.Instance.gold +=goldValue;
        Scene_Manager.Instance.updateGold();
        Combat_Manager.GetComponent<Combat_Manager>().removeEnemy(listNum);
        Destroy(gameObject);
    }
}   
