using UnityEngine;
using System.Collections;

public class movingDoor : MonoBehaviour
{

    // Update is called once per frame
    public bool bPassed = false;    //���� ���� ������ ���θ� ����
    public float movingSpeed = 10;  //�� ������ �ӵ� ����
    public float displacement = 7;  //�� ������ �Ÿ� ����
   // public Ball ball;               //�� ��ü
    public float x_threshold = 43;  //x������ ���� ������ �ִ� �Ÿ�
    private Vector3 sPos;           //�ʱ� ���� ��ġ ���� ���� 
    private float sDisplacement;    //�ʱ� ���� ���� ���� ����
    void Start()
    {
        sPos = this.transform.position;     //�ʱ� ���� ��ġ ����
        sDisplacement = displacement;       //�ʱ� ���� ���� ����
    }

    public void Init()
    {
        this.transform.position = sPos;     //�ʱ� ���� ��ġ�� �ʱ�ȭ
        this.bPassed = false;               //���� ���� ������ ���θ� �����ϴ� ������ �ʱ�ȭ 
        this.displacement = sDisplacement;  //�ʱ� ���� ���� ����
    }

    void Update()
    {
        if (Ball.getInstance().transform.position.x < x_threshold)
        {  //���� ��ġ�� �Ӱ�ġ �̳��� ���� ������ Ȯ��.
            Ball.getInstance().bStart = true;         //���� ���� ������ ������ �ʱ�ȭ  
            bPassed = true;             //���� ���� ���ٴ� ������ ����
        }
        if (bPassed)
        {                      //���� �̹����� ���ٸ�
            if (displacement < (movingSpeed * Time.deltaTime))
            {    //Ư�� ��ġ�� �������� ���� ���
                transform.Translate(0, 0, displacement);       //�̵�
                displacement = 0;
                bPassed = false;
            }
            else if (displacement == 0)
            {
                displacement = 0;
                bPassed = false;
            }
            else
            {
                transform.Translate(0, 0, movingSpeed * Time.deltaTime);
                displacement -= movingSpeed * Time.deltaTime;
            }
        }
        //Debug.DrawRay(this.transform.position,this.transform.forward*10, Color.red, 50f,false);
    }

}