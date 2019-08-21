using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedADog : MonoBehaviour
{
  protected float _timeElapsed;

  void Start()
  {
    Invoke("feedDog", 5);
    Debug.Log("Will feed dog after 5 seconds");
  }

  void feedDog()
  {
    Debug.Log("Now feeding Dog");
  }

  private void Update()
  {
    //_timeElapsed += Time.deltaTime;
    //Debug.Log("time elapsed: " + _timeElapsed);
  }
}
