using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableTest : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer testSprite1;

    [SerializeField]
    private SpriteRenderer testSprite2;

    private async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            testSprite1.sprite = await LoadSprite("game_ar_green");
            testSprite2.sprite = await LoadSprite("rakugaki_graffiti");
        }
    }

    private async Task<Sprite> LoadSprite(string address)
    {
        var handle = Addressables.LoadAssetAsync<Sprite>(address);
        await handle.Task;
        return handle.Result;
    }
}
