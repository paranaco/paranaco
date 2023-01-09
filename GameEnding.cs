using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    //声明开关变量，存储用户是否在触发器中
    bool m_IsPlayerAtExit;
    //声明一个公开对象，获取用户角色
    public GameObject player;

    //更改透明的时间
    public float fadeDuration = 1.90f;
    //计时器
    float m_Timer;
    //显示UI结束的时间
    public float displayImageDuration = 1.0f;

    //声明一个canvasGroup，用来获取ui中的实例，更改ui中图像的透明度
    public CanvasGroup exitBackgroundImageCanvasGroup;

    //游戏失败结束ui
    public CanvasGroup cuaghtBackgroundImageCanvasGroup;
    bool m_IsPlayerCaught;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    //触发器事件
    private void OnTriggerEnter(Collider other)
    {   
        //如果和触发器碰撞是玩家
        if (other.gameObject==player)
        {
            //将开关设置为true
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
        //如果玩家被抓住
        else if (m_IsPlayerCaught)
        {
            EndLevel(cuaghtBackgroundImageCanvasGroup,true);
        }
    }
    //结束当前关卡 1:结束的不同ui 2：是否重新开始
    void EndLevel(CanvasGroup imageCanvasGroup,bool doRestart)
    {
        
        //计时器增加
        m_Timer += Time.deltaTime;
        //逐渐更改透明度
        //透明度从0到1，从透明到不透明
        exitBackgroundImageCanvasGroup.alpha = m_Timer/fadeDuration;
        cuaghtBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        //当计时器时长大于设定透明度变化时长和显示ui时间之和时退出游戏
        if (m_Timer > fadeDuration + displayImageDuration)  
        {
            if(doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            { 
            //结束应用程序,打包发布时生效
            Application.Quit();
            //在unity编辑器中结束
            UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;    
    }
}
