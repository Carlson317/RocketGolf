using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {
	public Text countText;
	public Text golfText;
	public Text winText;
	private int count, golfCount;
	// Use this for initialization
	void Start () {
		count = 0;
		golfCount = 0;
		setText ();
		setGolfText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			count++;
			if (count >= 1) {
				winText.text = "YOU WIN!!!!!";
			}
			setText ();
		} 
	}
	void setText(){
		countText.text = "Count: " + count.ToString();	
	}
	void setGolfText(){
		golfText.text = "Count: " + golfCount.ToString();	
	}
	void OnCollisionEnter(Collision c){
		if (c.gameObject.CompareTag("Player")) {
			golfCount++;
			setGolfText ();

		}
	}
}
