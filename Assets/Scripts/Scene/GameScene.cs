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
        // �߰����� ������ �غ��� �ε��� �����ϰ� �Ѿ����
        progress = 0.2f;
        Debug.Log("���� �۸� ¢���ϴ�");
        player.transform.position = startPoint.position;
        yield return new WaitForSecondsRealtime(1f);
        progress = 0.6f;
        Debug.Log("����̰� �۸� ¢���ϴ�");
        yield return new WaitForSecondsRealtime(1f);
        progress = 1.0f;
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
