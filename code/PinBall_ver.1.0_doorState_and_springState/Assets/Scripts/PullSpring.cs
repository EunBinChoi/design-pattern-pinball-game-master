using UnityEngine;
using System.Collections;

public class PullSpring : MonoBehaviour
{
	public string inputButtonName = "Pull";
	public float distance = 50;     //최대 거리
	public float pullSpeed  = 1;     //당기는 속도   
	public float pushSpeed = 20;     //발사하는 속도
	public Ball ball;           //볼 객체  
	public float power  = 2000;      //볼 발사에 필요한 파워
	
	private bool ready = false;       //준비 여부
	private bool fire  = false;         //발사 여부
	private float moveCount  = 0;       //스페이스바가 눌리는 정도를 측정

    private springState readySt = new readyFireState();
    private springState pressSt = new pressButtonState();
    private springState releaseSt = new releaseButtonState();
    private springState returnSt = new returnBackState();

    private springState currentSt = null;

    // Use this for initialization
    void Start ()
	{
        this.Init();
    }
	
    public void Init()
    {
        currentSt = releaseSt;
        moveCount = 0;
    }
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetButton(inputButtonName))
        {   //키보드 입력이 되었을 경우
            if (currentSt.ready())          //레디 상태였다면,
                currentSt = pressSt;        //키가 눌린 상태로 전환
        }
        else {          //키가 안눌린 경우
            if(currentSt.moveBackward())    //키가 눌렸던 상태 였다면
                currentSt = releaseSt;      //키가 릴리즈 된 상태로 전환
        }

        if (currentSt.moveBackward())   //발사대를 뒤로 당겨야 하는 상황이면 (키가 눌려 있는 상태)
        {
            if (moveCount < distance)
            {                   //이동 도달 최대 거리 보다 현재 거리가 작으면
                transform.Translate(0, 0, -pullSpeed * Time.deltaTime);   //이동 명령
                moveCount += pullSpeed * Time.deltaTime;                //이동 정도 저장
            }
        }
        else if (currentSt.shooting())  //발사를 해야하는 상황이라면 (키가 릴리즈 된 상태),
        {
            Debug.Log("Shooting");
            ball.transform.TransformDirection(Vector3.forward * 50);    //볼 이동
            ball.GetComponent<Rigidbody>().AddForce(0, 0, moveCount * power);   //볼에 파워 인가
            currentSt = returnSt;
        }
        else if (currentSt.moveOriginalPosition()) {
            if (moveCount < (pushSpeed * Time.deltaTime))
            {
                transform.Translate(0, 0, moveCount); //이동
                moveCount = 0;
                currentSt = readySt;
            }
            else
            {   //빠른 속도로 발사
                transform.Translate(0, 0, pushSpeed * Time.deltaTime);
                moveCount -= pushSpeed * Time.deltaTime;
            }

        }        
	}
	void OnCollisionEnter(Collision collision) {        
		if(collision.gameObject.tag == "Ball"){     //볼과 충돌 했다면 준비 상태
            currentSt = readySt;
		}
	}
}

