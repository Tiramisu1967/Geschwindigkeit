using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameInstance.instance._IsTurn = true;
        
    }
    
}
