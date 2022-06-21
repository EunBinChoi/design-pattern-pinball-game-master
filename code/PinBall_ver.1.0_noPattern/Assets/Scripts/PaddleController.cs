using UnityEngine;
using System.Collections;

//좌우 패달을 제어할 수 있는 클래스
public class PaddleController  : MonoBehaviour
{
	public float restPosition = 0F;
	public float pressedPosition  = 45F;
	public float flipperStrength = 10F;  
	public float flipperDamper = 1F;    //플리퍼 댐퍼 설정
	public string inputButtonName  = "LeftPaddle";
	public JointLimits limits ;     
	public JointSpring spring  = new JointSpring();
	// Use this for initialization
	public void Start ()
	{
		GetComponent<HingeJoint>().useSpring = true;
	}

    // Update is called once per frame
    public void Update ()
	{	
//		
		spring.spring = flipperStrength;        
		spring.damper = flipperDamper;      //플립 버터 설정

		if (Input.GetButton(inputButtonName))   //버튼이 눌렸으면
			spring.targetPosition = pressedPosition;    
		else
			spring.targetPosition = restPosition;


		GetComponent<HingeJoint>().spring = spring;     
		GetComponent<HingeJoint>().useLimits = true;
		limits.min = restPosition;
		limits.max = pressedPosition;
		GetComponent<HingeJoint>().limits = limits;	
	}
}

