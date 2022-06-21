using UnityEngine;
using System.Collections;

//게임 매니저
public class gameManager : MonoBehaviour
{
		public string inputButtonName = "Reset";    //리셋 버튼 이름 저장
		public movingDoor door;         //도어 객체 생성
		public Ball ball;               //볼 객체 생성
		public OutOfBounds oob ;        //외곽 판정 객체 생성
		public TornadoMng tMng;         //토네이도 객체 생성
        public PullSpring springMng;   //발사대 매니저
		// Use this for initialization
		public void gameInit (){
			ball.Init();    //볼 객체 초기화
            door.Init();     //도어 객체 초기화  
            tMng.Init ();   //토네이도 객체 초기화
            springMng.Init();   //발사대 객체 초기화
			oob.bOutofBound = false;    //공위치가 외곽 위치에 있는지 판별하는 변수 초기화
		}
		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (oob.bOutofBound == true) {  //공이 밖으로 나갔는지 확인 되면,
				this.gameInit();            //게임 초기화
			}
			if (Input.GetButton (inputButtonName)) {    //리셋 버튼이 눌렸다면,
				print ("restart game!!");	
				this.gameInit();            //게임 초기화
			}
		}
		
}	

