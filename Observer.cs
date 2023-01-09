using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//使用触发器检测玩家
public class Observer : MonoBehaviour
{
    //声明玩家变换组件对象
    public Transform player;
    //声明bool变量，表示玩家是否碰撞
    bool m_IsPlayerInRange;
    //声明游戏结束脚本组件类对象，获取游戏结束脚本对象
    //调用游戏结束的公有方法（GameEnding）
    public GameEnding GameEnding;
    

    //触发器事件 
    private void OnTriggerEnter(Collider other)
    {
        //如果玩家进入触发器
        if(other.transform == player)
        {
            //
            m_IsPlayerInRange = true;
        }
    }

    //离开触发器事件
    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            //
            m_IsPlayerInRange = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        //触发器触发
        if (m_IsPlayerInRange)
        {
            //设置投射射线的向量
            Vector3 direction = player.position - transform.position +Vector3.up;
            //创建射线
            Ray ray = new Ray(transform.position, direction);

            //射线击中对象，包含射线碰撞信息
            RaycastHit raycastHit;
            
            //使用物理系统发射射线，碰到物体
            if (Physics.Raycast(ray,out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    GameEnding.CaughtPlayer();
                }
            }
        }
    }
}
