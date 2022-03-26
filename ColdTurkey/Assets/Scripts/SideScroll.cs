using System.Collections;
using UnityEngine;

public class SideScroll : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] float speed = 3;
    [SerializeField] float incrementDelay = 10;

    //---------------------------//
    void Start()
    //---------------------------//
    {
        StartCoroutine(IIncrementSpeed());

    }//END Start

    //---------------------------//
    void Update()
    //---------------------------//
    {
        Vector3 rightMove = (Vector3)transform.position + Vector3.right * speed * Time.deltaTime;
        transform.position = rightMove;

    }//END Update

    //---------------------------//
    IEnumerator IIncrementSpeed()
    //---------------------------//
    {
        while (true)
        {
            yield return new WaitForSeconds(incrementDelay);
            speed++;
        }

    }//END IIncrement Speed

}//END CLASS SideScroll
