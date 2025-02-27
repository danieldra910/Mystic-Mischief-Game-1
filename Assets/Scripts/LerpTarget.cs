using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTarget : MonoBehaviour
{
    public Transform Target;
    public float CamSpeed;
    private float time;
    private PlayerController player;
    bool isFlying;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        isFlying = !player.onGround;
        if (!isFlying)
        {
            transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * CamSpeed);
        }
        else
        {
            Vector3 tempTrans = new Vector3(Target.transform.position.x, Target.transform.position.y + 2, Target.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, tempTrans, Time.deltaTime * CamSpeed);
        }
    }
}
