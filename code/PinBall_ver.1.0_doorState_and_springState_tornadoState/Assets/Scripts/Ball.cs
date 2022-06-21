using UnityEngine;
using System.Collections;

//공 클래스
public class Ball : MonoBehaviour
{
		// Use this for initialization
		private float maximum = 0;  //최대 속도 변수
		public int score = 0;       //점수 저장 변수
		public bool bStart = false; //시작 여부 저장 변수
		private Vector3 sPos;       //초기 위치 저장 변수

		void Start ()
		{
				sPos = this.transform.position; //초기 위치 저장 
		}

		public void Init ()
		{		
				this.GetComponent<Rigidbody>().velocity = Vector3.zero; //속도 0 설정
				this.transform.position = sPos;  //초기 위치로 초기화
				this.bStart = false;            //시작 여부 초기화
				this.score = 0;                 //점수 초기화

		}

		// Update is called once per frame
		void Update ()
		{
				if (Mathf.Abs (this.GetComponent<Rigidbody>().velocity.z) > maximum)    //최대 속도 유지
						maximum = this.GetComponent<Rigidbody>().velocity.z;
		}

		void OnCollisionEnter (Collision collision) //충돌 한다면
		{
				if (bStart && collision.gameObject.tag != "Floor") {    
                           //볼이 시작 된 상태이면서 충돌 객체가 Floor가 아닌경우
						if (collision.gameObject.tag == "Bumper") { //충돌 대상이 범퍼인 경우
								score += 200;   //200점 추가
						} else {
								score += 0;
						}	
				}
				
		}

		void OnTriggerEnter (Collider other)    //트리거가 시작 되면 
		{
				if (bStart && other.gameObject.tag != "Floor") {
						if (other.gameObject.tag == "Tornado") {    //토네이도에 빠지면 
								score += 1000;                      //1000점 추가
						} else {
								score += 0;
						}	
				}
			
		}		
}

