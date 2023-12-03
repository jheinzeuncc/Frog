using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class FrogObject{
      public string name;
      public string abilityOne;
      public string abilityTwo;
      public string abilityThree;
      public string abilityFour;
      public string hat;
      public string armor;
      public string weapon;
      public Sprite frogSprite;


      public FrogObject(){
        abilityOne = "Attack";
        abilityTwo = "Defend";
        abilityThree = "";
        abilityFour = "";
        
        
      }

    }

    public class ShopItem{
      public int cost;
      public Sprite itemSprite;
      public string name;
      public string itemType;

      public ShopItem(Sprite sprt, int cst, string nam, string type){
        cost = cst;
        itemSprite = sprt;
        name = nam;
        itemType = type;


      
      }
    }
