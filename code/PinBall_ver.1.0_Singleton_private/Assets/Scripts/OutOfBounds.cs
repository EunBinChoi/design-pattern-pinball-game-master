using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour
{
		public bool bOutofBound = false; 
		void Start ()
		{
		}
		void OnCollisionEnter(Collision collision) {    //�浹 Ȯ��
			if(collision.gameObject.tag == Ball.getInstance().tag) {    //�浹 �� ���� ���̶��
				bOutofBound = true;			          //���� ������ ���Դٴ� ���� ����
				//door
			}
		}
		
}

