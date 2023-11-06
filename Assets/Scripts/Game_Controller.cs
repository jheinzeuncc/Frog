using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Game_Controller : MonoBehaviour{


    // Start is called before the first frame update
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Frog_Object;

    [Header("UI Elements")]
    [SerializeField] private GameObject Abilities_UI; 
    [SerializeField] private TMP_Text Player_Health; 
    [SerializeField] private Image Player_Health_Bar;





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
     
     


    private bool Action_Happening = false;
    private int Number_Of_Summoned_Frogs = 3;
   
    //Frog array first number is frog number second is a set of integers that line up with an ability
    
    private List<GameObject> frogPrefabList = new List<GameObject>();
    private string[] onScreenAbilities = new string[4];

    


    public class FrogObject{
      public string name;
      public string abilityOne;
      public string abilityTwo;
      public string abilityThree;
      public string abilityFour;
      public string hat;
      public string armor;
      public string weapon;

      public FrogObject(){
        abilityOne = "Attack";
        abilityTwo = "Defend";
      }

    }


 
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

      frogList["frog1"].abilityFour = "hi";
      frogList["frog1"].hat = "mushroom";
      frogList["frog2"].weapon = "stick";
      frogList["frog2"].armor = "cape";
    


      Random.InitState(1);
      Player_Health_Bar.fillAmount = .5f;
      updateHealth();
      resetAvailableFrogs();

        //Deactivate UI Overlays
        Abilities_UI.SetActive(false);

        
        roundStart();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
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
 temp.transform.Translate(-.9f,i-1,10);
 temp.transform.Translate(Vector3.left*5f);
 temp.transform.Translate(Vector3.up*.7f);
 temp.GetComponent<Frog>().setFrogNumber(i);
 addItems(temp, i);
}
}


public void frogClick(int frogNumber){

FrogObject temp;
temp = frogList[ onScreenFrogs[frogNumber]];
text1.text = temp.abilityOne;
onScreenAbilities[0] = text1.text;

text2.text = temp.abilityTwo;
onScreenAbilities[1] = text2.text;

text3.text = temp.abilityThree;
onScreenAbilities[2] = text3.text;

text4.text = temp.abilityFour;
onScreenAbilities[3] = text4.text;
updateUI();


}




//Get the abiliity of the button pressed and do whatever the ability is
public void abilityButtonPress(int buttonNumber){
string Ability_Used = onScreenAbilities[buttonNumber]; 

switch(Ability_Used){
case "Attack":
print("attakc happened");
break;

case "Defend":
print("player has blocked");
break;

default:

break;
}

//Needs to be changed to enemy attacking
roundEnd();
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


private void updateHealth(){
  int current = Player.GetComponent<Player_Controller>().getPlayerHealth();

  int max = Player.GetComponent<Player_Controller>().getPlayerMaxHealth();

  Player_Health_Bar.fillAmount = current/max;
}

private void addItems(GameObject tempFrog, int frogNum){
  FrogObject temp;
  temp = frogList[onScreenFrogs[frogNum]];

  tempFrog.GetComponent<Frog>().addItems(temp.hat, temp.armor, temp.weapon);
  

}



}