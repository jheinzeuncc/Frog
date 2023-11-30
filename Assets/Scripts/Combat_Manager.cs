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

    public static List<GameObject> enemyList = new List<GameObject>();
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void startEnemyTurn(){

   }

   public void startCombat(int combatNum){
    switch(combatNum){
    case 0:
    startCombat0();
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

public void startAttackCursor(){
    Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
}

public void endAttack(){
    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    if(enemyList.Count<1){
        print("Combat Ended");
        /*

        add end combat here


        */
        return;
    }

    foreach(GameObject i in enemyList){
        i.GetComponent<Enemy>().startAttack();
    }
    Game_Controller.GetComponent<Game_Controller>().roundEnd();
}
public void removeEnemy(int removeNum){
enemyList.RemoveAt(removeNum);
foreach(GameObject i in enemyList){
    i.GetComponent<Enemy>().listNum -=1;
}
if(enemyList.Count == 0){
    print("end combat");
    Scene_Manager.Instance.moveToTown();
}
}
}
