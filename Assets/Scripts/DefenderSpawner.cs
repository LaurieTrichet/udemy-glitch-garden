using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private const string Defenders = "Defenders";
    private GameObject defenderPrefab = null;
    [SerializeField] StarDisplay starDisplay = null;
    private GameObject[,] grid = new GameObject[6, 5];

    private GameObject defenderParent = null;

    private void Start()
    {
        defenderParent = GameObject.Find(Defenders);
    }

    public void SetDefenderPrefab(GameObject gameObject)
    {
        defenderPrefab = gameObject;
    }

    public void SpawnDefender(Vector3 position)
    {

        if (defenderPrefab == null) { return; }
        var cost = GetCostForDefender();
        bool isSpaceFree = grid[(int)position.x, (int)position.y] == null;
        if (starDisplay.CanPurchase(cost) && isSpaceFree)
        {
            starDisplay.MakePurchase(cost);
           
            var defenderGameObject = Instantiate(defenderPrefab, position, transform.rotation, defenderParent.transform);
            var defender = defenderGameObject.GetComponent<Defender>();
            defender.Line = Mathf.RoundToInt(position.y)+1;

            grid[(int)position.x, (int)position.y] = defenderGameObject;
        }
    }

    private int GetCostForDefender()
    {
        return defenderPrefab.GetComponent<Defender>().Cost;
    }

}
