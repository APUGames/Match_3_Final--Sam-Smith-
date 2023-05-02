using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    private Piece piece;

    private void LateUpdate()
    {
        GridController controller = GameObject.Find("GameManager").GetComponent<GridController>();
        if (controller.IsDestroyed(piece.GetGridPosition()))
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("mouse is down");
        Vector2 seedPiece = piece.GetGridPosition();
        Debug.Log("X: " + seedPiece.x + " Y: " + seedPiece.y);

        GridController controller = GameObject.Find("GameManager").GetComponent<GridController>();
        controller.pressedDown = true;
        controller.pressedDownPosition = seedPiece;
        controller.pressedDownGameObject = this.gameObject;
    }

    private void OnMouseUp()
    {
        Debug.Log("mouse is up");
        Vector2 seedPiece = piece.GetGridPosition();
        Debug.Log("X: " + seedPiece.x + " Y: " + seedPiece.y);

        GridController controller = GameObject.Find("GameManager").GetComponent<GridController>();
        controller.pressedDown = false;
        controller.pressedDownPosition = Vector2.zero;
    }

    private void OnMouseOver()
    {
        GridController controller = GameObject.Find("GameManager").GetComponent<GridController>();
        Vector2 seedPiece = piece.GetGridPosition();

        if (controller.pressedDown && (controller.pressedDownPosition != seedPiece))
        {
            Debug.Log("mouse is over");
            // Vector2 seedPiece = piece.GetGridPosition();
            Debug.Log("X: " + seedPiece.x + " Y: " + seedPiece.y);

            controller.pressedDown = false;
            // controller.pressedDownPosition = Vector2.zero;
            controller.pressedUpPosition = seedPiece;
            controller.pressedUpGameObject = this.gameObject;

            controller.ValidMove(controller.pressedDownPosition, seedPiece);

        }
    }

    public void SetPiece(Piece piece)
    {
        this.piece = piece;
    }
}