using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour
{
    public static Jukebox Instance;
    // Start is called before the first frame update

      private void Awake(){
      
      if (Instance == null) 
    { 
        
        Instance = this; 
    } 
    else 
    { 
       
        Destroy(gameObject); 
    } 
       
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
