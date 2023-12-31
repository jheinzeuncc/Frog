using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject frogObject;
    [SerializeField] GameObject spawnPos;
    [SerializeField] GameObject shopItemSpawnPos;
    [SerializeField] GameObject shopItemGameObject;
    [SerializeField] GameObject prefabToDelete;
    [SerializeField] GameObject shopUI;
    [SerializeField] GameObject frogUI;

    [Header ("Item Sprites")]
    [SerializeField] Sprite woodenSwordSprite;
    [SerializeField] Sprite leafHatSprite;
    [SerializeField] Sprite royalCapeSprite;
    [SerializeField] Sprite partyHatSprite;
    [SerializeField] Sprite capeSprite;
    [SerializeField] Sprite healSprite;

    private List<GameObject> deleteList = new List<GameObject>();


    public ShopItem woodenSword;
    public ShopItem leafHat;
    public ShopItem royalCape;
    public ShopItem partyHat;
    public ShopItem cape;
    public ShopItem healItem;

    public bool shopping;
    public bool buying;
    private float scale;
    private ShopItem currentBuyingItem;
    private Dictionary<string, FrogObject> frogList = new Dictionary<string, FrogObject>();

    private float spacing = 1.5f;
    private float itemSpacing = 2f;

    private float adjustDistance = 25f;
    //[SerializeField] GameObject Game_Controller;
    // Start is called before the first frame update



    Dictionary<string, ShopItem> itemList = new Dictionary<string, ShopItem>();
    void Start()
    {
        shopUI.SetActive(false);
        frogUI.SetActive(false);
        shopping = false;
        buying  = false;
        scale = 4f;

        woodenSword = new ShopItem(woodenSwordSprite, 5, "woodenSword", "weapon");
        itemList.Add("item1", woodenSword);
        leafHat = new ShopItem(leafHatSprite, 10, "leafHat", "hat");
        itemList.Add("item2", leafHat);
        royalCape = new ShopItem(royalCapeSprite, 15, "royalCape", "armor");
        itemList.Add("item3", royalCape);
        partyHat = new ShopItem(partyHatSprite, 10, "partyHat", "hat");
        itemList.Add("item4", partyHat);
        cape = new ShopItem(capeSprite, 5, "cape", "armor");
        itemList.Add("item5", cape);
        healItem = new ShopItem(healSprite, 5, true, 10);
        itemList.Add("item6", healItem);

        
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
        shopping = true;
         this.transform.localScale = new Vector3(1f* scale,1f* scale,1f* scale);
        openShop();
        //Scene_Manager.Instance.getFrogList();
       }
    }

    public void addNewItem(int num){
        buying = false;
        FrogObject temp;
        temp = frogList["frog" + (num + 1)];
        switch(currentBuyingItem.itemType){

        case "hat":
        temp.hat = currentBuyingItem.name;
        break;

        case "armor":
        temp.armor = currentBuyingItem.name;
        break;

        case "weapon":
        temp.weapon = currentBuyingItem.name;
        break;
        default: 

        break;
        }
    foreach(var GameObject in deleteList){
  Destroy(GameObject);
  shopping = false;
  shopUI.SetActive(false);
  frogUI.SetActive(false);
  
}  
  deleteList.Clear();


    }

    private void openShop(){
        shopUI.SetActive(true);
        openItems();


        

    }

    private void openItems(){
         Vector3 referencePosition = shopItemSpawnPos.transform.position;

        GameObject temp;
        int row = 0;
        int col = 0;
        for(int i =0; i<itemList.Count; i++){
            temp = Instantiate(shopItemGameObject,new Vector3(0, 0, 0), Quaternion.identity);
           temp.transform.position = shopItemSpawnPos.transform.position;
           string itm = "item" + (i+1);
          
            temp.GetComponent<Shop_Item>().setItem(itemList[itm]);
           deleteList.Add(temp);

            Vector3 newPosition = new Vector3(col * itemSpacing, -row * itemSpacing, 0) + referencePosition;

            if(temp.GetComponent<Shop_Item>().itemInformation.healItem==false){
             //Adjust for armor 
           if(temp.GetComponent<Shop_Item>().itemInformation.itemType.Equals("armor") ){
            newPosition.x += adjustDistance*Time.deltaTime;
            temp.GetComponent<Shop_Item>().adjustXDistance(adjustDistance);
           }

            if(temp.GetComponent<Shop_Item>().itemInformation.itemType.Equals("hat") ){
             newPosition.y -= adjustDistance*Time.deltaTime;
             temp.GetComponent<Shop_Item>().adjustYDistance(adjustDistance);
           }
            }
            
            temp.transform.position = newPosition;
           
           

            col++;
            if (col >= 3)
            {
                col = 0;
                row++;
            }


        }
    }

    public void openFrogs(ShopItem buyingItem){
        frogUI.SetActive(true);
        currentBuyingItem = buyingItem;
        buying = true;
         Vector3 referencePosition = spawnPos.transform.position;
        frogList = Scene_Manager.Instance.getFrogList();
        GameObject temp;
        int row = 0;
        int col = 0;
        for(int i = 0; i<frogList.Count; i++){
           temp = Instantiate(frogObject,new Vector3(0, 0, 0), Quaternion.identity);
           temp.transform.position = spawnPos.transform.position;
           deleteList.Add(temp);

           temp.GetComponent<Shop_Frog>().FrogNumber = i;

           addItems(temp,i);
           


           Vector3 newPosition = new Vector3(col * spacing, -row * spacing, 0) + referencePosition;
            temp.transform.position = newPosition;

            col++;
            if (col >= 3)
            {
                col = 0;
                row++;
            }

        }

    }



    private void addItems(GameObject tempFrog, int frogNum){
  FrogObject temp;
  string frogName = "frog"+ (frogNum +1);
  print(frogName);
  temp = frogList["frog" + (frogNum +1)];

  tempFrog.GetComponent<Shop_Frog>().addItems(temp.hat, temp.armor, temp.weapon, temp.frogSprite);
  

}



   
    
}
