
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Proyecto26;
public class pipecollision : MonoBehaviour
{
    // public List<string> Pipelist;
    public string Pipestorage;
    public List<GameObject> Pipelist;
    //public static List<GameObject> Pipelist;
    public List<string> ContactList;
    public List<string> ContactDetail;
    public GameObject BIM;
    public GameObject contactpoint;
    public GameObject thiscollider;
    public GameObject contactpointexit;
    public GameObject warning;
    public string namebox;
    public static string othercollidername;
    public static string thiscollidername;
    public Color originalcolor;
    // public int sign = 0;
    public int num;
    public static Vector3 Hcpoint;

    [SerializeField]
    PipeDetail pipeDetail;
    [System.Serializable]
    public class PipeDetail
    {

        public string[] Pipe_Name;
        public string[] Pipe_collision_detail;
    }
    void Start()
    {

        BIM = GameObject.Find("collider").gameObject;
        this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
        originalcolor = this.gameObject.GetComponent<MeshRenderer>().material.color;
        contactpoint = GameObject.Find("contact_point");
        StartCoroutine(SetFolderPath());
    }
    IEnumerator SetFolderPath()
    {
        yield return null;
        StartCoroutine(iniSetting());
    }

    IEnumerator iniSetting()
    {

        Pipelist = new List<GameObject>();
        pipeDetail = new PipeDetail();
        yield return null;

    }
    public void GetObjectStatus()
    {
        Pipelist = new List<GameObject>();  
        pipeDetail.Pipe_Name = new string[num];
        pipeDetail.Pipe_collision_detail = new string[num];
        //GameObject BIM = GameObject.Find("1fpipe(Clone)").gameObject;
        Debug.Log(1);
        foreach (Transform child in BIM.transform)
        {
            if (null == child)
                continue;
            //child.gameobject contains the current child you can do whatever you want like add it to an array
            Pipelist.Add(child.gameObject);
        }
        Debug.Log(2);
    }
    public void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag != "pipe")

        ContactPoint contact = collision.contacts[0];
        thiscollider = contact.thisCollider.gameObject;
        contactpointexit = contact.otherCollider.gameObject;

        contact.thisCollider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        Vector3 pos = contact.point;
        Hcpoint = pos;
        if (contact.otherCollider.gameObject.GetComponent<OChighlight>() == false)
        {
            contact.otherCollider.gameObject.AddComponent<OChighlight>();
        }
        /*if (contact.otherCollider.gameObject.GetComponent<OChighligt>().Equals(true))
        {
            contactpointexit.gameObject.SendMessage("OCpoint");
        }*/
        OChighlight.sign = 0;
        othercollidername = contact.otherCollider.name;
        thiscollidername = contact.thisCollider.name;

         int j = 0;
         if (j == 0)
         {
             ContactList.Add(contact.thisCollider.name);
             j++;
         }
         int i = 0;
         if (i == 0)
         {
             ContactDetail.Add(contact.thisCollider.name + "碰撞" + contact.otherCollider.name);
             i++;
         } 
        namebox = contact.thisCollider.name + "碰撞" + contact.otherCollider.name;
    }
    public void OnCollisionExit(Collision collision)
    {
        // Destroy(contactpointexit.gameObject.GetComponent<OChighlight>());
        thiscollider.gameObject.GetComponent<MeshRenderer>().material.color = originalcolor;
        OChighlight.sign = 2;

       /* if (contactpointexit.GetComponent<OChighlight>() == true)
        {
            Destroy(GameObject.Find(othercollidername + thiscollidername));
            Destroy(GameObject.Find(thiscollidername + othercollidername));
        }
        else
        {
            Destroy(GameObject.Find(thiscollidername + othercollidername));
        }*/

    }
        public void SaveToJsonHololens()
    {
        pipeDetail = new PipeDetail();
        Debug.Log(3);
        GetObjectStatus();//將RecordList值寫入Record.Record_Name
        num = Pipelist.Count;
        Debug.Log(3.5);
        int i;
        for (i = 0; i <= num - 1; i++)
        {
         //   obj = Pipelist[i];
            //下面這幾行存取obj的座標與旋轉殖與大小
            pipeDetail.Pipe_Name[i] = Pipelist[i].GetComponent<Transform>().name;
            pipeDetail.Pipe_collision_detail[i] = Pipelist[i].GetComponent<pipecollision>().namebox;
            Debug.Log(4);
        }
        //string filename = ";
        RestClient.Put("https://bonbon-87e02.firebaseio.com/" + "Pipecollision.json", pipeDetail);
        Debug.Log(5);

    }
}
