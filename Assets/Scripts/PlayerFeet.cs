using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeet : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] float stopThreshold;
    [SerializeField] float snapWindow;

    private void OnTriggerStay2D(Collider2D collision)
    {

        Tags T = collision.gameObject.GetComponent<Tags>();
        if (!T.platform)
            return;

        if (playerMove.transform.position.y - collision.transform.position.y > 0 && playerMove.verticalVelocity < 0)
        {
            playerMove.fixedFall = true;
        }
        else
        {
            playerMove.verticalVelocity = Mathf.Max(0, playerMove.verticalVelocity);

            if (playerMove.verticalVelocity == 0)
            {
                playerMove.transform.position = new Vector3(playerMove.transform.position.x, collision.transform.position.y, 0);
                playerMove.grounded = true;
                playerMove.pounding = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Tags T = collision.gameObject.GetComponent<Tags>();

        if (T.platform)
        {
            playerMove.grounded = false;
            playerMove.fixedFall = false;
        }
    }

}
