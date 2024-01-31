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

            // DLC Information は DLC 購入してるかどうかに関わらずゲームに組み込んでおく
            // → これをひとまずロード
            var info = await LoadDlcInformation("DlcResources1/DlcInformation.json");
            // 中身の enabled はデフォルトで false に設定されている
            // → DLC 購入者には enabled: true になっている bundle を提供する
            if (info.enabled)
            {
                // DLC 購入者だけが使えるリソースをロード
                testSprite1.sprite = await LoadSprite(
                    "DlcResources1/syougatsu_hatsuhinode_2024.png"
                );
            }
        }
    }

    private async Task<Sprite> LoadSprite(string address)
    {
        var handle = Addressables.LoadAssetAsync<Sprite>(address);
        await handle.Task;
        return handle.Result;
    }

    private async Task<DlcInformation> LoadDlcInformation(string address)
    {
        var handle = Addressables.LoadAssetAsync<TextAsset>(address);
        await handle.Task;
        return JsonUtility.FromJson<DlcInformation>(handle.Result.ToString());
    }
}

public class DlcInformation
{
    public string version;
    public bool enabled;
}
