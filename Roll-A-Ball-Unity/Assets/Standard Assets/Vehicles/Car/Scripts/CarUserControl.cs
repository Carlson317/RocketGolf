using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Car
{

    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
		public float speed;
		public Text countText;
		public Text golfText;
		public Text winText;
		private int count, golfCount;
		void Start(){
			count = 0;
			golfCount = 0;
			//setText ();
			//setGolfText ();
			winText.text = "";

		}
        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
		/*void OnTriggerEnter(Collider other) {
			if (other.gameObject.CompareTag ("PickUp")) {
				other.gameObject.SetActive (false);
				count++;
				if (count >= 10) {
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
			if (c.gameObject.CompareTag("GolfBall")) {
				golfCount++;
				setGolfText ();

			}
		}*/
    }
}
