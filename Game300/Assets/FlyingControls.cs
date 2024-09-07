using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingControls : MonoBehaviour
{
    [Header("Custom Properties")]
    public float MoveSpeed = 5f;
    public float YawRotSpeed = 180f;
    public float PitchRotSpeed = 180f;
    public float MaxPitchAngle = 85f;
    public float MinPitchAngle = -85f;
    public bool InvertPitch = false;

    [Header("External References")]
    public CharacterController CC;
    public Transform CamYawPivot;
    public Transform CamPitchPivot;
    public Transform PlayerModel;

    private float YawAngle = 0f;
    private float PitchAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Update yaw and pitch angles
        YawAngle += Input.GetAxis("Mouse X") * YawRotSpeed * Time.deltaTime;
        PitchAngle += Input.GetAxis("Mouse Y") * (InvertPitch ? -1.0f : 1.0f) * PitchRotSpeed * Time.deltaTime;
        PitchAngle = Mathf.Clamp(PitchAngle, MinPitchAngle, MaxPitchAngle);

        // Apply rotation to the camera
        CamPitchPivot.localRotation = Quaternion.Euler(PitchAngle, YawAngle, 0f);

        // Determine movement direction
        Vector3 dir = Vector3.zero;

        // Handle movement input
        if (Input.GetKey(KeyCode.W))
            dir += CamYawPivot.forward;

        if (Input.GetKey(KeyCode.A))
            dir -= CamYawPivot.right;

        if (Input.GetKey(KeyCode.S))
            dir -= CamYawPivot.forward;

        if (Input.GetKey(KeyCode.D))
            dir += CamYawPivot.right;

        // Apply movement
        CC.Move(dir * MoveSpeed * Time.deltaTime);
    }
}
