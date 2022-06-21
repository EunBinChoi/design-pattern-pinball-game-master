using UnityEngine;
using System.Collections;

//���� �Ŵ���
public class gameManager : MonoBehaviour
{
		public string inputButtonName = "Reset";    //���� ��ư �̸� ����
		public doorMng door;         //���� ��ü ����
		public Ball ball;               //�� ��ü ����
		public OutOfBounds oob ;        //�ܰ� ���� ��ü ����
		public TornadoMng tMng;         //����̵� ��ü ����
        public springMng springMng;   //�߻�� �Ŵ���
		// Use this for initialization
		public void gameInit (){
			ball.Init();    //�� ��ü �ʱ�ȭ
            door.Init();     //���� ��ü �ʱ�ȭ  
            tMng.Init ();   //����̵� ��ü �ʱ�ȭ
            springMng.Init();   //�߻�� ��ü �ʱ�ȭ
			oob.bOutofBound = false;    //����ġ�� �ܰ� ��ġ�� �ִ��� �Ǻ��ϴ� ���� �ʱ�ȭ
		}
		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (oob.bOutofBound == true) {  //���� ������ �������� Ȯ�� �Ǹ�,
				this.gameInit();            //���� �ʱ�ȭ
			}
			if (Input.GetButton (inputButtonName)) {    //���� ��ư�� ���ȴٸ�,
				print ("restart game!!");	
				this.gameInit();            //���� �ʱ�ȭ
			}
		}
		
}	

