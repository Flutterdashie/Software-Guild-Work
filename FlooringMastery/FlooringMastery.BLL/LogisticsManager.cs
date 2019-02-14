using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using FlooringMastery.Models;

namespace FlooringMastery.BLL
{
    internal class LogisticsManager
    {
        private StateGetter _states;
        private ProductGetter _products;

        public LogisticsManager(StateGetter StateGetter, ProductGetter ProductGetter)
        {
            _states = StateGetter;
            _products = ProductGetter;
        }

        internal IEnumerable<State> GetStates()
        {
            //Do logic for which states are valid. Region based?
            return _states.GetStates();
        }
        internal IEnumerable<Product> GetProducts()
        {
            //Do logic for which products are valid. Out-of-stock issues?
            return _products.GetAllProducts();
        }

    }
}
