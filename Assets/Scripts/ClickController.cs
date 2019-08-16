using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    private List<Transform> m_Balls = new List<Transform>();
    private List<Rigidbody2D> m_BallRigitbodys = new List<Rigidbody2D>();
    
    private float m_ClickPower = 500.0f;

    void Start()
    {
        m_Balls = new List<Transform>();

        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        if(balls == null) return;

        foreach(var b in balls)
        {
            m_Balls.Add(b.transform);
            m_BallRigitbodys.Add(b.GetComponent<Rigidbody2D>());
            print(b.transform.position);
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            BallAddForceByScreenPosition(Input.mousePosition);
        }
    }

    private void BallAddForceByScreenPosition(Vector3 screen)
    {
        Debug.Log(screen);

        Vector2 clickpos = Conveni.ScreenToWorld(screen);

        foreach(var b in m_BallRigitbodys)
        {
            Vector2 pos = b.transform.position;
            Vector2 v = (pos - clickpos).normalized;
            b.AddForce(v * m_ClickPower);
        }
    }
}
