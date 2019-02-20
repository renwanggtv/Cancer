using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{

    public float force = 300.0f;

    public int direction;

    public float maxSpeed = 10.0f;

    private Rigidbody2D rig;

    private float time = 0.0f;

    private float minSize = 10.0f;

    private float maxSize = 300.0f;

    private float foodSize = 5.0f;

	public ETCJoystick joystick;
    
	private Vector3 cameraMinOffset = new Vector3(0, 0, -6);

	private Vector3 cameraMaxOffset = new Vector3(0, 0, -15);

	private Vector3 cameraOffset = new Vector3(0, 0, -6);

	private PlayerInfo playerInfo;

	// Use this for initialization
	void Start ()
	{
	    transform.localScale = new Vector3(minSize, minSize, 1);

        rig = GetComponent<Rigidbody2D>();
		playerInfo = GetComponent<PlayerInfo>();
		joystick.followOffset = cameraMinOffset;

	}

	private void OnEnable()
	{
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
	    //time += 0.02f;
	    //if (time > 0.2f)
	    //{
	    //    time = 0.0f;
	    //    CheckInput();
     //   }
	    //CheckInput();
    }

      
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "food")
        {
			//Destroy(collision.gameObject);
			//GetBigger();

			////GetComponent<Rigidbody>().AddExplosionForce(500, transform.position, 10);
			//GetComponent<Rigidbody2D>().velocity = ((transform.position - collision.transform.position).normalized * 10);
			//Collider[] colliders = Physics.OverlapSphere(transform.position, 100);
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "food")
		{
            Vector2 pos = collision.transform.position;
			Vector2 m_forceHit = new Vector2(pos.normalized.x, pos.normalized.y);
			//collision.transform.GetComponent<Rigidbody2D>().AddForce(m_forceHit, ForceMode2D.Impulse);
            transform.GetComponent<Rigidbody2D>().AddForce(m_forceHit * -1, ForceMode2D.Impulse);
            
			FoodInfo info = collision.transform.GetComponent<FoodInfo>();
			info.Attacked();
			playerInfo.Attacked();
			//if (info.GetBlood() <= 0)
			//{
				Destroy(collision.gameObject);
				GetBigger();
			//}
			RefreshBloodBar();
		}
	}

    private void Dead()
	{
		
	}

    private void RefreshBloodBar()
	{
		float ratio = playerInfo.GetBloodRatio();
		GameObject.Find("Slider").transform.GetComponent<Slider>().value = ratio;
	}


	private void GetBigger()
    {
        transform.localScale += new Vector3(foodSize, foodSize, 0);
        if (transform.localScale.x > maxSize)
        {
            transform.localScale = new Vector3(maxSize, maxSize, 1);
        }

		Vector2 currentSize = transform.GetComponent<RectTransform>().sizeDelta;
		currentSize -= new Vector2(0.5f, 0.5f);
		if (currentSize.x < 1f) 
		{
			currentSize = new Vector2(1f, 1f);
		}
		transform.GetComponent<RectTransform>().sizeDelta = currentSize;

		joystick.followOffset -= new Vector3(0, 0, 1);
		if (joystick.followOffset.z < cameraMaxOffset.z)
		{
			joystick.followOffset = cameraMaxOffset;
		}
  
    }



}

