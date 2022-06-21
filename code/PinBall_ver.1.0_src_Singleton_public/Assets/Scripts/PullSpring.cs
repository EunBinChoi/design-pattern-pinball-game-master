using UnityEngine;
using System.Collections;

public class PullSpring : MonoBehaviour
{
	public string inputButtonName = "Pull";
	public float distance = 50;     //거리
	public float pullSpeed  = 1;     //당기는 속도   
	public float pushSpeed = 20;     //발사하는 속도
	//public GameObject ball;           //볼 객체  
	public float power  = 2000;      //볼 발사에 필요한 파워
	
	private bool ready = false;       //준비 여부
	private bool fire  = false;         //발사 여부
	private float moveCount  = 0;
	private bool bTouch;
	// Use this for initialization
	void Start ()
	{
    
    }
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButton(inputButtonName)){   //키보드 입력이나 터치 입력이 되었을 경우
			//As the button is held down, slowly move the piece
			if(moveCount < distance){                   //이동 도달 거리 보다 현재 거리가 작으면
				transform.Translate(0,0,-pullSpeed * Time.deltaTime);   //이동 명령
				moveCount += pullSpeed * Time.deltaTime;                //이동 정도 저장
				fire = true;                                            //발사 준비 상태
			}
		}
		else if(moveCount > 0){
			//Shoot the ball
			//Debug.Log(ball.transform.position);
			if(fire && ready){  //발사 준비가 끝났다면,

                Ball._instance.transform.TransformDirection(Vector3.forward * 50);    //볼 움직이
                Ball._instance.GetComponent<Rigidbody>().AddForce(0, 0, moveCount * power);   //볼에 파워 인가

				fire = false;
				ready = false;
			}

			//초기 위치로 수렴하기 위해
			if(moveCount < (pushSpeed * Time.deltaTime))
			{
				transform.Translate(0,0,moveCount); //이동
				moveCount = 0;
				fire = false; //fire
			}	
			else{	//빠른 속도로 발사
				transform.Translate(0,0,pushSpeed * Time.deltaTime);
				moveCount -= pushSpeed * Time.deltaTime;
			}
		}
	}
	void OnCollisionEnter(Collision collision) {        
		if(collision.gameObject.tag == Ball._instance.tag)
        {     //볼과 충돌 했다면 준비 상태
			ready = true;
		}
	}
	void OnCollisionExit(Collision collisionInfo) {

       
        if (collisionInfo.gameObject.tag ==  Ball._instance.tag)
        { //볼과 충돌이 끝났다면 준비 상태를 거짓으로 초기화
            ready = false;
		}
	}
}

