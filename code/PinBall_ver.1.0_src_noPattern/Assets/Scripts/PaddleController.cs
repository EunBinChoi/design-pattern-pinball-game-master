using UnityEngine;
using System.Collections;

//�¿� �д��� ������ �� �ִ� Ŭ����
public class PaddleController  : MonoBehaviour
{
	public float restPosition = 0F;
	public float pressedPosition  = 45F;
	public float flipperStrength = 10F;  
	public float flipperDamper = 1F;    //�ø��� ���� ����
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
		spring.damper = flipperDamper;      //�ø� ���� ����

		if (Input.GetButton(inputButtonName))   //��ư�� ��������
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

