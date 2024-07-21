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
        if (T == null || !T.platform)
            return;

        if (playerMove.transform.position.y - collision.transform.position.y > 0 && playerMove.verticalVelocity < 0)
        {
            playerMove.fixedFall = true;
        }
        else
        {
            playerMove.verticalVelocity = Mathf.Max(0, playerMove.verticalVelocity);

            if (playerMove.verticalVelocity > 0)
                return;

            playerMove.transform.position = new Vector3(playerMove.transform.position.x, collision.transform.position.y, 0);
            playerMove.grounded = true;
            playerMove.pounding = false;

            PanTrigger P = collision.gameObject.GetComponent<PanTrigger>();
            if (P == null)
                return;

            P.Activate();
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
