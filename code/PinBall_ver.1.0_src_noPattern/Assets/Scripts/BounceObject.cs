using UnityEngine;
using System.Collections;

//바운스를 만들어내는 오브젝트를 위한 클래스
public class BounceObject : MonoBehaviour
{
    public float explosionStrength = 100;   //폭발 강도 100
    public Vector3 outVect;                 //아웃 벡터
    public Vector3 expolsionVect;           //폭발 벡터

    public void OnCollisionEnter(Collision collision)  //충돌 된다면
    {
        foreach (ContactPoint contact in collision.contacts)    //접점을 찾아서
        {

            Debug.DrawRay(contact.point, contact.normal, Color.red, 50.0f, false);
            outVect = Vector3.Reflect(contact.point, Vector3.right);    //굴절각 계산
            expolsionVect = contact.point;      //폭발 벡터 설정
        }

        collision.rigidbody.AddExplosionForce(explosionStrength, this.transform.position, 100); //폭발 수행

    }
    public void Start()
    {}
}
