using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Joymg.Platformer2D.Entities
{
    public class AgentRenderer : MonoBehaviour
    {
        public void FaceDirection(Vector2 input)
        {
            Vector3 parentScale = transform.parent.localScale;
            if (input.x < 0f)
            {
                transform.parent.localScale = new Vector3(-1 * Mathf.Abs(parentScale.x), parentScale.y, parentScale.z);
            }
            else if (input.x > 0f)
            {
                transform.parent.localScale = new Vector3(Mathf.Abs(parentScale.x), parentScale.y, parentScale.z);
            }
        }
    }
}