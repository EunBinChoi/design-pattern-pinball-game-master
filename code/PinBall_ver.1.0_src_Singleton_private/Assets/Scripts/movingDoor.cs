using UnityEngine;
using System.Collections;

public class movingDoor : MonoBehaviour
{

    // Update is called once per frame
    public bool bPassed = false;    //공이 지나 갔는지 여부를 저장
    public float movingSpeed = 10;  //문 움직임 속도 설정
    public float displacement = 7;  //문 움직임 거리 설정
   // public Ball ball;               //볼 객체
    public float x_threshold = 43;  //x축으로 볼을 감지할 최대 거리
    private Vector3 sPos;           //초기 시작 위치 저장 변수 
    private float sDisplacement;    //초기 시작 변위 저장 변수
    void Start()
    {
        sPos = this.transform.position;     //초기 시작 위치 저장
        sDisplacement = displacement;       //초기 시작 변위 저장
    }

    public void Init()
    {
        this.transform.position = sPos;     //초기 시작 위치로 초기화
        this.bPassed = false;               //공이 지나 갔는지 여부를 저장하는 변수를 초기화 
        this.displacement = sDisplacement;  //초기 시작 변위 저장
    }

    void Update()
    {
        if (Ball.getInstance().transform.position.x < x_threshold)
        {  //볼의 위치가 임계치 이내로 지나 갔는지 확인.
            Ball.getInstance().bStart = true;         //볼의 시작 변수를 참으로 초기화  
            bPassed = true;             //공이 지나 갔다는 정보를 저장
        }
        if (bPassed)
        {                      //공이 이미지나 갔다면
            if (displacement < (movingSpeed * Time.deltaTime))
            {    //특정 위치에 도달하지 못한 경우
                transform.Translate(0, 0, displacement);       //이동
                displacement = 0;
                bPassed = false;
            }
            else if (displacement == 0)
            {
                displacement = 0;
                bPassed = false;
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