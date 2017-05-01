using UnityEngine;
using UnityEngine.UI;

public class Connect_MainVue : MonoBehaviour
{
    public Text titre;
    public Text description;
    public bool asSomethingShow;

    private Coroutine routineTitre;
    private Coroutine routineDescription;


    public void hideAll()
    {
        titre.color = new Color(titre.color.r, titre.color.g, titre.color.b, 0);
        description.color = new Color(description.color.r, description.color.g, description.color.b, 0);
    }

    public void showInformation(Model_CadreInfo info)
    {
        asSomethingShow = true;
        StopAllCoroutines();

        


        routineTitre = StartCoroutine(Fading.FadeTextToFullAlpha(1f,titre));
        titre.text = info.titre;

        routineDescription = StartCoroutine(Fading.FadeTextToFullAlpha(1f, description));
        description.text = info.description ;
        
    }


    public void hideInformation()
    {
        asSomethingShow = false;

        StoppingInnerCoroutine();

        routineTitre = StartCoroutine(Fading.FadeTextToZeroAlpha(1f, titre));
        routineDescription = StartCoroutine(Fading.FadeTextToZeroAlpha(1f, description));
       
    }

    private void StoppingInnerCoroutine()
    {
        if (routineTitre != null && routineDescription != null)
        {
            StopCoroutine(routineTitre);
            StopCoroutine(routineDescription);
        }
    }

}
