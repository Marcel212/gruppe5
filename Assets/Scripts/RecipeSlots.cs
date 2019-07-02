using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeSlots : MonoBehaviour
{

    public CraftingRecipe recipeToShow;

    [SerializeField] public Image _currentImage;
  

    public Item ResultAsItem
    {
        get
        {
            if (recipeToShow == null)
            {
                return null;
            }
            else
            {
                return recipeToShow.Result.item;
            }
        }
    }


    public CraftingRecipe CraftingRecipe
    {
        get { return recipeToShow; }
        set
        {
            recipeToShow = value;
            if (recipeToShow != null)
            {
                _currentImage.sprite = recipeToShow.Result.item.itemPicuture;
            }
            else
            {
                _currentImage.sprite = null;
               

            }
        }
    }
    


    private void OnValidate()
    {
        if (_currentImage == null)
        {
            _currentImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        }

        //Auf Default setzen & alle Eingaben vom Editor prüfen 
        CraftingRecipe = recipeToShow;
      



    }


}
