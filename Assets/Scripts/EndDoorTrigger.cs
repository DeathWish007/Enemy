using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndDoorTrigger : MonoBehaviour {

    public GameObject hold;
    public LayerMask player;


    private void Awake()
    {
        hold.SetActive(false);
    }
    private void Update()
    {

        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, transform.position, 1f, player);
        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.collider.CompareTag("Player"))
            {
                hold.SetActive(true);
            }
            else
            {
                hold.SetActive(false);
            }
        }
    }



}
