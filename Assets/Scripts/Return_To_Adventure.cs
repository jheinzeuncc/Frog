using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_To_Adventure : MonoBehaviour
{

    private float scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnMouseOver(){  
      
        this.transform.localScale = new Vector3(1.2f * scale,1.2f* scale,1.2f* scale);
        
       }
       

            private void OnMouseExit(){
                 
        this.transform.localScale = new Vector3(1f* scale,1f* scale,1f* scale);
                 
    }

      private void OnMouseDown(){

         Scene_Manager.Instance.moveToForest();
        
    
       }
}
