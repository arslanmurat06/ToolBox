using System;
using System.Collections.Generic;
using System.Text;

namespace LazySingleton
{
    internal class MyLazyMethodClass
    {
        private Lazy<List<string>> _lazyGetAllList;
        public MyLazyMethodClass()
        {
            _lazyGetAllList = new Lazy<List<string>>(() => GetAllList());
        }

        private List<string> GetAllList() => new List<string>()
            {
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
            };

        public List<string> GetLazyList => _lazyGetAllList.Value;

        public List<string> GetNonLazyList => GetAllList();
    }
}
