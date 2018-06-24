using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluttonyPatrol : MonoBehaviour {

		public float speed = 1;
		public float time = 1;
		public float distance = 1;

		private bool movingRight = true;

		public Transform groundDetection;

		void Update(){
			transform.Translate(Vector2.right * speed * time.);
			
			RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance = 1);
			if(groundInfo.collider == false){
				if(movingRight == true){
						transform.eulerAngles = new Vector3(0,-180,0);
						movingRight = false;
				} else {
						transform.eulerAngles = new Vector3(0,0,0);
						movingRight = true;
				}
			}
		}
		}
