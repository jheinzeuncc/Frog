using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private bool shopping;
    private float scale;
    //[SerializeField] GameObject Game_Controller;
    // Start is called before the first frame update
    void Start()
    {
        shopping = false;
        scale = 3f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       private void OnMouseOver(){  
        if(shopping == false){
        this.transform.localScale = new Vector3(1.1f * scale,1.1f* scale,1.1f* scale);
        }
       }

            private void OnMouseExit(){
        this.transform.localScale = new Vector3(1f* scale,1f* scale,1f* scale);
    }

      private void OnMouseDown(){
       if(shopping == false){
        
        openShop();
        //Scene_Manager.Instance.getFrogList();
       }
    }


    private void openShop(){
        

    }
    
}
