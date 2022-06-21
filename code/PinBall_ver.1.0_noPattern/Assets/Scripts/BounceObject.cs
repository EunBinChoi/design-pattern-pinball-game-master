using UnityEngine;
using System.Collections;

//�ٿ�� ������ ������Ʈ�� ���� Ŭ����
public class BounceObject : MonoBehaviour
{
    public float explosionStrength = 100;   //���� ���� 100
    public Vector3 outVect;                 //�ƿ� ����
    public Vector3 expolsionVect;           //���� ����

    public void OnCollisionEnter(Collision collision)  //�浹 �ȴٸ�
    {
        foreach (ContactPoint contact in collision.contacts)    //������ ã�Ƽ�
        {

            Debug.DrawRay(contact.point, contact.normal, Color.red, 50.0f, false);
            outVect = Vector3.Reflect(contact.point, Vector3.right);    //������ ���
            expolsionVect = contact.point;      //���� ���� ����
        }

        collision.rigidbody.AddExplosionForce(explosionStrength, this.transform.position, 100); //���� ����

    }
    public void Start()
    {}
}
