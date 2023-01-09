using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    //�������ر������洢�û��Ƿ��ڴ�������
    bool m_IsPlayerAtExit;
    //����һ���������󣬻�ȡ�û���ɫ
    public GameObject player;

    //����͸����ʱ��
    public float fadeDuration = 1.90f;
    //��ʱ��
    float m_Timer;
    //��ʾUI������ʱ��
    public float displayImageDuration = 1.0f;

    //����һ��canvasGroup��������ȡui�е�ʵ��������ui��ͼ���͸����
    public CanvasGroup exitBackgroundImageCanvasGroup;

    //��Ϸʧ�ܽ���ui
    public CanvasGroup cuaghtBackgroundImageCanvasGroup;
    bool m_IsPlayerCaught;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    //�������¼�
    private void OnTriggerEnter(Collider other)
    {   
        //����ʹ�������ײ�����
        if (other.gameObject==player)
        {
            //����������Ϊtrue
            m_IsPlayerAtExit = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerAtExit)
        {
           EndLevel(exitBackgroundImageCanvasGroup,false);
        }
        //�����ұ�ץס
        else if (m_IsPlayerCaught)
        {
            EndLevel(cuaghtBackgroundImageCanvasGroup,true);
        }
    }
    //������ǰ�ؿ� 1:�����Ĳ�ͬui 2���Ƿ����¿�ʼ
    void EndLevel(CanvasGroup imageCanvasGroup,bool doRestart)
    {
        
        //��ʱ������
        m_Timer += Time.deltaTime;
        //�𽥸���͸����
        //͸���ȴ�0��1����͸������͸��
        exitBackgroundImageCanvasGroup.alpha = m_Timer/fadeDuration;
        cuaghtBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        //����ʱ��ʱ�������趨͸���ȱ仯ʱ������ʾuiʱ��֮��ʱ�˳���Ϸ
        if (m_Timer > fadeDuration + displayImageDuration)  
        {
            if(doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            { 
            //����Ӧ�ó���,�������ʱ��Ч
            Application.Quit();
            //��unity�༭���н���
            UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;    
    }
}
