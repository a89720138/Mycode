using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class track : MonoBehaviour
{
    public GameObject obj;
    public LineRenderer lineRenderer;
    public List<GameObject> checkpoints=new List<GameObject>();
    public Vector3 checkpointpos;
    // Start is called before the first frame update
    public void Start()
    {
        
    }
    public void drawtrack()
    {
        //checkpoints = GameObject.FindGameObjectsWithTag("checkpoint");
        foreach (Transform checkpoint in GameObject.Find("checkpoints").transform)
        {
            checkpoints.Add(checkpoint.gameObject);
        }
        GameObject lineObject = new GameObject();
        this.lineRenderer = lineObject.AddComponent<LineRenderer>();
        this.lineRenderer.startWidth = 3f;
        this.lineRenderer.positionCount = checkpoints.Count;

        Vector3[] checkpointArray = new Vector3[this.checkpoints.Count];
        for (int i = 0; i < this.checkpoints.Count; i++)
        {
            checkpointpos = this.checkpoints[i].transform.position;
            checkpointArray[i] = new Vector3(checkpointpos.x, checkpointpos.y, checkpointpos.z);
        }
        this.lineRenderer.SetPositions(checkpointArray);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        obj = new GameObject("checkpoint");
        //obj.tag = "checkpoint";
        obj.transform.position = this.transform.position;
        obj.gameObject.transform.SetParent(GameObject.Find("checkpoints").transform);
    }
}
