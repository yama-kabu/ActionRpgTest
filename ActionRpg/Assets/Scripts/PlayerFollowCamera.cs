using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 10.0f;   // ��]���x
    [SerializeField] private Transform player;          // �����Ώۃv���C���[

    [SerializeField] private float distance = 15.0f;    // �����Ώۃv���C���[����J�����𗣂�����
    [SerializeField] private Quaternion vRotation;      // �J�����̐�����](�����낵��])
    [SerializeField] public Quaternion hRotation;      // �J�����̐�����]

    void Start()
    {
        vRotation = Quaternion.Euler(30, 0, 0);         
        hRotation = Quaternion.identity;                
        transform.rotation = hRotation * vRotation;     

        // �ʒu�̏�����
        transform.position = player.position - transform.rotation * Vector3.forward * distance;
    }

    void LateUpdate()
    {
        // ������]�̍X�V
        if (Input.GetMouseButton(0))
            hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * turnSpeed, 0);

        // �J�����̉�]�̍X�V
        transform.rotation = hRotation * vRotation;

        // �J�����̈ʒu�̍X�V
        transform.position = player.position + new Vector3(0, 3, 0) - transform.rotation * Vector3.forward * distance;
    }
}
