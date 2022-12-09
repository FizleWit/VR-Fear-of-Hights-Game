using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ControllerMoving : MonoBehaviour

{

    public SteamVR_Action_Vector2 joyconController;
    public Transform CameraTransform;
    private CapsuleCollider ccR;
    // Start is called before the first frame update
    void Start()
    {
        ccR = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
private void FixedUpdate()
    {
        Vector3 movementDir = Player.instance.hmdTransform.TransformDirection(new Vector3(joyconController.axis.x, 0, joyconController.axis.y));
        transform.position += Vector3.ProjectOnPlane(Time.deltaTime * movementDir * 2.0f, Vector3.up);
        
        float distancefromFLoor = Vector3.Dot(CameraTransform.localPosition, Vector3.up);
        ccR.height = Mathf.Max(ccR.radius, distancefromFLoor);

        ccR.center = CameraTransform.localPosition - 0.5f * distancefromFLoor * Vector3.up;
    }
}
