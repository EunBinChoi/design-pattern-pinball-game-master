using UnityEngine;
using System.Collections;

//가운데에 있는 토네이도 관리 매니저 
public class TornadoMng : MonoBehaviour
{
		//public Ball gameBall;			//
		public float gravity = 9.8f;	//중력 값 저장(기본 9.8)
		public float max_grv = 50f;		//최대 중력 값 범위
		public float min_grv = 25f;		//최소 중력 값 범위

		public float max_time = 2.0f;	//최대 중력 작용 시간
		public float min_time = 1.0f;	//최소 중력 작용 시간
		private bool bInside = false;	//볼이 안에 들어 왔는지 여부를 저장
		private Vector3 dir;

		//private float distance;
		private float duration;			//중력 작용 시간 저장
		private float endTime;          //구동 종료 시각 저장

		//Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		public void Init()
		{
			bInside = false;
		
		}
		void FixedUpdate ()
		{
				if (bInside) {
						
						dir = this.transform.position - Ball.getInstance().transform.position;
						//distance = Vector3.Distance (this.transform.position, gameBall.transform.position);
						if (Time.time >= endTime) {
                Ball.getInstance().GetComponent<Rigidbody>().AddForce (dir * (Random.Range (min_grv* duration, max_grv * duration)), ForceMode.Acceleration);
								bInside = false;
						} else {
                Ball.getInstance().GetComponent<Rigidbody>().AddForce (dir * (gravity), ForceMode.Acceleration);
						}
						//print (distance);
						gravity+=3;
						//gameBall.rigidbody.AddExplosionForce (-gravity, transform.position, radius, 0.0f, ForceMode.Acceleration);

				}
		
		}

		void OnTriggerEnter (Collider other) 	//뭔가 충돌 되면
		{
				if (other.gameObject.tag == Ball.getInstance().tag) {	//그 충돌된 물체가 Ball 이면 
						bInside = true;									//안에 있다는 것을 true로 변경 하고,
						gravity = Random.Range (min_grv, max_grv);		//중력의 초기 값을 랜덤 설정 (최소, 최대)
						duration = Random.Range (min_time, max_time);	//구동 시간의 초기값을 랜덤 설정 
						endTime = duration + Time.time;                  //현재 시간에서 구동시간을 더해서 종료 시각을 저장해둠
						print ("In Trigger");
				}
		}

		void OnTriggerExit (Collider other)
		{
				
				if (other.gameObject.tag == Ball.getInstance().tag) {   //볼이 밖으로 빠져 나갔다면?
						bInside = false;                //안에 있는지 여부를 거짓으로 설정
						gravity = Random.Range (min_grv, max_grv);  //중력 랜덤 값 설정
						print ("exit Trigger");     
				}
		}

}

