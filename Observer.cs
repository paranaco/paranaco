using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ʹ�ô�����������
public class Observer : MonoBehaviour
{
    //������ұ任�������
    public Transform player;
    //����bool��������ʾ����Ƿ���ײ
    bool m_IsPlayerInRange;
    //������Ϸ�����ű��������󣬻�ȡ��Ϸ�����ű�����
    //������Ϸ�����Ĺ��з�����GameEnding��
    public GameEnding GameEnding;
    

    //�������¼� 
    private void OnTriggerEnter(Collider other)
    {
        //�����ҽ��봥����
        if(other.transform == player)
        {
            //
            m_IsPlayerInRange = true;
        }
    }

    //�뿪�������¼�
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
        //����������
        if (m_IsPlayerInRange)
        {
            //����Ͷ�����ߵ�����
            Vector3 direction = player.position - transform.position +Vector3.up;
            //��������
            Ray ray = new Ray(transform.position, direction);

            //���߻��ж��󣬰���������ײ��Ϣ
            RaycastHit raycastHit;
            
            //ʹ������ϵͳ�������ߣ���������
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
