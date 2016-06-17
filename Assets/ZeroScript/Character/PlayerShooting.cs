using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    [SerializeField]
    private float interval;
    [SerializeField]
    private GameObject bullet;

	// Use this for initialization
	IEnumerator Start () {
        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, transform.position, transform.rotation);
                yield return new WaitForSeconds(interval);
            }
            yield return null;
        }    
	}
	
}
