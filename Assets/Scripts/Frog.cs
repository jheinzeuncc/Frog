using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour


{

   [Header("Item Sprites")]
    [SerializeField] private GameObject stick;
    [SerializeField] private GameObject mushroom;
    [SerializeField] private GameObject cape;
   
   private GameObject Game_Manager;
    public int FrogNumber;
    public GameObject weaponPosition;
    private float scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = .05f;
        
        this.transform.localScale = new Vector3(1f* scale,1f* scale,1f* scale);
        Game_Manager = GameObject.Find("Game_Manager");    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver(){
        if(Game_Manager.GetComponent<Game_Controller>().checkAttack() == false){
        this.transform.localScale = new Vector3(1.2f * scale,1.2f* scale,1.2f* scale);
        }
    }

    private void OnMouseExit(){
        this.transform.localScale = new Vector3(1f* scale,1f* scale,1f* scale);
    }

    private void OnMouseDown(){
       if(Game_Manager.GetComponent<Game_Controller>().checkAttack() == false){
        
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
    public void addItems(string hat, string armor, string weapon){
        
        switch(hat){
        case "mushroom":
        GameObject temp;
        temp = Instantiate(mushroom,new Vector3(0, 0, 0), Quaternion.identity, this.transform); 
        
        temp.transform.position = this.transform.position;
        break;
        default:
        break;
        }

        switch(armor){
        case "cape":
        GameObject temp;
        temp = Instantiate(cape,new Vector3(0, 0, 0), Quaternion.identity, this.transform); 
        temp.transform.position = this.transform.position;
        break;
        default:
        break;
        }

        switch(weapon){
        case "stick":
        GameObject temp;
        temp = Instantiate(stick,new Vector3(0, 0, 0), Quaternion.identity, this.transform); 
        temp.transform.position = weaponPosition.transform.position;
        break;
        default:
        break;
        }



    }


}
