using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private int atk;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
	}

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.Damage(atk);
        }
    }

}
