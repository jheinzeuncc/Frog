using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop_Item : MonoBehaviour
{

    
    [SerializeField]  private TMP_Text goldNum;
    [SerializeField] private GameObject notEnoughGoldText;
    [SerializeField] private SpriteRenderer sprRender;
    [SerializeField] private Image goldImage;
    public ShopItem itemInformation;
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
        if(Scene_Manager.Instance.gold >= itemInformation.cost){
            this.transform.localScale = new Vector3(1f* scale,1f* scale,1f* scale);
            Scene_Manager.Instance.gold -= itemInformation.cost;
            Scene_Manager.Instance.updateGold();
            if(itemInformation.healItem == true){
               // Player_UI_Canvas.Instance.healPlayer(itemInformation.healAmount);
            }else{
             shop.GetComponent<Shop>().openFrogs(itemInformation);
            }
        }     
       }
    

    public void setItem(ShopItem sho){
        //   this.transform.localScale = new Vector3(1f* scale,1f* scale,1f* scale);
        itemInformation = sho;
        goldNum.text = (itemInformation.cost).ToString();
        sprRender.sprite = itemInformation.itemSprite;
    }

    public void adjustXDistance(float adjustNum){
        print("moved "+ adjustNum);
         Vector3 newPosition = goldImage.transform.position;
         newPosition.x -= (adjustNum*Time.deltaTime*5);
         goldImage.transform.position = newPosition;
    }

        public void adjustYDistance(float adjustNum){
        print("moved "+ adjustNum);
         Vector3 newPosition = goldImage.transform.position;
         newPosition.y += (adjustNum*Time.deltaTime*5);
         goldImage.transform.position = newPosition;
    }
}
