using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class WaypointPatrol : MonoBehaviour
{
    //����navmeshagent�����������ȡ��ǰ����ĵ�������������
    NavMeshAgent agent;
    //·��������
    public Transform[] waypoints;
    //��ǰ·���������ֵ
    int m_CurrenWaypointIndex;


    // Start is called before the first frame update
    void Start()
    {
        //��ȡ���
        agent = GetComponent<NavMeshAgent>();
        //���õ�������ʼ��λ
        agent.SetDestination(waypoints[0].position);

    }


    //�趨��һ������·����
    // Update is called once per frame
    void Update()
    {
        //��ǰ��Ϸ����ָ����·����ľ���С������ֹͣ���� 

        if (agent.remainingDistance<agent.stoppingDistance)
        {
            //��ȡ��һ��·�����������е�������
            //ͨ������ʹ��������0��waypoints-1 
            //5/5=0��0 �ص���ʼ��λѭ��
            m_CurrenWaypointIndex = (m_CurrenWaypointIndex+1)%waypoints.Length;
            //�����µĵ���λ��
            //SetDestination�����������ƶ���Ŀ��λ�ã�ֵΪ��ά����
            agent.SetDestination(waypoints[m_CurrenWaypointIndex].position);

        }
    }
}
