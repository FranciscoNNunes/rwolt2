using UnityEngine;

public class AnimationEventBridge : MonoBehaviour
{
    private playerLogic player;

    void Start()
    {
        player = GetComponentInParent<playerLogic>();
    }
    public void InstanciarNoUltimoFrame()
    {
        if (player != null)
        {
            player.InstanciarNoUltimoFrame();
        }
    }
}
