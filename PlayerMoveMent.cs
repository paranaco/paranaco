using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{

    //使用3D向量表示角色的移动
    Vector3 m_Movement;
    //创建变量，获取用户输入的方向
    float horizontal;
    float vertical;

    //声明刚体对象
    Rigidbody m_rigidbody;
    //声明animator组件对象；
    Animator m_animator;

    //用四元数表示旋转
    //初始化对象，为不旋转
    Quaternion m_rotation=Quaternion.identity;
    //旋转速度
    public float turnSpeed = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        //获取刚体组件和动画管理者组件
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();  

    }

    // Update is called once per frame
    void Update()
    {
        //获取用户输入
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        //将用户输入值组装成3D向量
        m_Movement.Set(horizontal,0.0f,vertical);
        m_Movement.Normalize();

        //判断是否有横向、纵向移动
        bool hasHorizontal = !Mathf.Approximately(horizontal,0.0f);
        bool hasVertical = !Mathf.Approximately(vertical,0.0f);
        //横向或纵向移动，角色处于移动状态
        bool isWalking = hasHorizontal || hasVertical;
        //将变量传递给动画管理器
        m_animator.SetBool("IsWalking",isWalking);
        //使用3D向量表示旋转后角色朝向的位置
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward,m_Movement,turnSpeed*Time.deltaTime,0f);
        //设置四元数对象的值 
        m_rotation=Quaternion.LookRotation(desiredForward);

    }
    //当动画播放引发根移动时移动
    private void OnAnimatorMove()
    {
        //用用户输入的3D向量作为移动方向，用动画中每次0.02秒的移动距离移动
        m_rigidbody.MovePosition(m_rigidbody.position + m_Movement*m_animator.deltaPosition.magnitude);
        m_rigidbody.MoveRotation(m_rotation);
    }
}
