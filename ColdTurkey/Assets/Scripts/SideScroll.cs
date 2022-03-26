using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScroll : MonoBehaviour
{
    public float speed = 3;
    public float incrementDelay = 10;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(IncrementSpeed());
        //_center = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        var rightMove = (Vector3)transform.position + Vector3.right * speed * Time.deltaTime;
        transform.position = rightMove;

        //if (circleMove)
        //{
        //    angle += rotateSpeed * Time.deltaTime;

        //    var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        //    transform.position = _center + offset + leftMove;

        //}
    }

    IEnumerator IncrementSpeed()
    {
        while(true)
        {
            yield return new WaitForSeconds(incrementDelay);
            speed++;
        }
    }
}
