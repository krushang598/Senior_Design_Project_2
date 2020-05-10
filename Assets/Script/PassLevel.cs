using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassLevel : MonoBehaviour
{
    public delegate void PassHandler();
    public static event PassHandler onPass;
    
    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player"){
            onPass();
        }
    }
}
