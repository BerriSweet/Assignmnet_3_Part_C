using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TinderBayUnitTests
{
    /// <summary>
    /// handles all the methods related to searching for a product
    /// </summary>

    // This code was written by Ben Griffin, I (Danny Marshall) am just using it to preform unit tests for out app "TinderBay" and for my Part C of Assignment for Dynamic Data Structures
    public class Search
    {
        //Check if no item (Ben.G)
        bool IsItem = true;
        //Index for looping through items (Ben. G)
        int ProductIndex = 0;
        //Tag for searching (Ben.G)
        string selectedTag;
        public bool matchesTag;
        public bool searchFailed;
        public string searchedWord = "";

        public void UpdateToProduct()
        {
            //_productNameView.Text = APIClass.ProductArray[ProductIndex].Name;
            // _textView.Text = String.Format("${0}", APIClass.ProductArray[ProductIndex].Price.ToString("F"));
        }

        //Changes the layout to show that you have run out of new items to look at(Ben.G)
        public void UpdateToBlank()
        {
            // _productNameView.Text = "Run out of items";
            // _textView.Text = "N/A";
            IsItem = false;
        }
        /// <summary>
        /// Accesses the GetProductsAsync method from the API Class and runs it
        /// Creates a new List
        /// </summary>
        public async Task getProducts()
        {
            await APIClass.GetProductsAsync();
            APIClass.SelectedTagsList = new List<String>();
        }

        /// <summary>
        /// Adds new items to the list
        /// </summary>
        public void AddTags()
        {
            APIClass.SelectedTagsList.Add("Book");
            APIClass.SelectedTagsList.Add("Plants");
        }
        /// <summary>
        /// checks to see if the tags and the searched word exists in the database 
        /// </summary>
        public void CheckTag()
        {
            //await getProducts();
            matchesTag = false;
            //Select next item in array, loop back to 0 if it runs out of items 
            while (matchesTag == false)
            {
                //If all the items have been scene display a message showing youve run out of items
                if (ProductIndex >= APIClass.ProductArray.Length)
                {
                    UpdateToBlank();
                    matchesTag = true;
                    searchFailed = true;
                }
                //If theres no tag and no searched word then display the item
                else if (APIClass.SelectedTagsList.Count == 0 && (searchedWord == "" || searchedWord == "None"))
                {
                    UpdateToProduct();
                    matchesTag = true;
                }
                else
                {
                    //Check the tag against each tag in the tags list and if it matches display it
                    foreach (string tag in APIClass.SelectedTagsList)
                    {
                        if (tag == APIClass.ProductArray[ProductIndex].Tag)
                        {
                            matchesTag = true;
                        }
                    }

                    if (APIClass.ProductArray[ProductIndex].Name.ToUpper().Contains(searchedWord.ToUpper()) && searchedWord != "")
                    {
                        matchesTag = true;
                    }

                    if (matchesTag)
                    {
                        UpdateToProduct();
                    }
                }
                ProductIndex++;
            }
        }
    }
}
