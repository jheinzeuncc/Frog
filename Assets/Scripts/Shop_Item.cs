using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop_Item : MonoBehaviour
{
    [SerializeField]  private TMP_Text goldNum;
    private ShopItem itemInformation;
    private float scale;
    private GameObject shop;
    // Start is called before the first frame update
    void Start()
    {
        shop = GameObject.Find("Square"); 
        scale = .1f;
         this.transform.localScale = new Vector3(1.1f * scale,1.1f* scale,1.1f* scale);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     private void OnMouseOver(){  
        if(shop.GetComponent<Shop>().buying == false){
        this.transform.localScale = new Vector3(1.2f * scale,1.2f* scale,1.2f* scale);
        }
       }
       

            private void OnMouseExit(){
                 
        this.transform.localScale = new Vector3(1f* scale,1f* scale,1f* scale);
                 
    }

      private void OnMouseDown(){
        shop.GetComponent<Shop>().openFrogs(itemInformation);
      
        
        
       }
    

    public void setItem(ShopItem sho){
        //   this.transform.localScale = new Vector3(1f* scale,1f* scale,1f* scale);
        itemInformation = sho;
        goldNum.text = (itemInformation.cost).ToString();
    }
}
