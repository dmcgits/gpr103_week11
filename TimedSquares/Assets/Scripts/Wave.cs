using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
  public float delay;
  public Color squareColor = Color.black;
  public List<LaneId> lanes;

  public Wave( float delay, Color squareColor, List<LaneId> lanes )
  {
    this.delay = delay;
    this.squareColor = squareColor;
    this.lanes = lanes;
  }
}
