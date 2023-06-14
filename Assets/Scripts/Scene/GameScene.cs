using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameScene : BaseScene
{
    public GameObject player;
    public Transform startPoint;

    protected override IEnumerator LoadingRoutine()
    {
        // 추가적인 씬에서 준비할 로딩을 진행하고 넘어가야함
        progress = 0.2f;
        Debug.Log("개가 멍멍 짖습니다");
        player.transform.position = startPoint.position;
        yield return new WaitForSecondsRealtime(1f);
        progress = 0.6f;
        Debug.Log("고양이가 멍멍 짖습니다");
        yield return new WaitForSecondsRealtime(1f);
        progress = 1.0f;
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
