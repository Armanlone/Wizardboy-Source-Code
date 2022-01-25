using UnityEngine;

///<summary> Follows the target. </summary>

public class Follower : MonoBehaviour
{
    
    [Tooltip("Transform of the target to follow.")]
    [SerializeField]
    private Transform followTargetTransform = null;

    private void LateUpdate()
    {

        if (followTargetTransform == null)
        {
            return;
        }
        
        transform.position = followTargetTransform.position;

    }

}
