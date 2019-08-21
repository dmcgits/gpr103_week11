using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveManager : MonoBehaviour
{
  // Use color.adobe.com to come up with a nice triad screen, 
  // drop hex values into inspector
  public List<Color32> colors;

  private List<Wave> _level1;

  private List<AppearingSquare> _squares;

  void Start()
  {
    SetupWaves();                     // Go configure the waves that will appear
    _squares = GetComponentsInChildren<AppearingSquare>().ToList<AppearingSquare>();
    DisappearSquares(_squares);       // Hide the squares on screen
    
    StartCoroutine(DeployWaves());    // Deploy all the waves, including pauses for each wave.delay
  }

  private IEnumerator DeployWaves()
  {
    foreach (Wave wave in _level1)
    {
      yield return new WaitForSeconds(wave.delay);  // pause for the delay specified by current wave
      DisappearSquares(_squares);

      foreach (AppearingSquare square in _squares) // set color of squares in wave
      {
        foreach (LaneId lane in wave.lanes)
        {
          if (square.Lane == lane) // If this square is in a lane allowed in this wave, have it appear
          {
            square.SetColor(wave.squareColor);
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
    _level1 = new List<Wave>()  
    {                           // This is instantiating a new list  using { item1, item2, item2 }, they're just long calls to Wave constructor
      new Wave(0.5f, colors[0], lanes: new List<LaneId>() { LaneId.LANE_2, LaneId.LANE_4, LaneId.LANE_5 } ),
      new Wave(1.0f, colors[1], lanes: new List<LaneId>() { LaneId.LANE_1, LaneId.LANE_3, LaneId.LANE_6 } ),
      new Wave(1.5f, colors[2], lanes: new List<LaneId>() { LaneId.LANE_1, LaneId.LANE_2, LaneId.LANE_4, LaneId.LANE_5, LaneId.LANE_6 }),
      new Wave(0.7f, colors[3], lanes: new List<LaneId>() { LaneId.LANE_2, LaneId.LANE_3, LaneId.LANE_4, LaneId.LANE_5 } )
    };
  }
}

