using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    // Start is called once before t
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] Transform textContainer;
    [SerializeField] private float duration;

    [SerializeField] private Ease animationCurve;

    private float containerInitPosition;
    private float moveAmount;

    private void Start()
    {
       Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = textContainer.transform.localPosition.y;
        moveAmount = current.rectTransform.rect.height*-1.8f;
    }

     public void UpdateScore(int score)
    {
        Debug.Log($"Updating score to: {score}");
        toUpdate.SetText($"{score}");
        textContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(animationCurve);
        StartCoroutine(ResetCoinContainer(score));
        
    }

    private IEnumerator ResetCoinContainer(int score)
    {
        yield return new WaitForSeconds(duration);
        current.SetText($"{score}");
        Vector3 localPosition = textContainer.localPosition;
        textContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.z);
    }

}
