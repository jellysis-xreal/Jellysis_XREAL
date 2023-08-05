using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAnalyzer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float maxErrorDistance = 0.05f;

    public List<Vector3> circlePoints = new List<Vector3>();

    private bool _onCalculate = false;
    private WaitForSeconds _waitTime;
    void Start()
    {
        _waitTime = new WaitForSeconds(0.5f);
        StartCoroutine(AddPoint());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            circlePoints.Clear();
        }

        
        
        // 그려진 원이 실제 원과 유사한지 판단
        if (circlePoints.Count >2 && Input.GetKeyDown(KeyCode.A))
        {
            bool isCircle = IsApproximateCircle(circlePoints);
            Debug.Log("Is Circle : " + isCircle);
        }
    }
    // 지금 문제 점과 점 사이의 거리가 너무 작아 0으로 값이 나옴. 오차 크게 하고 
    // 그려진 원이 실제 원과 유사한지 판단하는 메서드
    private bool IsApproximateCircle(List<Vector3> points)
    {
        // 간단하게 점들의 거리를 비교해서 판단., 최근 그려진 것들만 판단?
        for (int i = points.Count- 1; i > 0 ; i--)
        {
            double distance = (double)Vector3.Distance(points[i], points[i - 1]) * 100;
            //Debug.Log("distance : "+distance);
            //Debug.Log("Mathf.Abs((float)distance - 1.0f) : "+ Mathf.Abs((float)distance - 1.0f));
            if (Mathf.Abs((float)distance - 1.0f) > maxErrorDistance)
            {
                return false;
            }
            break;
        }
        return true;
    }

    IEnumerator AddPoint()
    {
        while (true)
        {
            circlePoints.Add(new Vector3(transform.position.x, transform.position.y, transform.position.z));
            
            // 그려진 원의 궤적을 라인 렌더러를 통해 그림
            lineRenderer.positionCount = circlePoints.Count;
            lineRenderer.SetPositions(circlePoints.ToArray());
            
            bool isCircle = IsApproximateCircle(circlePoints);
            Debug.Log("Is Circle : " + isCircle);
            yield return _waitTime;
        }
    }
}
