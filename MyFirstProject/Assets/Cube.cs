using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // 필드의 인스펙터창 노출 설정
    // public : 외부 클래스 접근 가능, 인스펙터창 노출함
    // private : 외부 클래스 접근 불가, 인스펙터창 노출 안함 
    // [HideInInsepector] public : 외부 클래스 접근 가능, 인스펙터창 노출 안함
    // [SerializeField] private : 외부 클래스 접근 불가, 인스펙터창 노출함

    // this 키워드 
    // 객체 자신을 반환하는 키워드

    public int a = 3;
    private Transform tr;

    Vector3 move;

    private void Awake()
    {
        Debug.Log(this);
        Debug.Log(this.gameObject);
        Debug.Log(gameObject);

        tr = this.gameObject.GetComponent<Transform>();
        tr = gameObject.GetComponent<Transform>();
        tr = GetComponent<Transform>();
        tr = transform;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        tr.position = Vector3.zero;         
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Debug.Log($"h = {h}, v = {v}");
        move = new Vector3(h, 0, v);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // position 변경시에는 
        // position 의 프레임시간당 변화 량을 더해주어야 한다.
        // 시간 당 위치 변화량(속도) = 위치변화량 / 시간
        // 프레임 시간 당 위치 변화량(프레임단위 속도) = 위치변화량 / 프레임 시간
        // 위치변화량 = 프레임 시간 당 위치 변화량 * 프레임 시간
        tr.position += move * Time.fixedDeltaTime;
        
    }
}
