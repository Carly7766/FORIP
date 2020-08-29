using UnityEngine;

public class FloatingObjectJointConnector : MonoBehaviour
{
	private FixedJoint2D fixedJoint;

	private void Awake()
	{
		fixedJoint = GetComponent<FixedJoint2D>();
	}

	public void Connect(Rigidbody2D playerRigidbody)
	{
		fixedJoint.connectedBody = playerRigidbody;
	}

	public void DeConnect()
	{
		fixedJoint.connectedBody = null;
	}
}