using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour
{
		public bool bOutofBound = false; 
		public void Start ()
		{
		}
        public void OnCollisionEnter(Collision collision) {    //충돌 확인
			if(collision.gameObject.tag == "Ball") {    //충돌 된 것이 볼이라면
				bOutofBound = true;			          //볼이 밖으로 나왔다는 것을 저장
				//door
			}
		}
		
}

