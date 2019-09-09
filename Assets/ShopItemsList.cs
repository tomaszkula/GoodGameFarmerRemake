using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ShopItemsList
{
    public List<ShopItem> items;

    public int Count
    {
        get
        {
            return items.Count;
        }
    }

    public IEnumerator GetEnumerator()
    {
        return new ShopItemsList.Enumerator(items);
    }

    private sealed class Enumerator : IEnumerator
    {
        private List<ShopItem> outer;
        private int currentIndex = -1;

        public object Current
        {
            get { return outer[currentIndex]; }
        }

        internal Enumerator(List<ShopItem> outer)
        {
            this.outer = outer;
        }

        public bool MoveNext()
        {
            int childCount = outer.Count;
            return ++currentIndex < childCount;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }
}
