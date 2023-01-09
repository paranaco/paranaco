using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class WaypointPatrol : MonoBehaviour
{
    //声明navmeshagent组件对象，来获取当前对象的导航网格代理组件
    NavMeshAgent agent;
    //路径点数组
    public Transform[] waypoints;
    //当前路径点的索引值
    int m_CurrenWaypointIndex;


    // Start is called before the first frame update
    void Start()
    {
        //获取组件
        agent = GetComponent<NavMeshAgent>();
        //设置导航点起始点位
        agent.SetDestination(waypoints[0].position);

    }


    //设定下一个导航路径点
    // Update is called once per frame
    void Update()
    {
        //当前游戏对象到指定的路径点的距离小于最终停止距离 

        if (agent.remainingDistance<agent.stoppingDistance)
        {
            //获取下一个路径点在数组中的索引数
            //通过除余使索引数从0到waypoints-1 
            //5/5=0余0 回到起始点位循环
            m_CurrenWaypointIndex = (m_CurrenWaypointIndex+1)%waypoints.Length;
            //设置新的导航位置
            //SetDestination方法，设置移动的目标位置，值为三维向量
            agent.SetDestination(waypoints[m_CurrenWaypointIndex].position);

        }
    }
}
