using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatObject : MonoBehaviour
{
  public float divisor = 1f;
  public string range_start;
  public string range_stop;
  public bool active;
  private List<float> starts = new List<float>();
  private List<float> stops = new List<float>();
  private gameLevel level;
  public float rate { get; private set; }

  void Start() {
    level = GameObject.FindGameObjectWithTag("Level").GetComponent<gameLevel>();
    rate = (60 * level.BPM) * divisor;
    float pushu;
    foreach (string str in range_start.Split(new [] { "; ", " ", ";" }, System.StringSplitOptions.RemoveEmptyEntries)) {
      float.TryParse(str, out pushu);
      starts.Add(pushu);
    }
    foreach (string str in range_stop.Split(new [] { "; ", " " }, System.StringSplitOptions.RemoveEmptyEntries)) {
      float.TryParse(str, out pushu);
      stops.Add(pushu);
    }
  }

  void Update() {
    if (starts.Count != 0 && !active && level.Beat > starts[0]) {
      Debug.Log(gameObject.name + " Activate ! // Beat : " + level.Beat + " // Trigger : " + starts[0]);
      starts.RemoveAt(0);
      active = true;
    }
    if (stops.Count != 0 && active && level.Beat > stops[0]) {
      Debug.Log(gameObject.name + " Deactivate ! // Beat : " + level.Beat + " // Trigger : " + stops[0]);
      stops.RemoveAt(0);
      active = false;
    }
  }
}
