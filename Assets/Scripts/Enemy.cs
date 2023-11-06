using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
     [Header("Stats")]
     [SerializeField] private int Max_Health;
     [SerializeField] private int Damage;
     [SerializeField] private Slider Health_Bar;
     private int Current_Health;
     

    void Start()
    {
       Current_Health = Max_Health;
       updateHealthBar();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void updateHealthBar(){
        Health_Bar.value = .8f;

    }
}
