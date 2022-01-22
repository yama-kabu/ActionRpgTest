using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;              // �ړ�����
    [SerializeField] private float moveSpeed = 5.0f;        // �ړ����x
    [SerializeField] private float applySpeed = 0.2f;       // �U������̓K�p���x
    [SerializeField] private PlayerFollowCamera refCamera;  // �J�����̐�����]���Q�Ƃ���p

    private Rigidbody rb;
    public float upForce = 200f; 
    private bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            velocity.z += 1;
        if (Input.GetKey(KeyCode.A))
            velocity.x -= 1;
        if (Input.GetKey(KeyCode.S))
            velocity.z -= 1;
        if (Input.GetKey(KeyCode.D))
            velocity.x += 1;
        if (isGround == true)//���n���Ă���Ƃ�
        {
            if (Input.GetKeyDown("space"))
            {
                isGround = false;//  isGround��false�ɂ���
                rb.AddForce(new Vector3(0, upForce, 0)); //��Ɍ������ė͂�������
            }
        }

        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        // �����ꂩ�̕����Ɉړ����Ă���ꍇ
        if (velocity.magnitude > 0)
        {
            // �v���C���[�̉�]�̍X�V

            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(refCamera.hRotation * -velocity),
                                                  applySpeed);

            // �v���C���[�̈ʒu�̍X�V
            transform.position += refCamera.hRotation * velocity;
        }
    }

    void OnCollisionEnter(Collision other) //�n�ʂɐG�ꂽ���̏���
    {
        if (other.gameObject.tag == "Ground") //Ground�^�O�̃I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
        {
            isGround = true; //isGround��true�ɂ���
        }
    }
}
