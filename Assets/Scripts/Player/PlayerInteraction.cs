using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    private BaseInteraction _target;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && _target != null)
        {
            _target.Interact();
        }
    }


    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        BaseInteraction interaction = collider2D.GetComponent<BaseInteraction>();
        if (interaction)
        {
            _target = interaction;
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        _target = null;
    }
}
