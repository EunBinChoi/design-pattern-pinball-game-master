using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour
{
		public bool bOutofBound = false; 
		public void Start ()
		{
		}
        public void OnCollisionEnter(Collision collision) {    //�浹 Ȯ��
			if(collision.gameObject.tag == "Ball") {    //�浹 �� ���� ���̶��
				bOutofBound = true;			          //���� ������ ���Դٴ� ���� ����
				//door
			}
		}
		
}

