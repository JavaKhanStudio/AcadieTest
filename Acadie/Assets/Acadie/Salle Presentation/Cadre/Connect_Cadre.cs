using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection_Cadre : MonoBehaviour
{

    public Data_Cadre getCadre()
    {return (Data_Cadre)this.gameObject.transform.parent.gameObject.GetComponent(typeof(Data_Cadre));}
}
