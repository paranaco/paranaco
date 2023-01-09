using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{

    //ʹ��3D������ʾ��ɫ���ƶ�
    Vector3 m_Movement;
    //������������ȡ�û�����ķ���
    float horizontal;
    float vertical;

    //�����������
    Rigidbody m_rigidbody;
    //����animator�������
    Animator m_animator;

    //����Ԫ����ʾ��ת
    //��ʼ������Ϊ����ת
    Quaternion m_rotation=Quaternion.identity;
    //��ת�ٶ�
    public float turnSpeed = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        //��ȡ��������Ͷ������������
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();  

    }

    // Update is called once per frame
    void Update()
    {
        //��ȡ�û�����
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        //���û�����ֵ��װ��3D����
        m_Movement.Set(horizontal,0.0f,vertical);
        m_Movement.Normalize();

        //�ж��Ƿ��к��������ƶ�
        bool hasHorizontal = !Mathf.Approximately(horizontal,0.0f);
        bool hasVertical = !Mathf.Approximately(vertical,0.0f);
        //����������ƶ�����ɫ�����ƶ�״̬
        bool isWalking = hasHorizontal || hasVertical;
        //���������ݸ�����������
        m_animator.SetBool("IsWalking",isWalking);
        //ʹ��3D������ʾ��ת���ɫ�����λ��
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward,m_Movement,turnSpeed*Time.deltaTime,0f);
        //������Ԫ�������ֵ 
        m_rotation=Quaternion.LookRotation(desiredForward);

    }
    //�����������������ƶ�ʱ�ƶ�
    private void OnAnimatorMove()
    {
        //���û������3D������Ϊ�ƶ������ö�����ÿ��0.02����ƶ������ƶ�
        m_rigidbody.MovePosition(m_rigidbody.position + m_Movement*m_animator.deltaPosition.magnitude);
        m_rigidbody.MoveRotation(m_rotation);
    }
}
