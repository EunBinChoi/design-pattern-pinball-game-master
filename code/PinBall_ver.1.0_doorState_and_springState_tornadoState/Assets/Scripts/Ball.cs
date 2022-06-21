using UnityEngine;
using System.Collections;

//�� Ŭ����
public class Ball : MonoBehaviour
{
		// Use this for initialization
		private float maximum = 0;  //�ִ� �ӵ� ����
		public int score = 0;       //���� ���� ����
		public bool bStart = false; //���� ���� ���� ����
		private Vector3 sPos;       //�ʱ� ��ġ ���� ����

		void Start ()
		{
				sPos = this.transform.position; //�ʱ� ��ġ ���� 
		}

		public void Init ()
		{		
				this.GetComponent<Rigidbody>().velocity = Vector3.zero; //�ӵ� 0 ����
				this.transform.position = sPos;  //�ʱ� ��ġ�� �ʱ�ȭ
				this.bStart = false;            //���� ���� �ʱ�ȭ
				this.score = 0;                 //���� �ʱ�ȭ

		}

		// Update is called once per frame
		void Update ()
		{
				if (Mathf.Abs (this.GetComponent<Rigidbody>().velocity.z) > maximum)    //�ִ� �ӵ� ����
						maximum = this.GetComponent<Rigidbody>().velocity.z;
		}

		void OnCollisionEnter (Collision collision) //�浹 �Ѵٸ�
		{
				if (bStart && collision.gameObject.tag != "Floor") {    
                           //���� ���� �� �����̸鼭 �浹 ��ü�� Floor�� �ƴѰ��
						if (collision.gameObject.tag == "Bumper") { //�浹 ����� ������ ���
								score += 200;   //200�� �߰�
						} else {
								score += 0;
						}	
				}
				
		}

		void OnTriggerEnter (Collider other)    //Ʈ���Ű� ���� �Ǹ� 
		{
				if (bStart && other.gameObject.tag != "Floor") {
						if (other.gameObject.tag == "Tornado") {    //����̵��� ������ 
								score += 1000;                      //1000�� �߰�
						} else {
								score += 0;
						}	
				}
			
		}		
}

