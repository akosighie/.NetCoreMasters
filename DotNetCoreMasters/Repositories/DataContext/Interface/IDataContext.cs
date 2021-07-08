using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.DataContext.Interface
{
    public interface IDataContext
    {
        List<Item> ListOfItems();
    }
}
