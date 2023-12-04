using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour{


    // Start is called before the first frame update
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Frog_Object;
    [SerializeField] private GameObject Combat_Manager;
    [SerializeField] private Transform playerCombatPos;
    [SerializeField] private Transform playerAdventurePos;

    [Header("UI Elements")]
    [SerializeField] private GameObject Abilities_UI; 
    [SerializeField] private TMP_Text Player_Health; 
    [SerializeField] private Image Player_Health_Bar;
    [SerializeField] private Image Shield_Image;
    [SerializeField] private TMP_Text shield_UI_Number;
    [SerializeField] private GameObject Combat_UI;
    [SerializeField] private GameObject Adventure_UI;
    public int shieldAmount;



    [Header("Ability 1")]
    [SerializeField] private GameObject button1;
    [SerializeField] private TMP_Text text1;
    [Header("Ability 2")]
    [SerializeField] private GameObject button2;
      [SerializeField] private TMP_Text text2;
    [Header("Ability 3")]
    [SerializeField] private GameObject button3;
      [SerializeField] private TMP_Text text3;
    [Header("Ability 4")]
    [SerializeField] private GameObject button4;
      [SerializeField] private TMP_Text text4;

    [Header("Frog Sprites")]
    [SerializeField] private Sprite frogSprite1;
    [SerializeField] private Sprite frogSprite2;
    [SerializeField] private Sprite frogSprite3;
    [SerializeField] private Sprite frogSprite4;
    [SerializeField] private Sprite frogSprite5;
    [SerializeField] private Sprite frogSprite6;
    [SerializeField] private Sprite frogSprite7;
    [SerializeField] private Sprite frogSprite8;
    [SerializeField] private Sprite frogSprite9;
    [SerializeField] private Sprite frogSprite10;
    [SerializeField] private Sprite frogSprite11;
    [SerializeField] private Sprite frogSprite12;
    [SerializeField] private Sprite frogSprite13;
    [SerializeField] private Sprite frogSprite14;
    [SerializeField] private Sprite frogSprite15;
 

    
     
     


    private bool Action_Happening = false;
    private int Number_Of_Summoned_Frogs = 3;
     public bool attacking = false;
     

   
    //Frog array first number is frog number second is a set of integers that line up with an ability
    
    private List<GameObject> frogPrefabList = new List<GameObject>();
    private string[] onScreenAbilities = new string[4];

    




    public class AttackStatistics{
      public int damage;
      public int shield;
      public int heal;
      public bool targetable;

      public AttackStatistics(int damageNum, int shieldNum){
      damage = damageNum;
      shield = shieldNum;
      }
      public AttackStatistics(int damageNum, int shieldNum, int healNum){
        damage = damageNum;
        shield = shieldNum;
        heal = healNum;
      }

    }

    private AttackStatistics currentAttack;

  public FrogObject frog1 = new FrogObject();
   public FrogObject frog2 = new FrogObject();
   public FrogObject frog3 = new FrogObject();
   public FrogObject frog4 = new FrogObject();
   public FrogObject frog5 = new FrogObject();
   public FrogObject frog6 = new FrogObject();
   public FrogObject frog7 = new FrogObject();
   public FrogObject frog8 = new FrogObject();
   public FrogObject frog9 = new FrogObject();
   public FrogObject frog10 = new FrogObject();
   public FrogObject frog11 = new FrogObject();
   public FrogObject frog12 = new FrogObject();
   public FrogObject frog13 = new FrogObject();
   public FrogObject frog14 = new FrogObject();
   public FrogObject frog15 = new FrogObject();

  Dictionary<string, FrogObject> frogList = new Dictionary<string, FrogObject>();
 
  
   //Array of frog numbers currently available 
    private string[] frogsAvailable = new string[15];
    private string[] onScreenFrogs = new string[3];

    


    void Start()
    {
      //Add all frog objects to the dictionary
      frogList.Add("frog1", frog1);
      frogList.Add("frog2", frog2);
      frogList.Add("frog3", frog3);
      frogList.Add("frog4", frog4);
      frogList.Add("frog5", frog5);
      frogList.Add("frog6", frog6);
      frogList.Add("frog7", frog7);
      frogList.Add("frog8", frog8);
      frogList.Add("frog9", frog9);
      frogList.Add("frog10", frog10);
      frogList.Add("frog11", frog11);
      frogList.Add("frog12", frog12);
      frogList.Add("frog13", frog13);
      frogList.Add("frog14", frog14);
      frogList.Add("frog15", frog15);

      frog1.frogSprite = frogSprite1;
      frog2.frogSprite = frogSprite2;
      frog3.frogSprite = frogSprite3;
      frog4.frogSprite = frogSprite4;
      frog5.frogSprite = frogSprite5;
      frog5.frogSprite = frogSprite5;
      frog6.frogSprite = frogSprite6;
      frog7.frogSprite = frogSprite7;
      frog8.frogSprite = frogSprite8;
      frog9.frogSprite = frogSprite9;
      frog10.frogSprite = frogSprite10;
      frog11.frogSprite = frogSprite11;
      frog12.frogSprite = frogSprite12;
      frog13.frogSprite = frogSprite13;
      frog14.frogSprite = frogSprite14;
      frog15.frogSprite = frogSprite15;

      

      frogList["frog1"].abilityFour = "hi";
      frogList["frog1"].hat = "leafHat";
      frogList["frog2"].weapon = "woodenSword";
      frogList["frog2"].armor = "royalCape";
      frogList["frog4"].armor = "cape";
    


      Random.InitState(1);
      Player_Health_Bar.fillAmount = .5f;
      updateHealth();
      resetAvailableFrogs();

        //Deactivate UI Overlays
        Player.transform.position = playerAdventurePos.position;
        Abilities_UI.SetActive(false);
        Combat_UI.SetActive(false);

        
        //roundStart();
      //

        
        
    }

public void startAdventure(){
  Combat_Manager.GetComponent<Combat_Manager>().startCombat(0);
  Player.transform.position = playerCombatPos.position;
   Combat_UI.SetActive(true);
   Adventure_UI.SetActive(false);
   resetAvailableFrogs();
   roundStart();
   
}

public void startNavigation(){
Player.transform.position = playerAdventurePos.position;
Combat_UI.SetActive(false);
Adventure_UI.SetActive(true);
destroyFrogs();

}


 private void resetAvailableFrogs(){
  frogsAvailable = new string[15];
  for(int i=0; i<15; i++){   
  frogsAvailable[i]="frog" +(i+1);
  }
 }

    public void updateUI(){
     Abilities_UI.SetActive(true);

}

public void roundStart(){
setAbilities();


 //Remove a frog from the active list and store its abilities in onscreenfrogs
for(int i =0;i<Number_Of_Summoned_Frogs;i++){
//If there are not any frogs left reset frogs
if(frogsAvailable.GetLength(0) == 0){
  resetAvailableFrogs();
}
//Get random frog
int rand = Random.Range(0,frogsAvailable.GetLength(0));
//Set the on screen frog to the random frog selected
onScreenFrogs[i] = frogsAvailable[rand];
removeFrog(rand);
}
Abilities_UI.SetActive(false);
summonFrogObjects();
}

public void removeFrog(int removeNum){
  string[] temp = new string[frogsAvailable.GetLength(0)-1];
  bool removed = false;
  for(int i =0; i<frogsAvailable.GetLength(0); i++){
    if(i == removeNum){
      removed = true;
    }else{
      if(removed == false){
      temp[i] = frogsAvailable[i];
      }else{
      temp[i-1] = frogsAvailable[i];
      }
    }

  }

  frogsAvailable = temp;
  removed = false;

}



private void summonFrogObjects(){
  
  //Creates 3 Frogo objects and splits them vertically and moves them to the left to be next to the player and up slightly
  //Eventually should try to change to a radial summon to allow even spacing with more than 3 frogs
  GameObject temp;



  for(int i = 0; i<Number_Of_Summoned_Frogs;i++){
 temp = Instantiate(Frog_Object,new Vector3(0, 0, 0), Quaternion.identity);  

  
 frogPrefabList.Add(temp);
 
 temp.transform.Translate(-.9f,(i-1)*1.5f,10);
 temp.transform.Translate(Vector3.left*2f);
 temp.transform.Translate(Vector3.up*.7f);
 




 temp.GetComponent<Frog>().setFrogNumber(i);
 addItems(temp, i);
  button1.SetActive(false);
  button2.SetActive(false);
  button3.SetActive(false);
  button4.SetActive(false);
}
}


public void frogClick(int frogNumber){

button1.gameObject.GetComponent<Button>().interactable = true;
button2.gameObject.GetComponent<Button>().interactable = true;
button3.gameObject.GetComponent<Button>().interactable = true;
button4.gameObject.GetComponent<Button>().interactable = true;

FrogObject temp;
temp = frogList[ onScreenFrogs[frogNumber]];

if(temp.abilityOne != ""){
  button1.SetActive(true);
text1.text = temp.abilityOne;
onScreenAbilities[0] = text1.text;
}else{
  button1.SetActive(false);
}


if(!temp.abilityTwo.Equals("")){
  button2.SetActive(true);
text2.text = temp.abilityTwo;
onScreenAbilities[1] = text2.text;
}else{
  button2.SetActive(false);
}


if(temp.abilityThree !=""){
  button3.SetActive(true);
text3.text = temp.abilityThree;
onScreenAbilities[2] = text3.text;
}else{
  button3.SetActive(false);
  } 

if(temp.abilityFour != ""){
  button4.SetActive(true);
text4.text = temp.abilityFour;
onScreenAbilities[3] = text4.text;
}else{
  button4.SetActive(false);
}
updateUI();


}




//Get the abiliity of the button pressed and do whatever the ability is
public void abilityButtonPress(int buttonNumber){
string Ability_Used = onScreenAbilities[buttonNumber]; 
button1.gameObject.GetComponent<Button>().interactable = false;
button2.gameObject.GetComponent<Button>().interactable = false;
button3.gameObject.GetComponent<Button>().interactable = false;
button4.gameObject.GetComponent<Button>().interactable = false;

switch(Ability_Used){
case "Attack":

currentAttack = new AttackStatistics(5,0);
//Combat_Manager.GetComponent<Combat_Manager>().startAttackCursor();

break;

case "Defend":
currentAttack = new AttackStatistics(0,5);
//endAttack();

break;

case "Swing Sword":
currentAttack = new AttackStatistics(10,0);
break;
default:
print (Ability_Used + " not found ");
currentAttack = new AttackStatistics(0,0);
break;
}

//Needs to be changed to enemy attacking
//roundEnd();
startPlayerAbility();
}

public void roundEnd(){
destroyFrogs();
roundStart();
}


private void destroyFrogs(){
foreach(var Frog_Object in frogPrefabList){
  //Destroy(Frog_Object);
  Frog_Object.GetComponent<Frog>().poofAway();
}

  
  frogPrefabList.Clear();
  
}


public void updateHealth(){
  float current = Player.GetComponent<Player_Controller>().getPlayerHealth();

  float max = Player.GetComponent<Player_Controller>().getPlayerMaxHealth();
  Player_Health.text = current.ToString();

  Player_Health_Bar.fillAmount = current/max;

  if(shieldAmount == 0){
    Shield_Image.enabled = false;
    shield_UI_Number.enabled = false;
  }else{
    Shield_Image.enabled = true;
    shield_UI_Number.enabled = true;
    shield_UI_Number.text = shieldAmount.ToString();
  }
}

private void addItems(GameObject tempFrog, int frogNum){
  FrogObject temp;
  temp = frogList[onScreenFrogs[frogNum]];

  tempFrog.GetComponent<Frog>().addItems(temp.hat, temp.armor, temp.weapon, temp.frogSprite);
  

}

public void setAttackingTrue(){
  attacking = true;
}

public bool checkAttack(){
return attacking;
}

public void doDamage(Enemy beingAttacked){

beingAttacked.healthDown(currentAttack.damage);
}

public void endAttack(){
  attacking = false;
  Abilities_UI.SetActive(false);
  Combat_Manager.GetComponent<Combat_Manager>().endAttack();

}

private void startPlayerAbility(){
  shieldAmount += currentAttack.shield;
  if(currentAttack.damage > 0){
    attacking = true;
  Combat_Manager.GetComponent<Combat_Manager>().startAttackCursor();
  }else{
    Combat_Manager.GetComponent<Combat_Manager>().endAttack();
  updateHealth();

  }

}

public Dictionary<string, FrogObject> getFrogList(){
  return frogList;

}
public void instantToTown(){
    Combat_Manager.GetComponent<Combat_Manager>().instantToTown();
}


public void setFrogList(Dictionary<string, FrogObject> frg){
  frogList = frg;
}

public void setAbilities(){
  for(int i =0; i<frogList.Count;i++){
    string index = "frog"+(i+1);
    //Hat ability
    switch(frogList[index].hat){
    case "leafHat":
    frogList[index].abilityTwo = "Photosynthesis";
    
    break;
    default: 
    frogList[index].abilityTwo = "Defend";
    break;
  }

  switch(frogList[index].weapon){
    case "woodenSword":
    frogList[index].abilityOne = "Swing Sword";
    break;
    default:
    frogList[index].abilityOne = "Attack";
    break;
  }
  }


}


}
