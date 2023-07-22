using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(PositionFollower))]
public class ViewBobbing : NetworkBehaviour
{
    public float EffectIntensify;
    public float EffectIntensifyX;
    public float EffectSpeed;

    private PositionFollower FollowerInstance;
    private Vector3 OriginalOffset;
    private float SinTime;
    void Start()
    {
        FollowerInstance = GetComponent<PositionFollower>();
        OriginalOffset = FollowerInstance.Offset;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
        if (inputVector.magnitude > 0f)
        {
            SinTime += Time.deltaTime * EffectSpeed;
        }
        else
        {
            SinTime = 0f;
        }
        float sinAmountY = -Mathf.Abs(EffectIntensify * Mathf.Sin(SinTime));
        Vector3 sinAmountX = FollowerInstance.transform.right * EffectIntensify * Mathf.Cos(SinTime) * EffectIntensifyX;

        FollowerInstance.Offset = new Vector3
        {
            x = OriginalOffset.x,
            y = OriginalOffset.y + sinAmountY,
            z = OriginalOffset.z
        };

        FollowerInstance.Offset += sinAmountX;
        Debug.Log(sinAmountY);
        Debug.Log(sinAmountX);
    }
}
