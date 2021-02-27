using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorLayers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Projector ThisProjector = GetComponent<Projector>();
        ThisProjector.ignoreLayers = (1 << 9) | (1 << 10);
    }

}
