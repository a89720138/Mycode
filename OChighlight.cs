using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OChighlight : MonoBehaviour
{
    public  static int sign = 0;
    public  GameObject contactpointt;
    public  static GameObject warningg;


    // Start is called before the first frame update
    public void Update()
    {
        Quaternion rot = Quaternion.Euler(0, 0, 0);
        contactpointt = GameObject.Find("contact_point");
        //if (collision.gameObject.tag != "pipe")
        if (sign.Equals(0))
        {
            warningg = Instantiate(contactpointt, pipecollision.Hcpoint, rot);
            sign = 1;
            warningg.GetComponent<SphereCollider>().enabled = false;
            warningg.gameObject.name = pipecollision.thiscollidername + pipecollision.othercollidername;
            warningg.transform.parent = GameObject.Find("contact_points").transform;
        }
        if (sign.Equals(2))
        {
            Destroy(warningg);
        }


    }
    
}
