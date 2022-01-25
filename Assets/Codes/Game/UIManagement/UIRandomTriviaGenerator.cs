using UnityEngine;
using UnityEngine.UI;

namespace Game.UIManagement
{

    ///<summary>
    /// Random trivia generator.
    ///</summary>
    public class UIRandomTriviaGenerator : MonoBehaviour
    {

        public Text txtTrivia = null;

        [TextArea]
        public string[] arrTrivias;

        private void OnEnable()
        {
            RandomizeTrivia();
        }

        public void RandomizeTrivia()
        {

            if (txtTrivia == null)
                return;

            else
            {
                int i = Random.Range(0, arrTrivias.Length);
                print("Random: " + i);
                txtTrivia.text = arrTrivias[i];
            }

        }
        
    }


}