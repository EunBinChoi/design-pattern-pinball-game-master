using UnityEngine;
using System.Collections;

//간단한 GUI 클래스
public class pinballGUI : MonoBehaviour {

	private GUIStyle scoreSTY = new GUIStyle(); //GUIStyle 객체 생성
	public Ball gameball;   //볼 객체 
	// Use this for initialization
	public void Start () {
		scoreSTY.alignment = TextAnchor.MiddleCenter;   //가운데 정렬
		scoreSTY.fontSize = 20;                         //폰트 크기 20
	}

    // Update is called once per frame
    public void Update () {
	
	}
    public void OnGUI() {
		GUI.color = Color.white;        //흰색
		GUI.TextField (new Rect (10, 10, 150, 20), "Score : " + gameball.score) ;   //게임 스코어 출력
				
	}
}
