using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveManager : MonoBehaviour
{
  // Use color.adobe.com to come up with a nice triad screen, 
  // drop hex values into inspector
  public List<Color32> colors;

  private List<Wave> _waves;
  private List<AppearingSquare> _squares;

  void Start()
  {
    SetupWaves();
    _squares = GetComponentsInChildren<AppearingSquare>().ToList<AppearingSquare>();

    DisappearSquares(_squares);

    StartCoroutine(DeployWaves());
  }

  private IEnumerator DeployWaves()
  {
    foreach (Wave wave in _waves)
    {
      // pause for the delay specified by current wave
      yield return new WaitForSeconds(wave.delay);
      DisappearSquares(_squares);

      // set color of squares in wave
      foreach (AppearingSquare square in _squares)
      {
        square.SetColor(wave.squareColor);
        foreach (LaneId lane in wave.lanes)
        {
          if (square.Lane == lane)
          {
            //Debug.Log("Showing square in " + (int)lane);
            square.Appear();
          }
        }
      }
    }
  }

  // Update is called once per frame
  void Update()
  {

  }

  void DisappearSquares( List<AppearingSquare> squares)
  {
    foreach (var square in squares)  // var is set to AppearingSquare automatically because _squares is a collection of them.
    {
      square.Disappear();
    }
  }

  void SetupWaves()
  {
    // Initialising collections with { } notation:
    // When  you create a vector like new List<int>() you can fill it with initial items by following it with { 1, 2, 8, 3 };
    _waves = new List<Wave>();
    _waves.Add(new Wave(0.5f, colors[0], new List<LaneId>() { LaneId.LANE_2, LaneId.LANE_4, LaneId.LANE_5 } ));
    _waves.Add(new Wave(1.5f, colors[1], new List<LaneId>() { LaneId.LANE_1, LaneId.LANE_3, LaneId.LANE_6 }));
    _waves.Add(new Wave(1.8f, colors[2], new List<LaneId>() { LaneId.LANE_1, LaneId.LANE_2, LaneId.LANE_4, LaneId.LANE_5, LaneId.LANE_6 }));
    _waves.Add(new Wave(1.2f, colors[3], new List<LaneId>() { LaneId.LANE_2, LaneId.LANE_3, LaneId.LANE_4, LaneId.LANE_5 }));
  }
}

