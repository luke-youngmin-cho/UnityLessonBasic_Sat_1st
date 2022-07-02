using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float minDistance = 3; // 카메라와 타겟간의 최소거리
    [SerializeField] private float maxDistance = 30; // 카메라와 타겟간의 최대거리
    [SerializeField] private float wheelSpeed = 500; // 마우스 휠 속도
    [SerializeField] private float xPointSpeed = 500; // 마우스 x 축 이동속도
    [SerializeField] private float yPointSpeed = 500; // 마우스 y 축 이동속도
    private float yMinLimit = 5;
    private float yMaxLimit = 80;
    private float x, y; // 마우스 위치
    private float distance; //카메라와 타겟간의 거리
    private Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        x = tr.eulerAngles.y;
        y = tr.eulerAngles.x;
    }

    private void Start()
    {
        target = PlayerMove.instance.transform;
        distance = Vector3.Distance(tr.position, target.position);
    }

    private void Update()
    {
        x += Input.GetAxis("Mouse X") * xPointSpeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * yPointSpeed * Time.deltaTime;

        ClampAngle(ref y, yMinLimit, yMaxLimit);
        tr.rotation = Quaternion.Euler(y, x, 0);

        distance -= Input.GetAxis("Mouse ScrollWheel") * wheelSpeed * Time.deltaTime;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }

    private void LateUpdate()
    {
        tr.position = tr.rotation * new Vector3(0, 0, -distance) + target.position;
    }

    private void ClampAngle(ref float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        angle = Mathf.Clamp(angle, min, max);
    }
}

public struct st_Coord
{
    public float x, y;
}

public class c_Coord
{
    public float x, y;
}