using UnityEngine;

public class FunnyGPUInstance : MonoBehaviour
{
    [SerializeField]
    private GameObject _instanceGo;
    [SerializeField]
    private int _instanceCount;
    [SerializeField]
    private bool _bRandPos = false;
    
    void Start()
    {
        for (int i = 0; i < _instanceCount; i++)
        {
            GameObject pGO = GameObject.Instantiate<GameObject>(_instanceGo);
            pGO.transform.SetParent(gameObject.transform);
            if (_bRandPos)
            {
                pGO.transform.localPosition = Random.insideUnitSphere * 10.0f;
            }
            else
            {
                Vector3 pos = new Vector3(i * 1.5f, 0, 0);
                pGO.transform.localPosition = pos;
            }
            
            //与buffer交换数据
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();

            //随机每个对象的颜色
            mpb.SetColor("_Color", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1.0f));
            mpb.SetFloat("_Phi", Random.Range(-40f, 40f));

            MeshRenderer meshRenderer = pGO.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.SetPropertyBlock(mpb);
            }
        }
    }
}
