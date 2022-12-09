using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public Vector2 StartPosition;
    public SpriteRenderer barSpriteRenderer;
    public float MaxLength = 1f;
    public BoxCollider2D BoxCollider;
    public HingeJoint2D StartJoint;
    public HingeJoint2D EndJoint;

    float StartJointCurrentLoad = 0;
    float EndJointCurrentLoad = 0;
    MaterialPropertyBlock propBlock;

    public float Cost = 1;
    public float ActualCost;

    public void UpdateCreatingBar(Vector2 ToPosition)
    {
        transform.position = (ToPosition + StartPosition) / 2;

        Vector2 dir = ToPosition - StartPosition;
        float angle = Vector2.SignedAngle(Vector2.right, dir);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        float Length = dir.magnitude;
        barSpriteRenderer.size = new Vector2(Length, barSpriteRenderer.size.y);

        BoxCollider.size = barSpriteRenderer.size;

        ActualCost = Length * Cost;
    }
    public void UpdateMaterial()
    {
        if (StartJoint != null)
        {
            StartJointCurrentLoad = StartJoint.reactionForce.magnitude / StartJoint.breakForce;
        }
        if (EndJoint != null)
        {
            EndJointCurrentLoad = EndJoint.reactionForce.magnitude / EndJoint.breakForce;
        }

        float maxLoad = Mathf.Max(StartJointCurrentLoad, EndJointCurrentLoad);

        propBlock = new MaterialPropertyBlock();
        barSpriteRenderer.GetPropertyBlock(propBlock);
        propBlock.SetFloat("_Load", maxLoad);
        barSpriteRenderer.SetPropertyBlock(propBlock);
    }  
    
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            UpdateMaterial();
        }
    }
}
