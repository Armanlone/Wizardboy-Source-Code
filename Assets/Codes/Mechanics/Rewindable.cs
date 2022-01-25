using System.Collections.Generic;
using UnityEngine;
using Game;
using Platformer2DMechanics.CharacterControl;

public class Rewindable : MonoBehaviour
{

    [SerializeField]
    private KeyCode rewindKey = KeyCode.Z;

    [SerializeField]
    private Movement movement = null;

    [SerializeField]
    private PlayableCharacter playableCharacter = null;

    private bool isRewind = false;

    private List<Vector3> positions;

    private Vector3 storedPrevPosition = Vector3.zero;
    
    //decimalPoint

    private void Start()
    {
        positions = new List<Vector3>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(rewindKey))
        {
            StartRewind();
        }

        if (Input.GetKeyUp(rewindKey))
        {
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if (isRewind)
            Rewind();

        else
            Record();
    }

    private void Rewind()
    {
        if (positions.Count > 0)
        {

            //Disabling the Platformer2D and Moveable script.
            movement.enabled = false;
            playableCharacter.enabled = false;

            //Lerp between point a (its recorded position) and point b (its current position) at 0.1 seconds.
            transform.position = Vector3.Lerp(positions[0], transform.position, 0.1f);
            positions.RemoveAt(0);

        }

        else
        {
            StopRewind();
        }
    }

    private void Record()
    {

        //Enabling the Platformer2D and Moveable script.
        if (!movement.enabled)
            movement.enabled = true;
        
        if (!playableCharacter.enabled)
            playableCharacter.enabled = true;

        //if (storedPrevPosition == transform.position || storedPrevPosition == new Vector3(transform.position.x, transform.position.y + 1, transform.position.z))
            //return;

        if (Mathf.Round(storedPrevPosition.y * 10) * 0.1f == Mathf.Round(transform.position.y * 10) * 0.1f)
            return;

        else
        {
            positions.Insert(0, transform.position);
            storedPrevPosition = transform.position;
        }
        
    }

    private void StartRewind() => isRewind = true;

    private void StopRewind() => isRewind = false;

}

/*

OLD SCRIPT FOR REWIND:

using System.Collections.Generic;
using UnityEngine;
using Game;
using Game.ControlsManagement;
using Platformer2DMechanics.CharacterControl;

public class Rewindable : MonoBehaviour
{

    [SerializeField]
    private KeyCode rewindKey = KeyCode.Z;

    [SerializeField]
    private Movement movement = null;

    [SerializeField]
    private PlayableCharacter playableCharacter = null;

    private bool isRewind = false;

    private List<Vector3> positions;

    private Vector3 storedCurrentPosition = Vector3.zero; 

    private void Start()
    {
        positions = new List<Vector3>();

        for (byte i = 0; i < positions.Count; i++)
        {
            positions[i] = Vector3.zero;
        }
    }

    private void Update()
    {

        if (GameManager.getIsGamePause())
            return;

        if (ControllerManager.getKeyDown(rewindKey))
        {
            StartRewind();
        }

        if (ControllerManager.getKeyUp(rewindKey))
        {
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if (isRewind)
            Rewind();

        else
            Record();
    }

    private void Rewind()
    {
        if (positions.Count > 0)
        {

            //Disabling the Platformer2D and Moveable script.
            movement.enabled = false;
            playableCharacter.enabled = false;

            //Lerp between point a (its recorded position) and point b (its current position) at 0.1 seconds.
            transform.position = Vector3.Lerp(positions[0], transform.position, 0.1f);
            Debug.Log("Rewinded Position: " + transform.position);
            positions.RemoveAt(0);

        }

        else
        {
            StopRewind();
        }
    }

    private void Record()
    {

        //Enabling the Platformer2D and Moveable script.
        movement.enabled = true;
        playableCharacter.enabled = true;

        positions.Insert(0, transform.position);
        Debug.Log("Recorded Position: " + positions[0]);

        if (storedCurrentPosition !=  transform.position || storedCurrentPosition.y == transform.position.y)
        {
            
        }
        
    }

    private void StartRewind() => isRewind = true;

    private void StopRewind() => isRewind = false;

}

*/