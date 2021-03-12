
using System.Collections;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;    

public class QRloading : MonoBehaviour
{
    private float x = 1.9131881f;
    private float y = -1.260146f;
    private float z = 4.170755f;
    private float x1 = 0;
    private float y1 = 0;
    private float z1 = 0;
    public static GameObject go1;
   // public BoundingBox bbox;
    public GameObject mdl;
    public bool pipeline_1f = false;


    public IEnumerator getmodelfromazure()
    {
        //Status.text = "已點擊";
        yield return new WaitForSeconds(2f);
        var uwr = UnityWebRequestAssetBundle.GetAssetBundle("https://firebasestorage.googleapis.com/v0/b/bonbon-87e02-jiavs/o/drainpipe?alt=media&token=1f3f4328-f31d-4837-8e2e-ae0d26a18c1d");
        yield return uwr.SendWebRequest();

        // Get an asset from the bundle and instantiate it.
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);
        var loadAsset = bundle.LoadAsset("drainpipe");
        yield return loadAsset;
        go1 = Instantiate(loadAsset) as GameObject;
        setposition(go1);
     /*   if (GameObject.Find("1fv1(Clone)") != null)
        {
            go1.transform.parent = GameObject.Find("1fv1(Clone)").transform;

        }
        else if ((GameObject.Find("1fv1(Clone)") == null))
        {
            go1.transform.parent = GameObject.Find("ModelManager").transform;

        }*/

        Getrender(go1);
        GetChildmesh(go1);
        SplitList(go1);
    }
    public void getbuttomdown()
    {
        if (pipeline_1f.Equals(false))
        {

            StartCoroutine(getmodelfromazure());
            pipeline_1f = true;
        }
        else if (pipeline_1f.Equals(true))
        {
            pipeline_1f = false;
            Destroy(go1);
        }
    }

    public void ADDtag(GameObject s)
    {
        foreach (Transform child in s.transform)
        {

            if (child.gameObject.tag.Equals("pipe"))
            {
            }
            else
            {
                child.gameObject.tag = "pipe";
            }
            ADDtag(child.gameObject);
        }

    }
    public void setposition(GameObject BIM123)
    {
        BIM123.transform.position = new Vector3(x, y, z);
        //Status.text = "已移動";
        Debug.Log("OK");
    }
    public void setpositionin(GameObject BIM123)
    {
        BIM123.transform.position = new Vector3(x1, y1, z1);
        //Status.text = "已移動";
        Debug.Log("OK");
    }
   /* public void ADDrigin(GameObject wwwwwwww)
    {
        if (null == wwwwwwww)
            return;

        foreach (Transform child in wwwwwwww.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<Rigidbody>())
            {
                child.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                child.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
            else
            {
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                child.gameObject.GetComponent<Rigidbody>().useGravity = false;

            }
            ADDrigin(child.gameObject);
        }

    }
    public void Getclickapp(GameObject gameObject456)
    {
        if (null == gameObject456)
            return;

        foreach (Transform child in gameObject456.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<pointpipe>())
            {
            }
            else
            {
                child.gameObject.AddComponent<pointpipe>();

            }
            Getclickapp(child.gameObject);

        }


    }
    public void grabbable(GameObject wwwwww)
    {
        if (null == wwwwww)
            return;

        foreach (Transform child in wwwwww.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<NearInteractionGrabbable>())
            {
                child.gameObject.GetComponent<NearInteractionGrabbable>().enabled = false;

            }
            else
            {
                child.gameObject.AddComponent<NearInteractionGrabbable>();
                child.gameObject.GetComponent<NearInteractionGrabbable>().enabled = false;
            }
            grabbable(child.gameObject);
        }

    }
    public void MinMaxScale(GameObject wwwwwww)
    {
        foreach (Transform child in wwwwwww.transform)
        {
            if (child == null)
                continue;
            if (child.gameObject.GetComponent<MinMaxScaleConstraint>())
            {
                child.gameObject.GetComponent<MinMaxScaleConstraint>().enabled = false;

            }
            else
            {
                child.gameObject.AddComponent<MinMaxScaleConstraint>();
                child.gameObject.GetComponent<MinMaxScaleConstraint>().enabled = false;
            }
            grabbable(child.gameObject);
        }
    }

    public void Cursorcontext(GameObject ww)
    {
        if (null == ww)
            return;

        foreach (Transform child in ww.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<CursorContextObjectManipulator>())
            {
            }
            else
            {
                child.gameObject.AddComponent<CursorContextObjectManipulator>();

            }
            Cursorcontext(child.gameObject);
        }

    }
    public void Manipulator(GameObject www)
    {

        if (null == www)
            return;

        foreach (Transform child in www.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<ObjectManipulator>())
            {
            }
            else
            {
                child.gameObject.gameObject.AddComponent<ObjectManipulator>(); ;

            }
            Manipulator(child.gameObject);

        }
    }
    public void rotationaxis(GameObject wwww)
    {



        if (null == wwww)
            return;

        foreach (Transform child in wwww.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<RotationAxisConstraint>())
            {
            }
            else
            {
                child.gameObject.gameObject.AddComponent<RotationAxisConstraint>();

            }
            rotationaxis(child.gameObject);

        }

    }*/

    public void SplitList(GameObject mdll)//拆分場景名字

    {
        string[] elementid;
        string[] stringSeparators = new string[] { "[", "]" };
        Transform trans = mdll.transform;
        foreach (Transform objectt in trans)
        {
            if (objectt == null)
            {
                continue;
            }
            elementid = objectt.name.Split(stringSeparators, StringSplitOptions.None);
            objectt.name = elementid[1];

            foreach (Transform objecttin in objectt.transform)
            {
                elementid = objecttin.name.Split(stringSeparators, StringSplitOptions.None);
                objecttin.name = elementid[1];
            }
        }

    }
    public void Getrender(GameObject gameObject1234)
    {
        foreach (Transform child in gameObject1234.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<MeshRenderer>())
            {
                child.gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>("orangepipe");
            }
            else
            {
                child.gameObject.AddComponent<MeshRenderer>();

            }
            Getrender(child.gameObject);

        }


    }
    public void GetChildmesh(GameObject gameObject123)
    {
        if (null == gameObject123)
            return;

        foreach (Transform child in gameObject123.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<MeshCollider>())
            {
            }
            else
            {
                child.gameObject.AddComponent<MeshCollider>();

            }
            GetChildmesh(child.gameObject);

        }


    }
  
}
