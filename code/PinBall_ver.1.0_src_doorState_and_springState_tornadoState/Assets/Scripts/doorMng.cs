using UnityEngine;
using System.Collections;

public class doorMng : MonoBehaviour
{
    // Update is called once per frame
    public bool bPassed = false;    //공이 지나 갔는지 여부를 저장
    public float movingSpeed = 10;  //문 움직임 속도 설정
    public float displacement = 7;  //문 움직임 거리 설정
    public Ball ball;               //볼 객체
    public float x_threshold = 43;  //x축으로 볼을 감지할 최대 거리
    private Vector3 sPos;           //초기 시//		private float sDisplacement;    //초기 시작 변위 저장 변수
    public float sDisplacement;

    private doorState readySt = new readyState(); // 문이 준비된 상태
    private doorState passedSt = new passedState(); // 문에 공이 지나간 상태
    private doorState movingSt = new movingState(); // 문이 움직인 상태
    private doorState closedSt = new closedState(); // 문이 닫힌 상태

    private doorState currentState = null;

    void Start()
    {
        currentState = readySt;
        if (currentState.ready())
        {
            sPos = this.transform.position;     //초기 시작 위치 저장
            sDisplacement = displacement;       //초기 시작 변위 저장
        }
    }

    public void Init()
    {
        this.transform.position = sPos;      //초기 시작 위치로 초기화
        this.displacement = sDisplacement;   //초기 시작 변위 저장
        currentState = readySt;              //대기 상태로 초기화
    }

    void Update()
    {
        if (currentState.ready())       //레디 상태이고,
        {
            if (ball.transform.position.x < x_threshold)
            {  //볼의 위치가 임계치 이내로 지나 갔는지 확인.
                ball.bStart = true;                  //볼의 시작 변수를 참으로 초기화  
                currentState = passedSt;            //움직임 확인 상태로 전환
            }
        }
        if (currentState.movingStart())         //움직임이 시작 됐다면,
            currentState = movingSt;            //자동으로 움직임 상태로 전환

        if (currentState.moving()) //움직임 상태면  
        {                                //공이 이미지나 갔다면
            if (displacement < (movingSpeed * Time.deltaTime))
            {    //특정 위치에 도달하지 못한 경우
                transform.Translate(0, 0, displacement);       //이동
                displacement = 0;
                currentState = closedSt;    //움직임이 끝났기 때문에 닫힘 상태로 전환					
            }
            else if (displacement == 0)
            {
                displacement = 0;
                currentState = closedSt;    //움직임이 끝났기 때문에 닫힘 상태로 전환	
            }
            else
            {
                transform.Translate(0, 0, movingSpeed * Time.deltaTime);
                displacement -= movingSpeed * Time.deltaTime;
            }
        }
        //Debug.DrawRay(this.transform.position,this.transform.forward*10, Color.red, 50f,false);
    }

}