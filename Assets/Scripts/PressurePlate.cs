using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {
    [SerializeField]
    bool isActivatableByPlayer = true;

    [SerializeField]
    bool isActivatableByCreature1 = true;

    [SerializeField]
    bool isActivatableByCreature2 = true;

    [SerializeField]
    bool isActivatableByCreature3 = true;

    [SerializeField]
    ShootDart[] dartShooter;

    GameObject presser;

    private bool isPressed = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isActivatableByPlayer == true)
        {
            presser = collision.gameObject;           
            ActivatePlate();

            if (presser == null)
            {
                DeactivatePlate();
            }
        }

        if (collision.tag == "Invulnerable" && isActivatableByCreature1 == true)
        {
            presser = collision.gameObject;
            isPressed = true;
            ActivatePlate();
        }

        if (collision.tag == "Creature2" && isActivatableByCreature2 == true)
        {
            presser = collision.gameObject;
            isPressed = true;
            ActivatePlate();
        }

        if (collision.tag == "Creature3" && isActivatableByCreature3 == true)
        {
            presser = collision.gameObject;
            isPressed = true;
            ActivatePlate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DeactivatePlate();
    }

    private void DeactivatePlate()
    {
        isPressed = false;
    }

    private void ActivatePlate()
    {
        isPressed = true;
        foreach (var shooter in dartShooter)
        {
            shooter.isActivated = false;
        }
        

    }

    private void Update()
    {
        if (isPressed == false)
        {
            foreach (var shooter in dartShooter)
            {
                if (shooter.isActivated == false)
                {
                    shooter.isActivated = true;
                }

            }
        }

        
    }
}
