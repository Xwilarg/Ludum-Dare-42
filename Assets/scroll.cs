using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour {

    [SerializeField]
    float speed;
    [SerializeField]
    StarManager starManager;
    SpriteRenderer spriteR;

    private void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        resize();
        setSprite();
        setSpeed();
    }

    void Update () {
		if (transform.position.x < -10)
        {
            repop();
            resize();
            setSprite();
            setSpeed();
        }
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, 1);
	}

    void repop()
    {
        transform.position = new Vector3(Random.Range(10f, 12f), Random.Range(-4.8f, 4.8f), 1);
    }

    void resize()
    {
        var size = Random.Range(0.05f, 0.5f);
        transform.localScale = new Vector3(size, size, 1);
    }

    void setSprite()
    {
        spriteR.sprite = starManager.stars[Random.Range(0, starManager.stars.Length - 1)];
    }

    void setSpeed()
    {
        speed = Random.Range(0.05f, 0.6f);
    }
}