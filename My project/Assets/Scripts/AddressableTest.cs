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
            testSprite1.sprite = await LoadSprite("AAResources/game_ar_green.png");
            testSprite2.sprite = await LoadSprite("AAResources/rakugaki_graffiti.png");
        }
    }

    private async Task<Sprite> LoadSprite(string address)
    {
        var handle = Addressables.LoadAssetAsync<Sprite>(address);
        await handle.Task;
        return handle.Result;
    }
}
