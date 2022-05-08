using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFireBall : MonoBehaviour
{
    private GameObject _player;
    void Start()
    {
        _player = GameObject.Find("wizard_macanim DEMO");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,18f) * Time.deltaTime);
        if (Vector3.Distance(transform.position, _player.transform.position) > 25)
        {
            _player.GetComponentInParent<MovementPlayer>().lanciata = false;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
        // se colpisce il nemico gli toglie della vita
        /*if (other.gameObject.name.Contains("Enemy"))
        {
            _player.GetComponent<PlayerMovement>().lanciata = false;
            other.gameObject.GetComponent<EnemyMovement>().lifePoints -= 20;
            Destroy(gameObject);
        }*/
    }
}
