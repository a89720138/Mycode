using MRTKExtensions.QRCodes;
using UnityEngine;

public class JetController : MonoBehaviour
{
    [SerializeField]
    private QRTrackerController trackerController;

    private void Start()
    {
        trackerController.PositionSet += PoseFound;
    }

    private void PoseFound(object sender, Pose pose)
    {
        
        var childObj = transform.GetChild(0);
        childObj.SetPositionAndRotation(pose.position, pose.rotation);
        childObj.transform.Translate(-3.09f,-1.33f,-1.32f,Space.Self);
       childObj.transform.Rotate(90, 0, 0, Space.Self);
       
            //pose.position + new Vector3(-3.09f, -1.45f, -0.1f);
        //childObj.transform.Rotate(90, 0, 0);
        childObj.gameObject.SetActive(true);
    }
}