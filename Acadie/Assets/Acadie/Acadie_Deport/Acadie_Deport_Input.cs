using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acadie_Deport_Input : MonoBehaviour
{

    KeyCode key = KeyCode.F;
    public GameObject objectTest ;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(key))
        {
            Debug.Log(objectTest.transform.position);
        }
    }
}
