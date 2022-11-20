using UnityEngine;
using TMPro;

namespace VRTX
{
    public class TestingGraphQL : MonoBehaviour
    {
        public TextMeshProUGUI log;

        private StrawberryShakeImplementation strawberryShake = null;

        public void InitGrapQL()
        {
            strawberryShake = new StrawberryShakeImplementation();
            var result = strawberryShake.Init();
            AddToLog(result);
        }

        public void ResetGraphQL()
        {
            strawberryShake.Reset();
            AddToLog("ResetGraphQL");
        }

        public async void RunGrapQLQuery()
        {
            var result = await strawberryShake.RunQuery();
            AddToLog(result);
        }

        public void AddToLog(string value)
        {
            Debug.Log(value);
        }

        public void ClearLog()
        {
            log.text = "";
        }
    }
}