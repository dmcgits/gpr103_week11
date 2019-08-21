using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AppearingSquare : MonoBehaviour
{
  [SerializeField]
  private LaneId _lane = LaneId.LANE_1;

  private SpriteRenderer _spriteRenderer;
  
  void Awake()
  {
    _spriteRenderer = GetComponent<SpriteRenderer>();
  }

  public void SetColor(Color32 color)
  {
    _spriteRenderer.color = color;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void Appear()
  {
    transform.position.Set( transform.position.x, 6.0f, 0.0f);
    Debug.Log("Trying to appear in lane " + (int)Lane);
    _spriteRenderer.enabled = true;
    transform.DOMoveY(6.0f, 0.2f).From();
  }

  public void Disappear()
  {
    _spriteRenderer.enabled = false;
  }

  public LaneId Lane
  {
    get { return _lane; }
  }
}
