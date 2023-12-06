using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Manager : MonoBehaviour
{
    
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject Game_Controller;
    
    [Header ("Positions")]
    [SerializeField] private GameObject enemyPos1;
    [SerializeField] private GameObject enemyPos2;
    [SerializeField] private GameObject enemyPos3;
    [Header ("Sprites")]
    [SerializeField] private Texture2D cursor;
    private int iterator;
    private int enemyNum;
    private int lastEnemy;

    public static List<GameObject> enemyList = new List<GameObject>();
   

    // Start is called before the first frame update
    void Start()
    {
        Scene_Manager.Instance.combatNum =0;
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void startEnemyTurn(){

   }

   public void startCombat(){
    switch(Scene_Manager.Instance.combatNum){
    case 0:
    startCombat0();
    break;
    case 1:
    startCombat1();
    break;

    default:
    print("no combat found");
    break;

   }
}


private void startCombat0(){
GameObject temp;
int index;
 temp = Instantiate(enemy,new Vector3(0, 0, 0), Quaternion.identity); 
 enemyList.Add(temp);
 index = enemyList.IndexOf(temp);
 temp.GetComponent<Enemy>().listNum = index;
 temp.GetComponent<Enemy>().setEnemy("Slime");
 enemyList[0].transform.position = enemyPos1.transform.position;


 temp = Instantiate(enemy,new Vector3(0, 0, 0), Quaternion.identity); 
 enemyList.Add(temp);
  index = enemyList.IndexOf(temp);
 temp.GetComponent<Enemy>().listNum = index;
  temp.GetComponent<Enemy>().setEnemy("Slime");
 enemyList[1].transform.position = enemyPos2.transform.position;
}


private void startCombat1(){
GameObject temp;
int index;
 temp = Instantiate(enemy,new Vector3(0, 0, 0), Quaternion.identity); 
 enemyList.Add(temp);
 index = enemyList.IndexOf(temp);
 temp.GetComponent<Enemy>().listNum = index;
 temp.GetComponent<Enemy>().setEnemy("Slime");
 enemyList[0].transform.position = enemyPos1.transform.position;


 temp = Instantiate(enemy,new Vector3(0, 0, 0), Quaternion.identity); 
 enemyList.Add(temp);
  index = enemyList.IndexOf(temp);
 temp.GetComponent<Enemy>().listNum = index;
  temp.GetComponent<Enemy>().setEnemy("Slime");
 enemyList[1].transform.position = enemyPos2.transform.position;

 temp = Instantiate(enemy,new Vector3(0, 0, 0), Quaternion.identity); 
 enemyList.Add(temp);
  index = enemyList.IndexOf(temp);
 temp.GetComponent<Enemy>().listNum = index;
  temp.GetComponent<Enemy>().setEnemy("Slime");
 enemyList[2].transform.position = enemyPos3.transform.position;
}




public void startAttackCursor(){
    Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
}



public void endAttack(){
    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    if(enemyList.Count<1){
        print("Combat Ended");
        Scene_Manager.Instance.combatNum +=1;
        Game_Controller.GetComponent<Game_Controller>().Action_Happening = false;
        Game_Controller.GetComponent<Game_Controller>().clearShield();
        return;
    }
    iterator =0;
    enemyNum =0;
    lastEnemy = enemyList.Count;
    foreach(GameObject i in enemyList){
        iterator +=1;
        Invoke("delayedAttack",.5f*iterator);
      //  i.GetComponent<Enemy>().startAttack();
    }
    Game_Controller.GetComponent<Game_Controller>().roundEnd();
}

private void delayedAttack(){
enemyList[enemyNum].GetComponent<Enemy>().startAttack();
enemyNum +=1;
if(enemyNum == lastEnemy){
    Game_Controller.GetComponent<Game_Controller>().Action_Happening = false;
}


}

public void startAOEAttack(int damageAmount){
    foreach(GameObject i in enemyList){
        i.GetComponent<Enemy>().AOEHealthDown(damageAmount);
    }
    Game_Controller.GetComponent<Game_Controller>().endAttack();
}





public void removeEnemy(int removeNum){

foreach(GameObject i in enemyList){

    if(i.GetComponent<Enemy>().listNum ==removeNum){
        enemyList.Remove(i);
        break;
    }
}
if(enemyList.Count == 0){
    print("end combat");
    
   Game_Controller.GetComponent<Game_Controller>().startNavigation();
}

}

public void instantToTown(){
    Scene_Manager.Instance.moveToTown(Game_Controller.GetComponent<Game_Controller>().getFrogList());
}


}
