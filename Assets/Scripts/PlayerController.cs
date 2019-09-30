using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;

	private Animator anim;
	private Rigidbody2D myRigidbody;


	private bool playerMoving;
	private Vector2 lastMove;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		playerMoving = false; // 玩家一開始都沒動

		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f ) 
		{ // 控制玩家左右
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f)); 
			myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal")* moveSpeed , myRigidbody.velocity.y);

			playerMoving = true; // 玩家正在動
			lastMove = new Vector2( Input.GetAxisRaw("Horizontal"), 0f);
		}

		if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f ) 
		{ // 控制玩家上下
			//transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x , Input.GetAxisRaw("Vertical")* moveSpeed);

			playerMoving = true; // 玩家正在動
			lastMove = new Vector2( 0f, Input.GetAxisRaw("Vertical"));
		}

		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) 
		{
			myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
		}
		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) 
		{
			myRigidbody.velocity = new Vector2 ( myRigidbody.velocity.x, 0f);
		}


		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal")); // 介面中 MoveX 對應到 這裡的 Horizontal
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));   // 介面中 MoveY 對應到 這裡的 Vertical
		anim.SetBool ("PlayerMoving", playerMoving); // 介面中 PlayerMoving 對應到 這裡的 playerMoving
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}
}
