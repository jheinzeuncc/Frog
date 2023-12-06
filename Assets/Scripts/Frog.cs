using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour


{
    [SerializeField] private SpriteRenderer spriteRenderer;
   [Header("Item Sprites")]
    [SerializeField] private GameObject royalCape;
    [SerializeField] private GameObject woodenSword;
    [SerializeField] private GameObject leafHat;
    [SerializeField] private GameObject cape;

   
   private GameObject Game_Manager;
    public int FrogNumber;
    public GameObject weaponPosition;
    private float scale;

    // Start is called before the first frame update
    void Start()
    {
        scale = .1f;
        
        this.transform.localScale = new Vector3(1f* scale,1f* scale,1f* scale);
        Game_Manager = GameObject.Find("Game_Manager");    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver(){
            if(Game_Manager.GetComponent<Game_Controller>().Action_Happening == true){
            return;
        }
        if(Game_Manager.GetComponent<Game_Controller>().checkAttack() == false){
        this.transform.localScale = new Vector3(1.2f * scale,1.2f* scale,1.2f* scale);
        }
    }

    private void OnMouseExit(){
        this.transform.localScale = new Vector3(1f* scale,1f* scale,1f* scale);
    }

    private void OnMouseDown(){
        if(Game_Manager.GetComponent<Game_Controller>().Action_Happening == true){
            return;
        }
       if(Game_Manager.GetComponent<Game_Controller>().checkAttack() == false){
       this.transform.localScale = new Vector3(1f* scale,1f* scale,1f* scale);
        Game_Manager.GetComponent<Game_Controller>().frogClick(FrogNumber);
       }
    }

    public void setFrogNumber(int num){
        FrogNumber = num;
    }

    public void poofAway(){
        if(gameObject != null){
         GameObject.Destroy(gameObject);
    }}


   /** test **/
    public void addItems(string hat, string armor, string weapon, Sprite frogSprite){

        spriteRenderer.sprite = frogSprite;
        
        switch(hat){
        case "leafHat":
        GameObject temp;
        temp = Instantiate(leafHat,new Vector3(0, 0, 0), Quaternion.identity, this.transform); 
        
        temp.transform.position = this.transform.position;
        break;
        default:
        break;
        }

        switch(armor){
        case "royalCape":
        GameObject temp;
        temp = Instantiate(royalCape,new Vector3(0, 0, 0), Quaternion.identity, this.transform); 
        temp.transform.position = this.transform.position;
        break;
        case "cape":
        temp = Instantiate(cape,new Vector3(0, 0, 0), Quaternion.identity, this.transform); 
        temp.transform.position = this.transform.position;
        break;
        default:
        break;
        }

        switch(weapon){
        case "woodenSword":
        GameObject temp;
        temp = Instantiate(woodenSword,new Vector3(0, 0, 0), Quaternion.identity, this.transform); 
        temp.transform.position = this.transform.position;
        break;
        default:
        break;
        }



    }


}
