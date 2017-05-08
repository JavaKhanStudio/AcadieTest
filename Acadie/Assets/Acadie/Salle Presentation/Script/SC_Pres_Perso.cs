using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

public class SC_Pres_Perso : MonoBehaviour
{

    public int checkDistance;
    public LayerMask prodLayer;
    public GameObject vue;

    private void Start()
    {
        Connect_MainVue value = (Connect_MainVue)(vue.GetComponent(typeof(Connect_MainVue)));
        value.hideAll();
    }



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "IsZone")
        {
            Debug.Log(col.gameObject.name);
            return;
        }
            
        Transform trans = col.gameObject.transform.parent;
        GameObject parent;

        if (trans == null)
        {Debug.Log("impossible de trouver parent de " + col.gameObject.name); return;}
        else
            parent = trans.gameObject;

        Component reff = parent.GetComponent(typeof(Connect_Cadre));

        if (reff != null)
        {
            Data_Cadre cadre = (Data_Cadre)((Connect_Cadre)reff).getCadre();
            Debug.Log("test de colision");
        }
        else
        {Debug.Log(parent.name + "Impossible de trouver la reff");}
        
    }

    RaycastHit hit;
    public void FixedUpdate()
    {
        /*
        Ray ray = camera.hit.collider.GetComponent<VRInteractiveItem>();

        if (Physics.Raycast(ray, out hit, checkDistance, prodLayer))
        {
            Data_Cadre data = (Data_Cadre)hit.collider.gameObject.GetComponent(typeof(Data_Cadre));
            showInfo(data.infoCadre);
        }
        else
        {hideInfo();}
        */
        RaycastHit seen;
        Quaternion HMDRotation = InputTracking.GetLocalRotation(VRNode.Head);
        Vector3 playerRotation = HMDRotation * transform.forward;
        //Quaternion camrot = transform.rotation;
        //Vector3 playerRotation = camrot * transform.forward;
        Ray raydirection = new Ray(transform.position, playerRotation);
        if (Physics.Raycast(raydirection, out seen))
        {
            if (seen.collider.tag == "Test")
            {
                Debug.Log("GOOD HIT");
            }
            else
            {
                //Debug.Log(seen.collider.tag);
            }

        }

        Debug.DrawRay(transform.position, playerRotation, Color.blue, 100);
    }

    public void showInfo(Model_CadreInfo data)
    {
        Connect_MainVue mainVue = (Connect_MainVue)vue.GetComponent(typeof(Connect_MainVue));

        if (!mainVue.asSomethingShow)
            mainVue.showInformation(data);
    }

    public void hideInfo()
    {
        Connect_MainVue mainVue = (Connect_MainVue)vue.GetComponent(typeof(Connect_MainVue)) ;

        if (mainVue.asSomethingShow)
            mainVue.hideInformation() ;
    }

}
