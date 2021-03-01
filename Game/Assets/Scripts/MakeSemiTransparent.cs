using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
public class MakeSemiTransparent : MonoBehaviour
{
    //private List<GameObject> TransparentObjects = new List<GameObject>();
    private Dictionary<GameObject, Renderer> TransparentObjectRenderers = new Dictionary<GameObject, Renderer>();
    private Transform myCamera;
    private NavMeshAgent PlayerAgent;
    private SkinnedMeshRenderer PlayerRenderer;
    [SerializeField]
    private Material DefaultMaterial;
    [SerializeField]
    private Material OutlineMaterial;
    //[SerializeField]
    //private Shader OutlineShader;
    //[SerializeField]
    //private Shader DefaultShader;
    void ToOpaqueMode(Material material)
    {
        material.SetOverrideTag("RenderType", "");
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        material.SetInt("_ZWrite", 1);
        material.DisableKeyword("_ALPHATEST_ON");
        material.DisableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = -1;
    }
    void ToFadeMode(Material material)
    {
        material.SetOverrideTag("RenderType", "Transparent");
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
    }
    void Start()
    {
        PlayerRenderer= GetComponent<SkinnedMeshRenderer>();
        //DefaultShader = PlayerRenderer.material.shader;
        DefaultMaterial = PlayerRenderer.material;
        PlayerAgent = GetComponentInParent<NavMeshAgent>();
        myCamera = Camera.main.transform;
    }
    void Update()
    {
        Vector3 Target = PlayerAgent.transform.position;
        Ray ray = new Ray(myCamera.position, Target - myCamera.position);
        GameObject HitGameObject = null;
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            HitGameObject = hit.transform.gameObject;
            if (HitGameObject != PlayerAgent.gameObject)
            {
                switch (HitGameObject.layer)
                {
                    case 11:
                        PlayerRenderer.material = OutlineMaterial;
                        break;
                    case 12:
                        if (TransparentObjectRenderers.ContainsKey(HitGameObject))
                            break;
                        TransparentObjectRenderers.Add(HitGameObject, HitGameObject.GetComponent<Renderer>());
                        Color CurrentColor = TransparentObjectRenderers[HitGameObject].material.color;
                        ToFadeMode(TransparentObjectRenderers[HitGameObject].material);
                        CurrentColor.a = 0.5f;
                        TransparentObjectRenderers[HitGameObject].material.color = CurrentColor;
                        break;
                    default:
                        PlayerRenderer.material = DefaultMaterial;
                        break;
                }
            }
            else
                PlayerRenderer.material = DefaultMaterial;
            foreach(var key in TransparentObjectRenderers.Keys)
            {
                if (key != HitGameObject)
                {
                    Color CurrentColor = TransparentObjectRenderers[key].material.color;
                    ToOpaqueMode(TransparentObjectRenderers[key].material);
                    TransparentObjectRenderers[key].material.color = CurrentColor;
                }
            }
            TransparentObjectRenderers = TransparentObjectRenderers.Where(x => x.Key == HitGameObject).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
