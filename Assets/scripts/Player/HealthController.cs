using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	// Use this for initialization
    Animator anim;
    GameObject player, hitbox;
    GameController gameController;
	void Start () {
	 anim = GetComponent<Animator>();
     
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void ReduceHealth ()
    {
        int h = anim.GetInteger("Health");
        h = h -1;
        anim.SetInteger("Health",h);
        Debug.Log(h);
        if (h == 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        player = GameObject.Find("Player");
        hitbox = GameObject.Find("hitbox");
        Destroy(player.GetComponent<CircleCollider2D>());
        Destroy(player.GetComponent<SpriteRenderer>());
        Destroy(hitbox.GetComponent<SpriteRenderer>());
        gameController = GameObject.Find("_GameController").GetComponent<GameController>();
        gameController.GameEnd();
    }
}
