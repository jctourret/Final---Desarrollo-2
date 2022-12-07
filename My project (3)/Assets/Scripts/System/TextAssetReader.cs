using UnityEngine;
using TMPro;
namespace TankGame
{
    public class TextAssetReader : MonoBehaviour
    {
        TextMeshProUGUI textMesh;
        [SerializeField] TextAsset asset;
        // Start is called before the first frame update
        void Start()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
            textMesh.text = asset.text;
        }

    }
}