using System;
using System.Collections.Generic;

namespace Services
{
    public class ItemService
    {
        public IEnumerable<string> GetAll(int userId)
        {
            var list = new List<string>();

            list.Add("test");
            list.Add("test1");
            list.Add("test2");

            return list;
        }
    }
}
