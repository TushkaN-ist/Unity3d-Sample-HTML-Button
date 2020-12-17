using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public Vector3 targetPos;
    public Vector3 currentPos;
    float time;
    [Range(0.1f,10)]
    public float timeStep=1;
    bool complete = false;

    public void SetTargetPos(string _targetPos)
    {
        if (time < 1)
            return;
        currentPos += targetPos;
        targetPos = JsonUtility.FromJson<Vector3>(_targetPos) - currentPos;
        time = 0;
        complete = false;
        CallToJs.SetElementText(0);
    }
    public void AddTargetPos(string _targetPos)
    {
        if (time < 1)
            return;
        currentPos += targetPos;
        targetPos = JsonUtility.FromJson<Vector3>(_targetPos);
        time = 0;
        complete = false;
        CallToJs.SetElementText(0);
    }

    [ContextMenu("Reset")]
    void SetTarget(){
        AddTargetPos("{\"x\":1,\"y\":0,\"z\":0}");
    }
	private void Awake()
	{
        CallToJs.SetElementText(200);
    }
	// Update is called once per frame
	void Update()
    {
        time = Mathf.Clamp01(time+Time.deltaTime* timeStep);
        Vector3 _currentPos = Vector3.Lerp(currentPos, currentPos+targetPos, time);
        transform.position = new Vector3(_currentPos.x, _currentPos.y + Mathf.Abs(Mathf.Sin(_currentPos.x * Mathf.PI) + Mathf.Sin(_currentPos.z * Mathf.PI)), _currentPos.z);
        if (time>=1 && !complete)
        {
            complete = true;
            CallToJs.SetElementText(200);
        }
    }
}
