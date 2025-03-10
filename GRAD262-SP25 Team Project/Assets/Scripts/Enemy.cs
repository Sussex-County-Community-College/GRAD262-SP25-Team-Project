﻿using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using UnityEngine;

namespace SCCC
{
    public class Enemy : Character
    {
        public int damageStrength;

        Coroutine damageCoroutine;

        float hitPoints;

        private void OnEnable()
        {
            ResetCharacter();
        }

        public override void ResetCharacter()
        {
            hitPoints = startingHitPoints;
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        public override IEnumerator DamageCharacter(int damage, float interval)
        {
            while (true)
            {
                StartCoroutine(FlickerCharacter());

                hitPoints = hitPoints - damage;

                if (hitPoints <= float.Epsilon)
                {
                    KillCharacter();
                    break;
                }

                if (interval > float.Epsilon)
                {
                    yield return new WaitForSeconds(interval);
                }
                else
                {
                    break;
                }
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            // Because only enemies can only hurt the player
            if (collision.gameObject.CompareTag("Player"))
            {
                Actionable actionable = collision.gameObject.GetComponent<Actionable>();
                if (actionable)
                    actionable.DoAction();
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (damageCoroutine != null)
                {
                    StopCoroutine(damageCoroutine);
                    damageCoroutine = null;
                }
            }
        }
    }
}
