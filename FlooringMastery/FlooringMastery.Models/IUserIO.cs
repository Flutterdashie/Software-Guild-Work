using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public interface IUserIO
    {
        void WriteLine(string line);
        void Write(string value);

        /// <summary>
        /// Displays the main menu and gets the user's choice
        /// </summary>
        /// <returns>Menu option chosen</returns>
        MenuChoice GetMenuChoice();

        /// <summary>
        /// Displays the given list of products and forces the user to choose one
        /// </summary>
        /// <param name="products">List of available products</param>
        /// <returns>The chosen product</returns>
        Product PickProduct(IEnumerable<Product> products);

        /// <summary>
        /// Prompts the user to enter a decimal area
        /// </summary>
        /// <param name="prompt">Displayed message</param>
        /// <returns>Decimal obtained</returns>
        decimal GetArea(string prompt);

        /// <summary>
        /// Prompts the user for a date and locks them in until input is valid.
        /// </summary>
        /// <param name="prompt">String to display to the user</param>
        /// <returns>Date from user</returns>
        DateTime GetDate(string prompt);
    }
}
