using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int atk;

    public enum HitTag
    {
        Player,
        Enemy,
    }
    public HitTag hitTag = new HitTag();

    // Use this for initialization
    void Start()
    {
        if (hitTag == HitTag.Enemy) GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.up) * speed;
        if (hitTag == HitTag.Player) GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.down) * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy") && hitTag == HitTag.Enemy)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.Damage(atk);
        }
        if (collider.CompareTag("Player") && hitTag == HitTag.Player)
        {
            Player player = collider.GetComponent<Player>();
            player.Damage(atk);
        }
    }

}
